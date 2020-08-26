using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 写真館システム
{
    public partial class Photo_form : Form
    {
        private Photo_selection photo_Selection;
        public string imgName;

        public Photo_form(Photo_selection _photo_Selection, string _imgName)
        {
            InitializeComponent();
            pictureBox1.MouseDown += new MouseEventHandler(this.picMouseDown);
            pictureBox1.MouseMove += new MouseEventHandler(this.picMouseMove);
            pictureBox1.MouseUp += new MouseEventHandler(this.picMouseUp);

            this.photo_Selection = _photo_Selection;
            this.imgName = _imgName;

            var ppath = System.IO.Path.Combine(this.photo_Selection.Photographer_Select_dir, this.imgName);

            this.pictureBox1.BackgroundImage = new Bitmap(ppath);
            this.id.Text = "[" + this.photo_Selection.imageList1.Images.Keys.IndexOf(this.imgName).ToString().PadLeft(4, '0') + "]";
            this.Text = _imgName;
            
            tagList.ColumnCount = photo_Selection.tagCount;
            for(int i=0; photo_Selection.tagCount > i; i++)
            {
                CheckBoxExp c = new CheckBoxExp();
                c.Text = "■";
                c.Size = new Size(30,15);
                c.ForeColor = photo_Selection.TAGS[i];
                c.Click += new System.EventHandler(this.c_cleck);
                c.photo_Selection = photo_Selection;
                c.tagId = i;
                tagList.Controls.Add(c, i, 0);
                foreach (tagControl tagc in photo_Selection.tagsPanel.Controls)
                {
                    if(tagc.tagId == i)
                    {
                        foreach(var key in tagc.imageList1.Images.Keys)
                        {
                            if (key == imgName)
                                c.Checked = true;
                        }
                    } 
                }
            }
        }

        private void c_cleck(object sender, System.EventArgs e)
        {
            if(sender is CheckBoxExp)
            {
                CheckBoxExp c = (CheckBoxExp)sender;
                if (c.Checked)
                {
                    foreach(tagControl tagControl in c.photo_Selection.tagsPanel.Controls)
                    {
                        if(tagControl.tagId == c.tagId)
                        {
                            if(!tagControl.imgNameList.Contains(this.imgName))
                            {
                                //タグ付け一覧へ追加
                                tagControl.imgNameList.Add(this.imgName);
                                tagControl.thumbnailListRefresh();
                            }

                        }
                    }
                }
                else
                {
                    foreach (tagControl tagControl in c.photo_Selection.tagsPanel.Controls)
                    {
                        if (tagControl.tagId == c.tagId)
                        {
                            //タグ付け一覧の操作
                            tagControl.imgNameList.Remove(this.imgName);
                            tagControl.thumbnailListRefresh();
                        }
                    }
                }
                this.photo_Selection.thumbnailListTagRefresh(this.imgName);
            }
        }

        private bool IsDragging;
        private Point DraggingOld;

        private void picMouseDown(object sender, MouseEventArgs e)
        {

            this.IsDragging = true; // ドラッグ中であることを知らせる
            this.DraggingOld = new Point(e.X, e.Y);

        }

        private void picMouseMove(object sender, MouseEventArgs e)
        {

            if (!this.IsDragging)
            {
                return;
            }


            if (this.photo_Selection.b_hand.Checked)
            {
                //ONの場合はすべての画像
                foreach(var con in MainForm.Photo_selection.selectPanel.Controls)
                {
                    var pic = ((Photo_form)con).pictureBox1;
                    int x = pic.Location.X + e.X - this.DraggingOld.X;
                    int y = pic.Location.Y + e.Y - this.DraggingOld.Y;
                    pic.Location = new Point(x, y);
                }
            }
            else
            {
                //OFFの場合は単体の画像
                int x = pictureBox1.Location.X + e.X - this.DraggingOld.X;
                int y = pictureBox1.Location.Y + e.Y - this.DraggingOld.Y;
                pictureBox1.Location = new Point(x, y);
            }
        }

        private void picMouseUp(object sender, MouseEventArgs e)
        {
            this.IsDragging = false;
        }

        public void picScale(double scale)
        {
            double w = this.Size.Width / 2;
            double h = (this.Size.Height + 10) / 2;
            double x = -pictureBox1.Location.X + w;
            double y = -pictureBox1.Location.Y + h;
            x = x * scale;
            x = w - x;
            y = y * scale;
            y = h - y;
            pictureBox1.Location = new Point((int)x, (int)y);
            pictureBox1.Size = new Size((int)(pictureBox1.Size.Width * scale), (int)(pictureBox1.Size.Height * scale));
        }
    }
    public partial class CheckBoxExp : CheckBox
    {
        public Photo_selection photo_Selection;
        public int tagId;
    }
}
