namespace 写真館システム
{
    partial class Facility_master
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
            this.d_tenpo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.t_facility_code = new System.Windows.Forms.TextBox();
            this.t_current_page = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.t_total_page = new System.Windows.Forms.Label();
            this.b_decrease = new System.Windows.Forms.LinkLabel();
            this.b_increase = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.t_facility = new System.Windows.Forms.TextBox();
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(846, 591);
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
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.333332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.439803F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.194103F));
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
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.d_tenpo, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.label2, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.t_facility_code, 4, 4);
            this.tableLayoutPanel2.Controls.Add(this.t_current_page, 9, 4);
            this.tableLayoutPanel2.Controls.Add(this.label3, 10, 4);
            this.tableLayoutPanel2.Controls.Add(this.t_total_page, 11, 4);
            this.tableLayoutPanel2.Controls.Add(this.b_decrease, 13, 4);
            this.tableLayoutPanel2.Controls.Add(this.b_increase, 14, 4);
            this.tableLayoutPanel2.Controls.Add(this.label5, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.t_facility, 4, 6);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(814, 528);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label1, 2);
            this.label1.Location = new System.Drawing.Point(30, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "店舗名";
            // 
            // d_tenpo
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.d_tenpo, 4);
            this.d_tenpo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.d_tenpo.FormattingEnabled = true;
            this.d_tenpo.Location = new System.Drawing.Point(111, 34);
            this.d_tenpo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.d_tenpo.Name = "d_tenpo";
            this.d_tenpo.Size = new System.Drawing.Size(102, 20);
            this.d_tenpo.TabIndex = 1;
            this.d_tenpo.SelectedIndexChanged += new System.EventHandler(this.d_tenpo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label2, 3);
            this.label2.Location = new System.Drawing.Point(30, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "施設コード";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // t_facility_code
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.t_facility_code, 4);
            this.t_facility_code.Location = new System.Drawing.Point(111, 68);
            this.t_facility_code.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.t_facility_code.Name = "t_facility_code";
            this.t_facility_code.Size = new System.Drawing.Size(100, 19);
            this.t_facility_code.TabIndex = 2;
            this.t_facility_code.TextChanged += new System.EventHandler(this.t_facility_code_TextChanged);
            // 
            // t_current_page
            // 
            this.t_current_page.Location = new System.Drawing.Point(246, 68);
            this.t_current_page.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.t_current_page.Name = "t_current_page";
            this.t_current_page.Size = new System.Drawing.Size(21, 19);
            this.t_current_page.TabIndex = 3;
            this.t_current_page.TextChanged += new System.EventHandler(this.t_current_page_TextChanged);
            this.t_current_page.Leave += new System.EventHandler(this.t_current_page_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "／";
            // 
            // t_total_page
            // 
            this.t_total_page.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.t_total_page, 2);
            this.t_total_page.Location = new System.Drawing.Point(300, 68);
            this.t_total_page.Name = "t_total_page";
            this.t_total_page.Size = new System.Drawing.Size(23, 12);
            this.t_total_page.TabIndex = 5;
            this.t_total_page.Text = "100";
            // 
            // b_decrease
            // 
            this.b_decrease.AutoSize = true;
            this.b_decrease.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.b_decrease.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.b_decrease.Location = new System.Drawing.Point(354, 68);
            this.b_decrease.Name = "b_decrease";
            this.b_decrease.Size = new System.Drawing.Size(14, 13);
            this.b_decrease.TabIndex = 0;
            this.b_decrease.TabStop = true;
            this.b_decrease.Text = "◀";
            this.b_decrease.Click += new System.EventHandler(this.b_decrease_Click);
            // 
            // b_increase
            // 
            this.b_increase.AutoSize = true;
            this.b_increase.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.b_increase.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.b_increase.Location = new System.Drawing.Point(381, 68);
            this.b_increase.Name = "b_increase";
            this.b_increase.Size = new System.Drawing.Size(14, 13);
            this.b_increase.TabIndex = 0;
            this.b_increase.TabStop = true;
            this.b_increase.Text = "▶";
            this.b_increase.Click += new System.EventHandler(this.b_increase_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label5, 2);
            this.label5.Location = new System.Drawing.Point(30, 105);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "施設名";
            this.label5.Click += new System.EventHandler(this.label1_Click);
            // 
            // t_facility
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.t_facility, 7);
            this.t_facility.Location = new System.Drawing.Point(111, 102);
            this.t_facility.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.t_facility.Name = "t_facility";
            this.t_facility.Size = new System.Drawing.Size(183, 19);
            this.t_facility.TabIndex = 4;
            this.t_facility.TextChanged += new System.EventHandler(this.t_facility_TextChanged);
            // 
            // b_new_regist
            // 
            this.b_new_regist.Location = new System.Drawing.Point(505, 544);
            this.b_new_regist.Name = "b_new_regist";
            this.b_new_regist.Size = new System.Drawing.Size(75, 23);
            this.b_new_regist.TabIndex = 5;
            this.b_new_regist.Text = "新規登録";
            this.b_new_regist.UseVisualStyleBackColor = true;
            this.b_new_regist.Click += new System.EventHandler(this.b_new_regist_Click);
            // 
            // b_delete
            // 
            this.b_delete.Location = new System.Drawing.Point(587, 544);
            this.b_delete.Name = "b_delete";
            this.b_delete.Size = new System.Drawing.Size(75, 23);
            this.b_delete.TabIndex = 6;
            this.b_delete.Text = "削除";
            this.b_delete.UseVisualStyleBackColor = true;
            this.b_delete.Click += new System.EventHandler(this.b_delete_Click);
            // 
            // b_regist
            // 
            this.b_regist.Location = new System.Drawing.Point(669, 544);
            this.b_regist.Name = "b_regist";
            this.b_regist.Size = new System.Drawing.Size(75, 23);
            this.b_regist.TabIndex = 7;
            this.b_regist.Text = "登録";
            this.b_regist.UseVisualStyleBackColor = true;
            this.b_regist.Click += new System.EventHandler(this.b_regist_Click);
            // 
            // b_return
            // 
            this.b_return.Location = new System.Drawing.Point(751, 544);
            this.b_return.Name = "b_return";
            this.b_return.Size = new System.Drawing.Size(75, 23);
            this.b_return.TabIndex = 8;
            this.b_return.Text = "戻る";
            this.b_return.UseVisualStyleBackColor = true;
            this.b_return.Click += new System.EventHandler(this.b_return_Click);
            // 
            // Facility_master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Facility_master";
            this.Size = new System.Drawing.Size(846, 591);
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
        private System.Windows.Forms.ComboBox d_tenpo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox t_facility_code;
        private System.Windows.Forms.TextBox t_current_page;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label t_total_page;
        private System.Windows.Forms.LinkLabel b_decrease;
        private System.Windows.Forms.LinkLabel b_increase;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox t_facility;
        private System.Windows.Forms.Button b_new_regist;
        private System.Windows.Forms.Button b_delete;
        private System.Windows.Forms.Button b_regist;
        private System.Windows.Forms.Button b_return;
    }
}
