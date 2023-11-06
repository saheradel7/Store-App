namespace Store
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.SellSearshLbl = new System.Windows.Forms.Label();
            this.SellTb1 = new System.Windows.Forms.TextBox();
            this.SellTb2 = new System.Windows.Forms.TextBox();
            this.SellTb3 = new System.Windows.Forms.TextBox();
            this.SellTb4 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SellGridView = new System.Windows.Forms.DataGridView();
            this.SellSearchTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.QuantityToSellTb = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SellGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(83, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SellSearshLbl
            // 
            this.SellSearshLbl.AutoSize = true;
            this.SellSearshLbl.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Italic);
            this.SellSearshLbl.Location = new System.Drawing.Point(407, 21);
            this.SellSearshLbl.Name = "SellSearshLbl";
            this.SellSearshLbl.Size = new System.Drawing.Size(76, 26);
            this.SellSearshLbl.TabIndex = 3;
            this.SellSearshLbl.Text = "Search";
            // 
            // SellTb1
            // 
            this.SellTb1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SellTb1.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SellTb1.Location = new System.Drawing.Point(51, 38);
            this.SellTb1.Name = "SellTb1";
            this.SellTb1.ReadOnly = true;
            this.SellTb1.Size = new System.Drawing.Size(316, 27);
            this.SellTb1.TabIndex = 5;
            // 
            // SellTb2
            // 
            this.SellTb2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SellTb2.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SellTb2.Location = new System.Drawing.Point(51, 98);
            this.SellTb2.Name = "SellTb2";
            this.SellTb2.ReadOnly = true;
            this.SellTb2.Size = new System.Drawing.Size(316, 27);
            this.SellTb2.TabIndex = 6;
            // 
            // SellTb3
            // 
            this.SellTb3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SellTb3.Font = new System.Drawing.Font("Arial", 13.8F);
            this.SellTb3.Location = new System.Drawing.Point(51, 159);
            this.SellTb3.Name = "SellTb3";
            this.SellTb3.ReadOnly = true;
            this.SellTb3.Size = new System.Drawing.Size(316, 27);
            this.SellTb3.TabIndex = 7;
            this.SellTb3.TextChanged += new System.EventHandler(this.SellTb3_TextChanged);
            // 
            // SellTb4
            // 
            this.SellTb4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SellTb4.Font = new System.Drawing.Font("Arial", 13.8F);
            this.SellTb4.Location = new System.Drawing.Point(51, 218);
            this.SellTb4.Name = "SellTb4";
            this.SellTb4.ReadOnly = true;
            this.SellTb4.Size = new System.Drawing.Size(316, 27);
            this.SellTb4.TabIndex = 8;
            this.SellTb4.TextChanged += new System.EventHandler(this.SellTb4_TextChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(83, 329);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(237, 46);
            this.button2.TabIndex = 9;
            this.button2.Text = "Sell";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SellGridView
            // 
            this.SellGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SellGridView.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.SellGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SellGridView.Location = new System.Drawing.Point(412, 63);
            this.SellGridView.Name = "SellGridView";
            this.SellGridView.RowHeadersWidth = 51;
            this.SellGridView.RowTemplate.Height = 24;
            this.SellGridView.Size = new System.Drawing.Size(376, 375);
            this.SellGridView.TabIndex = 1;
            this.SellGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SellGridView_CellContentClick);
            this.SellGridView.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.SellGridView_RowHeaderMouseClick);
            // 
            // SellSearchTb
            // 
            this.SellSearchTb.Location = new System.Drawing.Point(489, 25);
            this.SellSearchTb.Name = "SellSearchTb";
            this.SellSearchTb.Size = new System.Drawing.Size(231, 22);
            this.SellSearchTb.TabIndex = 10;
            this.SellSearchTb.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 21);
            this.label1.TabIndex = 12;
            this.label1.Text = "ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(53, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "Item :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.Location = new System.Drawing.Point(52, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "Price :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label4.Location = new System.Drawing.Point(52, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "Quantity :";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Black;
            this.button4.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(245, 392);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 35);
            this.button4.TabIndex = 17;
            this.button4.Text = "Back Up";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // QuantityToSellTb
            // 
            this.QuantityToSellTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.QuantityToSellTb.Font = new System.Drawing.Font("Arial", 13.8F);
            this.QuantityToSellTb.Location = new System.Drawing.Point(151, 267);
            this.QuantityToSellTb.Name = "QuantityToSellTb";
            this.QuantityToSellTb.Size = new System.Drawing.Size(88, 27);
            this.QuantityToSellTb.TabIndex = 18;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DimGray;
            this.button5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic);
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(164, 392);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 35);
            this.button5.TabIndex = 19;
            this.button5.Text = "Store";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::Store.Properties.Resources.refresh;
            this.pictureBox1.Location = new System.Drawing.Point(735, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(44, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.QuantityToSellTb);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SellSearchTb);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SellTb4);
            this.Controls.Add(this.SellTb3);
            this.Controls.Add(this.SellTb2);
            this.Controls.Add(this.SellTb1);
            this.Controls.Add(this.SellSearshLbl);
            this.Controls.Add(this.SellGridView);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Casher";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SellGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label SellSearshLbl;
        private System.Windows.Forms.TextBox SellTb1;
        private System.Windows.Forms.TextBox SellTb2;
        private System.Windows.Forms.TextBox SellTb3;
        private System.Windows.Forms.TextBox SellTb4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView SellGridView;
        private System.Windows.Forms.TextBox SellSearchTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox QuantityToSellTb;
        private System.Windows.Forms.Button button5;
    }
}

