using System;

namespace 写真館システム
{
    partial class Customer_information
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.t_name = new System.Windows.Forms.TextBox();
            this.t_name_kana = new System.Windows.Forms.TextBox();
            this.l_Last_use_store = new System.Windows.Forms.Label();
            this.l_age = new System.Windows.Forms.Label();
            this.co_Sex = new System.Windows.Forms.ComboBox();
            this.l_Sex = new System.Windows.Forms.Label();
            this.da_Birthday = new System.Windows.Forms.DateTimePicker();
            this.l_Birthday = new System.Windows.Forms.Label();
            this.l_Last_use_store_name = new System.Windows.Forms.Label();
            this.t_surname = new System.Windows.Forms.TextBox();
            this.t_surname_kana = new System.Windows.Forms.TextBox();
            this.l_Cutoner_name_rubi = new System.Windows.Forms.Label();
            this.t_Customer_code = new System.Windows.Forms.TextBox();
            this.l_Customer_code = new System.Windows.Forms.Label();
            this.b_customer_search = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ta_Customer_Infomation = new System.Windows.Forms.TabPage();
            this.t_mail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.t_Remark = new System.Windows.Forms.RichTextBox();
            this.l_Remark = new System.Windows.Forms.Label();
            this.t_Free_item3 = new System.Windows.Forms.TextBox();
            this.t_Free_item2 = new System.Windows.Forms.TextBox();
            this.t_Free_item1 = new System.Windows.Forms.TextBox();
            this.l_Free_item = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ch_Sample = new System.Windows.Forms.CheckBox();
            this.da_Customer_wedding_anniversary = new System.Windows.Forms.DateTimePicker();
            this.l_Wedding_anniversary = new System.Windows.Forms.Label();
            this.co_Visit_motive = new System.Windows.Forms.ComboBox();
            this.l_Visit_motive = new System.Windows.Forms.Label();
            this.t_Fax = new System.Windows.Forms.TextBox();
            this.l_Fax = new System.Windows.Forms.Label();
            this.t_Phone_number3 = new System.Windows.Forms.TextBox();
            this.l_Phone_number3 = new System.Windows.Forms.Label();
            this.t_Phone_number2 = new System.Windows.Forms.TextBox();
            this.l_Phone_number2 = new System.Windows.Forms.Label();
            this.t_Phone_number1 = new System.Windows.Forms.TextBox();
            this.l_Phone_number1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.t_Apartment_mansion = new System.Windows.Forms.TextBox();
            this.l_Apartment_mansion = new System.Windows.Forms.Label();
            this.t_Address2 = new System.Windows.Forms.TextBox();
            this.l_Address2 = new System.Windows.Forms.Label();
            this.b_Postal_code_search = new System.Windows.Forms.Button();
            this.b_Address_search = new System.Windows.Forms.Button();
            this.t_Pref_city_town_village_name = new System.Windows.Forms.TextBox();
            this.l_Pref_City_town_village_name = new System.Windows.Forms.Label();
            this.t_Postal_code = new System.Windows.Forms.TextBox();
            this.l_Postal_code = new System.Windows.Forms.Label();
            this.ch_DM_Available = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ta_Family_Infomation = new System.Windows.Forms.TabPage();
            this.b_Family_delete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.続柄 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.姓 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.姓カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.名カナ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.誕生日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.性別 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.備考 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ta_Menber_Infomation = new System.Windows.Forms.TabPage();
            this.co_Membership_type = new System.Windows.Forms.ComboBox();
            this.l_Membership_type = new System.Windows.Forms.Label();
            this.co_Rank = new System.Windows.Forms.ComboBox();
            this.l_Rank = new System.Windows.Forms.Label();
            this.co_Registered_store = new System.Windows.Forms.ComboBox();
            this.l_Registered_store = new System.Windows.Forms.Label();
            this.t_Registration_officer = new System.Windows.Forms.TextBox();
            this.l_Registration_officer = new System.Windows.Forms.Label();
            this.da_Registration_date = new System.Windows.Forms.DateTimePicker();
            this.l_Registration_date = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.ta_Reservation_information = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.d_Reservation_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_Reservation_store = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_Reservation_start_time_end_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_Reserved_facility_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_Reserved_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_Reserved_sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_Reserved_shooting_purpose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ta_Exchange_information = new System.Windows.Forms.TabPage();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.d_Exchange_receipt_date_hour_minute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_Exchange_receiving_store = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_Exchage_corresponding_clerk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_Exchage_customer_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_Exchange_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listView1 = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.b_Return = new System.Windows.Forms.Button();
            this.b_touroku = new System.Windows.Forms.Button();
            this.b_delete = new System.Windows.Forms.Button();
            this.b_Reception = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.ta_Customer_Infomation.SuspendLayout();
            this.ta_Family_Infomation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.ta_Menber_Infomation.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.ta_Reservation_information.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.ta_Exchange_information.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.19048F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.809524F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.b_Return, 10, 2);
            this.tableLayoutPanel1.Controls.Add(this.b_touroku, 9, 2);
            this.tableLayoutPanel1.Controls.Add(this.b_delete, 8, 2);
            this.tableLayoutPanel1.Controls.Add(this.b_Reception, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(973, 602);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 30;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 10);
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
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tabControl1, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.tabControl2, 0, 18);
            this.tableLayoutPanel2.Controls.Add(this.listView1, 0, 25);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(13, 10);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
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
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(944, 539);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.groupBox1, 31);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.t_name);
            this.groupBox1.Controls.Add(this.t_name_kana);
            this.groupBox1.Controls.Add(this.l_Last_use_store);
            this.groupBox1.Controls.Add(this.l_age);
            this.groupBox1.Controls.Add(this.co_Sex);
            this.groupBox1.Controls.Add(this.l_Sex);
            this.groupBox1.Controls.Add(this.da_Birthday);
            this.groupBox1.Controls.Add(this.l_Birthday);
            this.groupBox1.Controls.Add(this.l_Last_use_store_name);
            this.groupBox1.Controls.Add(this.t_surname);
            this.groupBox1.Controls.Add(this.t_surname_kana);
            this.groupBox1.Controls.Add(this.l_Cutoner_name_rubi);
            this.groupBox1.Controls.Add(this.t_Customer_code);
            this.groupBox1.Controls.Add(this.l_Customer_code);
            this.groupBox1.Controls.Add(this.b_customer_search);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.tableLayoutPanel2.SetRowSpan(this.groupBox1, 7);
            this.groupBox1.Size = new System.Drawing.Size(938, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // t_name
            // 
            this.t_name.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.t_name.Location = new System.Drawing.Point(164, 81);
            this.t_name.Name = "t_name";
            this.t_name.Size = new System.Drawing.Size(80, 19);
            this.t_name.TabIndex = 3;
            // 
            // t_name_kana
            // 
            this.t_name_kana.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.t_name_kana.Location = new System.Drawing.Point(164, 62);
            this.t_name_kana.Name = "t_name_kana";
            this.t_name_kana.Size = new System.Drawing.Size(80, 19);
            this.t_name_kana.TabIndex = 5;
            // 
            // l_Last_use_store
            // 
            this.l_Last_use_store.AutoSize = true;
            this.l_Last_use_store.Location = new System.Drawing.Point(605, 38);
            this.l_Last_use_store.Name = "l_Last_use_store";
            this.l_Last_use_store.Size = new System.Drawing.Size(0, 12);
            this.l_Last_use_store.TabIndex = 8;
            // 
            // l_age
            // 
            this.l_age.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_age.AutoSize = true;
            this.l_age.Location = new System.Drawing.Point(767, 54);
            this.l_age.Name = "l_age";
            this.l_age.Size = new System.Drawing.Size(23, 12);
            this.l_age.TabIndex = 7;
            this.l_age.Text = "0歳";
            // 
            // co_Sex
            // 
            this.co_Sex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.co_Sex.FormattingEnabled = true;
            this.co_Sex.Location = new System.Drawing.Point(605, 69);
            this.co_Sex.Name = "co_Sex";
            this.co_Sex.Size = new System.Drawing.Size(141, 20);
            this.co_Sex.TabIndex = 7;
            // 
            // l_Sex
            // 
            this.l_Sex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Sex.AutoSize = true;
            this.l_Sex.Location = new System.Drawing.Point(523, 73);
            this.l_Sex.Name = "l_Sex";
            this.l_Sex.Size = new System.Drawing.Size(29, 12);
            this.l_Sex.TabIndex = 0;
            this.l_Sex.Text = "性別";
            // 
            // da_Birthday
            // 
            this.da_Birthday.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.da_Birthday.Location = new System.Drawing.Point(605, 51);
            this.da_Birthday.Name = "da_Birthday";
            this.da_Birthday.Size = new System.Drawing.Size(141, 19);
            this.da_Birthday.TabIndex = 6;
            this.da_Birthday.ValueChanged += new System.EventHandler(this.da_Birthday_ValueChanged);
            // 
            // l_Birthday
            // 
            this.l_Birthday.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Birthday.AutoSize = true;
            this.l_Birthday.Location = new System.Drawing.Point(522, 54);
            this.l_Birthday.Name = "l_Birthday";
            this.l_Birthday.Size = new System.Drawing.Size(53, 12);
            this.l_Birthday.TabIndex = 0;
            this.l_Birthday.Text = "生年月日";
            // 
            // l_Last_use_store_name
            // 
            this.l_Last_use_store_name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Last_use_store_name.AutoSize = true;
            this.l_Last_use_store_name.Location = new System.Drawing.Point(521, 36);
            this.l_Last_use_store_name.Name = "l_Last_use_store_name";
            this.l_Last_use_store_name.Size = new System.Drawing.Size(77, 12);
            this.l_Last_use_store_name.TabIndex = 0;
            this.l_Last_use_store_name.Text = "最終利用店舗";
            // 
            // t_surname
            // 
            this.t_surname.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.t_surname.Location = new System.Drawing.Point(84, 81);
            this.t_surname.Name = "t_surname";
            this.t_surname.Size = new System.Drawing.Size(80, 19);
            this.t_surname.TabIndex = 2;
            // 
            // t_surname_kana
            // 
            this.t_surname_kana.ImeMode = System.Windows.Forms.ImeMode.Katakana;
            this.t_surname_kana.Location = new System.Drawing.Point(84, 62);
            this.t_surname_kana.Name = "t_surname_kana";
            this.t_surname_kana.Size = new System.Drawing.Size(80, 19);
            this.t_surname_kana.TabIndex = 4;
            // 
            // l_Cutoner_name_rubi
            // 
            this.l_Cutoner_name_rubi.Location = new System.Drawing.Point(8, 62);
            this.l_Cutoner_name_rubi.Name = "l_Cutoner_name_rubi";
            this.l_Cutoner_name_rubi.Size = new System.Drawing.Size(70, 19);
            this.l_Cutoner_name_rubi.TabIndex = 0;
            this.l_Cutoner_name_rubi.Text = "フリガナ";
            this.l_Cutoner_name_rubi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.l_Cutoner_name_rubi.Click += new System.EventHandler(this.l_Cutoner_name_rubi_Click);
            // 
            // t_Customer_code
            // 
            this.t_Customer_code.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.t_Customer_code.Location = new System.Drawing.Point(84, 36);
            this.t_Customer_code.Name = "t_Customer_code";
            this.t_Customer_code.Size = new System.Drawing.Size(148, 19);
            this.t_Customer_code.TabIndex = 1;
            // 
            // l_Customer_code
            // 
            this.l_Customer_code.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Customer_code.AutoSize = true;
            this.l_Customer_code.Location = new System.Drawing.Point(7, 39);
            this.l_Customer_code.Name = "l_Customer_code";
            this.l_Customer_code.Size = new System.Drawing.Size(56, 12);
            this.l_Customer_code.TabIndex = 1;
            this.l_Customer_code.Text = "顧客コード";
            // 
            // b_customer_search
            // 
            this.b_customer_search.Location = new System.Drawing.Point(3, 11);
            this.b_customer_search.Name = "b_customer_search";
            this.b_customer_search.Size = new System.Drawing.Size(75, 23);
            this.b_customer_search.TabIndex = 0;
            this.b_customer_search.Text = "顧客検索";
            this.b_customer_search.UseVisualStyleBackColor = true;
            this.b_customer_search.Click += new System.EventHandler(this.b_customer_search_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.tabControl1, 30);
            this.tabControl1.Controls.Add(this.ta_Customer_Infomation);
            this.tabControl1.Controls.Add(this.ta_Family_Infomation);
            this.tabControl1.Controls.Add(this.ta_Menber_Infomation);
            this.tabControl1.Location = new System.Drawing.Point(3, 122);
            this.tabControl1.Name = "tabControl1";
            this.tableLayoutPanel2.SetRowSpan(this.tabControl1, 11);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(938, 181);
            this.tabControl1.TabIndex = 7;
            // 
            // ta_Customer_Infomation
            // 
            this.ta_Customer_Infomation.Controls.Add(this.t_mail);
            this.ta_Customer_Infomation.Controls.Add(this.label4);
            this.ta_Customer_Infomation.Controls.Add(this.t_Remark);
            this.ta_Customer_Infomation.Controls.Add(this.l_Remark);
            this.ta_Customer_Infomation.Controls.Add(this.t_Free_item3);
            this.ta_Customer_Infomation.Controls.Add(this.t_Free_item2);
            this.ta_Customer_Infomation.Controls.Add(this.t_Free_item1);
            this.ta_Customer_Infomation.Controls.Add(this.l_Free_item);
            this.ta_Customer_Infomation.Controls.Add(this.label3);
            this.ta_Customer_Infomation.Controls.Add(this.ch_Sample);
            this.ta_Customer_Infomation.Controls.Add(this.da_Customer_wedding_anniversary);
            this.ta_Customer_Infomation.Controls.Add(this.l_Wedding_anniversary);
            this.ta_Customer_Infomation.Controls.Add(this.co_Visit_motive);
            this.ta_Customer_Infomation.Controls.Add(this.l_Visit_motive);
            this.ta_Customer_Infomation.Controls.Add(this.t_Fax);
            this.ta_Customer_Infomation.Controls.Add(this.l_Fax);
            this.ta_Customer_Infomation.Controls.Add(this.t_Phone_number3);
            this.ta_Customer_Infomation.Controls.Add(this.l_Phone_number3);
            this.ta_Customer_Infomation.Controls.Add(this.t_Phone_number2);
            this.ta_Customer_Infomation.Controls.Add(this.l_Phone_number2);
            this.ta_Customer_Infomation.Controls.Add(this.t_Phone_number1);
            this.ta_Customer_Infomation.Controls.Add(this.l_Phone_number1);
            this.ta_Customer_Infomation.Controls.Add(this.label2);
            this.ta_Customer_Infomation.Controls.Add(this.t_Apartment_mansion);
            this.ta_Customer_Infomation.Controls.Add(this.l_Apartment_mansion);
            this.ta_Customer_Infomation.Controls.Add(this.t_Address2);
            this.ta_Customer_Infomation.Controls.Add(this.l_Address2);
            this.ta_Customer_Infomation.Controls.Add(this.b_Postal_code_search);
            this.ta_Customer_Infomation.Controls.Add(this.b_Address_search);
            this.ta_Customer_Infomation.Controls.Add(this.t_Pref_city_town_village_name);
            this.ta_Customer_Infomation.Controls.Add(this.l_Pref_City_town_village_name);
            this.ta_Customer_Infomation.Controls.Add(this.t_Postal_code);
            this.ta_Customer_Infomation.Controls.Add(this.l_Postal_code);
            this.ta_Customer_Infomation.Controls.Add(this.ch_DM_Available);
            this.ta_Customer_Infomation.Controls.Add(this.label1);
            this.ta_Customer_Infomation.Location = new System.Drawing.Point(4, 22);
            this.ta_Customer_Infomation.Name = "ta_Customer_Infomation";
            this.ta_Customer_Infomation.Padding = new System.Windows.Forms.Padding(3);
            this.ta_Customer_Infomation.Size = new System.Drawing.Size(930, 155);
            this.ta_Customer_Infomation.TabIndex = 0;
            this.ta_Customer_Infomation.Text = "顧客情報";
            this.ta_Customer_Infomation.UseVisualStyleBackColor = true;
            // 
            // t_mail
            // 
            this.t_mail.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.t_mail.Location = new System.Drawing.Point(130, 132);
            this.t_mail.Name = "t_mail";
            this.t_mail.Size = new System.Drawing.Size(249, 19);
            this.t_mail.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "メールアドレス";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // t_Remark
            // 
            this.t_Remark.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.t_Remark.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.t_Remark.Location = new System.Drawing.Point(514, 98);
            this.t_Remark.Name = "t_Remark";
            this.t_Remark.Size = new System.Drawing.Size(404, 49);
            this.t_Remark.TabIndex = 26;
            this.t_Remark.Text = "";
            // 
            // l_Remark
            // 
            this.l_Remark.Location = new System.Drawing.Point(489, 103);
            this.l_Remark.Name = "l_Remark";
            this.l_Remark.Size = new System.Drawing.Size(19, 44);
            this.l_Remark.TabIndex = 0;
            this.l_Remark.Text = "備\r\n考";
            this.l_Remark.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // t_Free_item3
            // 
            this.t_Free_item3.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.t_Free_item3.Location = new System.Drawing.Point(514, 81);
            this.t_Free_item3.Name = "t_Free_item3";
            this.t_Free_item3.Size = new System.Drawing.Size(404, 19);
            this.t_Free_item3.TabIndex = 25;
            // 
            // t_Free_item2
            // 
            this.t_Free_item2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.t_Free_item2.Location = new System.Drawing.Point(514, 62);
            this.t_Free_item2.Name = "t_Free_item2";
            this.t_Free_item2.Size = new System.Drawing.Size(404, 19);
            this.t_Free_item2.TabIndex = 24;
            // 
            // t_Free_item1
            // 
            this.t_Free_item1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.t_Free_item1.Location = new System.Drawing.Point(514, 43);
            this.t_Free_item1.Name = "t_Free_item1";
            this.t_Free_item1.Size = new System.Drawing.Size(404, 19);
            this.t_Free_item1.TabIndex = 23;
            // 
            // l_Free_item
            // 
            this.l_Free_item.Location = new System.Drawing.Point(488, 45);
            this.l_Free_item.Name = "l_Free_item";
            this.l_Free_item.Size = new System.Drawing.Size(19, 52);
            this.l_Free_item.TabIndex = 0;
            this.l_Free_item.Text = "自\r\n由\r\n項目";
            this.l_Free_item.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(652, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "サンプル許可";
            // 
            // ch_Sample
            // 
            this.ch_Sample.AutoSize = true;
            this.ch_Sample.Location = new System.Drawing.Point(726, 27);
            this.ch_Sample.Name = "ch_Sample";
            this.ch_Sample.Size = new System.Drawing.Size(48, 16);
            this.ch_Sample.TabIndex = 22;
            this.ch_Sample.Text = "許可";
            this.ch_Sample.UseVisualStyleBackColor = true;
            // 
            // da_Customer_wedding_anniversary
            // 
            this.da_Customer_wedding_anniversary.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.da_Customer_wedding_anniversary.Location = new System.Drawing.Point(514, 25);
            this.da_Customer_wedding_anniversary.Name = "da_Customer_wedding_anniversary";
            this.da_Customer_wedding_anniversary.Size = new System.Drawing.Size(129, 19);
            this.da_Customer_wedding_anniversary.TabIndex = 21;
            // 
            // l_Wedding_anniversary
            // 
            this.l_Wedding_anniversary.AutoSize = true;
            this.l_Wedding_anniversary.Location = new System.Drawing.Point(442, 30);
            this.l_Wedding_anniversary.Name = "l_Wedding_anniversary";
            this.l_Wedding_anniversary.Size = new System.Drawing.Size(65, 12);
            this.l_Wedding_anniversary.TabIndex = 0;
            this.l_Wedding_anniversary.Text = "結婚記念日";
            // 
            // co_Visit_motive
            // 
            this.co_Visit_motive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.co_Visit_motive.FormattingEnabled = true;
            this.co_Visit_motive.ItemHeight = 12;
            this.co_Visit_motive.Location = new System.Drawing.Point(514, 5);
            this.co_Visit_motive.Name = "co_Visit_motive";
            this.co_Visit_motive.Size = new System.Drawing.Size(264, 20);
            this.co_Visit_motive.TabIndex = 20;
            // 
            // l_Visit_motive
            // 
            this.l_Visit_motive.AutoSize = true;
            this.l_Visit_motive.Location = new System.Drawing.Point(440, 9);
            this.l_Visit_motive.Name = "l_Visit_motive";
            this.l_Visit_motive.Size = new System.Drawing.Size(53, 12);
            this.l_Visit_motive.TabIndex = 0;
            this.l_Visit_motive.Text = "来店動機";
            // 
            // t_Fax
            // 
            this.t_Fax.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.t_Fax.Location = new System.Drawing.Point(319, 113);
            this.t_Fax.Name = "t_Fax";
            this.t_Fax.Size = new System.Drawing.Size(124, 19);
            this.t_Fax.TabIndex = 18;
            // 
            // l_Fax
            // 
            this.l_Fax.AutoSize = true;
            this.l_Fax.Location = new System.Drawing.Point(260, 116);
            this.l_Fax.Name = "l_Fax";
            this.l_Fax.Size = new System.Drawing.Size(27, 12);
            this.l_Fax.TabIndex = 0;
            this.l_Fax.Text = "FAX";
            this.l_Fax.Click += new System.EventHandler(this.l_Fax_Click);
            // 
            // t_Phone_number3
            // 
            this.t_Phone_number3.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.t_Phone_number3.Location = new System.Drawing.Point(319, 94);
            this.t_Phone_number3.Name = "t_Phone_number3";
            this.t_Phone_number3.Size = new System.Drawing.Size(124, 19);
            this.t_Phone_number3.TabIndex = 17;
            // 
            // l_Phone_number3
            // 
            this.l_Phone_number3.AutoSize = true;
            this.l_Phone_number3.Location = new System.Drawing.Point(260, 99);
            this.l_Phone_number3.Name = "l_Phone_number3";
            this.l_Phone_number3.Size = new System.Drawing.Size(59, 12);
            this.l_Phone_number3.TabIndex = 0;
            this.l_Phone_number3.Text = "電話番号3";
            // 
            // t_Phone_number2
            // 
            this.t_Phone_number2.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.t_Phone_number2.Location = new System.Drawing.Point(130, 113);
            this.t_Phone_number2.Name = "t_Phone_number2";
            this.t_Phone_number2.Size = new System.Drawing.Size(124, 19);
            this.t_Phone_number2.TabIndex = 16;
            // 
            // l_Phone_number2
            // 
            this.l_Phone_number2.AutoSize = true;
            this.l_Phone_number2.Location = new System.Drawing.Point(29, 117);
            this.l_Phone_number2.Name = "l_Phone_number2";
            this.l_Phone_number2.Size = new System.Drawing.Size(59, 12);
            this.l_Phone_number2.TabIndex = 0;
            this.l_Phone_number2.Text = "電話番号2";
            // 
            // t_Phone_number1
            // 
            this.t_Phone_number1.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.t_Phone_number1.Location = new System.Drawing.Point(130, 94);
            this.t_Phone_number1.Name = "t_Phone_number1";
            this.t_Phone_number1.Size = new System.Drawing.Size(124, 19);
            this.t_Phone_number1.TabIndex = 15;
            // 
            // l_Phone_number1
            // 
            this.l_Phone_number1.AutoSize = true;
            this.l_Phone_number1.Location = new System.Drawing.Point(29, 99);
            this.l_Phone_number1.Name = "l_Phone_number1";
            this.l_Phone_number1.Size = new System.Drawing.Size(59, 12);
            this.l_Phone_number1.TabIndex = 0;
            this.l_Phone_number1.Text = "電話番号1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 53);
            this.label2.TabIndex = 0;
            this.label2.Text = "連\r\n絡\r\n先";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // t_Apartment_mansion
            // 
            this.t_Apartment_mansion.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.t_Apartment_mansion.Location = new System.Drawing.Point(130, 75);
            this.t_Apartment_mansion.Name = "t_Apartment_mansion";
            this.t_Apartment_mansion.Size = new System.Drawing.Size(249, 19);
            this.t_Apartment_mansion.TabIndex = 14;
            // 
            // l_Apartment_mansion
            // 
            this.l_Apartment_mansion.AutoSize = true;
            this.l_Apartment_mansion.Location = new System.Drawing.Point(30, 77);
            this.l_Apartment_mansion.Name = "l_Apartment_mansion";
            this.l_Apartment_mansion.Size = new System.Drawing.Size(91, 12);
            this.l_Apartment_mansion.TabIndex = 0;
            this.l_Apartment_mansion.Text = "アパート・マンション";
            // 
            // t_Address2
            // 
            this.t_Address2.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.t_Address2.Location = new System.Drawing.Point(130, 56);
            this.t_Address2.Name = "t_Address2";
            this.t_Address2.Size = new System.Drawing.Size(249, 19);
            this.t_Address2.TabIndex = 13;
            // 
            // l_Address2
            // 
            this.l_Address2.AutoSize = true;
            this.l_Address2.Location = new System.Drawing.Point(29, 60);
            this.l_Address2.Name = "l_Address2";
            this.l_Address2.Size = new System.Drawing.Size(29, 12);
            this.l_Address2.TabIndex = 0;
            this.l_Address2.Text = "番地";
            // 
            // b_Postal_code_search
            // 
            this.b_Postal_code_search.Location = new System.Drawing.Point(289, 17);
            this.b_Postal_code_search.Name = "b_Postal_code_search";
            this.b_Postal_code_search.Size = new System.Drawing.Size(95, 20);
            this.b_Postal_code_search.TabIndex = 11;
            this.b_Postal_code_search.Text = "郵便番号検索";
            this.b_Postal_code_search.UseVisualStyleBackColor = true;
            this.b_Postal_code_search.Click += new System.EventHandler(this.b_Postal_code_search_Click);
            // 
            // b_Address_search
            // 
            this.b_Address_search.Location = new System.Drawing.Point(225, 17);
            this.b_Address_search.Name = "b_Address_search";
            this.b_Address_search.Size = new System.Drawing.Size(64, 20);
            this.b_Address_search.TabIndex = 10;
            this.b_Address_search.Text = "住所検索";
            this.b_Address_search.UseVisualStyleBackColor = true;
            this.b_Address_search.Click += new System.EventHandler(this.b_Address_search_Click);
            // 
            // t_Pref_city_town_village_name
            // 
            this.t_Pref_city_town_village_name.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.t_Pref_city_town_village_name.Location = new System.Drawing.Point(130, 37);
            this.t_Pref_city_town_village_name.Name = "t_Pref_city_town_village_name";
            this.t_Pref_city_town_village_name.Size = new System.Drawing.Size(249, 19);
            this.t_Pref_city_town_village_name.TabIndex = 12;
            // 
            // l_Pref_City_town_village_name
            // 
            this.l_Pref_City_town_village_name.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Pref_City_town_village_name.AutoSize = true;
            this.l_Pref_City_town_village_name.Location = new System.Drawing.Point(29, 42);
            this.l_Pref_City_town_village_name.Name = "l_Pref_City_town_village_name";
            this.l_Pref_City_town_village_name.Size = new System.Drawing.Size(83, 12);
            this.l_Pref_City_town_village_name.TabIndex = 0;
            this.l_Pref_City_town_village_name.Text = "県・市町区村名";
            // 
            // t_Postal_code
            // 
            this.t_Postal_code.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.t_Postal_code.Location = new System.Drawing.Point(130, 17);
            this.t_Postal_code.Name = "t_Postal_code";
            this.t_Postal_code.Size = new System.Drawing.Size(89, 19);
            this.t_Postal_code.TabIndex = 9;
            // 
            // l_Postal_code
            // 
            this.l_Postal_code.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.l_Postal_code.AutoSize = true;
            this.l_Postal_code.Location = new System.Drawing.Point(29, 21);
            this.l_Postal_code.Name = "l_Postal_code";
            this.l_Postal_code.Size = new System.Drawing.Size(53, 12);
            this.l_Postal_code.TabIndex = 0;
            this.l_Postal_code.Text = "郵便番号";
            // 
            // ch_DM_Available
            // 
            this.ch_DM_Available.AutoSize = true;
            this.ch_DM_Available.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ch_DM_Available.Location = new System.Drawing.Point(29, 5);
            this.ch_DM_Available.Name = "ch_DM_Available";
            this.ch_DM_Available.Size = new System.Drawing.Size(77, 16);
            this.ch_DM_Available.TabIndex = 8;
            this.ch_DM_Available.Text = "DM発送可";
            this.ch_DM_Available.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 87);
            this.label1.TabIndex = 0;
            this.label1.Text = "情\r\n報";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ta_Family_Infomation
            // 
            this.ta_Family_Infomation.Controls.Add(this.b_Family_delete);
            this.ta_Family_Infomation.Controls.Add(this.dataGridView1);
            this.ta_Family_Infomation.Location = new System.Drawing.Point(4, 22);
            this.ta_Family_Infomation.Name = "ta_Family_Infomation";
            this.ta_Family_Infomation.Padding = new System.Windows.Forms.Padding(3);
            this.ta_Family_Infomation.Size = new System.Drawing.Size(930, 155);
            this.ta_Family_Infomation.TabIndex = 1;
            this.ta_Family_Infomation.Text = "家族情報";
            this.ta_Family_Infomation.UseVisualStyleBackColor = true;
            // 
            // b_Family_delete
            // 
            this.b_Family_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.b_Family_delete.Location = new System.Drawing.Point(825, 127);
            this.b_Family_delete.Name = "b_Family_delete";
            this.b_Family_delete.Size = new System.Drawing.Size(99, 23);
            this.b_Family_delete.TabIndex = 27;
            this.b_Family_delete.Text = "家族削除";
            this.b_Family_delete.UseVisualStyleBackColor = true;
            this.b_Family_delete.Click += new System.EventHandler(this.b_Family_delete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.続柄,
            this.姓,
            this.名,
            this.姓カナ,
            this.名カナ,
            this.誕生日,
            this.性別,
            this.備考});
            this.dataGridView1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(930, 120);
            this.dataGridView1.TabIndex = 25;
            // 
            // 続柄
            // 
            this.続柄.FillWeight = 70F;
            this.続柄.HeaderText = "続柄";
            this.続柄.Name = "続柄";
            this.続柄.Width = 70;
            // 
            // 姓
            // 
            this.姓.HeaderText = "姓";
            this.姓.Name = "姓";
            // 
            // 名
            // 
            this.名.HeaderText = "名";
            this.名.Name = "名";
            // 
            // 姓カナ
            // 
            this.姓カナ.HeaderText = "姓カナ";
            this.姓カナ.Name = "姓カナ";
            // 
            // 名カナ
            // 
            this.名カナ.HeaderText = "名カナ";
            this.名カナ.Name = "名カナ";
            // 
            // 誕生日
            // 
            this.誕生日.HeaderText = "誕生日";
            this.誕生日.Name = "誕生日";
            // 
            // 性別
            // 
            this.性別.FillWeight = 70F;
            this.性別.HeaderText = "性別";
            this.性別.Name = "性別";
            this.性別.Width = 70;
            // 
            // 備考
            // 
            this.備考.FillWeight = 300F;
            this.備考.HeaderText = "備考";
            this.備考.Name = "備考";
            this.備考.Width = 300;
            // 
            // ta_Menber_Infomation
            // 
            this.ta_Menber_Infomation.Controls.Add(this.co_Membership_type);
            this.ta_Menber_Infomation.Controls.Add(this.l_Membership_type);
            this.ta_Menber_Infomation.Controls.Add(this.co_Rank);
            this.ta_Menber_Infomation.Controls.Add(this.l_Rank);
            this.ta_Menber_Infomation.Controls.Add(this.co_Registered_store);
            this.ta_Menber_Infomation.Controls.Add(this.l_Registered_store);
            this.ta_Menber_Infomation.Controls.Add(this.t_Registration_officer);
            this.ta_Menber_Infomation.Controls.Add(this.l_Registration_officer);
            this.ta_Menber_Infomation.Controls.Add(this.da_Registration_date);
            this.ta_Menber_Infomation.Controls.Add(this.l_Registration_date);
            this.ta_Menber_Infomation.Location = new System.Drawing.Point(4, 22);
            this.ta_Menber_Infomation.Name = "ta_Menber_Infomation";
            this.ta_Menber_Infomation.Size = new System.Drawing.Size(930, 155);
            this.ta_Menber_Infomation.TabIndex = 2;
            this.ta_Menber_Infomation.Text = "会員情報";
            this.ta_Menber_Infomation.UseVisualStyleBackColor = true;
            // 
            // co_Membership_type
            // 
            this.co_Membership_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.co_Membership_type.FormattingEnabled = true;
            this.co_Membership_type.Location = new System.Drawing.Point(91, 110);
            this.co_Membership_type.Name = "co_Membership_type";
            this.co_Membership_type.Size = new System.Drawing.Size(137, 20);
            this.co_Membership_type.TabIndex = 32;
            // 
            // l_Membership_type
            // 
            this.l_Membership_type.AutoSize = true;
            this.l_Membership_type.Location = new System.Drawing.Point(22, 115);
            this.l_Membership_type.Name = "l_Membership_type";
            this.l_Membership_type.Size = new System.Drawing.Size(53, 12);
            this.l_Membership_type.TabIndex = 0;
            this.l_Membership_type.Text = "会員種別";
            // 
            // co_Rank
            // 
            this.co_Rank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.co_Rank.FormattingEnabled = true;
            this.co_Rank.Location = new System.Drawing.Point(91, 90);
            this.co_Rank.Name = "co_Rank";
            this.co_Rank.Size = new System.Drawing.Size(137, 20);
            this.co_Rank.TabIndex = 31;
            // 
            // l_Rank
            // 
            this.l_Rank.AutoSize = true;
            this.l_Rank.Location = new System.Drawing.Point(22, 94);
            this.l_Rank.Name = "l_Rank";
            this.l_Rank.Size = new System.Drawing.Size(30, 12);
            this.l_Rank.TabIndex = 0;
            this.l_Rank.Text = "ランク";
            // 
            // co_Registered_store
            // 
            this.co_Registered_store.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.co_Registered_store.FormattingEnabled = true;
            this.co_Registered_store.ItemHeight = 12;
            this.co_Registered_store.Location = new System.Drawing.Point(91, 46);
            this.co_Registered_store.Name = "co_Registered_store";
            this.co_Registered_store.Size = new System.Drawing.Size(137, 20);
            this.co_Registered_store.TabIndex = 30;
            // 
            // l_Registered_store
            // 
            this.l_Registered_store.AutoSize = true;
            this.l_Registered_store.Location = new System.Drawing.Point(17, 50);
            this.l_Registered_store.Name = "l_Registered_store";
            this.l_Registered_store.Size = new System.Drawing.Size(53, 12);
            this.l_Registered_store.TabIndex = 0;
            this.l_Registered_store.Text = "登録店舗";
            // 
            // t_Registration_officer
            // 
            this.t_Registration_officer.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.t_Registration_officer.Location = new System.Drawing.Point(91, 27);
            this.t_Registration_officer.Name = "t_Registration_officer";
            this.t_Registration_officer.Size = new System.Drawing.Size(137, 19);
            this.t_Registration_officer.TabIndex = 29;
            // 
            // l_Registration_officer
            // 
            this.l_Registration_officer.AutoSize = true;
            this.l_Registration_officer.Location = new System.Drawing.Point(17, 31);
            this.l_Registration_officer.Name = "l_Registration_officer";
            this.l_Registration_officer.Size = new System.Drawing.Size(65, 12);
            this.l_Registration_officer.TabIndex = 0;
            this.l_Registration_officer.Text = "登録担当者";
            // 
            // da_Registration_date
            // 
            this.da_Registration_date.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.da_Registration_date.Location = new System.Drawing.Point(91, 8);
            this.da_Registration_date.Name = "da_Registration_date";
            this.da_Registration_date.Size = new System.Drawing.Size(137, 19);
            this.da_Registration_date.TabIndex = 28;
            // 
            // l_Registration_date
            // 
            this.l_Registration_date.AutoSize = true;
            this.l_Registration_date.Location = new System.Drawing.Point(17, 13);
            this.l_Registration_date.Name = "l_Registration_date";
            this.l_Registration_date.Size = new System.Drawing.Size(41, 12);
            this.l_Registration_date.TabIndex = 0;
            this.l_Registration_date.Text = "登録日";
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.tabControl2, 31);
            this.tabControl2.Controls.Add(this.ta_Reservation_information);
            this.tabControl2.Controls.Add(this.ta_Exchange_information);
            this.tabControl2.Location = new System.Drawing.Point(3, 309);
            this.tabControl2.Name = "tabControl2";
            this.tableLayoutPanel2.SetRowSpan(this.tabControl2, 7);
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(938, 113);
            this.tabControl2.TabIndex = 33;
            // 
            // ta_Reservation_information
            // 
            this.ta_Reservation_information.Controls.Add(this.dataGridView2);
            this.ta_Reservation_information.Location = new System.Drawing.Point(4, 22);
            this.ta_Reservation_information.Name = "ta_Reservation_information";
            this.ta_Reservation_information.Padding = new System.Windows.Forms.Padding(3);
            this.ta_Reservation_information.Size = new System.Drawing.Size(930, 87);
            this.ta_Reservation_information.TabIndex = 0;
            this.ta_Reservation_information.Text = "予約情報";
            this.ta_Reservation_information.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.d_Reservation_date,
            this.d_Reservation_store,
            this.d_Reservation_start_time_end_time,
            this.d_Reserved_facility_name,
            this.d_Reserved_name,
            this.d_Reserved_sex,
            this.d_Reserved_shooting_purpose});
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 21;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(930, 87);
            this.dataGridView2.TabIndex = 34;
            // 
            // d_Reservation_date
            // 
            this.d_Reservation_date.HeaderText = "予約年月日";
            this.d_Reservation_date.Name = "d_Reservation_date";
            this.d_Reservation_date.Width = 200;
            // 
            // d_Reservation_store
            // 
            this.d_Reservation_store.HeaderText = "店舗名称";
            this.d_Reservation_store.Name = "d_Reservation_store";
            this.d_Reservation_store.Width = 150;
            // 
            // d_Reservation_start_time_end_time
            // 
            this.d_Reservation_start_time_end_time.HeaderText = "予約開始時分　予約終了時分";
            this.d_Reservation_start_time_end_time.Name = "d_Reservation_start_time_end_time";
            this.d_Reservation_start_time_end_time.Width = 250;
            // 
            // d_Reserved_facility_name
            // 
            this.d_Reserved_facility_name.HeaderText = "施設名";
            this.d_Reserved_facility_name.Name = "d_Reserved_facility_name";
            // 
            // d_Reserved_name
            // 
            this.d_Reserved_name.HeaderText = "お客様名";
            this.d_Reserved_name.Name = "d_Reserved_name";
            // 
            // d_Reserved_sex
            // 
            this.d_Reserved_sex.HeaderText = "性別";
            this.d_Reserved_sex.Name = "d_Reserved_sex";
            this.d_Reserved_sex.Width = 70;
            // 
            // d_Reserved_shooting_purpose
            // 
            this.d_Reserved_shooting_purpose.HeaderText = "撮影目的";
            this.d_Reserved_shooting_purpose.Name = "d_Reserved_shooting_purpose";
            this.d_Reserved_shooting_purpose.Width = 200;
            // 
            // ta_Exchange_information
            // 
            this.ta_Exchange_information.Controls.Add(this.dataGridView4);
            this.ta_Exchange_information.Location = new System.Drawing.Point(4, 22);
            this.ta_Exchange_information.Name = "ta_Exchange_information";
            this.ta_Exchange_information.Padding = new System.Windows.Forms.Padding(3);
            this.ta_Exchange_information.Size = new System.Drawing.Size(930, 87);
            this.ta_Exchange_information.TabIndex = 2;
            this.ta_Exchange_information.Text = "対応履歴";
            this.ta_Exchange_information.UseVisualStyleBackColor = true;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.AllowUserToOrderColumns = true;
            this.dataGridView4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.d_Exchange_receipt_date_hour_minute,
            this.d_Exchange_receiving_store,
            this.d_Exchage_corresponding_clerk,
            this.d_Exchage_customer_name,
            this.d_Exchange_status,
            this.d_memo});
            this.dataGridView4.Location = new System.Drawing.Point(0, 0);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowHeadersVisible = false;
            this.dataGridView4.RowTemplate.Height = 21;
            this.dataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView4.Size = new System.Drawing.Size(934, 87);
            this.dataGridView4.TabIndex = 36;
            // 
            // d_Exchange_receipt_date_hour_minute
            // 
            this.d_Exchange_receipt_date_hour_minute.HeaderText = "受付年月日　時分";
            this.d_Exchange_receipt_date_hour_minute.Name = "d_Exchange_receipt_date_hour_minute";
            this.d_Exchange_receipt_date_hour_minute.Width = 200;
            // 
            // d_Exchange_receiving_store
            // 
            this.d_Exchange_receiving_store.HeaderText = "受取店舗";
            this.d_Exchange_receiving_store.Name = "d_Exchange_receiving_store";
            this.d_Exchange_receiving_store.Width = 120;
            // 
            // d_Exchage_corresponding_clerk
            // 
            this.d_Exchage_corresponding_clerk.HeaderText = "対応店員";
            this.d_Exchage_corresponding_clerk.Name = "d_Exchage_corresponding_clerk";
            this.d_Exchage_corresponding_clerk.Width = 120;
            // 
            // d_Exchage_customer_name
            // 
            this.d_Exchage_customer_name.HeaderText = "顧客名";
            this.d_Exchage_customer_name.Name = "d_Exchage_customer_name";
            this.d_Exchage_customer_name.Width = 120;
            // 
            // d_Exchange_status
            // 
            this.d_Exchange_status.HeaderText = "ステータス";
            this.d_Exchange_status.Name = "d_Exchange_status";
            this.d_Exchange_status.Width = 120;
            // 
            // d_memo
            // 
            this.d_memo.HeaderText = "対応内容";
            this.d_memo.Name = "d_memo";
            this.d_memo.Width = 200;
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.listView1, 31);
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(3, 428);
            this.listView1.Name = "listView1";
            this.tableLayoutPanel2.SetRowSpan(this.listView1, 5);
            this.listView1.Size = new System.Drawing.Size(938, 108);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 34;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(110, 110);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // b_Return
            // 
            this.b_Return.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.b_Return.Location = new System.Drawing.Point(868, 555);
            this.b_Return.Name = "b_Return";
            this.b_Return.Size = new System.Drawing.Size(75, 23);
            this.b_Return.TabIndex = 36;
            this.b_Return.Text = "戻る";
            this.b_Return.UseVisualStyleBackColor = true;
            this.b_Return.Click += new System.EventHandler(this.b_Return_Click);
            // 
            // b_touroku
            // 
            this.b_touroku.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.b_touroku.Location = new System.Drawing.Point(773, 555);
            this.b_touroku.Name = "b_touroku";
            this.b_touroku.Size = new System.Drawing.Size(75, 23);
            this.b_touroku.TabIndex = 35;
            this.b_touroku.Text = "登録";
            this.b_touroku.UseVisualStyleBackColor = true;
            this.b_touroku.Click += new System.EventHandler(this.touroku_Click);
            // 
            // b_delete
            // 
            this.b_delete.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.b_delete.Location = new System.Drawing.Point(678, 555);
            this.b_delete.Name = "b_delete";
            this.b_delete.Size = new System.Drawing.Size(75, 23);
            this.b_delete.TabIndex = 34;
            this.b_delete.Text = "削除";
            this.b_delete.UseVisualStyleBackColor = true;
            this.b_delete.Click += new System.EventHandler(this.b_delete_Click);
            // 
            // b_Reception
            // 
            this.b_Reception.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.b_Reception.Location = new System.Drawing.Point(13, 555);
            this.b_Reception.Name = "b_Reception";
            this.b_Reception.Size = new System.Drawing.Size(75, 23);
            this.b_Reception.TabIndex = 33;
            this.b_Reception.Text = "受付登録へ";
            this.b_Reception.UseVisualStyleBackColor = true;
            this.b_Reception.Click += new System.EventHandler(this.b_Reception_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(7, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "氏名";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Customer_information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Customer_information";
            this.Size = new System.Drawing.Size(976, 602);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ta_Customer_Infomation.ResumeLayout(false);
            this.ta_Customer_Infomation.PerformLayout();
            this.ta_Family_Infomation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ta_Menber_Infomation.ResumeLayout(false);
            this.ta_Menber_Infomation.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.ta_Reservation_information.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ta_Exchange_information.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox t_surname;
        private System.Windows.Forms.TextBox t_surname_kana;
        private System.Windows.Forms.Label l_Cutoner_name_rubi;
        private System.Windows.Forms.TextBox t_Customer_code;
        private System.Windows.Forms.Label l_Customer_code;
        private System.Windows.Forms.Button b_customer_search;
        private System.Windows.Forms.Label l_Last_use_store_name;
        private System.Windows.Forms.ComboBox co_Sex;
        private System.Windows.Forms.Label l_Sex;
        private System.Windows.Forms.DateTimePicker da_Birthday;
        private System.Windows.Forms.Label l_Birthday;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ta_Customer_Infomation;
        private System.Windows.Forms.TabPage ta_Family_Infomation;
        private System.Windows.Forms.TabPage ta_Menber_Infomation;
        private System.Windows.Forms.Label l_Fax;
        private System.Windows.Forms.TextBox t_Phone_number3;
        private System.Windows.Forms.Label l_Phone_number3;
        private System.Windows.Forms.TextBox t_Phone_number2;
        private System.Windows.Forms.Label l_Phone_number2;
        private System.Windows.Forms.TextBox t_Phone_number1;
        private System.Windows.Forms.Label l_Phone_number1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox t_Apartment_mansion;
        private System.Windows.Forms.Label l_Apartment_mansion;
        private System.Windows.Forms.TextBox t_Address2;
        private System.Windows.Forms.Label l_Address2;
        private System.Windows.Forms.Button b_Postal_code_search;
        private System.Windows.Forms.Button b_Address_search;
        private System.Windows.Forms.TextBox t_Pref_city_town_village_name;
        private System.Windows.Forms.Label l_Pref_City_town_village_name;
        private System.Windows.Forms.TextBox t_Postal_code;
        private System.Windows.Forms.Label l_Postal_code;
        private System.Windows.Forms.CheckBox ch_DM_Available;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage ta_Reservation_information;
        private System.Windows.Forms.Button b_touroku;
        private System.Windows.Forms.Button b_Return;
        private System.Windows.Forms.ComboBox co_Visit_motive;
        private System.Windows.Forms.Label l_Visit_motive;
        private System.Windows.Forms.TextBox t_Fax;
        private System.Windows.Forms.RichTextBox t_Remark;
        private System.Windows.Forms.Label l_Remark;
        private System.Windows.Forms.TextBox t_Free_item3;
        private System.Windows.Forms.TextBox t_Free_item2;
        private System.Windows.Forms.TextBox t_Free_item1;
        private System.Windows.Forms.Label l_Free_item;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ch_Sample;
        private System.Windows.Forms.DateTimePicker da_Customer_wedding_anniversary;
        private System.Windows.Forms.Label l_Wedding_anniversary;
        private System.Windows.Forms.Button b_Family_delete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label l_Membership_type;
        private System.Windows.Forms.ComboBox co_Rank;
        private System.Windows.Forms.Label l_Rank;
        private System.Windows.Forms.ComboBox co_Registered_store;
        private System.Windows.Forms.Label l_Registered_store;
        private System.Windows.Forms.TextBox t_Registration_officer;
        private System.Windows.Forms.Label l_Registration_officer;
        private System.Windows.Forms.DateTimePicker da_Registration_date;
        private System.Windows.Forms.Label l_Registration_date;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TabPage ta_Exchange_information;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.ComboBox co_Membership_type;
        private System.Windows.Forms.Button b_delete;
        private System.Windows.Forms.Label l_age;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label l_Last_use_store;
        private System.Windows.Forms.Button b_Reception;
        private System.Windows.Forms.TextBox t_mail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox t_name;
        private System.Windows.Forms.TextBox t_name_kana;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_Reservation_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_Reservation_store;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_Reservation_start_time_end_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_Reserved_facility_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_Reserved_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_Reserved_sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_Reserved_shooting_purpose;
        private System.Windows.Forms.DataGridViewTextBoxColumn 続柄;
        private System.Windows.Forms.DataGridViewTextBoxColumn 姓;
        private System.Windows.Forms.DataGridViewTextBoxColumn 名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 姓カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 名カナ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 誕生日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 性別;
        private System.Windows.Forms.DataGridViewTextBoxColumn 備考;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_Exchange_receipt_date_hour_minute;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_Exchange_receiving_store;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_Exchage_corresponding_clerk;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_Exchage_customer_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_Exchange_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_memo;
        private System.Windows.Forms.Label label5;
    }
}
