namespace 写真館システム
{
    partial class tagControl
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
            this.d_tag = new System.Windows.Forms.CheckBox();
            this.d_tagName = new System.Windows.Forms.ComboBox();
            this.l_count = new System.Windows.Forms.Label();
            this.thumbnailList = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.b_spread = new System.Windows.Forms.Button();
            this.b_allClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // d_tag
            // 
            this.d_tag.AutoSize = true;
            this.d_tag.Location = new System.Drawing.Point(3, 6);
            this.d_tag.Name = "d_tag";
            this.d_tag.Size = new System.Drawing.Size(15, 14);
            this.d_tag.TabIndex = 0;
            this.d_tag.UseVisualStyleBackColor = true;
            // 
            // d_tagName
            // 
            this.d_tagName.FormattingEnabled = true;
            this.d_tagName.Location = new System.Drawing.Point(23, 3);
            this.d_tagName.Name = "d_tagName";
            this.d_tagName.Size = new System.Drawing.Size(140, 20);
            this.d_tagName.TabIndex = 1;
            // 
            // l_count
            // 
            this.l_count.AutoSize = true;
            this.l_count.Location = new System.Drawing.Point(169, 5);
            this.l_count.Name = "l_count";
            this.l_count.Size = new System.Drawing.Size(23, 12);
            this.l_count.TabIndex = 2;
            this.l_count.Text = "0枚";
            // 
            // thumbnailList
            // 
            this.thumbnailList.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.thumbnailList.LargeImageList = this.imageList1;
            this.thumbnailList.Location = new System.Drawing.Point(0, 26);
            this.thumbnailList.Name = "thumbnailList";
            this.thumbnailList.Size = new System.Drawing.Size(260, 74);
            this.thumbnailList.SmallImageList = this.imageList1;
            this.thumbnailList.TabIndex = 3;
            this.thumbnailList.UseCompatibleStateImageBehavior = false;
            this.thumbnailList.View = System.Windows.Forms.View.List;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(60, 60);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // b_spread
            // 
            this.b_spread.Location = new System.Drawing.Point(198, 0);
            this.b_spread.Name = "b_spread";
            this.b_spread.Size = new System.Drawing.Size(25, 25);
            this.b_spread.TabIndex = 4;
            this.b_spread.Text = "←";
            this.b_spread.UseVisualStyleBackColor = true;
            this.b_spread.Click += new System.EventHandler(this.b_spread_Click);
            // 
            // b_allClose
            // 
            this.b_allClose.Location = new System.Drawing.Point(229, 0);
            this.b_allClose.Name = "b_allClose";
            this.b_allClose.Size = new System.Drawing.Size(25, 25);
            this.b_allClose.TabIndex = 4;
            this.b_allClose.Text = "×";
            this.b_allClose.UseVisualStyleBackColor = true;
            this.b_allClose.Click += new System.EventHandler(this.b_allClose_Click);
            // 
            // tagControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.b_allClose);
            this.Controls.Add(this.b_spread);
            this.Controls.Add(this.thumbnailList);
            this.Controls.Add(this.l_count);
            this.Controls.Add(this.d_tagName);
            this.Controls.Add(this.d_tag);
            this.Name = "tagControl";
            this.Size = new System.Drawing.Size(260, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button b_spread;
        private System.Windows.Forms.Button b_allClose;
        public System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.ListView thumbnailList;
        public System.Windows.Forms.CheckBox d_tag;
        public System.Windows.Forms.ComboBox d_tagName;
        public System.Windows.Forms.Label l_count;
    }
}
