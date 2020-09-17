using System;
using C1.C1Schedule;
using C1.Win.C1Schedule;

namespace 写真館システム
{
    partial class Reservation_timetable
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
            this.components = new System.ComponentModel.Container();
            C1.C1Schedule.Printing.PrintStyle printStyle1 = new C1.C1Schedule.Printing.PrintStyle();
            C1.C1Schedule.Printing.PrintStyle printStyle2 = new C1.C1Schedule.Printing.PrintStyle();
            C1.C1Schedule.Printing.PrintStyle printStyle3 = new C1.C1Schedule.Printing.PrintStyle();
            C1.C1Schedule.Printing.PrintStyle printStyle4 = new C1.C1Schedule.Printing.PrintStyle();
            C1.C1Schedule.Printing.PrintStyle printStyle5 = new C1.C1Schedule.Printing.PrintStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.b_return = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.d_tenpomei = new System.Windows.Forms.ComboBox();
            this.d_osirase = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabList = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.d_yoyaku = new System.Windows.Forms.DataGridView();
            this.予約一覧_施設名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.予約一覧_名前 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.予約一覧_性別 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.予約一覧_来店日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.予約一覧_予約時間 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.予約一覧_撮影目的 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.d_isyou_yoyaku = new System.Windows.Forms.DataGridView();
            this.衣装予約一覧_衣装コード = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.衣装予約一覧_施設名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.衣装予約一覧_衣装予約時間 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.衣装予約一覧_お客様名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.衣装予約一覧_性別 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.衣装予約一覧_摘要 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.d_sukejuru = new System.Windows.Forms.DataGridView();
            this.スケジュール一覧_時刻 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.スケジュール一覧_内容 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.l_year = new System.Windows.Forms.Label();
            this.b_next = new System.Windows.Forms.LinkLabel();
            this.b_prev = new System.Windows.Forms.LinkLabel();
            this.l_date = new System.Windows.Forms.Label();
            this.c1Schedule1 = new C1.Win.C1Schedule.C1Schedule();
            this.reservation_timetableDataSet = new 写真館システム.Asset.Reservation_timetableDataSet();
            this.c1Calendar1 = new C1.Win.C1Schedule.C1Calendar();
            this.label1 = new System.Windows.Forms.Label();
            this.b_print = new System.Windows.Forms.Button();
            this.reservationtimetableDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contactsTableAdapter = new 写真館システム.Asset.Reservation_timetableDataSetTableAdapters.ContactsTableAdapter();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabList.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.d_yoyaku)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.d_isyou_yoyaku)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.d_sukejuru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.AppointmentStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.CategoryStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.ContactStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.LabelStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.OwnerStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.ResourceStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.StatusStorage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservation_timetableDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Calendar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservationtimetableDataSetBindingSource)).BeginInit();
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel1.Controls.Add(this.b_return, 10, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.b_print, 9, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(976, 602);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // b_return
            // 
            this.b_return.Location = new System.Drawing.Point(868, 555);
            this.b_return.Name = "b_return";
            this.b_return.Size = new System.Drawing.Size(75, 23);
            this.b_return.TabIndex = 1;
            this.b_return.Text = "戻る";
            this.b_return.UseVisualStyleBackColor = true;
            this.b_return.Click += new System.EventHandler(this.b_return_Click);
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
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333333F));
            this.tableLayoutPanel2.Controls.Add(this.d_tenpomei, 9, 1);
            this.tableLayoutPanel2.Controls.Add(this.d_osirase, 17, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 15, 1);
            this.tableLayoutPanel2.Controls.Add(this.tabList, 0, 23);
            this.tableLayoutPanel2.Controls.Add(this.l_year, 9, 3);
            this.tableLayoutPanel2.Controls.Add(this.b_next, 8, 3);
            this.tableLayoutPanel2.Controls.Add(this.b_prev, 7, 3);
            this.tableLayoutPanel2.Controls.Add(this.l_date, 9, 5);
            this.tableLayoutPanel2.Controls.Add(this.c1Schedule1, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.c1Calendar1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 7, 1);
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
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(944, 536);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // d_tenpomei
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_tenpomei, 5);
            this.d_tenpomei.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.d_tenpomei.FormattingEnabled = true;
            this.d_tenpomei.Location = new System.Drawing.Point(282, 20);
            this.d_tenpomei.Name = "d_tenpomei";
            this.d_tenpomei.Size = new System.Drawing.Size(147, 20);
            this.d_tenpomei.TabIndex = 4;
            this.d_tenpomei.SelectedValueChanged += new System.EventHandler(this.d_tenpomei_SelectedValueChanged);
            // 
            // d_osirase
            // 
            this.d_osirase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.d_osirase, 13);
            this.d_osirase.Enabled = false;
            this.d_osirase.Location = new System.Drawing.Point(530, 20);
            this.d_osirase.Multiline = true;
            this.d_osirase.Name = "d_osirase";
            this.tableLayoutPanel2.SetRowSpan(this.d_osirase, 3);
            this.d_osirase.Size = new System.Drawing.Size(411, 45);
            this.d_osirase.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label4, 2);
            this.label4.Location = new System.Drawing.Point(479, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "お知らせ";
            // 
            // tabList
            // 
            this.tabList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.SetColumnSpan(this.tabList, 30);
            this.tabList.Controls.Add(this.tabPage1);
            this.tabList.Controls.Add(this.tabPage2);
            this.tabList.Controls.Add(this.tabPage3);
            this.tabList.Location = new System.Drawing.Point(3, 394);
            this.tabList.Name = "tabList";
            this.tableLayoutPanel2.SetRowSpan(this.tabList, 7);
            this.tabList.SelectedIndex = 0;
            this.tabList.Size = new System.Drawing.Size(938, 139);
            this.tabList.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.d_yoyaku);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(930, 113);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "予約一覧";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // d_yoyaku
            // 
            this.d_yoyaku.AllowUserToAddRows = false;
            this.d_yoyaku.AllowUserToDeleteRows = false;
            this.d_yoyaku.AllowUserToOrderColumns = true;
            this.d_yoyaku.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.d_yoyaku.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.d_yoyaku.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.予約一覧_施設名,
            this.予約一覧_名前,
            this.予約一覧_性別,
            this.予約一覧_来店日,
            this.予約一覧_予約時間,
            this.予約一覧_撮影目的});
            this.d_yoyaku.Location = new System.Drawing.Point(0, 0);
            this.d_yoyaku.Name = "d_yoyaku";
            this.d_yoyaku.RowHeadersVisible = false;
            this.d_yoyaku.RowTemplate.Height = 21;
            this.d_yoyaku.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.d_yoyaku.Size = new System.Drawing.Size(930, 200);
            this.d_yoyaku.TabIndex = 0;
            // 
            // 予約一覧_施設名
            // 
            this.予約一覧_施設名.HeaderText = "施設名";
            this.予約一覧_施設名.Name = "予約一覧_施設名";
            // 
            // 予約一覧_名前
            // 
            this.予約一覧_名前.HeaderText = "名前";
            this.予約一覧_名前.Name = "予約一覧_名前";
            // 
            // 予約一覧_性別
            // 
            this.予約一覧_性別.HeaderText = "性別";
            this.予約一覧_性別.Name = "予約一覧_性別";
            // 
            // 予約一覧_来店日
            // 
            this.予約一覧_来店日.HeaderText = "来店日";
            this.予約一覧_来店日.Name = "予約一覧_来店日";
            // 
            // 予約一覧_予約時間
            // 
            this.予約一覧_予約時間.FillWeight = 250F;
            this.予約一覧_予約時間.HeaderText = "予約時間";
            this.予約一覧_予約時間.Name = "予約一覧_予約時間";
            this.予約一覧_予約時間.Width = 250;
            // 
            // 予約一覧_撮影目的
            // 
            this.予約一覧_撮影目的.HeaderText = "撮影目的";
            this.予約一覧_撮影目的.Name = "予約一覧_撮影目的";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.d_isyou_yoyaku);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(930, 113);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "衣装予約一覧";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // d_isyou_yoyaku
            // 
            this.d_isyou_yoyaku.AllowUserToAddRows = false;
            this.d_isyou_yoyaku.AllowUserToDeleteRows = false;
            this.d_isyou_yoyaku.AllowUserToOrderColumns = true;
            this.d_isyou_yoyaku.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.d_isyou_yoyaku.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.d_isyou_yoyaku.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.衣装予約一覧_衣装コード,
            this.衣装予約一覧_施設名,
            this.衣装予約一覧_衣装予約時間,
            this.衣装予約一覧_お客様名,
            this.衣装予約一覧_性別,
            this.衣装予約一覧_摘要});
            this.d_isyou_yoyaku.Location = new System.Drawing.Point(0, 0);
            this.d_isyou_yoyaku.Name = "d_isyou_yoyaku";
            this.d_isyou_yoyaku.RowHeadersVisible = false;
            this.d_isyou_yoyaku.RowTemplate.Height = 21;
            this.d_isyou_yoyaku.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.d_isyou_yoyaku.Size = new System.Drawing.Size(930, 189);
            this.d_isyou_yoyaku.TabIndex = 0;
            // 
            // 衣装予約一覧_衣装コード
            // 
            this.衣装予約一覧_衣装コード.HeaderText = "衣装コード";
            this.衣装予約一覧_衣装コード.Name = "衣装予約一覧_衣装コード";
            // 
            // 衣装予約一覧_施設名
            // 
            this.衣装予約一覧_施設名.HeaderText = "施設名";
            this.衣装予約一覧_施設名.Name = "衣装予約一覧_施設名";
            // 
            // 衣装予約一覧_衣装予約時間
            // 
            this.衣装予約一覧_衣装予約時間.FillWeight = 250F;
            this.衣装予約一覧_衣装予約時間.HeaderText = "衣装予約時間";
            this.衣装予約一覧_衣装予約時間.Name = "衣装予約一覧_衣装予約時間";
            this.衣装予約一覧_衣装予約時間.Width = 250;
            // 
            // 衣装予約一覧_お客様名
            // 
            this.衣装予約一覧_お客様名.HeaderText = "お客様名";
            this.衣装予約一覧_お客様名.Name = "衣装予約一覧_お客様名";
            // 
            // 衣装予約一覧_性別
            // 
            this.衣装予約一覧_性別.HeaderText = "性別";
            this.衣装予約一覧_性別.Name = "衣装予約一覧_性別";
            // 
            // 衣装予約一覧_摘要
            // 
            this.衣装予約一覧_摘要.FillWeight = 200F;
            this.衣装予約一覧_摘要.HeaderText = "摘要";
            this.衣装予約一覧_摘要.Name = "衣装予約一覧_摘要";
            this.衣装予約一覧_摘要.Width = 200;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.d_sukejuru);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(930, 113);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "スケジュール一覧";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // d_sukejuru
            // 
            this.d_sukejuru.AllowUserToAddRows = false;
            this.d_sukejuru.AllowUserToDeleteRows = false;
            this.d_sukejuru.AllowUserToOrderColumns = true;
            this.d_sukejuru.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.d_sukejuru.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.d_sukejuru.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.スケジュール一覧_時刻,
            this.スケジュール一覧_内容});
            this.d_sukejuru.Location = new System.Drawing.Point(0, 0);
            this.d_sukejuru.Name = "d_sukejuru";
            this.d_sukejuru.RowHeadersVisible = false;
            this.d_sukejuru.RowTemplate.Height = 21;
            this.d_sukejuru.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.d_sukejuru.Size = new System.Drawing.Size(930, 150);
            this.d_sukejuru.TabIndex = 0;
            // 
            // スケジュール一覧_時刻
            // 
            this.スケジュール一覧_時刻.FillWeight = 250F;
            this.スケジュール一覧_時刻.HeaderText = "時刻";
            this.スケジュール一覧_時刻.Name = "スケジュール一覧_時刻";
            this.スケジュール一覧_時刻.Width = 250;
            // 
            // スケジュール一覧_内容
            // 
            this.スケジュール一覧_内容.FillWeight = 500F;
            this.スケジュール一覧_内容.HeaderText = "内容";
            this.スケジュール一覧_内容.Name = "スケジュール一覧_内容";
            this.スケジュール一覧_内容.Width = 500;
            // 
            // l_year
            // 
            this.l_year.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_year, 3);
            this.l_year.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.l_year.Location = new System.Drawing.Point(282, 51);
            this.l_year.Name = "l_year";
            this.tableLayoutPanel2.SetRowSpan(this.l_year, 2);
            this.l_year.Size = new System.Drawing.Size(69, 19);
            this.l_year.TabIndex = 3;
            this.l_year.Text = "2018年";
            // 
            // b_next
            // 
            this.b_next.AutoSize = true;
            this.b_next.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.b_next.Location = new System.Drawing.Point(251, 51);
            this.b_next.Name = "b_next";
            this.b_next.Size = new System.Drawing.Size(19, 17);
            this.b_next.TabIndex = 6;
            this.b_next.TabStop = true;
            this.b_next.Text = "▶";
            this.b_next.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.b_next_LinkClicked);
            // 
            // b_prev
            // 
            this.b_prev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_prev.AutoSize = true;
            this.b_prev.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.b_prev.Location = new System.Drawing.Point(226, 51);
            this.b_prev.Name = "b_prev";
            this.b_prev.Size = new System.Drawing.Size(19, 17);
            this.b_prev.TabIndex = 5;
            this.b_prev.TabStop = true;
            this.b_prev.Text = "◀";
            this.b_prev.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.b_prev_LinkClicked);
            // 
            // l_date
            // 
            this.l_date.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.l_date, 10);
            this.l_date.Font = new System.Drawing.Font("ＭＳ ゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.l_date.Location = new System.Drawing.Point(282, 85);
            this.l_date.Name = "l_date";
            this.tableLayoutPanel2.SetRowSpan(this.l_date, 2);
            this.l_date.Size = new System.Drawing.Size(250, 27);
            this.l_date.TabIndex = 7;
            this.l_date.Text = "8月21日（火）赤口";
            // 
            // c1Schedule1
            // 
            this.c1Schedule1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c1Schedule1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            // 
            // 
            // 
            this.c1Schedule1.CalendarInfo.CultureInfo = new System.Globalization.CultureInfo("ja-JP");
            this.c1Schedule1.CalendarInfo.DateFormatString = "MM/dd/yyyy ddd";
            this.c1Schedule1.CalendarInfo.EndDayTime = System.TimeSpan.Parse("19:00:00");
            this.c1Schedule1.CalendarInfo.FirstDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.c1Schedule1.CalendarInfo.StartDayTime = System.TimeSpan.Parse("13:00:00");
            this.c1Schedule1.CalendarInfo.TimeInterval = C1.C1Schedule.TimeScaleEnum.FifteenMinutes;
            this.c1Schedule1.CalendarInfo.TimeScale = System.TimeSpan.Parse("00:15:00");
            this.c1Schedule1.CalendarInfo.WeekStart = System.DayOfWeek.Sunday;
            this.c1Schedule1.CalendarInfo.WorkDays.AddRange(new System.DayOfWeek[] {
            System.DayOfWeek.Monday,
            System.DayOfWeek.Tuesday,
            System.DayOfWeek.Wednesday,
            System.DayOfWeek.Thursday,
            System.DayOfWeek.Friday});
            this.tableLayoutPanel2.SetColumnSpan(this.c1Schedule1, 30);
            // 
            // 
            // 
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.AppointmentStorage.DataMember = "Appointments";
            this.c1Schedule1.DataStorage.AppointmentStorage.DataSource = this.reservation_timetableDataSet;
            // 
            // 
            // 
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.AppointmentStorage.Mappings.AppointmentProperties.MappingName = "Properties";
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.AppointmentStorage.Mappings.Body.MappingName = "Body";
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.AppointmentStorage.Mappings.End.MappingName = "End";
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.AppointmentStorage.Mappings.IdMapping.MappingName = "AppointmentID";
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.AppointmentStorage.Mappings.Location.MappingName = "Location";
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.AppointmentStorage.Mappings.Start.MappingName = "Start";
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.AppointmentStorage.Mappings.Subject.MappingName = "Subject";
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.CategoryStorage.DataMember = "Categories";
            this.c1Schedule1.DataStorage.CategoryStorage.DataSource = this.reservation_timetableDataSet;
            // 
            // 
            // 
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.CategoryStorage.Mappings.CaptionMapping.MappingName = "CategoryName";
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.CategoryStorage.Mappings.IndexMapping.MappingName = "CategoryID";
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.CategoryStorage.Mappings.TextMapping.MappingName = "CategoryName";
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.ContactStorage.DataMember = "Contacts";
            this.c1Schedule1.DataStorage.ContactStorage.DataSource = this.reservation_timetableDataSet;
            // 
            // 
            // 
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.ContactStorage.Mappings.CaptionMapping.MappingName = "Name";
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.ContactStorage.Mappings.ColorMapping.MappingName = "Color";
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.ContactStorage.Mappings.IndexMapping.MappingName = "ContactID";
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.ContactStorage.Mappings.TextMapping.MappingName = "Name";
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.ResourceStorage.DataMember = "Resources";
            this.c1Schedule1.DataStorage.ResourceStorage.DataSource = this.reservation_timetableDataSet;
            // 
            // 
            // 
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.ResourceStorage.Mappings.CaptionMapping.MappingName = "ResourceName";
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.ResourceStorage.Mappings.IndexMapping.MappingName = "ResourceID";
            // 
            // 
            // 
            this.c1Schedule1.DataStorage.ResourceStorage.Mappings.TextMapping.MappingName = "ResourceName";
            this.c1Schedule1.EditOptions = C1.Win.C1Schedule.EditOptions.None;
            this.c1Schedule1.EmptyGroupName = "美容室";
            this.c1Schedule1.GroupBy = "Contact";
            this.c1Schedule1.GroupPageSize = 100;
            this.c1Schedule1.Location = new System.Drawing.Point(3, 139);
            this.c1Schedule1.Name = "c1Schedule1";
            this.c1Schedule1.PrintInfo.IsPrintingEnabled = false;
            printStyle1.Description = "Daily Style";
            printStyle1.StyleName = "Daily";
            printStyle1.StyleSource = "day.c1d";
            printStyle2.Description = "Weekly Style";
            printStyle2.StyleName = "Week";
            printStyle2.StyleSource = "week.c1d";
            printStyle3.Description = "Monthly Style";
            printStyle3.StyleName = "Month";
            printStyle3.StyleSource = "month.c1d";
            printStyle4.Description = "Details Style";
            printStyle4.StyleName = "Details";
            printStyle4.StyleSource = "details.c1d";
            printStyle5.Context = C1.C1Schedule.Printing.PrintContextType.Appointment;
            printStyle5.Description = "Memo Style";
            printStyle5.StyleName = "Memo";
            printStyle5.StyleSource = "memo.c1d";
            this.c1Schedule1.PrintInfo.PrintStyles.AddRange(new C1.C1Schedule.Printing.PrintStyle[] {
            printStyle1,
            printStyle2,
            printStyle3,
            printStyle4,
            printStyle5});
            this.tableLayoutPanel2.SetRowSpan(this.c1Schedule1, 15);
            this.c1Schedule1.ShowAllDayArea = false;
            this.c1Schedule1.ShowAppointmentToolTip = false;
            this.c1Schedule1.ShowContextMenu = false;
            this.c1Schedule1.ShowReminderForm = false;
            this.c1Schedule1.ShowTitle = false;
            this.c1Schedule1.ShowWorkTimeOnly = true;
            this.c1Schedule1.Size = new System.Drawing.Size(938, 249);
            this.c1Schedule1.TabIndex = 10;
            this.c1Schedule1.ViewType = C1.Win.C1Schedule.ScheduleViewEnum.TimeLineView;
            this.c1Schedule1.BeforeViewChange += new System.EventHandler<C1.Win.C1Schedule.BeforeViewChangeEventArgs>(this.c1Schedule1_BeforeViewChange);
            this.c1Schedule1.BeforeAppointmentShow += new C1.C1Schedule.CancelAppointmentEventHandler(this.c1Schedule1_BeforeAppointmentShow);
            this.c1Schedule1.BeforeAppointmentCreate += new C1.C1Schedule.CancelAppointmentEventHandler(this.c1Schedule1_Create);
            this.c1Schedule1.BeforeAppointmentEdit += new C1.C1Schedule.CancelAppointmentEventHandler(this.c1Schedule1_Edit);
            this.c1Schedule1.Load += new System.EventHandler(this.c1Schedule1_Load);
            this.c1Schedule1.Click += new System.EventHandler(this.c1Schedule1_Click);
            this.c1Schedule1.DoubleClick += new System.EventHandler(this.c1Schedule1_Click);
            // 
            // reservation_timetableDataSet
            // 
            this.reservation_timetableDataSet.DataSetName = "Reservation_timetableDataSet";
            this.reservation_timetableDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // c1Calendar1
            // 
            this.c1Calendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c1Calendar1.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            this.c1Calendar1.BoldedDates = new System.DateTime[0];
            this.c1Calendar1.CalendarDimensions = 3;
            this.tableLayoutPanel2.SetColumnSpan(this.c1Calendar1, 6);
            this.c1Calendar1.Location = new System.Drawing.Point(3, 3);
            this.c1Calendar1.MaxSelectionCount = 1;
            this.c1Calendar1.Name = "c1Calendar1";
            this.tableLayoutPanel2.SetRowSpan(this.c1Calendar1, 8);
            this.c1Calendar1.Schedule = this.c1Schedule1;
            this.c1Calendar1.ShowWeekNumbers = false;
            this.c1Calendar1.Size = new System.Drawing.Size(180, 130);
            this.c1Calendar1.TabIndex = 12;
            this.c1Calendar1.VisualStyle = C1.Win.C1Schedule.UI.VisualStyle.Office2010Blue;
            this.c1Calendar1.BeforeDayFormat += new System.EventHandler<C1.Win.C1Schedule.BeforeDayFormatEventArgs>(this.c1Calendar1_BeforeDayFormat);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label1, 2);
            this.label1.Location = new System.Drawing.Point(235, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "店舗名";
            // 
            // b_print
            // 
            this.b_print.Location = new System.Drawing.Point(773, 555);
            this.b_print.Name = "b_print";
            this.b_print.Size = new System.Drawing.Size(75, 23);
            this.b_print.TabIndex = 2;
            this.b_print.Text = "印刷";
            this.b_print.UseVisualStyleBackColor = true;
            this.b_print.Click += new System.EventHandler(this.b_print_Click);
            // 
            // reservationtimetableDataSetBindingSource
            // 
            this.reservationtimetableDataSetBindingSource.DataSource = this.reservation_timetableDataSet;
            this.reservationtimetableDataSetBindingSource.Position = 0;
            // 
            // contactsTableAdapter
            // 
            this.contactsTableAdapter.ClearBeforeFill = true;
            // 
            // Reservation_timetable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Reservation_timetable";
            this.Size = new System.Drawing.Size(976, 602);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabList.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.d_yoyaku)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.d_isyou_yoyaku)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.d_sukejuru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.AppointmentStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.CategoryStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.ContactStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.LabelStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.OwnerStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.ResourceStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1.DataStorage.StatusStorage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Schedule1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservation_timetableDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1Calendar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reservationtimetableDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button b_return;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label l_year;
        private System.Windows.Forms.ComboBox d_tenpomei;
        private System.Windows.Forms.LinkLabel b_prev;
        private System.Windows.Forms.LinkLabel b_next;
        private System.Windows.Forms.Label l_date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox d_osirase;
        private System.Windows.Forms.Button b_print;
        private C1.Win.C1Schedule.C1Schedule c1Schedule1;
        private System.Windows.Forms.TabControl tabList;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Asset.Reservation_timetableDataSet reservation_timetableDataSet;
        private System.Windows.Forms.BindingSource reservationtimetableDataSetBindingSource;
        private Asset.Reservation_timetableDataSetTableAdapters.ContactsTableAdapter contactsTableAdapter;
        private System.Windows.Forms.DataGridView d_yoyaku;
        private System.Windows.Forms.DataGridView d_isyou_yoyaku;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView d_sukejuru;
        private System.Windows.Forms.DataGridViewTextBoxColumn 予約一覧_施設名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 予約一覧_名前;
        private System.Windows.Forms.DataGridViewTextBoxColumn 予約一覧_性別;
        private System.Windows.Forms.DataGridViewTextBoxColumn 予約一覧_来店日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 予約一覧_予約時間;
        private System.Windows.Forms.DataGridViewTextBoxColumn 予約一覧_撮影目的;
        private System.Windows.Forms.DataGridViewTextBoxColumn 衣装予約一覧_衣装コード;
        private System.Windows.Forms.DataGridViewTextBoxColumn 衣装予約一覧_施設名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 衣装予約一覧_衣装予約時間;
        private System.Windows.Forms.DataGridViewTextBoxColumn 衣装予約一覧_お客様名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 衣装予約一覧_性別;
        private System.Windows.Forms.DataGridViewTextBoxColumn 衣装予約一覧_摘要;
        private System.Windows.Forms.DataGridViewTextBoxColumn スケジュール一覧_時刻;
        private System.Windows.Forms.DataGridViewTextBoxColumn スケジュール一覧_内容;
        public C1Calendar c1Calendar1;
    }
}
