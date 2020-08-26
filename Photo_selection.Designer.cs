using System;
using System.Windows.Forms;

namespace 写真館システム
{
    partial class Photo_selection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Photo_selection));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.c1Sizer1 = new C1.Win.C1Sizer.C1Sizer();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.thumbnailList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tagsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.b_folder = new C1.Win.C1Input.C1Button();
            this.b_print = new C1.Win.C1Input.C1Button();
            this.b_collect = new C1.Win.C1Input.C1Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.b_renew = new C1.Win.C1Input.C1Button();
            this.b_tarnRight = new C1.Win.C1Input.C1Button();
            this.b_turnLeft = new C1.Win.C1Input.C1Button();
            this.b_plas = new C1.Win.C1Input.C1Button();
            this.b_minus = new C1.Win.C1Input.C1Button();
            this.b_max = new C1.Win.C1Input.C1Button();
            this.b_arrangeLine = new C1.Win.C1Input.C1Button();
            this.b_arrangeVertical = new C1.Win.C1Input.C1Button();
            this.b_arrange = new C1.Win.C1Input.C1Button();
            this.b_allClose = new C1.Win.C1Input.C1Button();
            this.d_scale = new System.Windows.Forms.TextBox();
            this.selectPanel = new System.Windows.Forms.Panel();
            this.b_hand = new System.Windows.Forms.CheckBox();
            this.b_camera = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1Sizer1)).BeginInit();
            this.c1Sizer1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.b_folder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_print)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_collect)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.b_renew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_tarnRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_turnLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_plas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_minus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_arrangeLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_arrangeVertical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_arrange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_allClose)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.c1Sizer1, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(976, 602);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // c1Sizer1
            // 
            this.c1Sizer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c1Sizer1.Controls.Add(this.progressBar1);
            this.c1Sizer1.Controls.Add(this.thumbnailList);
            this.c1Sizer1.Controls.Add(this.tableLayoutPanel4);
            this.c1Sizer1.Controls.Add(this.tableLayoutPanel2);
            this.c1Sizer1.GridDefinition = "73.4939759036145:True:False;25.1290877796902:False:False;\t68.8935281837161:True:F" +
    "alse;30.2713987473904:False:True;";
            this.c1Sizer1.Location = new System.Drawing.Point(8, 8);
            this.c1Sizer1.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.c1Sizer1.Name = "c1Sizer1";
            this.c1Sizer1.Padding = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.c1Sizer1.Size = new System.Drawing.Size(958, 581);
            this.c1Sizer1.TabIndex = 0;
            this.c1Sizer1.Text = "c1Sizer1";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(0, 431);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(954, 146);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Value = 10;
            this.progressBar1.Visible = false;
            // 
            // thumbnailList
            // 
            this.thumbnailList.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.thumbnailList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.thumbnailList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.thumbnailList.LargeImageList = this.imageList1;
            this.thumbnailList.Location = new System.Drawing.Point(0, 431);
            this.thumbnailList.Name = "thumbnailList";
            this.thumbnailList.Size = new System.Drawing.Size(954, 146);
            this.thumbnailList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.thumbnailList.TabIndex = 4;
            this.thumbnailList.UseCompatibleStateImageBehavior = false;
            this.thumbnailList.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.thumbnailList_ItemDrag);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1205saya0I9A6935_TP_V.jpg");
            this.imageList1.Images.SetKeyName(1, "1205yuka0I9A6906_TP_V.jpg");
            this.imageList1.Images.SetKeyName(2, "KIM150922107032_TP_V.jpg");
            this.imageList1.Images.SetKeyName(3, "KIM150922596795_TP_V.jpg");
            this.imageList1.Images.SetKeyName(4, "YUKA150922576861_TP_V.jpg");
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Controls.Add(this.tagsPanel, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.b_folder, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.b_print, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.b_collect, 3, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(664, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(290, 427);
            this.tableLayoutPanel4.TabIndex = 3;
            // 
            // tagsPanel
            // 
            this.tagsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagsPanel.AutoScroll = true;
            this.tagsPanel.ColumnCount = 1;
            this.tableLayoutPanel4.SetColumnSpan(this.tagsPanel, 4);
            this.tagsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tagsPanel.Location = new System.Drawing.Point(3, 43);
            this.tagsPanel.Name = "tagsPanel";
            this.tagsPanel.RowCount = 1;
            this.tagsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tagsPanel.Size = new System.Drawing.Size(284, 381);
            this.tagsPanel.TabIndex = 1;
            // 
            // b_folder
            // 
            this.b_folder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_folder.BackgroundImage = global::写真館システム.Properties.Resources.forder;
            this.b_folder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.b_folder.Location = new System.Drawing.Point(75, 3);
            this.b_folder.Name = "b_folder";
            this.b_folder.Size = new System.Drawing.Size(66, 34);
            this.b_folder.TabIndex = 0;
            this.b_folder.UseVisualStyleBackColor = true;
            this.b_folder.VisualStyle = C1.Win.C1Input.VisualStyle.System;
            this.b_folder.Click += new System.EventHandler(this.b_folder_Click);
            // 
            // b_print
            // 
            this.b_print.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_print.BackgroundImage = global::写真館システム.Properties.Resources.print;
            this.b_print.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.b_print.Location = new System.Drawing.Point(147, 3);
            this.b_print.Name = "b_print";
            this.b_print.Size = new System.Drawing.Size(66, 34);
            this.b_print.TabIndex = 0;
            this.b_print.UseVisualStyleBackColor = true;
            this.b_print.VisualStyle = C1.Win.C1Input.VisualStyle.System;
            this.b_print.Click += new System.EventHandler(this.b_print_Click);
            // 
            // b_collect
            // 
            this.b_collect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_collect.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.b_collect.Location = new System.Drawing.Point(219, 3);
            this.b_collect.Name = "b_collect";
            this.b_collect.Size = new System.Drawing.Size(68, 34);
            this.b_collect.TabIndex = 0;
            this.b_collect.Text = "セレクト写真確定";
            this.b_collect.UseVisualStyleBackColor = true;
            this.b_collect.VisualStyle = C1.Win.C1Input.VisualStyle.System;
            this.b_collect.Click += new System.EventHandler(this.b_collect_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 15;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel2.Controls.Add(this.b_renew, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.b_tarnRight, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.b_turnLeft, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.b_plas, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.b_minus, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.b_max, 8, 1);
            this.tableLayoutPanel2.Controls.Add(this.b_arrangeLine, 11, 1);
            this.tableLayoutPanel2.Controls.Add(this.b_arrangeVertical, 12, 1);
            this.tableLayoutPanel2.Controls.Add(this.b_arrange, 13, 1);
            this.tableLayoutPanel2.Controls.Add(this.b_allClose, 14, 1);
            this.tableLayoutPanel2.Controls.Add(this.d_scale, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.selectPanel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.b_hand, 9, 1);
            this.tableLayoutPanel2.Controls.Add(this.b_camera, 10, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(660, 427);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // b_renew
            // 
            this.b_renew.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_renew.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.b_renew.Location = new System.Drawing.Point(3, 390);
            this.b_renew.Name = "b_renew";
            this.b_renew.Size = new System.Drawing.Size(38, 34);
            this.b_renew.TabIndex = 0;
            this.b_renew.Text = "更新";
            this.b_renew.UseVisualStyleBackColor = true;
            this.b_renew.VisualStyle = C1.Win.C1Input.VisualStyle.System;
            this.b_renew.Click += new System.EventHandler(this.b_renew_Click);
            // 
            // b_tarnRight
            // 
            this.b_tarnRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_tarnRight.BackgroundImage = global::写真館システム.Properties.Resources.turnL;
            this.b_tarnRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.b_tarnRight.Location = new System.Drawing.Point(91, 390);
            this.b_tarnRight.Name = "b_tarnRight";
            this.b_tarnRight.Size = new System.Drawing.Size(38, 34);
            this.b_tarnRight.TabIndex = 0;
            this.b_tarnRight.UseVisualStyleBackColor = true;
            this.b_tarnRight.VisualStyle = C1.Win.C1Input.VisualStyle.System;
            this.b_tarnRight.Click += new System.EventHandler(this.b_tarnRight_Click);
            // 
            // b_turnLeft
            // 
            this.b_turnLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_turnLeft.BackgroundImage = global::写真館システム.Properties.Resources.turnR;
            this.b_turnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.b_turnLeft.Location = new System.Drawing.Point(135, 390);
            this.b_turnLeft.Name = "b_turnLeft";
            this.b_turnLeft.Size = new System.Drawing.Size(38, 34);
            this.b_turnLeft.TabIndex = 0;
            this.b_turnLeft.UseVisualStyleBackColor = true;
            this.b_turnLeft.VisualStyle = C1.Win.C1Input.VisualStyle.System;
            this.b_turnLeft.Click += new System.EventHandler(this.b_turnLeft_Click);
            // 
            // b_plas
            // 
            this.b_plas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_plas.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.b_plas.Location = new System.Drawing.Point(223, 390);
            this.b_plas.Name = "b_plas";
            this.b_plas.Size = new System.Drawing.Size(38, 34);
            this.b_plas.TabIndex = 0;
            this.b_plas.Text = "＋";
            this.b_plas.UseVisualStyleBackColor = true;
            this.b_plas.VisualStyle = C1.Win.C1Input.VisualStyle.System;
            this.b_plas.Click += new System.EventHandler(this.b_plas_Click);
            // 
            // b_minus
            // 
            this.b_minus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_minus.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.b_minus.Location = new System.Drawing.Point(267, 390);
            this.b_minus.Name = "b_minus";
            this.b_minus.Size = new System.Drawing.Size(38, 34);
            this.b_minus.TabIndex = 0;
            this.b_minus.Text = "-";
            this.b_minus.UseVisualStyleBackColor = true;
            this.b_minus.VisualStyle = C1.Win.C1Input.VisualStyle.System;
            this.b_minus.Click += new System.EventHandler(this.b_minus_Click);
            // 
            // b_max
            // 
            this.b_max.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_max.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.b_max.Location = new System.Drawing.Point(355, 390);
            this.b_max.Name = "b_max";
            this.b_max.Size = new System.Drawing.Size(38, 34);
            this.b_max.TabIndex = 0;
            this.b_max.Text = "最大化";
            this.b_max.UseVisualStyleBackColor = true;
            this.b_max.Click += new System.EventHandler(this.b_max_Click);
            // 
            // b_arrangeLine
            // 
            this.b_arrangeLine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_arrangeLine.Location = new System.Drawing.Point(487, 390);
            this.b_arrangeLine.Name = "b_arrangeLine";
            this.b_arrangeLine.Size = new System.Drawing.Size(38, 34);
            this.b_arrangeLine.TabIndex = 0;
            this.b_arrangeLine.Text = "□□";
            this.b_arrangeLine.UseVisualStyleBackColor = true;
            this.b_arrangeLine.VisualStyle = C1.Win.C1Input.VisualStyle.System;
            this.b_arrangeLine.Click += new System.EventHandler(this.b_arrangeLine_Click);
            // 
            // b_arrangeVertical
            // 
            this.b_arrangeVertical.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_arrangeVertical.Location = new System.Drawing.Point(531, 390);
            this.b_arrangeVertical.Name = "b_arrangeVertical";
            this.b_arrangeVertical.Size = new System.Drawing.Size(38, 34);
            this.b_arrangeVertical.TabIndex = 0;
            this.b_arrangeVertical.Text = "□\r\n□";
            this.b_arrangeVertical.UseVisualStyleBackColor = true;
            this.b_arrangeVertical.VisualStyle = C1.Win.C1Input.VisualStyle.System;
            this.b_arrangeVertical.Click += new System.EventHandler(this.b_arrangeVertical_Click);
            // 
            // b_arrange
            // 
            this.b_arrange.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_arrange.Location = new System.Drawing.Point(575, 390);
            this.b_arrange.Name = "b_arrange";
            this.b_arrange.Size = new System.Drawing.Size(38, 34);
            this.b_arrange.TabIndex = 0;
            this.b_arrange.Text = "□□\r\n□□";
            this.b_arrange.UseVisualStyleBackColor = true;
            this.b_arrange.VisualStyle = C1.Win.C1Input.VisualStyle.System;
            this.b_arrange.Click += new System.EventHandler(this.b_arrange_Click);
            // 
            // b_allClose
            // 
            this.b_allClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_allClose.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.b_allClose.Location = new System.Drawing.Point(619, 390);
            this.b_allClose.Name = "b_allClose";
            this.b_allClose.Size = new System.Drawing.Size(38, 34);
            this.b_allClose.TabIndex = 0;
            this.b_allClose.Text = "すべて×";
            this.b_allClose.UseVisualStyleBackColor = true;
            this.b_allClose.VisualStyle = C1.Win.C1Input.VisualStyle.System;
            this.b_allClose.Click += new System.EventHandler(this.b_allClose_Click);
            // 
            // d_scale
            // 
            this.d_scale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.d_scale.Location = new System.Drawing.Point(311, 397);
            this.d_scale.Name = "d_scale";
            this.d_scale.Size = new System.Drawing.Size(38, 19);
            this.d_scale.TabIndex = 1;
            this.d_scale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.d_scale.KeyDown += new System.Windows.Forms.KeyEventHandler(this.d_scale_KeyDown);
            // 
            // selectPanel
            // 
            this.selectPanel.AllowDrop = true;
            this.selectPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectPanel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tableLayoutPanel2.SetColumnSpan(this.selectPanel, 15);
            this.selectPanel.Location = new System.Drawing.Point(3, 3);
            this.selectPanel.Name = "selectPanel";
            this.selectPanel.Size = new System.Drawing.Size(654, 381);
            this.selectPanel.TabIndex = 2;
            this.selectPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.selectPanel_DragDrop);
            this.selectPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.selectPanel_DragEnter);
            this.selectPanel.DragOver += new System.Windows.Forms.DragEventHandler(this.selectPanel_DragOver);
            // 
            // b_hand
            // 
            this.b_hand.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_hand.Appearance = System.Windows.Forms.Appearance.Button;
            this.b_hand.AutoSize = true;
            this.b_hand.BackgroundImage = global::写真館システム.Properties.Resources.hand;
            this.b_hand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.b_hand.Location = new System.Drawing.Point(399, 390);
            this.b_hand.Name = "b_hand";
            this.b_hand.Size = new System.Drawing.Size(38, 34);
            this.b_hand.TabIndex = 3;
            this.b_hand.UseVisualStyleBackColor = true;
            this.b_hand.CheckedChanged += new System.EventHandler(this.b_hand_CheckedChanged);
            // 
            // b_camera
            // 
            this.b_camera.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.b_camera.BackgroundImage = global::写真館システム.Properties.Resources.カメラアイコン8;
            this.b_camera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.b_camera.Location = new System.Drawing.Point(443, 390);
            this.b_camera.Name = "b_camera";
            this.b_camera.Size = new System.Drawing.Size(38, 34);
            this.b_camera.TabIndex = 4;
            this.b_camera.UseVisualStyleBackColor = true;
            this.b_camera.Click += new System.EventHandler(this.b_camera_Click);
            // 
            // Photo_selection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Photo_selection";
            this.Size = new System.Drawing.Size(976, 602);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1Sizer1)).EndInit();
            this.c1Sizer1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.b_folder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_print)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_collect)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.b_renew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_tarnRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_turnLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_plas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_minus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_arrangeLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_arrangeVertical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_arrange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.b_allClose)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private C1.Win.C1Sizer.C1Sizer c1Sizer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private C1.Win.C1Input.C1Button b_renew;
        private C1.Win.C1Input.C1Button b_tarnRight;
        private C1.Win.C1Input.C1Button b_turnLeft;
        private C1.Win.C1Input.C1Button b_plas;
        private C1.Win.C1Input.C1Button b_minus;
        private C1.Win.C1Input.C1Button b_max;
        private C1.Win.C1Input.C1Button b_arrangeLine;
        private C1.Win.C1Input.C1Button b_arrangeVertical;
        private C1.Win.C1Input.C1Button b_arrange;
        private C1.Win.C1Input.C1Button b_allClose;
        private System.Windows.Forms.TextBox d_scale;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private C1.Win.C1Input.C1Button b_folder;
        private C1.Win.C1Input.C1Button b_print;
        private C1.Win.C1Input.C1Button b_collect;
        public System.Windows.Forms.ListView thumbnailList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.TableLayoutPanel tagsPanel;
        public System.Windows.Forms.CheckBox b_hand;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button b_camera;
        public System.Windows.Forms.Panel selectPanel;
    }
}
