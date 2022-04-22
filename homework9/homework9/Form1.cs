using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            myCrawler.errorInfo = FalseInfo;
            myCrawler.successInfo = TrueInfo;
        }

        private void beginButton_Click(object sender, EventArgs e)
        {
            if(URL.Text=="")
            {
                return;
            }
            if(!myCrawler.urls.Contains(URL.Text))
            {
                myCrawler.beginUrl = URL.Text;
                myCrawler.root = URL.Text.Substring(URL.Text.IndexOf(":") + 3);
                myCrawler.urls.Add(URL.Text, false);//加入初始页面
            }
            new Thread(myCrawler.Crawl).Start();
        }
    }
}
