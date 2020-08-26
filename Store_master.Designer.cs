using System;

namespace 写真館システム
{
    partial class Store_master
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.t_tenpo_code = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.t_company = new System.Windows.Forms.TextBox();
            this.t_current_page = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.t_total_page = new System.Windows.Forms.Label();
            this.b_decrease = new System.Windows.Forms.LinkLabel();
            this.b_increase = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.t_tenpo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.t_postal_code = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.t_kensikuchouson = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.t_banchi = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.t_apart = new System.Windows.Forms.TextBox();
            this.t_telephon_no = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.d_status = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.t_eigyou_start = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.t_eigyou_end = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.t_regular_holiday = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.d_tenpo_kubun = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.b_new_regist = new System.Windows.Forms.Button();
            this.b_delete = new System.Windows.Forms.Button();
            this.b_regist = new System.Windows.Forms.Button();
            this.b_return = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 12;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.b_new_regist, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.b_delete, 8, 2);
            this.tableLayoutPanel1.Controls.Add(this.b_regist, 9, 2);
            this.tableLayoutPanel1.Controls.Add(this.b_return, 10, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1063, 676);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 30;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 10);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.191489F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.384913F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.191489F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.384913F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.t_tenpo_code, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.linkLabel1, 13, 4);
            this.tableLayoutPanel2.Controls.Add(this.label5, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.t_company, 4, 5);
            this.tableLayoutPanel2.Controls.Add(this.t_current_page, 9, 3);
            this.tableLayoutPanel2.Controls.Add(this.label3, 10, 3);
            this.tableLayoutPanel2.Controls.Add(this.t_total_page, 11, 3);
            this.tableLayoutPanel2.Controls.Add(this.b_decrease, 12, 3);
            this.tableLayoutPanel2.Controls.Add(this.b_increase, 13, 3);
            this.tableLayoutPanel2.Controls.Add(this.label6, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.t_tenpo, 4, 7);
            this.tableLayoutPanel2.Controls.Add(this.label7, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.t_postal_code, 4, 9);
            this.tableLayoutPanel2.Controls.Add(this.label8, 1, 11);
            this.tableLayoutPanel2.Controls.Add(this.t_kensikuchouson, 1, 12);
            this.tableLayoutPanel2.Controls.Add(this.label9, 1, 13);
            this.tableLayoutPanel2.Controls.Add(this.t_banchi, 1, 14);
            this.tableLayoutPanel2.Controls.Add(this.label10, 1, 15);
            this.tableLayoutPanel2.Controls.Add(this.t_apart, 1, 16);
            this.tableLayoutPanel2.Controls.Add(this.t_telephon_no, 21, 3);
            this.tableLayoutPanel2.Controls.Add(this.label11, 18, 3);
            this.tableLayoutPanel2.Controls.Add(this.d_status, 21, 5);
            this.tableLayoutPanel2.Controls.Add(this.label12, 18, 5);
            this.tableLayoutPanel2.Controls.Add(this.t_eigyou_start, 21, 7);
            this.tableLayoutPanel2.Controls.Add(this.label13, 18, 7);
            this.tableLayoutPanel2.Controls.Add(this.t_eigyou_end, 21, 9);
            this.tableLayoutPanel2.Controls.Add(this.label14, 18, 9);
            this.tableLayoutPanel2.Controls.Add(this.t_regular_holiday, 21, 11);
            this.tableLayoutPanel2.Controls.Add(this.label15, 18, 11);
            this.tableLayoutPanel2.Controls.Add(this.d_tenpo_kubun, 21, 13);
            this.tableLayoutPanel2.Controls.Add(this.label16, 18, 13);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(13, 13);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 30;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1034, 610);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label1, 2);
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(37, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "店舗登録";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label2, 2);
            this.label2.Location = new System.Drawing.Point(37, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "店舗コード";
            // 
            // t_tenpo_code
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.t_tenpo_code, 3);
            this.t_tenpo_code.Enabled = false;
            this.t_tenpo_code.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.t_tenpo_code.Location = new System.Drawing.Point(139, 60);
            this.t_tenpo_code.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.t_tenpo_code.Name = "t_tenpo_code";
            this.t_tenpo_code.Size = new System.Drawing.Size(80, 19);
            this.t_tenpo_code.TabIndex = 2;
            this.t_tenpo_code.TextChanged += new System.EventHandler(this.d_tenpo_code_TextChnged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(445, 80);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 12);
            this.linkLabel1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label5, 2);
            this.label5.Location = new System.Drawing.Point(37, 103);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "会社名";
            // 
            // t_company
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.t_company, 12);
            this.t_company.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.t_company.Location = new System.Drawing.Point(139, 100);
            this.t_company.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.t_company.Name = "t_company";
            this.t_company.Size = new System.Drawing.Size(402, 19);
            this.t_company.TabIndex = 2;
            this.t_company.TextChanged += new System.EventHandler(this.d_company_TextChanged);
            // 
            // t_current_page
            // 
            this.t_current_page.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.t_current_page.Location = new System.Drawing.Point(308, 60);
            this.t_current_page.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.t_current_page.Name = "t_current_page";
            this.t_current_page.Size = new System.Drawing.Size(29, 19);
            this.t_current_page.TabIndex = 5;
            this.t_current_page.Leave += new System.EventHandler(this.t_current_page_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "／";
            // 
            // t_total_page
            // 
            this.t_total_page.AutoSize = true;
            this.t_total_page.Location = new System.Drawing.Point(377, 63);
            this.t_total_page.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.t_total_page.Name = "t_total_page";
            this.t_total_page.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.t_total_page.Size = new System.Drawing.Size(11, 12);
            this.t_total_page.TabIndex = 6;
            this.t_total_page.Text = "0";
            // 
            // b_decrease
            // 
            this.b_decrease.AutoSize = true;
            this.b_decrease.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.b_decrease.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.b_decrease.Location = new System.Drawing.Point(411, 63);
            this.b_decrease.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.b_decrease.Name = "b_decrease";
            this.b_decrease.Size = new System.Drawing.Size(14, 13);
            this.b_decrease.TabIndex = 8;
            this.b_decrease.TabStop = true;
            this.b_decrease.Text = "◀";
            this.b_decrease.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.b_decrease.Click += new System.EventHandler(this.b_decrease_Click);
            // 
            // b_increase
            // 
            this.b_increase.AutoSize = true;
            this.b_increase.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.b_increase.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.b_increase.Location = new System.Drawing.Point(445, 63);
            this.b_increase.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.b_increase.Name = "b_increase";
            this.b_increase.Size = new System.Drawing.Size(14, 13);
            this.b_increase.TabIndex = 9;
            this.b_increase.TabStop = true;
            this.b_increase.Text = "▶";
            this.b_increase.Click += new System.EventHandler(this.b_increase_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label6, 2);
            this.label6.Location = new System.Drawing.Point(37, 143);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "店舗名";
            // 
            // t_tenpo
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.t_tenpo, 12);
            this.t_tenpo.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.t_tenpo.Location = new System.Drawing.Point(139, 140);
            this.t_tenpo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.t_tenpo.Name = "t_tenpo";
            this.t_tenpo.Size = new System.Drawing.Size(402, 19);
            this.t_tenpo.TabIndex = 2;
            this.t_tenpo.TextChanged += new System.EventHandler(this.d_tenpo_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label7, 2);
            this.label7.Location = new System.Drawing.Point(37, 183);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "郵便番号";
            // 
            // t_postal_code
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.t_postal_code, 3);
            this.t_postal_code.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.t_postal_code.Location = new System.Drawing.Point(139, 180);
            this.t_postal_code.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.t_postal_code.Name = "t_postal_code";
            this.t_postal_code.Size = new System.Drawing.Size(80, 19);
            this.t_postal_code.TabIndex = 2;
            this.t_postal_code.TextChanged += new System.EventHandler(this.t_postal_code_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label8, 3);
            this.label8.Location = new System.Drawing.Point(37, 223);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "県・市区町村";
            // 
            // t_kensikuchouson
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.t_kensikuchouson, 15);
            this.t_kensikuchouson.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.t_kensikuchouson.Location = new System.Drawing.Point(37, 240);
            this.t_kensikuchouson.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.t_kensikuchouson.Name = "t_kensikuchouson";
            this.t_kensikuchouson.Size = new System.Drawing.Size(504, 19);
            this.t_kensikuchouson.TabIndex = 2;
            this.t_kensikuchouson.TextChanged += new System.EventHandler(this.t_kensikuchouson_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label9, 2);
            this.label9.Location = new System.Drawing.Point(37, 263);
            this.label9.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "番地";
            // 
            // t_banchi
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.t_banchi, 15);
            this.t_banchi.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.t_banchi.Location = new System.Drawing.Point(37, 280);
            this.t_banchi.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.t_banchi.Name = "t_banchi";
            this.t_banchi.Size = new System.Drawing.Size(504, 19);
            this.t_banchi.TabIndex = 2;
            this.t_banchi.TextChanged += new System.EventHandler(this.t_banchi_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label10, 3);
            this.label10.Location = new System.Drawing.Point(37, 303);
            this.label10.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "アパート・マンション";
            // 
            // t_apart
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.t_apart, 15);
            this.t_apart.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.t_apart.Location = new System.Drawing.Point(37, 320);
            this.t_apart.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.t_apart.Name = "t_apart";
            this.t_apart.Size = new System.Drawing.Size(504, 19);
            this.t_apart.TabIndex = 2;
            this.t_apart.TextChanged += new System.EventHandler(this.t_apart_TextChanged);
            // 
            // t_telephon_no
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.t_telephon_no, 3);
            this.t_telephon_no.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.t_telephon_no.Location = new System.Drawing.Point(717, 60);
            this.t_telephon_no.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.t_telephon_no.Name = "t_telephon_no";
            this.t_telephon_no.Size = new System.Drawing.Size(96, 19);
            this.t_telephon_no.TabIndex = 2;
            this.t_telephon_no.TextChanged += new System.EventHandler(this.t_telephon_no_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label11, 3);
            this.label11.Location = new System.Drawing.Point(615, 63);
            this.label11.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "電話番号";
            // 
            // d_status
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_status, 3);
            this.d_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.d_status.FormattingEnabled = true;
            this.d_status.Location = new System.Drawing.Point(717, 100);
            this.d_status.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.d_status.Name = "d_status";
            this.d_status.Size = new System.Drawing.Size(96, 20);
            this.d_status.TabIndex = 10;
            this.d_status.SelectedIndexChanged += new System.EventHandler(this.d_status_SelectIndexChange);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label12, 3);
            this.label12.Location = new System.Drawing.Point(615, 103);
            this.label12.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "ステータス";
            // 
            // t_eigyou_start
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.t_eigyou_start, 2);
            this.t_eigyou_start.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.t_eigyou_start.Location = new System.Drawing.Point(717, 140);
            this.t_eigyou_start.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.t_eigyou_start.Name = "t_eigyou_start";
            this.t_eigyou_start.Size = new System.Drawing.Size(62, 19);
            this.t_eigyou_start.TabIndex = 2;
            this.t_eigyou_start.TextChanged += new System.EventHandler(this.t_eigyou_start_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label13, 3);
            this.label13.Location = new System.Drawing.Point(615, 143);
            this.label13.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 12);
            this.label13.TabIndex = 1;
            this.label13.Text = "営業開始時分";
            // 
            // t_eigyou_end
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.t_eigyou_end, 2);
            this.t_eigyou_end.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.t_eigyou_end.Location = new System.Drawing.Point(717, 180);
            this.t_eigyou_end.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.t_eigyou_end.Name = "t_eigyou_end";
            this.t_eigyou_end.Size = new System.Drawing.Size(62, 19);
            this.t_eigyou_end.TabIndex = 2;
            this.t_eigyou_end.TextChanged += new System.EventHandler(this.t_eigyou_end_TextChaged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label14, 3);
            this.label14.Location = new System.Drawing.Point(615, 183);
            this.label14.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 1;
            this.label14.Text = "営業終了時分";
            // 
            // t_regular_holiday
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.t_regular_holiday, 4);
            this.t_regular_holiday.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.t_regular_holiday.Location = new System.Drawing.Point(717, 220);
            this.t_regular_holiday.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.t_regular_holiday.Name = "t_regular_holiday";
            this.t_regular_holiday.Size = new System.Drawing.Size(130, 19);
            this.t_regular_holiday.TabIndex = 2;
            this.t_regular_holiday.TextChanged += new System.EventHandler(this.t_regular_holiday_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label15, 3);
            this.label15.Location = new System.Drawing.Point(615, 223);
            this.label15.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 1;
            this.label15.Text = "定休日";
            // 
            // d_tenpo_kubun
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_tenpo_kubun, 3);
            this.d_tenpo_kubun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.d_tenpo_kubun.FormattingEnabled = true;
            this.d_tenpo_kubun.Location = new System.Drawing.Point(717, 260);
            this.d_tenpo_kubun.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.d_tenpo_kubun.Name = "d_tenpo_kubun";
            this.d_tenpo_kubun.Size = new System.Drawing.Size(96, 20);
            this.d_tenpo_kubun.TabIndex = 10;
            this.d_tenpo_kubun.SelectedIndexChanged += new System.EventHandler(this.d_tenpo_kubun_SelectIndexChange);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label16, 3);
            this.label16.Location = new System.Drawing.Point(615, 263);
            this.label16.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 1;
            this.label16.Text = "店舗区分";
            // 
            // b_new_regist
            // 
            this.b_new_regist.Location = new System.Drawing.Point(637, 629);
            this.b_new_regist.Name = "b_new_regist";
            this.b_new_regist.Size = new System.Drawing.Size(98, 23);
            this.b_new_regist.TabIndex = 1;
            this.b_new_regist.Text = "新規登録";
            this.b_new_regist.UseVisualStyleBackColor = true;
            this.b_new_regist.Click += new System.EventHandler(this.b_new_regist_Click);
            // 
            // b_delete
            // 
            this.b_delete.Location = new System.Drawing.Point(741, 629);
            this.b_delete.Name = "b_delete";
            this.b_delete.Size = new System.Drawing.Size(98, 23);
            this.b_delete.TabIndex = 1;
            this.b_delete.Text = "削除";
            this.b_delete.UseVisualStyleBackColor = true;
            this.b_delete.Click += new System.EventHandler(this.b_delete_Click);
            // 
            // b_regist
            // 
            this.b_regist.Location = new System.Drawing.Point(845, 629);
            this.b_regist.Name = "b_regist";
            this.b_regist.Size = new System.Drawing.Size(98, 23);
            this.b_regist.TabIndex = 1;
            this.b_regist.Text = "登録";
            this.b_regist.UseVisualStyleBackColor = true;
            this.b_regist.Click += new System.EventHandler(this.b_regist_Click);
            // 
            // b_return
            // 
            this.b_return.Location = new System.Drawing.Point(949, 629);
            this.b_return.Name = "b_return";
            this.b_return.Size = new System.Drawing.Size(98, 23);
            this.b_return.TabIndex = 1;
            this.b_return.Text = "戻る";
            this.b_return.UseVisualStyleBackColor = true;
            this.b_return.Click += new System.EventHandler(this.b_return_Click);
            // 
            // Store_master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Store_master";
            this.Size = new System.Drawing.Size(1066, 676);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox t_tenpo_code;
        private System.Windows.Forms.TextBox t_current_page;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label t_total_page;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel b_decrease;
        private System.Windows.Forms.LinkLabel b_increase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox t_company;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox t_tenpo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox t_postal_code;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox t_kensikuchouson;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox t_banchi;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox t_apart;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox t_telephon_no;
        private System.Windows.Forms.ComboBox d_status;
        private System.Windows.Forms.TextBox t_eigyou_start;
        private System.Windows.Forms.TextBox t_eigyou_end;
        private System.Windows.Forms.TextBox t_regular_holiday;
        private System.Windows.Forms.ComboBox d_tenpo_kubun;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button b_new_regist;
        private System.Windows.Forms.Button b_delete;
        private System.Windows.Forms.Button b_regist;
        private System.Windows.Forms.Button b_return;
    }
}
