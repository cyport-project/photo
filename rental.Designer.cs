namespace 写真館システム
{
    partial class rental
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
            this.l_rental = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.d_rental_store = new System.Windows.Forms.ComboBox();
            this.b_ok = new System.Windows.Forms.Button();
            this.b_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l_rental
            // 
            this.l_rental.AutoSize = true;
            this.l_rental.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.l_rental.Location = new System.Drawing.Point(90, 28);
            this.l_rental.Name = "l_rental";
            this.l_rental.Size = new System.Drawing.Size(96, 28);
            this.l_rental.TabIndex = 0;
            this.l_rental.Text = "店舗名";
            this.l_rental.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 1;
            // 
            // d_rental_store
            // 
            this.d_rental_store.FormattingEnabled = true;
            this.d_rental_store.Location = new System.Drawing.Point(227, 28);
            this.d_rental_store.Name = "d_rental_store";
            this.d_rental_store.Size = new System.Drawing.Size(186, 23);
            this.d_rental_store.TabIndex = 1;
            // 
            // b_ok
            // 
            this.b_ok.Location = new System.Drawing.Point(365, 69);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(98, 36);
            this.b_ok.TabIndex = 2;
            this.b_ok.Text = "OK";
            this.b_ok.UseVisualStyleBackColor = true;
            this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
            // 
            // b_cancel
            // 
            this.b_cancel.Location = new System.Drawing.Point(496, 71);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Size = new System.Drawing.Size(113, 34);
            this.b_cancel.TabIndex = 3;
            this.b_cancel.Text = "キャンセル";
            this.b_cancel.UseVisualStyleBackColor = true;
            this.b_cancel.Click += new System.EventHandler(this.b_cancel_Click);
            // 
            // rental
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 145);
            this.Controls.Add(this.b_cancel);
            this.Controls.Add(this.b_ok);
            this.Controls.Add(this.d_rental_store);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.l_rental);
            this.Name = "rental";
            this.Text = "一括貸出";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_rental;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox d_rental_store;
        private System.Windows.Forms.Button b_ok;
        private System.Windows.Forms.Button b_cancel;
    }
}