using System;
using System.Windows.Forms;

namespace 写真館システム
{
    partial class Facility_reservation
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.l_customer_code = new System.Windows.Forms.Label();
            this.l_postal_code = new System.Windows.Forms.Label();
            this.l_address1 = new System.Windows.Forms.Label();
            this.l_address2 = new System.Windows.Forms.Label();
            this.l_address3 = new System.Windows.Forms.Label();
            this.l_phone_number1 = new System.Windows.Forms.Label();
            this.l_mail_address = new System.Windows.Forms.Label();
            this.l_customer_name = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.l_birthday = new System.Windows.Forms.Label();
            this.l_phone_number2 = new System.Windows.Forms.Label();
            this.l_phone_number3 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.l_sex = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.l_age = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.d_check = new System.Windows.Forms.CheckBox();
            this.d_tenpomei = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.d_shisetumei = new System.Windows.Forms.ComboBox();
            this.d_select_start_time = new System.Windows.Forms.TextBox();
            this.d_select_end_time = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.d_start_time = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.d_end_time = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.d_start_date = new System.Windows.Forms.DateTimePicker();
            this.d_end_date = new System.Windows.Forms.DateTimePicker();
            this.d_select_start_date = new System.Windows.Forms.DateTimePicker();
            this.d_select_end_date = new System.Windows.Forms.DateTimePicker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.d_yoyaku_list = new System.Windows.Forms.DataGridView();
            this.施設名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.来店日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.予約時間 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.撮影目的 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.d_schedule_list = new System.Windows.Forms.DataGridView();
            this.時刻 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.内容 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_satsueimokuteki = new System.Windows.Forms.ComboBox();
            this.label43 = new System.Windows.Forms.Label();
            this.d_satueisya_id = new System.Windows.Forms.TextBox();
            this.d_tekiyou = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.d_yoyakusya = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.d_tyushi = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.d_tasukukubun = new System.Windows.Forms.ComboBox();
            this.d_select_staff_id = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.d_satueisya = new System.Windows.Forms.ComboBox();
            this.d_select_name = new System.Windows.Forms.ComboBox();
            this.b_return = new System.Windows.Forms.Button();
            this.b_regist = new System.Windows.Forms.Button();
            this.b_delete = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.d_yoyaku_list)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.d_schedule_list)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.b_return, 10, 2);
            this.tableLayoutPanel1.Controls.Add(this.b_regist, 9, 2);
            this.tableLayoutPanel1.Controls.Add(this.b_delete, 8, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(846, 591);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint_1);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 30;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 10);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.389831F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.177966F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label5, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label6, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.label7, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.label8, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.label10, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.label11, 1, 11);
            this.tableLayoutPanel2.Controls.Add(this.label12, 1, 12);
            this.tableLayoutPanel2.Controls.Add(this.l_customer_code, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.l_postal_code, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.l_address1, 5, 3);
            this.tableLayoutPanel2.Controls.Add(this.l_address2, 5, 4);
            this.tableLayoutPanel2.Controls.Add(this.l_address3, 5, 5);
            this.tableLayoutPanel2.Controls.Add(this.l_phone_number1, 5, 6);
            this.tableLayoutPanel2.Controls.Add(this.l_mail_address, 5, 7);
            this.tableLayoutPanel2.Controls.Add(this.l_customer_name, 13, 1);
            this.tableLayoutPanel2.Controls.Add(this.label26, 16, 1);
            this.tableLayoutPanel2.Controls.Add(this.l_birthday, 19, 1);
            this.tableLayoutPanel2.Controls.Add(this.l_phone_number2, 9, 6);
            this.tableLayoutPanel2.Controls.Add(this.l_phone_number3, 13, 6);
            this.tableLayoutPanel2.Controls.Add(this.label24, 10, 1);
            this.tableLayoutPanel2.Controls.Add(this.l_sex, 28, 1);
            this.tableLayoutPanel2.Controls.Add(this.label29, 26, 1);
            this.tableLayoutPanel2.Controls.Add(this.l_age, 22, 1);
            this.tableLayoutPanel2.Controls.Add(this.label28, 23, 1);
            this.tableLayoutPanel2.Controls.Add(this.d_check, 4, 9);
            this.tableLayoutPanel2.Controls.Add(this.d_tenpomei, 4, 10);
            this.tableLayoutPanel2.Controls.Add(this.label34, 9, 10);
            this.tableLayoutPanel2.Controls.Add(this.d_shisetumei, 12, 10);
            this.tableLayoutPanel2.Controls.Add(this.d_select_start_time, 25, 11);
            this.tableLayoutPanel2.Controls.Add(this.d_select_end_time, 25, 12);
            this.tableLayoutPanel2.Controls.Add(this.label39, 22, 11);
            this.tableLayoutPanel2.Controls.Add(this.label40, 22, 12);
            this.tableLayoutPanel2.Controls.Add(this.label35, 8, 11);
            this.tableLayoutPanel2.Controls.Add(this.d_start_time, 10, 11);
            this.tableLayoutPanel2.Controls.Add(this.label37, 14, 11);
            this.tableLayoutPanel2.Controls.Add(this.d_end_time, 10, 12);
            this.tableLayoutPanel2.Controls.Add(this.label36, 8, 12);
            this.tableLayoutPanel2.Controls.Add(this.label38, 14, 12);
            this.tableLayoutPanel2.Controls.Add(this.d_start_date, 4, 11);
            this.tableLayoutPanel2.Controls.Add(this.d_end_date, 4, 12);
            this.tableLayoutPanel2.Controls.Add(this.d_select_start_date, 18, 11);
            this.tableLayoutPanel2.Controls.Add(this.d_select_end_date, 18, 12);
            this.tableLayoutPanel2.Controls.Add(this.tabControl1, 0, 22);
            this.tableLayoutPanel2.Controls.Add(this.d_satsueimokuteki, 14, 13);
            this.tableLayoutPanel2.Controls.Add(this.label43, 1, 13);
            this.tableLayoutPanel2.Controls.Add(this.d_satueisya_id, 4, 13);
            this.tableLayoutPanel2.Controls.Add(this.d_tekiyou, 1, 18);
            this.tableLayoutPanel2.Controls.Add(this.label16, 1, 17);
            this.tableLayoutPanel2.Controls.Add(this.label15, 1, 16);
            this.tableLayoutPanel2.Controls.Add(this.d_yoyakusya, 4, 16);
            this.tableLayoutPanel2.Controls.Add(this.label42, 14, 16);
            this.tableLayoutPanel2.Controls.Add(this.d_tyushi, 18, 16);
            this.tableLayoutPanel2.Controls.Add(this.label14, 1, 15);
            this.tableLayoutPanel2.Controls.Add(this.d_tasukukubun, 4, 15);
            this.tableLayoutPanel2.Controls.Add(this.d_select_staff_id, 4, 14);
            this.tableLayoutPanel2.Controls.Add(this.label41, 1, 14);
            this.tableLayoutPanel2.Controls.Add(this.label13, 12, 13);
            this.tableLayoutPanel2.Controls.Add(this.d_satueisya, 7, 13);
            this.tableLayoutPanel2.Controls.Add(this.d_select_name, 7, 14);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(13, 13);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 30;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(814, 525);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label1, 4);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "■顧客情報";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label2, 4);
            this.label2.Location = new System.Drawing.Point(30, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "顧客コード";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label3, 4);
            this.label3.Location = new System.Drawing.Point(30, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "郵便番号";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label4, 4);
            this.label4.Location = new System.Drawing.Point(30, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "県・市区町村";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label5, 4);
            this.label5.Location = new System.Drawing.Point(30, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "番地";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label6, 4);
            this.label6.Location = new System.Drawing.Point(30, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "アパート・マンション";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label7, 4);
            this.label7.Location = new System.Drawing.Point(30, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "電話番号";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label8, 4);
            this.label8.Location = new System.Drawing.Point(30, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "メール";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label9, 4);
            this.label9.Location = new System.Drawing.Point(3, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "■施設予約";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label10, 3);
            this.label10.Location = new System.Drawing.Point(30, 170);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "店舗名";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label11, 3);
            this.label11.Location = new System.Drawing.Point(30, 187);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 9;
            this.label11.Text = "開始年月日";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label12, 3);
            this.label12.Location = new System.Drawing.Point(30, 204);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 10;
            this.label12.Text = "終了年月日";
            // 
            // l_customer_code
            // 
            this.l_customer_code.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_customer_code, 4);
            this.l_customer_code.Location = new System.Drawing.Point(138, 17);
            this.l_customer_code.Name = "l_customer_code";
            this.l_customer_code.Size = new System.Drawing.Size(53, 12);
            this.l_customer_code.TabIndex = 1;
            this.l_customer_code.Text = "00000001";
            // 
            // l_postal_code
            // 
            this.l_postal_code.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_postal_code, 4);
            this.l_postal_code.Location = new System.Drawing.Point(138, 34);
            this.l_postal_code.Name = "l_postal_code";
            this.l_postal_code.Size = new System.Drawing.Size(53, 12);
            this.l_postal_code.TabIndex = 1;
            this.l_postal_code.Text = "000-0000";
            // 
            // l_address1
            // 
            this.l_address1.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_address1, 10);
            this.l_address1.Location = new System.Drawing.Point(138, 51);
            this.l_address1.Name = "l_address1";
            this.l_address1.Size = new System.Drawing.Size(89, 12);
            this.l_address1.TabIndex = 1;
            this.l_address1.Text = "愛知県名古屋市";
            // 
            // l_address2
            // 
            this.l_address2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_address2, 10);
            this.l_address2.Location = new System.Drawing.Point(138, 68);
            this.l_address2.Name = "l_address2";
            this.l_address2.Size = new System.Drawing.Size(89, 12);
            this.l_address2.TabIndex = 1;
            this.l_address2.Text = "中区栄１－２－１";
            // 
            // l_address3
            // 
            this.l_address3.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_address3, 10);
            this.l_address3.Location = new System.Drawing.Point(138, 85);
            this.l_address3.Name = "l_address3";
            this.l_address3.Size = new System.Drawing.Size(185, 12);
            this.l_address3.TabIndex = 1;
            this.l_address3.Text = "ライオンズマンション名古屋　２０２号室";
            // 
            // l_phone_number1
            // 
            this.l_phone_number1.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_phone_number1, 4);
            this.l_phone_number1.Location = new System.Drawing.Point(138, 102);
            this.l_phone_number1.Name = "l_phone_number1";
            this.l_phone_number1.Size = new System.Drawing.Size(83, 12);
            this.l_phone_number1.TabIndex = 1;
            this.l_phone_number1.Text = "000-0000-0000";
            // 
            // l_mail_address
            // 
            this.l_mail_address.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_mail_address, 4);
            this.l_mail_address.Location = new System.Drawing.Point(138, 119);
            this.l_mail_address.Name = "l_mail_address";
            this.l_mail_address.Size = new System.Drawing.Size(84, 12);
            this.l_mail_address.TabIndex = 1;
            this.l_mail_address.Text = "aaaa@aaaa.com";
            // 
            // l_customer_name
            // 
            this.l_customer_name.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_customer_name, 3);
            this.l_customer_name.Location = new System.Drawing.Point(354, 17);
            this.l_customer_name.Name = "l_customer_name";
            this.l_customer_name.Size = new System.Drawing.Size(53, 12);
            this.l_customer_name.TabIndex = 1;
            this.l_customer_name.Text = "鈴木一郎";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label26, 3);
            this.label26.Location = new System.Drawing.Point(435, 17);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 12);
            this.label26.TabIndex = 1;
            this.label26.Text = "生年月日";
            // 
            // l_birthday
            // 
            this.l_birthday.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_birthday, 3);
            this.l_birthday.Location = new System.Drawing.Point(516, 17);
            this.l_birthday.Name = "l_birthday";
            this.l_birthday.Size = new System.Drawing.Size(65, 12);
            this.l_birthday.TabIndex = 1;
            this.l_birthday.Text = "2018/01/01";
            // 
            // l_phone_number2
            // 
            this.l_phone_number2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_phone_number2, 4);
            this.l_phone_number2.Location = new System.Drawing.Point(246, 102);
            this.l_phone_number2.Name = "l_phone_number2";
            this.l_phone_number2.Size = new System.Drawing.Size(83, 12);
            this.l_phone_number2.TabIndex = 1;
            this.l_phone_number2.Text = "000-0000-0000";
            // 
            // l_phone_number3
            // 
            this.l_phone_number3.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_phone_number3, 4);
            this.l_phone_number3.Location = new System.Drawing.Point(354, 102);
            this.l_phone_number3.Name = "l_phone_number3";
            this.l_phone_number3.Size = new System.Drawing.Size(83, 12);
            this.l_phone_number3.TabIndex = 1;
            this.l_phone_number3.Text = "000-0000-0000";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label24, 3);
            this.label24.Location = new System.Drawing.Point(273, 17);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(51, 12);
            this.label24.TabIndex = 1;
            this.label24.Text = "お客様名";
            // 
            // l_sex
            // 
            this.l_sex.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_sex, 2);
            this.l_sex.Location = new System.Drawing.Point(757, 17);
            this.l_sex.Name = "l_sex";
            this.l_sex.Size = new System.Drawing.Size(17, 12);
            this.l_sex.TabIndex = 1;
            this.l_sex.Text = "男";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label29, 2);
            this.label29.Location = new System.Drawing.Point(703, 17);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(29, 12);
            this.label29.TabIndex = 1;
            this.label29.Text = "性別";
            // 
            // l_age
            // 
            this.l_age.AutoSize = true;
            this.l_age.Location = new System.Drawing.Point(597, 17);
            this.l_age.Name = "l_age";
            this.l_age.Size = new System.Drawing.Size(17, 12);
            this.l_age.TabIndex = 1;
            this.l_age.Text = "10";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(624, 17);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(17, 12);
            this.label28.TabIndex = 1;
            this.label28.Text = "歳";
            // 
            // d_check
            // 
            this.d_check.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.d_check, 4);
            this.d_check.Enabled = false;
            this.d_check.Location = new System.Drawing.Point(111, 156);
            this.d_check.Name = "d_check";
            this.d_check.Size = new System.Drawing.Size(102, 11);
            this.d_check.TabIndex = 20;
            this.d_check.Text = "スケジュール入力";
            this.d_check.UseVisualStyleBackColor = true;
            this.d_check.CheckedChanged += new System.EventHandler(this.d_check_CheckedChanged);
            // 
            // d_tenpomei
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_tenpomei, 5);
            this.d_tenpomei.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.d_tenpomei.FormattingEnabled = true;
            this.d_tenpomei.Location = new System.Drawing.Point(111, 173);
            this.d_tenpomei.Name = "d_tenpomei";
            this.d_tenpomei.Size = new System.Drawing.Size(129, 20);
            this.d_tenpomei.TabIndex = 16;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label34, 3);
            this.label34.Location = new System.Drawing.Point(246, 170);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(41, 12);
            this.label34.TabIndex = 8;
            this.label34.Text = "施設名";
            // 
            // d_shisetumei
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_shisetumei, 5);
            this.d_shisetumei.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.d_shisetumei.FormattingEnabled = true;
            this.d_shisetumei.Location = new System.Drawing.Point(327, 173);
            this.d_shisetumei.Name = "d_shisetumei";
            this.d_shisetumei.Size = new System.Drawing.Size(129, 20);
            this.d_shisetumei.TabIndex = 16;
            // 
            // d_select_start_time
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_select_start_time, 4);
            this.d_select_start_time.Location = new System.Drawing.Point(678, 190);
            this.d_select_start_time.Name = "d_select_start_time";
            this.d_select_start_time.Size = new System.Drawing.Size(100, 19);
            this.d_select_start_time.TabIndex = 26;
            // 
            // d_select_end_time
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_select_end_time, 4);
            this.d_select_end_time.Location = new System.Drawing.Point(678, 207);
            this.d_select_end_time.Name = "d_select_end_time";
            this.d_select_end_time.Size = new System.Drawing.Size(100, 19);
            this.d_select_end_time.TabIndex = 27;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label39, 3);
            this.label39.Location = new System.Drawing.Point(597, 187);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(53, 12);
            this.label39.TabIndex = 23;
            this.label39.Text = "開始時分";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label40, 3);
            this.label40.Location = new System.Drawing.Point(597, 204);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(53, 12);
            this.label40.TabIndex = 24;
            this.label40.Text = "終了時分";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label35, 2);
            this.label35.Location = new System.Drawing.Point(219, 187);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(41, 17);
            this.label35.TabIndex = 9;
            this.label35.Text = "開始時分";
            // 
            // d_start_time
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_start_time, 4);
            this.d_start_time.Location = new System.Drawing.Point(273, 190);
            this.d_start_time.Name = "d_start_time";
            this.d_start_time.Size = new System.Drawing.Size(102, 19);
            this.d_start_time.TabIndex = 21;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label37, 4);
            this.label37.Location = new System.Drawing.Point(381, 187);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(100, 12);
            this.label37.TabIndex = 22;
            this.label37.Text = "セレクト開始年月日";
            // 
            // d_end_time
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_end_time, 4);
            this.d_end_time.Location = new System.Drawing.Point(273, 207);
            this.d_end_time.Name = "d_end_time";
            this.d_end_time.Size = new System.Drawing.Size(102, 19);
            this.d_end_time.TabIndex = 21;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label36, 2);
            this.label36.Location = new System.Drawing.Point(219, 204);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(41, 17);
            this.label36.TabIndex = 9;
            this.label36.Text = "終了時分";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label38, 4);
            this.label38.Location = new System.Drawing.Point(381, 204);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(100, 12);
            this.label38.TabIndex = 25;
            this.label38.Text = "セレクト終了年月日";
            // 
            // d_start_date
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_start_date, 4);
            this.d_start_date.Location = new System.Drawing.Point(111, 190);
            this.d_start_date.Name = "d_start_date";
            this.d_start_date.Size = new System.Drawing.Size(102, 19);
            this.d_start_date.TabIndex = 29;
            this.d_start_date.Leave += new System.EventHandler(this.d_start_date_Leave);
            // 
            // d_end_date
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_end_date, 4);
            this.d_end_date.Location = new System.Drawing.Point(111, 207);
            this.d_end_date.Name = "d_end_date";
            this.d_end_date.Size = new System.Drawing.Size(102, 19);
            this.d_end_date.TabIndex = 29;
            // 
            // d_select_start_date
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_select_start_date, 4);
            this.d_select_start_date.Location = new System.Drawing.Point(489, 190);
            this.d_select_start_date.Name = "d_select_start_date";
            this.d_select_start_date.Size = new System.Drawing.Size(102, 19);
            this.d_select_start_date.TabIndex = 29;
            // 
            // d_select_end_date
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_select_end_date, 4);
            this.d_select_end_date.Location = new System.Drawing.Point(489, 207);
            this.d_select_end_date.Name = "d_select_end_date";
            this.d_select_end_date.Size = new System.Drawing.Size(102, 19);
            this.d_select_end_date.TabIndex = 29;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.tabControl1, 30);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 377);
            this.tabControl1.Name = "tabControl1";
            this.tableLayoutPanel2.SetRowSpan(this.tabControl1, 8);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(808, 145);
            this.tabControl1.TabIndex = 30;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.d_yoyaku_list);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(800, 119);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "予約一覧";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // d_yoyaku_list
            // 
            this.d_yoyaku_list.AllowUserToAddRows = false;
            this.d_yoyaku_list.AllowUserToDeleteRows = false;
            this.d_yoyaku_list.AllowUserToOrderColumns = true;
            this.d_yoyaku_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.d_yoyaku_list.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.d_yoyaku_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.d_yoyaku_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.施設名,
            this.Column2,
            this.Column3,
            this.来店日,
            this.予約時間,
            this.撮影目的});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.d_yoyaku_list.DefaultCellStyle = dataGridViewCellStyle2;
            this.d_yoyaku_list.Location = new System.Drawing.Point(0, 0);
            this.d_yoyaku_list.Name = "d_yoyaku_list";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.d_yoyaku_list.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.d_yoyaku_list.RowHeadersVisible = false;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.d_yoyaku_list.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.d_yoyaku_list.RowTemplate.Height = 21;
            this.d_yoyaku_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.d_yoyaku_list.Size = new System.Drawing.Size(800, 119);
            this.d_yoyaku_list.TabIndex = 0;
            this.d_yoyaku_list.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.d_yoyaku_list_CellClick);
            // 
            // 施設名
            // 
            this.施設名.HeaderText = "施設名";
            this.施設名.Name = "施設名";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "名前";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "性別";
            this.Column3.Name = "Column3";
            // 
            // 来店日
            // 
            this.来店日.HeaderText = "来店日";
            this.来店日.Name = "来店日";
            // 
            // 予約時間
            // 
            this.予約時間.FillWeight = 250F;
            this.予約時間.HeaderText = "予約時間";
            this.予約時間.Name = "予約時間";
            this.予約時間.Width = 250;
            // 
            // 撮影目的
            // 
            this.撮影目的.HeaderText = "撮影目的";
            this.撮影目的.Name = "撮影目的";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.d_schedule_list);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(800, 119);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "スケジュール一覧";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // d_schedule_list
            // 
            this.d_schedule_list.AllowUserToAddRows = false;
            this.d_schedule_list.AllowUserToDeleteRows = false;
            this.d_schedule_list.AllowUserToOrderColumns = true;
            this.d_schedule_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.d_schedule_list.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.d_schedule_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.d_schedule_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.時刻,
            this.内容});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.d_schedule_list.DefaultCellStyle = dataGridViewCellStyle6;
            this.d_schedule_list.Location = new System.Drawing.Point(0, 0);
            this.d_schedule_list.Name = "d_schedule_list";
            this.d_schedule_list.RowHeadersVisible = false;
            this.d_schedule_list.RowTemplate.Height = 21;
            this.d_schedule_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.d_schedule_list.Size = new System.Drawing.Size(930, 130);
            this.d_schedule_list.TabIndex = 0;
            this.d_schedule_list.TabStop = false;
            this.d_schedule_list.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.d_schedule_list_CellClick);
            // 
            // 時刻
            // 
            this.時刻.FillWeight = 250F;
            this.時刻.HeaderText = "時刻";
            this.時刻.Name = "時刻";
            this.時刻.Width = 250;
            // 
            // 内容
            // 
            this.内容.FillWeight = 500F;
            this.内容.HeaderText = "内容";
            this.内容.Name = "内容";
            this.内容.Width = 500;
            // 
            // d_satsueimokuteki
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_satsueimokuteki, 5);
            this.d_satsueimokuteki.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.d_satsueimokuteki.FormattingEnabled = true;
            this.d_satsueimokuteki.Location = new System.Drawing.Point(408, 224);
            this.d_satsueimokuteki.Name = "d_satsueimokuteki";
            this.d_satsueimokuteki.Size = new System.Drawing.Size(129, 20);
            this.d_satsueimokuteki.TabIndex = 15;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label43, 3);
            this.label43.Location = new System.Drawing.Point(30, 221);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(41, 12);
            this.label43.TabIndex = 11;
            this.label43.Text = "撮影者";
            // 
            // d_satueisya_id
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_satueisya_id, 3);
            this.d_satueisya_id.Location = new System.Drawing.Point(111, 224);
            this.d_satueisya_id.Name = "d_satueisya_id";
            this.d_satueisya_id.Size = new System.Drawing.Size(75, 19);
            this.d_satueisya_id.TabIndex = 32;
            this.d_satueisya_id.KeyDown += new System.Windows.Forms.KeyEventHandler(this.d_satueisya_id_KeyDown);
            // 
            // d_tekiyou
            // 
            this.d_tekiyou.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.d_tekiyou, 25);
            this.d_tekiyou.Location = new System.Drawing.Point(30, 309);
            this.d_tekiyou.Multiline = true;
            this.d_tekiyou.Name = "d_tekiyou";
            this.tableLayoutPanel2.SetRowSpan(this.d_tekiyou, 4);
            this.d_tekiyou.Size = new System.Drawing.Size(667, 62);
            this.d_tekiyou.TabIndex = 18;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label16, 3);
            this.label16.Location = new System.Drawing.Point(30, 289);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 14;
            this.label16.Text = "摘要";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label15, 3);
            this.label15.Location = new System.Drawing.Point(30, 272);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 13;
            this.label15.Text = "予約者名";
            // 
            // d_yoyakusya
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_yoyakusya, 5);
            this.d_yoyakusya.Location = new System.Drawing.Point(111, 275);
            this.d_yoyakusya.Name = "d_yoyakusya";
            this.d_yoyakusya.Size = new System.Drawing.Size(129, 19);
            this.d_yoyakusya.TabIndex = 18;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label42, 4);
            this.label42.Location = new System.Drawing.Point(381, 272);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(65, 12);
            this.label42.TabIndex = 25;
            this.label42.Text = "中止年月日";
            this.label42.Visible = false;
            // 
            // d_tyushi
            // 
            this.d_tyushi.Checked = false;
            this.tableLayoutPanel2.SetColumnSpan(this.d_tyushi, 4);
            this.d_tyushi.Location = new System.Drawing.Point(489, 275);
            this.d_tyushi.Name = "d_tyushi";
            this.d_tyushi.ShowCheckBox = true;
            this.d_tyushi.Size = new System.Drawing.Size(102, 19);
            this.d_tyushi.TabIndex = 29;
            this.d_tyushi.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label14, 3);
            this.label14.Location = new System.Drawing.Point(30, 255);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 12);
            this.label14.TabIndex = 12;
            this.label14.Text = "タスク区分";
            // 
            // d_tasukukubun
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_tasukukubun, 5);
            this.d_tasukukubun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.d_tasukukubun.FormattingEnabled = true;
            this.d_tasukukubun.Location = new System.Drawing.Point(111, 258);
            this.d_tasukukubun.Name = "d_tasukukubun";
            this.d_tasukukubun.Size = new System.Drawing.Size(129, 20);
            this.d_tasukukubun.TabIndex = 17;
            // 
            // d_select_staff_id
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_select_staff_id, 3);
            this.d_select_staff_id.Location = new System.Drawing.Point(111, 241);
            this.d_select_staff_id.Name = "d_select_staff_id";
            this.d_select_staff_id.Size = new System.Drawing.Size(75, 19);
            this.d_select_staff_id.TabIndex = 18;
            this.d_select_staff_id.KeyDown += new System.Windows.Forms.KeyEventHandler(this.d_select_staff_id_KeyDown);
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label41, 3);
            this.label41.Location = new System.Drawing.Point(30, 238);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(52, 12);
            this.label41.TabIndex = 13;
            this.label41.Text = "セレクト者";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label13, 3);
            this.label13.Location = new System.Drawing.Point(327, 221);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 11;
            this.label13.Text = "撮影目的";
            // 
            // d_satueisya
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_satueisya, 3);
            this.d_satueisya.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.d_satueisya.FormattingEnabled = true;
            this.d_satueisya.Location = new System.Drawing.Point(192, 224);
            this.d_satueisya.Name = "d_satueisya";
            this.d_satueisya.Size = new System.Drawing.Size(75, 20);
            this.d_satueisya.TabIndex = 15;
            // 
            // d_select_name
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_select_name, 3);
            this.d_select_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.d_select_name.FormattingEnabled = true;
            this.d_select_name.Location = new System.Drawing.Point(192, 241);
            this.d_select_name.Name = "d_select_name";
            this.d_select_name.Size = new System.Drawing.Size(75, 20);
            this.d_select_name.TabIndex = 31;
            this.d_select_name.SelectedIndexChanged += new System.EventHandler(this.d_select_name_SelectedIndexChanged);
            // 
            // b_return
            // 
            this.b_return.Location = new System.Drawing.Point(751, 544);
            this.b_return.Name = "b_return";
            this.b_return.Size = new System.Drawing.Size(75, 23);
            this.b_return.TabIndex = 1;
            this.b_return.Text = "戻る";
            this.b_return.UseVisualStyleBackColor = true;
            this.b_return.Click += new System.EventHandler(this.b_return_Click);
            // 
            // b_regist
            // 
            this.b_regist.Location = new System.Drawing.Point(669, 544);
            this.b_regist.Name = "b_regist";
            this.b_regist.Size = new System.Drawing.Size(75, 23);
            this.b_regist.TabIndex = 2;
            this.b_regist.Text = "登録";
            this.b_regist.UseVisualStyleBackColor = true;
            this.b_regist.Click += new System.EventHandler(this.b_regist_Click);
            // 
            // b_delete
            // 
            this.b_delete.Location = new System.Drawing.Point(587, 544);
            this.b_delete.Name = "b_delete";
            this.b_delete.Size = new System.Drawing.Size(75, 23);
            this.b_delete.TabIndex = 3;
            this.b_delete.Text = "削除";
            this.b_delete.UseVisualStyleBackColor = true;
            this.b_delete.Click += new System.EventHandler(this.b_delete_Click);
            // 
            // Facility_reservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Facility_reservation";
            this.Size = new System.Drawing.Size(846, 591);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.d_yoyaku_list)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.d_schedule_list)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button b_return;
        private System.Windows.Forms.Button b_regist;
        private System.Windows.Forms.Button b_delete;
        private System.Windows.Forms.Label l_customer_code;
        private System.Windows.Forms.Label l_postal_code;
        private System.Windows.Forms.Label l_address1;
        private System.Windows.Forms.Label l_address2;
        private System.Windows.Forms.Label l_address3;
        private System.Windows.Forms.Label l_phone_number1;
        private System.Windows.Forms.Label l_mail_address;
        private System.Windows.Forms.Label l_customer_name;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label l_birthday;
        private System.Windows.Forms.Label l_phone_number2;
        private System.Windows.Forms.Label l_phone_number3;
        private System.Windows.Forms.ComboBox d_tenpomei;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label l_sex;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label l_age;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox d_satsueimokuteki;
        private System.Windows.Forms.ComboBox d_tasukukubun;
        private System.Windows.Forms.TextBox d_yoyakusya;
        private System.Windows.Forms.TextBox d_tekiyou;
        private System.Windows.Forms.CheckBox d_check;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.ComboBox d_shisetumei;
        private System.Windows.Forms.TextBox d_select_start_time;
        private System.Windows.Forms.TextBox d_select_end_time;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox d_start_time;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox d_end_time;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox d_select_staff_id;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.DateTimePicker d_start_date;
        private System.Windows.Forms.DateTimePicker d_end_date;
        private System.Windows.Forms.DateTimePicker d_select_start_date;
        private System.Windows.Forms.DateTimePicker d_select_end_date;
        private System.Windows.Forms.DateTimePicker d_tyushi;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView d_yoyaku_list;
        private System.Windows.Forms.DataGridView d_schedule_list;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.ComboBox d_satueisya;
        private System.Windows.Forms.ComboBox d_select_name;
        private System.Windows.Forms.TextBox d_satueisya_id;
        private DataGridViewTextBoxColumn 施設名;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn 来店日;
        private DataGridViewTextBoxColumn 予約時間;
        private DataGridViewTextBoxColumn 撮影目的;
        private DataGridViewTextBoxColumn 時刻;
        private DataGridViewTextBoxColumn 内容;
    }
}
