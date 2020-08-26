using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 写真館システム
{
    public partial class tagControl : UserControl
    {
        public int tagId;
        public List<string> imgNameList;
        public Photo_selection photo_Selection;

        public tagControl(Photo_selection _photo_Selection)
        {
            InitializeComponent();
            this.imgNameList = new List<string>();
            this.photo_Selection = _photo_Selection;
            d_tagName.DataSource = new List<string>( DB.m_product.getProductList().Values);
        }
        public void thumbnailListRefresh()
        {
            //imageList1をクリア
            this.imageList1.Images.Clear();

            //imageList1に格納
            foreach(string iName in photo_Selection.imageListBase.Images.Keys)
            {
                if (imgNameList.Contains(iName))
                {
                    imageList1.Images.Add(iName, photo_Selection.imageListBase.Images[iName]);
                }
            }
            
            //thumbnailListをクリア
            this.thumbnailList.Items.Clear();

            //thumbnailListに格納
            ListViewItem lvi = new ListViewItem("");
            for (int i = 0; this.imageList1.Images.Count > i; i++)
            {
                lvi = new ListViewItem(this.imageList1.Images.Keys[i]);
                //lvi = new ListViewItem();
                lvi.ImageIndex = i;
                this.thumbnailList.Items.Add(lvi);
            }

            //枚数表示
            this.l_count.Text = this.imageList1.Images.Count.ToString() + "枚";
        }

        private void b_allClose_Click(object sender, EventArgs e)
        {
            //imgNameListをクリア
            imgNameList.Clear();
            //thumbnailListをクリア
            this.thumbnailList.Items.Clear();
            //枚数表示
            this.l_count.Text = this.imageList1.Images.Count.ToString() + "枚";

        }

        private void b_spread_Click(object sender, EventArgs e)
        {
            this.photo_Selection.selectPanel.Controls.Clear();

            foreach (ListViewItem srcItem in this.thumbnailList.Items)
            {
                Photo_form f1 = new Photo_form(this.photo_Selection, this.imageList1.Images.Keys[srcItem.ImageIndex]);
                f1.TopLevel = false;
                this.photo_Selection.selectPanel.Controls.Add(f1);
                this.photo_Selection.selectPanel.Controls.SetChildIndex(f1, 0);
                f1.Show();
            }

            this.photo_Selection.arrange();
        }
    }
}
