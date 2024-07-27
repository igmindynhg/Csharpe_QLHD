namespace QLHD
{
    partial class XemHD
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.data_hd = new System.Windows.Forms.DataGridView();
            this.pl_ThongKe = new System.Windows.Forms.Panel();
            this.txt_date = new System.Windows.Forms.TextBox();
            this.txt_mahd = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_delete = new System.Windows.Forms.Button();
            this.txt_totalMoney = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_ThongKe = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_hd)).BeginInit();
            this.pl_ThongKe.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.txt_Search);
            this.panel2.Controls.Add(this.btn_Search);
            this.panel2.Controls.Add(this.data_hd);
            this.panel2.Location = new System.Drawing.Point(336, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(577, 450);
            this.panel2.TabIndex = 3;
            // 
            // txt_Search
            // 
            this.txt_Search.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Search.BackColor = System.Drawing.SystemColors.Menu;
            this.txt_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search.Location = new System.Drawing.Point(119, 15);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(351, 24);
            this.txt_Search.TabIndex = 3;
            // 
            // btn_Search
            // 
            this.btn_Search.AutoSize = true;
            this.btn_Search.BackColor = System.Drawing.Color.Cyan;
            this.btn_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.Location = new System.Drawing.Point(30, 12);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(79, 28);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = "Tìm kiếm";
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // data_hd
            // 
            this.data_hd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data_hd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_hd.Location = new System.Drawing.Point(3, 51);
            this.data_hd.Name = "data_hd";
            this.data_hd.RowHeadersWidth = 51;
            this.data_hd.RowTemplate.Height = 24;
            this.data_hd.Size = new System.Drawing.Size(571, 399);
            this.data_hd.TabIndex = 1;
            this.data_hd.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_hd_CellClick);
            // 
            // pl_ThongKe
            // 
            this.pl_ThongKe.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pl_ThongKe.Controls.Add(this.txt_date);
            this.pl_ThongKe.Controls.Add(this.txt_mahd);
            this.pl_ThongKe.Controls.Add(this.panel1);
            this.pl_ThongKe.Controls.Add(this.btn_delete);
            this.pl_ThongKe.Controls.Add(this.txt_totalMoney);
            this.pl_ThongKe.Controls.Add(this.label3);
            this.pl_ThongKe.Controls.Add(this.label2);
            this.pl_ThongKe.Controls.Add(this.label1);
            this.pl_ThongKe.Controls.Add(this.lb_ThongKe);
            this.pl_ThongKe.Dock = System.Windows.Forms.DockStyle.Left;
            this.pl_ThongKe.Location = new System.Drawing.Point(0, 0);
            this.pl_ThongKe.Name = "pl_ThongKe";
            this.pl_ThongKe.Size = new System.Drawing.Size(333, 450);
            this.pl_ThongKe.TabIndex = 2;
            // 
            // txt_date
            // 
            this.txt_date.BackColor = System.Drawing.SystemColors.Control;
            this.txt_date.Enabled = false;
            this.txt_date.Location = new System.Drawing.Point(26, 184);
            this.txt_date.Name = "txt_date";
            this.txt_date.Size = new System.Drawing.Size(256, 22);
            this.txt_date.TabIndex = 9;
            // 
            // txt_mahd
            // 
            this.txt_mahd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_mahd.BackColor = System.Drawing.SystemColors.Control;
            this.txt_mahd.Enabled = false;
            this.txt_mahd.Location = new System.Drawing.Point(26, 116);
            this.txt_mahd.Name = "txt_mahd";
            this.txt_mahd.Size = new System.Drawing.Size(259, 22);
            this.txt_mahd.TabIndex = 8;
            this.txt_mahd.UseWaitCursor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(234, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 1;
            // 
            // btn_delete
            // 
            this.btn_delete.AutoSize = true;
            this.btn_delete.BackColor = System.Drawing.Color.Cyan;
            this.btn_delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(108, 307);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(104, 34);
            this.btn_delete.TabIndex = 7;
            this.btn_delete.Text = "Xóa";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // txt_totalMoney
            // 
            this.txt_totalMoney.Enabled = false;
            this.txt_totalMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_totalMoney.Location = new System.Drawing.Point(26, 255);
            this.txt_totalMoney.Name = "txt_totalMoney";
            this.txt_totalMoney.ReadOnly = true;
            this.txt_totalMoney.Size = new System.Drawing.Size(256, 24);
            this.txt_totalMoney.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tổng tiền";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ngày lập:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã hóa đơn";
            // 
            // lb_ThongKe
            // 
            this.lb_ThongKe.AutoSize = true;
            this.lb_ThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ThongKe.Location = new System.Drawing.Point(31, 32);
            this.lb_ThongKe.Name = "lb_ThongKe";
            this.lb_ThongKe.Size = new System.Drawing.Size(107, 25);
            this.lb_ThongKe.TabIndex = 0;
            this.lb_ThongKe.Text = "Thống Kê";
            // 
            // XemHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pl_ThongKe);
            this.Name = "XemHD";
            this.Text = "XemHD";
            this.Load += new System.EventHandler(this.XemHD_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_hd)).EndInit();
            this.pl_ThongKe.ResumeLayout(false);
            this.pl_ThongKe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.DataGridView data_hd;
        private System.Windows.Forms.Panel pl_ThongKe;
        private System.Windows.Forms.TextBox txt_date;
        private System.Windows.Forms.TextBox txt_mahd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.TextBox txt_totalMoney;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_ThongKe;
    }
}