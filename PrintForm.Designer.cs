namespace 写真館システム
{
    partial class PrintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintForm));
            this.c1FlexViewer = new C1.Win.FlexViewer.C1FlexViewer();
            this.PrintReport = new C1.Win.FlexReport.C1FlexReport();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // c1FlexViewer
            // 
            this.c1FlexViewer.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.c1FlexViewer.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.c1FlexViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexViewer.Location = new System.Drawing.Point(0, 0);
            this.c1FlexViewer.Name = "c1FlexViewer";
            this.c1FlexViewer.Size = new System.Drawing.Size(800, 450);
            this.c1FlexViewer.TabIndex = 0;
            this.c1FlexViewer.Load += new System.EventHandler(this.c1FlexViewer_Load);
            // 
            // PrintReport
            // 
            this.PrintReport.ReportDefinition = resources.GetString("PrintReport.ReportDefinition");
            this.PrintReport.ReportName = "Costume_reservation_list";
            // 
            // PrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.c1FlexViewer);
            this.Name = "PrintForm";
            this.Text = "印刷";
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public C1.Win.FlexViewer.C1FlexViewer c1FlexViewer;
        public C1.Win.FlexReport.C1FlexReport PrintReport;
    }
}