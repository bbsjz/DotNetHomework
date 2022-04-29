using SimpleCrawler;
namespace homework10
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.URL = new System.Windows.Forms.TextBox();
            this.beginButton = new System.Windows.Forms.Button();
            this.TrueInfo = new System.Windows.Forms.TextBox();
            this.FalseInfo = new System.Windows.Forms.TextBox();
            this.trueLabel = new System.Windows.Forms.Label();
            this.falseLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // URL
            // 
            this.URL.ForeColor = System.Drawing.SystemColors.MenuBar;
            this.URL.Location = new System.Drawing.Point(50, 42);
            this.URL.Name = "URL";
            this.URL.Size = new System.Drawing.Size(1812, 53);
            this.URL.TabIndex = 0;
            this.URL.Text = "请输入要爬取的URL";
            // 
            // beginButton
            // 
            this.beginButton.Location = new System.Drawing.Point(1916, 42);
            this.beginButton.Name = "beginButton";
            this.beginButton.Size = new System.Drawing.Size(225, 69);
            this.beginButton.TabIndex = 1;
            this.beginButton.Text = "开始爬取";
            this.beginButton.UseVisualStyleBackColor = true;
            this.beginButton.Click += new System.EventHandler(this.beginButton_Click);
            // 
            // TrueInfo
            // 
            this.TrueInfo.Location = new System.Drawing.Point(50, 174);
            this.TrueInfo.Multiline = true;
            this.TrueInfo.Name = "TrueInfo";
            this.TrueInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TrueInfo.Size = new System.Drawing.Size(1032, 1067);
            this.TrueInfo.TabIndex = 2;
            // 
            // FalseInfo
            // 
            this.FalseInfo.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.FalseInfo.ForeColor = System.Drawing.Color.Red;
            this.FalseInfo.Location = new System.Drawing.Point(1109, 174);
            this.FalseInfo.Multiline = true;
            this.FalseInfo.Name = "FalseInfo";
            this.FalseInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FalseInfo.Size = new System.Drawing.Size(1032, 1067);
            this.FalseInfo.TabIndex = 3;
            // 
            // trueLabel
            // 
            this.trueLabel.AutoSize = true;
            this.trueLabel.Location = new System.Drawing.Point(50, 117);
            this.trueLabel.Name = "trueLabel";
            this.trueLabel.Size = new System.Drawing.Size(164, 46);
            this.trueLabel.TabIndex = 4;
            this.trueLabel.Text = "正确信息";
            // 
            // falseLabel
            // 
            this.falseLabel.AutoSize = true;
            this.falseLabel.Location = new System.Drawing.Point(1109, 117);
            this.falseLabel.Name = "falseLabel";
            this.falseLabel.Size = new System.Drawing.Size(164, 46);
            this.falseLabel.TabIndex = 5;
            this.falseLabel.Text = "异常信息";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 46F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2238, 1279);
            this.Controls.Add(this.falseLabel);
            this.Controls.Add(this.trueLabel);
            this.Controls.Add(this.FalseInfo);
            this.Controls.Add(this.TrueInfo);
            this.Controls.Add(this.beginButton);
            this.Controls.Add(this.URL);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox URL;
        private System.Windows.Forms.Button beginButton;
        private System.Windows.Forms.TextBox TrueInfo;
        private System.Windows.Forms.TextBox FalseInfo;
        private System.Windows.Forms.Label trueLabel;
        private System.Windows.Forms.Label falseLabel;
    }
}

