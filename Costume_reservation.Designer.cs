using System;
using System.Windows.Forms;

namespace 写真館システム
{
    partial class Costume_reservation
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
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.d_renral_result = new System.Windows.Forms.DataGridView();
            this.d_CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.d_costume_image = new System.Windows.Forms.DataGridViewImageColumn();
            this.d_costume_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_cotume_store_rental_store = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_costume_class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_costume_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_costume_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_rental_start_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_rental_start_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_rental_end_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_rental_end_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.d_memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.l_name = new System.Windows.Forms.Label();
            this.t_name = new System.Windows.Forms.TextBox();
            this.l_name_kana = new System.Windows.Forms.Label();
            this.t_name_kana = new System.Windows.Forms.TextBox();
            this.l_sex2 = new System.Windows.Forms.Label();
            this.d_sex2 = new System.Windows.Forms.ComboBox();
            this.l_birthday2 = new System.Windows.Forms.Label();
            this.dt_birthday = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.d_facility = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.d_Shooting_purpose = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.d_Cancellation_date = new System.Windows.Forms.DateTimePicker();
            this.l_customer_code = new System.Windows.Forms.Label();
            this.d_customer_code = new System.Windows.Forms.Label();
            this.l_customer_name = new System.Windows.Forms.Label();
            this.d_customer_name = new System.Windows.Forms.Label();
            this.l_birthday = new System.Windows.Forms.Label();
            this.d_birthday = new System.Windows.Forms.Label();
            this.l_sex = new System.Windows.Forms.Label();
            this.d_sex = new System.Windows.Forms.Label();
            this.l_customer_postal_code = new System.Windows.Forms.Label();
            this.d_customer_postal_code = new System.Windows.Forms.Label();
            this.l_address1 = new System.Windows.Forms.Label();
            this.d_address1 = new System.Windows.Forms.Label();
            this.l_address2 = new System.Windows.Forms.Label();
            this.d_address2 = new System.Windows.Forms.Label();
            this.l_address3 = new System.Windows.Forms.Label();
            this.d_address3 = new System.Windows.Forms.Label();
            this.l_phone_number = new System.Windows.Forms.Label();
            this.d_phone_number = new System.Windows.Forms.Label();
            this.d_sleeve = new System.Windows.Forms.TextBox();
            this.l_sleeve = new System.Windows.Forms.Label();
            this.d_foot = new System.Windows.Forms.TextBox();
            this.l_footsize = new System.Windows.Forms.Label();
            this.d_height = new System.Windows.Forms.TextBox();
            this.l_tall = new System.Windows.Forms.Label();
            this.b_regist_costume = new System.Windows.Forms.Button();
            this.b_return = new System.Windows.Forms.Button();
            this.b_delete = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.d_renral_result)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.b_regist_costume, 9, 2);
            this.tableLayoutPanel1.Controls.Add(this.b_return, 10, 2);
            this.tableLayoutPanel1.Controls.Add(this.b_delete, 8, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1075, 576);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 30;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 10);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.374013F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.230438F));
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
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.d_renral_result, 0, 11);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 27);
            this.tableLayoutPanel2.Controls.Add(this.l_name, 1, 28);
            this.tableLayoutPanel2.Controls.Add(this.t_name, 3, 28);
            this.tableLayoutPanel2.Controls.Add(this.l_name_kana, 6, 28);
            this.tableLayoutPanel2.Controls.Add(this.t_name_kana, 8, 28);
            this.tableLayoutPanel2.Controls.Add(this.l_sex2, 11, 28);
            this.tableLayoutPanel2.Controls.Add(this.d_sex2, 12, 28);
            this.tableLayoutPanel2.Controls.Add(this.l_birthday2, 14, 28);
            this.tableLayoutPanel2.Controls.Add(this.dt_birthday, 16, 28);
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 29);
            this.tableLayoutPanel2.Controls.Add(this.d_facility, 3, 29);
            this.tableLayoutPanel2.Controls.Add(this.label4, 6, 29);
            this.tableLayoutPanel2.Controls.Add(this.d_Shooting_purpose, 8, 29);
            this.tableLayoutPanel2.Controls.Add(this.label6, 11, 29);
            this.tableLayoutPanel2.Controls.Add(this.d_Cancellation_date, 14, 29);
            this.tableLayoutPanel2.Controls.Add(this.l_customer_code, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.d_customer_code, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.l_customer_name, 8, 1);
            this.tableLayoutPanel2.Controls.Add(this.d_customer_name, 10, 1);
            this.tableLayoutPanel2.Controls.Add(this.l_birthday, 16, 1);
            this.tableLayoutPanel2.Controls.Add(this.d_birthday, 18, 1);
            this.tableLayoutPanel2.Controls.Add(this.l_sex, 23, 1);
            this.tableLayoutPanel2.Controls.Add(this.d_sex, 25, 1);
            this.tableLayoutPanel2.Controls.Add(this.l_customer_postal_code, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.d_customer_postal_code, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.l_address1, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.d_address1, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.l_address2, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.d_address2, 4, 4);
            this.tableLayoutPanel2.Controls.Add(this.l_address3, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.d_address3, 4, 5);
            this.tableLayoutPanel2.Controls.Add(this.l_phone_number, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.d_phone_number, 4, 6);
            this.tableLayoutPanel2.Controls.Add(this.d_sleeve, 28, 28);
            this.tableLayoutPanel2.Controls.Add(this.l_sleeve, 27, 28);
            this.tableLayoutPanel2.Controls.Add(this.d_foot, 25, 28);
            this.tableLayoutPanel2.Controls.Add(this.l_footsize, 23, 28);
            this.tableLayoutPanel2.Controls.Add(this.d_height, 21, 28);
            this.tableLayoutPanel2.Controls.Add(this.l_tall, 20, 28);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1044, 513);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label5
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.label5, 10);
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "■顧客情報";
            // 
            // label1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.label1, 10);
            this.label1.Location = new System.Drawing.Point(3, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 12);
            this.label1.TabIndex = 57;
            this.label1.Text = "■衣装予約";
            // 
            // d_renral_result
            // 
            this.d_renral_result.AllowUserToAddRows = false;
            this.d_renral_result.AllowUserToDeleteRows = false;
            this.d_renral_result.AllowUserToResizeRows = false;
            this.d_renral_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.d_renral_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.d_renral_result.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.d_CheckBox,
            this.d_costume_image,
            this.d_costume_code,
            this.d_cotume_store_rental_store,
            this.d_costume_class,
            this.d_costume_price,
            this.d_costume_name,
            this.d_rental_start_date,
            this.d_rental_start_time,
            this.d_rental_end_date,
            this.d_rental_end_time,
            this.d_memo});
            this.tableLayoutPanel2.SetColumnSpan(this.d_renral_result, 30);
            this.d_renral_result.Location = new System.Drawing.Point(3, 190);
            this.d_renral_result.Name = "d_renral_result";
            this.d_renral_result.RowHeadersWidth = 10;
            this.tableLayoutPanel2.SetRowSpan(this.d_renral_result, 16);
            this.d_renral_result.RowTemplate.Height = 21;
            this.d_renral_result.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.d_renral_result.Size = new System.Drawing.Size(1038, 266);
            this.d_renral_result.TabIndex = 10;
            this.d_renral_result.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.d_renral_result_CellContentClick);
            // 
            // d_CheckBox
            // 
            this.d_CheckBox.HeaderText = "□";
            this.d_CheckBox.Name = "d_CheckBox";
            this.d_CheckBox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.d_CheckBox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.d_CheckBox.Width = 25;
            // 
            // d_costume_image
            // 
            this.d_costume_image.HeaderText = "";
            this.d_costume_image.Name = "d_costume_image";
            this.d_costume_image.ReadOnly = true;
            this.d_costume_image.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.d_costume_image.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.d_costume_image.Width = 150;
            // 
            // d_costume_code
            // 
            this.d_costume_code.HeaderText = "衣装コード";
            this.d_costume_code.Name = "d_costume_code";
            this.d_costume_code.ReadOnly = true;
            // 
            // d_cotume_store_rental_store
            // 
            this.d_cotume_store_rental_store.HeaderText = "店舗／貸出";
            this.d_cotume_store_rental_store.Name = "d_cotume_store_rental_store";
            this.d_cotume_store_rental_store.ReadOnly = true;
            this.d_cotume_store_rental_store.Width = 150;
            // 
            // d_costume_class
            // 
            this.d_costume_class.HeaderText = "分類";
            this.d_costume_class.Name = "d_costume_class";
            this.d_costume_class.ReadOnly = true;
            // 
            // d_costume_price
            // 
            this.d_costume_price.HeaderText = "価格";
            this.d_costume_price.Name = "d_costume_price";
            this.d_costume_price.ReadOnly = true;
            // 
            // d_costume_name
            // 
            this.d_costume_name.HeaderText = "衣装名";
            this.d_costume_name.Name = "d_costume_name";
            this.d_costume_name.ReadOnly = true;
            this.d_costume_name.Width = 150;
            // 
            // d_rental_start_date
            // 
            this.d_rental_start_date.HeaderText = "予約開始年月日";
            this.d_rental_start_date.Name = "d_rental_start_date";
            this.d_rental_start_date.ReadOnly = true;
            this.d_rental_start_date.Width = 150;
            // 
            // d_rental_start_time
            // 
            this.d_rental_start_time.HeaderText = "予約開始時分";
            this.d_rental_start_time.Name = "d_rental_start_time";
            this.d_rental_start_time.ReadOnly = true;
            this.d_rental_start_time.Width = 150;
            // 
            // d_rental_end_date
            // 
            this.d_rental_end_date.HeaderText = "予約終了年月日";
            this.d_rental_end_date.Name = "d_rental_end_date";
            this.d_rental_end_date.ReadOnly = true;
            this.d_rental_end_date.Width = 150;
            // 
            // d_rental_end_time
            // 
            this.d_rental_end_time.HeaderText = "予約終了時分";
            this.d_rental_end_time.Name = "d_rental_end_time";
            this.d_rental_end_time.ReadOnly = true;
            this.d_rental_end_time.Width = 150;
            // 
            // d_memo
            // 
            this.d_memo.HeaderText = "摘要";
            this.d_memo.MaxInputLength = 254;
            this.d_memo.Name = "d_memo";
            this.d_memo.Width = 150;
            // 
            // label2
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.label2, 10);
            this.label2.Location = new System.Drawing.Point(3, 459);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 12);
            this.label2.TabIndex = 58;
            this.label2.Text = "■個別情報";
            // 
            // l_name
            // 
            this.l_name.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_name, 2);
            this.l_name.Location = new System.Drawing.Point(35, 476);
            this.l_name.Margin = new System.Windows.Forms.Padding(0);
            this.l_name.Name = "l_name";
            this.l_name.Size = new System.Drawing.Size(39, 12);
            this.l_name.TabIndex = 59;
            this.l_name.Text = "お名前";
            // 
            // t_name
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.t_name, 3);
            this.t_name.Location = new System.Drawing.Point(102, 476);
            this.t_name.Margin = new System.Windows.Forms.Padding(0);
            this.t_name.Name = "t_name";
            this.t_name.Size = new System.Drawing.Size(102, 19);
            this.t_name.TabIndex = 60;
            // 
            // l_name_kana
            // 
            this.l_name_kana.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_name_kana, 2);
            this.l_name_kana.Location = new System.Drawing.Point(204, 476);
            this.l_name_kana.Margin = new System.Windows.Forms.Padding(0);
            this.l_name_kana.Name = "l_name_kana";
            this.l_name_kana.Size = new System.Drawing.Size(58, 12);
            this.l_name_kana.TabIndex = 61;
            this.l_name_kana.Text = "お名前カナ";
            // 
            // t_name_kana
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.t_name_kana, 3);
            this.t_name_kana.Location = new System.Drawing.Point(272, 476);
            this.t_name_kana.Margin = new System.Windows.Forms.Padding(0);
            this.t_name_kana.Name = "t_name_kana";
            this.t_name_kana.Size = new System.Drawing.Size(102, 19);
            this.t_name_kana.TabIndex = 62;
            // 
            // l_sex2
            // 
            this.l_sex2.AutoSize = true;
            this.l_sex2.Location = new System.Drawing.Point(376, 476);
            this.l_sex2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_sex2.Name = "l_sex2";
            this.l_sex2.Size = new System.Drawing.Size(29, 12);
            this.l_sex2.TabIndex = 63;
            this.l_sex2.Text = "性別";
            // 
            // d_sex2
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_sex2, 2);
            this.d_sex2.FormattingEnabled = true;
            this.d_sex2.Location = new System.Drawing.Point(408, 476);
            this.d_sex2.Margin = new System.Windows.Forms.Padding(0);
            this.d_sex2.Name = "d_sex2";
            this.d_sex2.Size = new System.Drawing.Size(68, 20);
            this.d_sex2.TabIndex = 64;
            // 
            // l_birthday2
            // 
            this.l_birthday2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_birthday2, 2);
            this.l_birthday2.Location = new System.Drawing.Point(478, 476);
            this.l_birthday2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_birthday2.Name = "l_birthday2";
            this.l_birthday2.Size = new System.Drawing.Size(53, 12);
            this.l_birthday2.TabIndex = 65;
            this.l_birthday2.Text = "生年月日";
            // 
            // dt_birthday
            // 
            this.dt_birthday.Checked = false;
            this.tableLayoutPanel2.SetColumnSpan(this.dt_birthday, 4);
            this.dt_birthday.Location = new System.Drawing.Point(544, 476);
            this.dt_birthday.Margin = new System.Windows.Forms.Padding(0);
            this.dt_birthday.Name = "dt_birthday";
            this.dt_birthday.ShowCheckBox = true;
            this.dt_birthday.Size = new System.Drawing.Size(136, 19);
            this.dt_birthday.TabIndex = 66;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label3, 2);
            this.label3.Location = new System.Drawing.Point(35, 493);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 59;
            this.label3.Text = "施設名";
            // 
            // d_facility
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_facility, 3);
            this.d_facility.Location = new System.Drawing.Point(102, 493);
            this.d_facility.Margin = new System.Windows.Forms.Padding(0);
            this.d_facility.Name = "d_facility";
            this.d_facility.Size = new System.Drawing.Size(102, 19);
            this.d_facility.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label4, 2);
            this.label4.Location = new System.Drawing.Point(204, 493);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 61;
            this.label4.Text = "撮影目的";
            // 
            // d_Shooting_purpose
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_Shooting_purpose, 3);
            this.d_Shooting_purpose.FormattingEnabled = true;
            this.d_Shooting_purpose.Location = new System.Drawing.Point(272, 493);
            this.d_Shooting_purpose.Margin = new System.Windows.Forms.Padding(0);
            this.d_Shooting_purpose.Name = "d_Shooting_purpose";
            this.d_Shooting_purpose.Size = new System.Drawing.Size(102, 20);
            this.d_Shooting_purpose.TabIndex = 74;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label6, 3);
            this.label6.Location = new System.Drawing.Point(376, 493);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 63;
            this.label6.Text = "中止年月日";
            this.label6.Visible = false;
            // 
            // d_Cancellation_date
            // 
            this.d_Cancellation_date.Checked = false;
            this.tableLayoutPanel2.SetColumnSpan(this.d_Cancellation_date, 4);
            this.d_Cancellation_date.Location = new System.Drawing.Point(476, 493);
            this.d_Cancellation_date.Margin = new System.Windows.Forms.Padding(0);
            this.d_Cancellation_date.Name = "d_Cancellation_date";
            this.d_Cancellation_date.ShowCheckBox = true;
            this.d_Cancellation_date.Size = new System.Drawing.Size(136, 19);
            this.d_Cancellation_date.TabIndex = 75;
            this.d_Cancellation_date.Visible = false;
            // 
            // l_customer_code
            // 
            this.l_customer_code.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_customer_code, 3);
            this.l_customer_code.Location = new System.Drawing.Point(38, 17);
            this.l_customer_code.Name = "l_customer_code";
            this.l_customer_code.Size = new System.Drawing.Size(56, 12);
            this.l_customer_code.TabIndex = 35;
            this.l_customer_code.Text = "顧客コード";
            // 
            // d_customer_code
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_customer_code, 4);
            this.d_customer_code.Location = new System.Drawing.Point(139, 17);
            this.d_customer_code.Name = "d_customer_code";
            this.d_customer_code.Size = new System.Drawing.Size(120, 17);
            this.d_customer_code.TabIndex = 36;
            // 
            // l_customer_name
            // 
            this.l_customer_name.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_customer_name, 2);
            this.l_customer_name.Location = new System.Drawing.Point(275, 17);
            this.l_customer_name.Name = "l_customer_name";
            this.l_customer_name.Size = new System.Drawing.Size(51, 12);
            this.l_customer_name.TabIndex = 37;
            this.l_customer_name.Text = "お客様名";
            // 
            // d_customer_name
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_customer_name, 6);
            this.d_customer_name.Location = new System.Drawing.Point(343, 17);
            this.d_customer_name.Name = "d_customer_name";
            this.d_customer_name.Size = new System.Drawing.Size(149, 17);
            this.d_customer_name.TabIndex = 39;
            // 
            // l_birthday
            // 
            this.l_birthday.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_birthday, 2);
            this.l_birthday.Location = new System.Drawing.Point(547, 17);
            this.l_birthday.Name = "l_birthday";
            this.l_birthday.Size = new System.Drawing.Size(53, 12);
            this.l_birthday.TabIndex = 41;
            this.l_birthday.Text = "生年月日";
            // 
            // d_birthday
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_birthday, 4);
            this.d_birthday.Location = new System.Drawing.Point(615, 17);
            this.d_birthday.Name = "d_birthday";
            this.d_birthday.Size = new System.Drawing.Size(130, 17);
            this.d_birthday.TabIndex = 0;
            // 
            // l_sex
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.l_sex, 2);
            this.l_sex.Location = new System.Drawing.Point(785, 17);
            this.l_sex.Name = "l_sex";
            this.l_sex.Size = new System.Drawing.Size(35, 12);
            this.l_sex.TabIndex = 0;
            this.l_sex.Text = "性別";
            // 
            // d_sex
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_sex, 4);
            this.d_sex.Location = new System.Drawing.Point(853, 17);
            this.d_sex.Name = "d_sex";
            this.d_sex.Size = new System.Drawing.Size(130, 17);
            this.d_sex.TabIndex = 43;
            // 
            // l_customer_postal_code
            // 
            this.l_customer_postal_code.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_customer_postal_code, 2);
            this.l_customer_postal_code.Location = new System.Drawing.Point(38, 34);
            this.l_customer_postal_code.Name = "l_customer_postal_code";
            this.l_customer_postal_code.Size = new System.Drawing.Size(53, 12);
            this.l_customer_postal_code.TabIndex = 45;
            this.l_customer_postal_code.Text = "郵便番号";
            // 
            // d_customer_postal_code
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_customer_postal_code, 14);
            this.d_customer_postal_code.Location = new System.Drawing.Point(139, 34);
            this.d_customer_postal_code.Name = "d_customer_postal_code";
            this.d_customer_postal_code.Size = new System.Drawing.Size(470, 17);
            this.d_customer_postal_code.TabIndex = 46;
            // 
            // l_address1
            // 
            this.l_address1.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_address1, 2);
            this.l_address1.Location = new System.Drawing.Point(38, 51);
            this.l_address1.Name = "l_address1";
            this.l_address1.Size = new System.Drawing.Size(59, 12);
            this.l_address1.TabIndex = 47;
            this.l_address1.Text = "県・市町名";
            // 
            // d_address1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_address1, 14);
            this.d_address1.Location = new System.Drawing.Point(139, 51);
            this.d_address1.Name = "d_address1";
            this.d_address1.Size = new System.Drawing.Size(470, 17);
            this.d_address1.TabIndex = 48;
            // 
            // l_address2
            // 
            this.l_address2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_address2, 2);
            this.l_address2.Location = new System.Drawing.Point(38, 68);
            this.l_address2.Name = "l_address2";
            this.l_address2.Size = new System.Drawing.Size(29, 12);
            this.l_address2.TabIndex = 50;
            this.l_address2.Text = "番地";
            // 
            // d_address2
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_address2, 14);
            this.d_address2.Location = new System.Drawing.Point(139, 68);
            this.d_address2.Name = "d_address2";
            this.d_address2.Size = new System.Drawing.Size(470, 17);
            this.d_address2.TabIndex = 51;
            // 
            // l_address3
            // 
            this.l_address3.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_address3, 3);
            this.l_address3.Location = new System.Drawing.Point(38, 85);
            this.l_address3.Name = "l_address3";
            this.l_address3.Size = new System.Drawing.Size(91, 12);
            this.l_address3.TabIndex = 52;
            this.l_address3.Text = "アパート・マンション";
            // 
            // d_address3
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_address3, 14);
            this.d_address3.Location = new System.Drawing.Point(139, 85);
            this.d_address3.Name = "d_address3";
            this.d_address3.Size = new System.Drawing.Size(470, 17);
            this.d_address3.TabIndex = 53;
            // 
            // l_phone_number
            // 
            this.l_phone_number.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_phone_number, 2);
            this.l_phone_number.Location = new System.Drawing.Point(38, 102);
            this.l_phone_number.Name = "l_phone_number";
            this.l_phone_number.Size = new System.Drawing.Size(53, 12);
            this.l_phone_number.TabIndex = 54;
            this.l_phone_number.Text = "電話番号";
            // 
            // d_phone_number
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_phone_number, 14);
            this.d_phone_number.Location = new System.Drawing.Point(139, 102);
            this.d_phone_number.Name = "d_phone_number";
            this.d_phone_number.Size = new System.Drawing.Size(470, 17);
            this.d_phone_number.TabIndex = 55;
            // 
            // d_sleeve
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_sleeve, 2);
            this.d_sleeve.Location = new System.Drawing.Point(952, 476);
            this.d_sleeve.Margin = new System.Windows.Forms.Padding(0);
            this.d_sleeve.Name = "d_sleeve";
            this.d_sleeve.Size = new System.Drawing.Size(68, 19);
            this.d_sleeve.TabIndex = 72;
            // 
            // l_sleeve
            // 
            this.l_sleeve.AutoSize = true;
            this.l_sleeve.Location = new System.Drawing.Point(920, 476);
            this.l_sleeve.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_sleeve.Name = "l_sleeve";
            this.l_sleeve.Size = new System.Drawing.Size(29, 12);
            this.l_sleeve.TabIndex = 71;
            this.l_sleeve.Text = "裄丈";
            // 
            // d_foot
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_foot, 2);
            this.d_foot.Location = new System.Drawing.Point(850, 476);
            this.d_foot.Margin = new System.Windows.Forms.Padding(0);
            this.d_foot.Name = "d_foot";
            this.d_foot.Size = new System.Drawing.Size(68, 19);
            this.d_foot.TabIndex = 70;
            // 
            // l_footsize
            // 
            this.l_footsize.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_footsize, 2);
            this.l_footsize.Location = new System.Drawing.Point(784, 476);
            this.l_footsize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_footsize.Name = "l_footsize";
            this.l_footsize.Size = new System.Drawing.Size(46, 12);
            this.l_footsize.TabIndex = 69;
            this.l_footsize.Text = "足サイズ";
            // 
            // d_height
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_height, 2);
            this.d_height.Location = new System.Drawing.Point(714, 476);
            this.d_height.Margin = new System.Windows.Forms.Padding(0);
            this.d_height.Name = "d_height";
            this.d_height.Size = new System.Drawing.Size(68, 19);
            this.d_height.TabIndex = 68;
            // 
            // l_tall
            // 
            this.l_tall.AutoSize = true;
            this.l_tall.Location = new System.Drawing.Point(682, 476);
            this.l_tall.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.l_tall.Name = "l_tall";
            this.l_tall.Size = new System.Drawing.Size(29, 12);
            this.l_tall.TabIndex = 67;
            this.l_tall.Text = "身長";
            // 
            // b_regist_costume
            // 
            this.b_regist_costume.Location = new System.Drawing.Point(853, 529);
            this.b_regist_costume.Name = "b_regist_costume";
            this.b_regist_costume.Size = new System.Drawing.Size(89, 23);
            this.b_regist_costume.TabIndex = 15;
            this.b_regist_costume.Text = "衣装予約";
            this.b_regist_costume.UseVisualStyleBackColor = true;
            this.b_regist_costume.Click += new System.EventHandler(this.b_regist_Click);
            // 
            // b_return
            // 
            this.b_return.Location = new System.Drawing.Point(958, 529);
            this.b_return.Name = "b_return";
            this.b_return.Size = new System.Drawing.Size(89, 23);
            this.b_return.TabIndex = 16;
            this.b_return.Text = "戻る";
            this.b_return.UseVisualStyleBackColor = true;
            this.b_return.Click += new System.EventHandler(this.b_return_Click);
            // 
            // b_delete
            // 
            this.b_delete.Location = new System.Drawing.Point(748, 529);
            this.b_delete.Name = "b_delete";
            this.b_delete.Size = new System.Drawing.Size(89, 23);
            this.b_delete.TabIndex = 14;
            this.b_delete.Text = "削除";
            this.b_delete.UseVisualStyleBackColor = true;
            this.b_delete.Click += new System.EventHandler(this.b_delete_Click);
            // 
            // Costume_reservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Costume_reservation";
            this.Size = new System.Drawing.Size(1078, 576);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.d_renral_result)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button b_regist_costume;
        private System.Windows.Forms.Button b_return;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label l_customer_code;
        private System.Windows.Forms.Label d_customer_code;
        private System.Windows.Forms.Label l_customer_name;
        private System.Windows.Forms.Label d_customer_name;
        private System.Windows.Forms.Label l_birthday;
        private System.Windows.Forms.Label d_birthday;
        private System.Windows.Forms.Label l_sex;
        private System.Windows.Forms.Label d_sex;
        private System.Windows.Forms.Label l_customer_postal_code;
        private System.Windows.Forms.Label l_address1;
        private System.Windows.Forms.Label d_address1;
        private System.Windows.Forms.Label d_customer_postal_code;
        private System.Windows.Forms.Label l_address2;
        private System.Windows.Forms.Label d_address2;
        private System.Windows.Forms.Label l_address3;
        private System.Windows.Forms.Label d_address3;
        private System.Windows.Forms.Label l_phone_number;
        private System.Windows.Forms.Label d_phone_number;
        private System.Windows.Forms.DataGridView d_renral_result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_delete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label l_name;
        private System.Windows.Forms.TextBox t_name;
        private System.Windows.Forms.Label l_name_kana;
        private System.Windows.Forms.TextBox t_name_kana;
        private System.Windows.Forms.Label l_sex2;
        private System.Windows.Forms.ComboBox d_sex2;
        private System.Windows.Forms.Label l_birthday2;
        private System.Windows.Forms.DateTimePicker dt_birthday;
        private System.Windows.Forms.Label l_tall;
        private System.Windows.Forms.TextBox d_height;
        private System.Windows.Forms.Label l_footsize;
        private System.Windows.Forms.TextBox d_foot;
        private System.Windows.Forms.Label l_sleeve;
        private System.Windows.Forms.TextBox d_sleeve;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox d_facility;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox d_Shooting_purpose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker d_Cancellation_date;
        private System.Windows.Forms.DataGridViewCheckBoxColumn d_CheckBox;
        private System.Windows.Forms.DataGridViewImageColumn d_costume_image;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_costume_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_cotume_store_rental_store;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_costume_class;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_costume_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_costume_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_rental_start_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_rental_start_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_rental_end_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_rental_end_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn d_memo;
    }
}
