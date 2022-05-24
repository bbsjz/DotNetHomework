namespace OrderApp
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.orderIDTextBox = new System.Windows.Forms.TextBox();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.customerTextBox = new System.Windows.Forms.TextBox();
            this.indexTextBox = new System.Windows.Forms.TextBox();
            this.QuantityTextBox = new System.Windows.Forms.TextBox();
            this.GoodsNameTextBox = new System.Windows.Forms.TextBox();
            this.orderIDLabel = new System.Windows.Forms.Label();
            this.CustomerLabel = new System.Windows.Forms.Label();
            this.indexLabel = new System.Windows.Forms.Label();
            this.PriceLabel = new System.Windows.Forms.Label();
            this.GoodsNameLabel = new System.Windows.Forms.Label();
            this.QuantityLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // orderIDTextBox
            // 
            this.orderIDTextBox.Location = new System.Drawing.Point(193, 86);
            this.orderIDTextBox.Name = "orderIDTextBox";
            this.orderIDTextBox.Size = new System.Drawing.Size(100, 25);
            this.orderIDTextBox.TabIndex = 0;
            // 
            // PriceTextBox
            // 
            this.PriceTextBox.Location = new System.Drawing.Point(460, 332);
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.Size = new System.Drawing.Size(100, 25);
            this.PriceTextBox.TabIndex = 1;
            this.PriceTextBox.TextChanged += new System.EventHandler(this.PriceTextBox_TextChanged);
            // 
            // customerTextBox
            // 
            this.customerTextBox.Location = new System.Drawing.Point(460, 86);
            this.customerTextBox.Name = "customerTextBox";
            this.customerTextBox.Size = new System.Drawing.Size(100, 25);
            this.customerTextBox.TabIndex = 2;
            // 
            // indexTextBox
            // 
            this.indexTextBox.Location = new System.Drawing.Point(193, 332);
            this.indexTextBox.Name = "indexTextBox";
            this.indexTextBox.Size = new System.Drawing.Size(100, 25);
            this.indexTextBox.TabIndex = 3;
            // 
            // QuantityTextBox
            // 
            this.QuantityTextBox.Location = new System.Drawing.Point(460, 204);
            this.QuantityTextBox.Name = "QuantityTextBox";
            this.QuantityTextBox.Size = new System.Drawing.Size(100, 25);
            this.QuantityTextBox.TabIndex = 4;
            // 
            // GoodsNameTextBox
            // 
            this.GoodsNameTextBox.Location = new System.Drawing.Point(193, 204);
            this.GoodsNameTextBox.Name = "GoodsNameTextBox";
            this.GoodsNameTextBox.Size = new System.Drawing.Size(100, 25);
            this.GoodsNameTextBox.TabIndex = 5;
            // 
            // orderIDLabel
            // 
            this.orderIDLabel.AutoSize = true;
            this.orderIDLabel.Location = new System.Drawing.Point(202, 48);
            this.orderIDLabel.Name = "orderIDLabel";
            this.orderIDLabel.Size = new System.Drawing.Size(53, 15);
            this.orderIDLabel.TabIndex = 6;
            this.orderIDLabel.Text = "订单ID";
            // 
            // CustomerLabel
            // 
            this.CustomerLabel.AutoSize = true;
            this.CustomerLabel.Location = new System.Drawing.Point(477, 48);
            this.CustomerLabel.Name = "CustomerLabel";
            this.CustomerLabel.Size = new System.Drawing.Size(52, 15);
            this.CustomerLabel.TabIndex = 7;
            this.CustomerLabel.Text = "客户名";
            // 
            // indexLabel
            // 
            this.indexLabel.AutoSize = true;
            this.indexLabel.Location = new System.Drawing.Point(205, 269);
            this.indexLabel.Name = "indexLabel";
            this.indexLabel.Size = new System.Drawing.Size(67, 15);
            this.indexLabel.TabIndex = 8;
            this.indexLabel.Text = "商品编号";
            // 
            // PriceLabel
            // 
            this.PriceLabel.AutoSize = true;
            this.PriceLabel.Location = new System.Drawing.Point(492, 269);
            this.PriceLabel.Name = "PriceLabel";
            this.PriceLabel.Size = new System.Drawing.Size(37, 15);
            this.PriceLabel.TabIndex = 9;
            this.PriceLabel.Text = "单价";
            // 
            // GoodsNameLabel
            // 
            this.GoodsNameLabel.AutoSize = true;
            this.GoodsNameLabel.Location = new System.Drawing.Point(205, 154);
            this.GoodsNameLabel.Name = "GoodsNameLabel";
            this.GoodsNameLabel.Size = new System.Drawing.Size(52, 15);
            this.GoodsNameLabel.TabIndex = 10;
            this.GoodsNameLabel.Text = "商品名";
            // 
            // QuantityLabel
            // 
            this.QuantityLabel.AutoSize = true;
            this.QuantityLabel.Location = new System.Drawing.Point(477, 154);
            this.QuantityLabel.Name = "QuantityLabel";
            this.QuantityLabel.Size = new System.Drawing.Size(67, 15);
            this.QuantityLabel.TabIndex = 11;
            this.QuantityLabel.Text = "商品数量";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(351, 396);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 12;
            this.okButton.Text = "确定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 482);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.QuantityLabel);
            this.Controls.Add(this.GoodsNameLabel);
            this.Controls.Add(this.PriceLabel);
            this.Controls.Add(this.indexLabel);
            this.Controls.Add(this.CustomerLabel);
            this.Controls.Add(this.orderIDLabel);
            this.Controls.Add(this.GoodsNameTextBox);
            this.Controls.Add(this.QuantityTextBox);
            this.Controls.Add(this.indexTextBox);
            this.Controls.Add(this.customerTextBox);
            this.Controls.Add(this.PriceTextBox);
            this.Controls.Add(this.orderIDTextBox);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox orderIDTextBox;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.TextBox customerTextBox;
        private System.Windows.Forms.TextBox indexTextBox;
        private System.Windows.Forms.TextBox QuantityTextBox;
        private System.Windows.Forms.TextBox GoodsNameTextBox;
        private System.Windows.Forms.Label orderIDLabel;
        private System.Windows.Forms.Label CustomerLabel;
        private System.Windows.Forms.Label indexLabel;
        private System.Windows.Forms.Label PriceLabel;
        private System.Windows.Forms.Label GoodsNameLabel;
        private System.Windows.Forms.Label QuantityLabel;
        private System.Windows.Forms.Button okButton;
    }
}