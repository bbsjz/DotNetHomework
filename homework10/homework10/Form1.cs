using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using SimpleCrawler;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework10
{
    public partial class Form1 : Form
    {
        Crawler myCrawler = new Crawler();
        public Form1()
        {
            InitializeComponent();
            myCrawler.MsgChange += changeText;
        }

        private void beginButton_Click(object sender, EventArgs e)
        {
            if (URL.Text == "")
            {
                return;
            }
            string fileType = @".(html?|aspx|jsp|php)$";
            Task.Run(() => myCrawler.Crawl(URL.Text,fileType));
        }

        private void changeText(String Info,bool isSuccess)
        {
            if(isSuccess)
            {
                TrueInfo.Invoke(new Action(() =>
                {
                    TrueInfo.Text = Info;
                }));
            }
            else
            {
                FalseInfo.Invoke(new Action(() =>
                {
                    FalseInfo.Text = Info;
                }));
            }
        }
    }
}
