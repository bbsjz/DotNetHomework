using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCrawler {
    class Crawler {
        //获取一切满足href=" "的内容
        string urlToCrawl = @"(href|HREF)[ ]*=[ ]*[""'](?<url>[^""'#>]+)[""']";
        //获取url各个部分
        string part = @"(?<site>(?<protocal>(https?))://(?<host>[\w\d.]+)(?<port>(:\d))?($|/))(?<path>([\w\d]*/)*)(?<file>[^#?]*)";
        //成功/失败的爬取状态更新
        public event Action<string, bool> MsgChange;
        //用哈希表存储已经成功爬取过的网页
        private Hashtable crawled = new Hashtable();
        //待爬队列
        private Queue<string> toBeCrawled = new Queue<string>();
        //爬取的文件类型
        string fileType;
        //爬取的主机名
        string host;
        //用于计数是第几个文件
        private int count = 0;
        //可爬取的最大数量
        public int max { get; set; }
        //下载任务列表
        List<Task> list=new List<Task>();
        //记录错误信息
        StringBuilder errorBuilder = new StringBuilder();
        //记录正确信息
        StringBuilder successBuilder = new StringBuilder();
        public void Crawl(string startUrl,string fileType) {
            this.max = 10;
            successBuilder.Clear();
            errorBuilder.Clear();
            this.fileType = fileType;
            Match match = new Regex(part).Match(startUrl);
            host = match.Groups["host"].Value;
            crawled.Clear();
            toBeCrawled.Clear();
            toBeCrawled.Enqueue(startUrl);
            successBuilder.Append("开始爬行了.... \r\n");
            while (crawled.Count + list.Count(t => t.Status == TaskStatus.Running) < max && toBeCrawled.Count > 0)
            {
                string current = toBeCrawled.Dequeue();
                list.Add(Task.Run(() => DownLoad(current)));// 从根网站开始下载
            }
        }
        public void DownLoad(string url) {
            if (!Directory.Exists("./crawl"))
            {
                Directory.CreateDirectory("./crawl");
            }
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                Regex tail = new Regex(@"(.html|.htm|.aspx|.jsp)");
                Match match = tail.Match(url);
                String suffix = (match.ToString() != "") ? match.ToString() : "";
                string html = webClient.DownloadString(url);
                lock(this)
                {
                    count++;
                    string fileName = "./crawl/" + "page" + count.ToString() + suffix;
                    File.WriteAllText(fileName, html, Encoding.UTF8);
                    crawled[url] = true;
                    successBuilder.Append("爬行" + url + "页面!\r\n");
                    successBuilder.Append("爬行结束\r\n");
                    MsgChange(successBuilder.ToString(), true);
                }
                Parse(html,url);//解析,并加入新的链接
            }
            catch (Exception ex)
            {
                lock(this)
                {
                    errorBuilder.Append(ex.Message);
                    errorBuilder.Append(url + "爬行失败\r\n");
                    MsgChange(errorBuilder.ToString(), false);
                }
            }
        }
        public void Parse(string url,string parentUrl)
        {

            MatchCollection matches = new Regex(urlToCrawl).Matches(url);
            foreach (Match match in matches)
            {
                string urlNext = match.Groups["url"].Value;
                if(urlNext==null||urlNext==""||urlNext.StartsWith("javascript:"))
                {
                    continue;
                }
                string fullUrl = completeUrl(urlNext, parentUrl);
                string targetHost = new Regex(part).Match(fullUrl).Groups["host"].Value;
                string file = new Regex(part).Match(fullUrl).Groups["file"].Value;
                if(Regex.IsMatch(host,targetHost)&&Regex.IsMatch(file,fileType)
                    &&!crawled.ContainsKey(fullUrl)&&!toBeCrawled.Contains(fullUrl))
                {
                    list.RemoveAll(t => t.Status == TaskStatus.RanToCompletion);
                    if (crawled.Count + list.Count < max)
                    {
                        list.Add(Task.Run(() => DownLoad(fullUrl)));
                    }
                    else
                    {
                        toBeCrawled.Enqueue(fullUrl);
                    }
                }
            }
        }
        private string completeUrl(string url,string parentUrl)
        {
            Match match = Regex.Match(parentUrl, part);
            if (url.Contains("http"))
            {
                return url;
            }
            else if(url.StartsWith("//"))
            {
               
                string protocal = match.Groups["protocal"].Value;
                return protocal + ":" + url;
            }
            else if(url.StartsWith("/"))
            {
                string site = match.Groups["site"].Value;
                return site.EndsWith("/") ? site + url.Substring(1) : site + url;
            }
            else if(url.StartsWith("../"))
            {
                int index = parentUrl.LastIndexOf("/");
                parentUrl = parentUrl.Substring(0, index);
                index = parentUrl.LastIndexOf("/");
                parentUrl = parentUrl.Substring(0, index);
                return parentUrl + url.Substring(2);
            }
            else //if(url.StartsWith("./"))
            {
                int index = parentUrl.LastIndexOf("/");
                parentUrl = parentUrl.Substring(0, index);
                return parentUrl + url.Substring(1);
            }
        }
    }
}
