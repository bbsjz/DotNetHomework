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
using System.Windows.Forms;

namespace SimpleCrawler {
    class Crawler {
        public Hashtable urls { get; set; } = new Hashtable();
        public string beginUrl { get; set; }
        public string root { get; set; }
        private int count = 0;
        StringBuilder errorBuilder = new StringBuilder();
        StringBuilder successBuilder = new StringBuilder();
        public TextBox errorInfo { get; set; }
        public TextBox successInfo { get; set; }
        public void Crawl() {
            successBuilder.Append("开始爬行了.... \r\n");
            while (true) {
                string current = null;
                foreach (string url in urls.Keys) {
                    if ((bool)urls[url]) continue;
                    current = url;
                }

                if (current == null) break;
                successBuilder.Append("爬行" + current + "页面!\r\n");
                string html = DownLoad(current); // 下载
                urls[current] = true;
                count++;
                if(html=="")
                {
                    errorBuilder.Append(current+"爬行失败\r\n");
                    errorInfo.Invoke(new Action(() =>
                    {
                        errorInfo.Text = errorBuilder.ToString();
                    }));
                  continue;
                }
                Parse(html);//解析,并加入新的链接
                successBuilder.Append("爬行结束\r\n");
                successInfo.Invoke(new Action(() =>
                {
                    successInfo.Text = successBuilder.ToString();
                }));
            }
        }

        public string DownLoad(string url) {
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
                string fileName = "./crawl/" + "page" + count.ToString() + suffix;
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch(Exception ex)
            {
                errorBuilder.Append(ex.Message);
                return "";
            }

        }
        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[ ]*=[ ]*[""'](http|https)://"+root+@"[^""'#>].*(.html|.aspx|.jsp|.htm).*[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            string half = @"(href|HREF)[ ]*=[ ]*[""'](?:(?!http)(?!https))[\S]*(.html|.aspx|.jsp|.htm)[""']";
            MatchCollection halfMatches = new Regex(half).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                            .Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
            foreach(Match match in halfMatches)
            {
                half= match.Value.Substring(match.Value.IndexOf('=') + 1)
                            .Trim('"', '\"', '#', '>');
                if (half.Length == 0) continue;
                if (urls[beginUrl+half] == null) urls[beginUrl+half] = false;
            }
        }
    }
}
