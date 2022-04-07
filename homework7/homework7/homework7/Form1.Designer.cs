
namespace homework7
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
            this.panelTree = new System.Windows.Forms.Panel();
            this.buttonGroup = new System.Windows.Forms.Panel();
            this.per1Label = new System.Windows.Forms.Label();
            this.greenWarning = new System.Windows.Forms.Label();
            this.blueWarning = new System.Windows.Forms.Label();
            this.redWarning = new System.Windows.Forms.Label();
            this.greenBox = new System.Windows.Forms.TextBox();
            this.greenLabel = new System.Windows.Forms.Label();
            this.blueBox = new System.Windows.Forms.TextBox();
            this.blueLabel = new System.Windows.Forms.Label();
            this.draw = new System.Windows.Forms.Button();
            this.redLabel = new System.Windows.Forms.Label();
            this.redBox = new System.Windows.Forms.TextBox();
            this.th2Label = new System.Windows.Forms.Label();
            this.th1Bar = new System.Windows.Forms.TrackBar();
            this.per2Bar = new System.Windows.Forms.TrackBar();
            this.th1Label = new System.Windows.Forms.Label();
            this.per2Label = new System.Windows.Forms.Label();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.depthLabel = new System.Windows.Forms.Label();
            this.th2Bar = new System.Windows.Forms.TrackBar();
            this.length = new System.Windows.Forms.TrackBar();
            this.per1Bar = new System.Windows.Forms.TrackBar();
            this.recursionDepth = new System.Windows.Forms.TrackBar();
            this.buttonGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.th1Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.per2Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.th2Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.length)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.per1Bar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursionDepth)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTree
            // 
            this.panelTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTree.Location = new System.Drawing.Point(0, 0);
            this.panelTree.Name = "panelTree";
            this.panelTree.Size = new System.Drawing.Size(1781, 1484);
            this.panelTree.TabIndex = 0;
            this.panelTree.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // buttonGroup
            // 
            this.buttonGroup.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonGroup.Controls.Add(this.per1Label);
            this.buttonGroup.Controls.Add(this.greenWarning);
            this.buttonGroup.Controls.Add(this.blueWarning);
            this.buttonGroup.Controls.Add(this.redWarning);
            this.buttonGroup.Controls.Add(this.greenBox);
            this.buttonGroup.Controls.Add(this.greenLabel);
            this.buttonGroup.Controls.Add(this.blueBox);
            this.buttonGroup.Controls.Add(this.blueLabel);
            this.buttonGroup.Controls.Add(this.draw);
            this.buttonGroup.Controls.Add(this.redLabel);
            this.buttonGroup.Controls.Add(this.redBox);
            this.buttonGroup.Controls.Add(this.th2Label);
            this.buttonGroup.Controls.Add(this.th1Bar);
            this.buttonGroup.Controls.Add(this.per2Bar);
            this.buttonGroup.Controls.Add(this.th1Label);
            this.buttonGroup.Controls.Add(this.per2Label);
            this.buttonGroup.Controls.Add(this.lengthLabel);
            this.buttonGroup.Controls.Add(this.depthLabel);
            this.buttonGroup.Controls.Add(this.th2Bar);
            this.buttonGroup.Controls.Add(this.length);
            this.buttonGroup.Controls.Add(this.per1Bar);
            this.buttonGroup.Controls.Add(this.recursionDepth);
            this.buttonGroup.Location = new System.Drawing.Point(0, 0);
            this.buttonGroup.Name = "buttonGroup";
            this.buttonGroup.Size = new System.Drawing.Size(676, 1484);
            this.buttonGroup.TabIndex = 1;
            this.buttonGroup.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint_1);
            // 
            // per1Label
            // 
            this.per1Label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.per1Label.AutoSize = true;
            this.per1Label.Location = new System.Drawing.Point(3, 313);
            this.per1Label.Name = "per1Label";
            this.per1Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.per1Label.Size = new System.Drawing.Size(236, 46);
            this.per1Label.TabIndex = 22;
            this.per1Label.Text = "左分支长度比";
            this.per1Label.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // greenWarning
            // 
            this.greenWarning.AutoSize = true;
            this.greenWarning.ForeColor = System.Drawing.Color.Red;
            this.greenWarning.Location = new System.Drawing.Point(34, 1292);
            this.greenWarning.Name = "greenWarning";
            this.greenWarning.Size = new System.Drawing.Size(119, 46);
            this.greenWarning.TabIndex = 21;
            this.greenWarning.Text = "         ";
            // 
            // blueWarning
            // 
            this.blueWarning.AutoSize = true;
            this.blueWarning.ForeColor = System.Drawing.Color.Red;
            this.blueWarning.Location = new System.Drawing.Point(34, 1149);
            this.blueWarning.Name = "blueWarning";
            this.blueWarning.Size = new System.Drawing.Size(130, 46);
            this.blueWarning.TabIndex = 20;
            this.blueWarning.Text = "          ";
            this.blueWarning.Click += new System.EventHandler(this.label11_Click);
            // 
            // redWarning
            // 
            this.redWarning.AutoSize = true;
            this.redWarning.ForeColor = System.Drawing.Color.Red;
            this.redWarning.Location = new System.Drawing.Point(30, 1008);
            this.redWarning.Name = "redWarning";
            this.redWarning.Size = new System.Drawing.Size(108, 46);
            this.redWarning.TabIndex = 19;
            this.redWarning.Text = "        ";
            this.redWarning.Click += new System.EventHandler(this.label10_Click);
            // 
            // greenBox
            // 
            this.greenBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.greenBox.Location = new System.Drawing.Point(376, 1220);
            this.greenBox.Name = "greenBox";
            this.greenBox.Size = new System.Drawing.Size(225, 53);
            this.greenBox.TabIndex = 18;
            this.greenBox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // greenLabel
            // 
            this.greenLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.greenLabel.AutoSize = true;
            this.greenLabel.Location = new System.Drawing.Point(30, 1223);
            this.greenLabel.Name = "greenLabel";
            this.greenLabel.Size = new System.Drawing.Size(239, 46);
            this.greenLabel.TabIndex = 17;
            this.greenLabel.Text = "绘图颜色(G）";
            this.greenLabel.Click += new System.EventHandler(this.label9_Click);
            // 
            // blueBox
            // 
            this.blueBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.blueBox.Location = new System.Drawing.Point(376, 1077);
            this.blueBox.Name = "blueBox";
            this.blueBox.Size = new System.Drawing.Size(225, 53);
            this.blueBox.TabIndex = 16;
            this.blueBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // blueLabel
            // 
            this.blueLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.blueLabel.AutoSize = true;
            this.blueLabel.Location = new System.Drawing.Point(29, 1077);
            this.blueLabel.Name = "blueLabel";
            this.blueLabel.Size = new System.Drawing.Size(235, 46);
            this.blueLabel.TabIndex = 15;
            this.blueLabel.Text = "绘图颜色(B）";
            this.blueLabel.Click += new System.EventHandler(this.label8_Click);
            // 
            // draw
            // 
            this.draw.Location = new System.Drawing.Point(187, 1371);
            this.draw.Name = "draw";
            this.draw.Size = new System.Drawing.Size(225, 69);
            this.draw.TabIndex = 14;
            this.draw.Text = "绘制";
            this.draw.UseVisualStyleBackColor = true;
            this.draw.Click += new System.EventHandler(this.button1_Click);
            // 
            // redLabel
            // 
            this.redLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.redLabel.AutoSize = true;
            this.redLabel.Location = new System.Drawing.Point(29, 939);
            this.redLabel.Name = "redLabel";
            this.redLabel.Size = new System.Drawing.Size(236, 46);
            this.redLabel.TabIndex = 13;
            this.redLabel.Text = "绘图颜色(R）";
            this.redLabel.Click += new System.EventHandler(this.label7_Click);
            // 
            // redBox
            // 
            this.redBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.redBox.Location = new System.Drawing.Point(376, 939);
            this.redBox.Name = "redBox";
            this.redBox.Size = new System.Drawing.Size(225, 53);
            this.redBox.TabIndex = 12;
            this.redBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // th2Label
            // 
            this.th2Label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.th2Label.AutoSize = true;
            this.th2Label.Location = new System.Drawing.Point(3, 648);
            this.th2Label.Name = "th2Label";
            this.th2Label.Size = new System.Drawing.Size(200, 46);
            this.th2Label.TabIndex = 11;
            this.th2Label.Text = "左分支角度";
            this.th2Label.Click += new System.EventHandler(this.label6_Click);
            // 
            // th1Bar
            // 
            this.th1Bar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.th1Bar.Location = new System.Drawing.Point(306, 801);
            this.th1Bar.Maximum = 180;
            this.th1Bar.Name = "th1Bar";
            this.th1Bar.Size = new System.Drawing.Size(355, 136);
            this.th1Bar.TabIndex = 9;
            this.th1Bar.Scroll += new System.EventHandler(this.trackBar6_Scroll);
            // 
            // per2Bar
            // 
            this.per2Bar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.per2Bar.Location = new System.Drawing.Point(306, 313);
            this.per2Bar.Maximum = 100;
            this.per2Bar.Name = "per2Bar";
            this.per2Bar.Size = new System.Drawing.Size(355, 136);
            this.per2Bar.TabIndex = 8;
            this.per2Bar.Scroll += new System.EventHandler(this.trackBar5_Scroll);
            // 
            // th1Label
            // 
            this.th1Label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.th1Label.AutoSize = true;
            this.th1Label.Location = new System.Drawing.Point(3, 801);
            this.th1Label.Name = "th1Label";
            this.th1Label.Size = new System.Drawing.Size(200, 46);
            this.th1Label.TabIndex = 7;
            this.th1Label.Text = "右分支角度";
            this.th1Label.Click += new System.EventHandler(this.label4_Click);
            // 
            // per2Label
            // 
            this.per2Label.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.per2Label.AutoSize = true;
            this.per2Label.Location = new System.Drawing.Point(3, 474);
            this.per2Label.Name = "per2Label";
            this.per2Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.per2Label.Size = new System.Drawing.Size(236, 46);
            this.per2Label.TabIndex = 6;
            this.per2Label.Text = "右分支长度比";
            this.per2Label.Click += new System.EventHandler(this.label3_Click);
            // 
            // lengthLabel
            // 
            this.lengthLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(3, 171);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(164, 46);
            this.lengthLabel.TabIndex = 5;
            this.lengthLabel.Text = "主干长度";
            this.lengthLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // depthLabel
            // 
            this.depthLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.depthLabel.AutoSize = true;
            this.depthLabel.Location = new System.Drawing.Point(3, 37);
            this.depthLabel.Name = "depthLabel";
            this.depthLabel.Size = new System.Drawing.Size(164, 46);
            this.depthLabel.TabIndex = 4;
            this.depthLabel.Text = "递归深度";
            this.depthLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // th2Bar
            // 
            this.th2Bar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.th2Bar.Location = new System.Drawing.Point(306, 648);
            this.th2Bar.Maximum = 180;
            this.th2Bar.Name = "th2Bar";
            this.th2Bar.Size = new System.Drawing.Size(355, 136);
            this.th2Bar.TabIndex = 3;
            this.th2Bar.Scroll += new System.EventHandler(this.trackBar4_Scroll);
            // 
            // length
            // 
            this.length.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.length.Location = new System.Drawing.Point(306, 171);
            this.length.Maximum = 500;
            this.length.Minimum = 50;
            this.length.Name = "length";
            this.length.Size = new System.Drawing.Size(355, 136);
            this.length.TabIndex = 2;
            this.length.Value = 50;
            this.length.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // per1Bar
            // 
            this.per1Bar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.per1Bar.Location = new System.Drawing.Point(306, 474);
            this.per1Bar.Maximum = 100;
            this.per1Bar.Name = "per1Bar";
            this.per1Bar.Size = new System.Drawing.Size(355, 136);
            this.per1Bar.TabIndex = 1;
            this.per1Bar.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // recursionDepth
            // 
            this.recursionDepth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.recursionDepth.Location = new System.Drawing.Point(306, 37);
            this.recursionDepth.Maximum = 20;
            this.recursionDepth.Name = "recursionDepth";
            this.recursionDepth.Size = new System.Drawing.Size(355, 136);
            this.recursionDepth.TabIndex = 0;
            this.recursionDepth.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(22F, 46F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1781, 1484);
            this.Controls.Add(this.buttonGroup);
            this.Controls.Add(this.panelTree);
            this.Name = "Form1";
            this.Text = "Form1";
            this.buttonGroup.ResumeLayout(false);
            this.buttonGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.th1Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.per2Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.th2Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.length)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.per1Bar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recursionDepth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTree;
        private System.Windows.Forms.Panel buttonGroup;
        private System.Windows.Forms.TrackBar recursionDepth;
        private System.Windows.Forms.TrackBar th2Bar;
        private System.Windows.Forms.TrackBar length;
        private System.Windows.Forms.TrackBar per1Bar;
        private System.Windows.Forms.Label depthLabel;
        private System.Windows.Forms.Label per2Label;
        private System.Windows.Forms.TrackBar th1Bar;
        private System.Windows.Forms.TrackBar per2Bar;
        private System.Windows.Forms.Label th1Label;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Label redLabel;
        private System.Windows.Forms.TextBox redBox;
        private System.Windows.Forms.Label th2Label;
        private System.Windows.Forms.Button draw;
        private System.Windows.Forms.TextBox greenBox;
        private System.Windows.Forms.Label greenLabel;
        private System.Windows.Forms.TextBox blueBox;
        private System.Windows.Forms.Label blueLabel;
        private System.Windows.Forms.Label greenWarning;
        private System.Windows.Forms.Label blueWarning;
        private System.Windows.Forms.Label redWarning;
        private System.Windows.Forms.Label per1Label;
    }
}

