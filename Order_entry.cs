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
    public partial class Order_entry : UserControlExp
    {
        public Order_entry()
        {
            InitializeComponent();
        }

        //初期表示
        private void UserControl1_Load(object sender, EventArgs e)
        {
            //お客様情報初期化
            l_customer_code = null;
            l_customer_name = null;

            //注文情報初期化
            t_order_code = null;
            c_store.DataSource = Enum.GetValues(typeof(Utile.Data.店舗名));
            t_album = null;
            t_finish_contact = null;
            t_contact_telno = null;
            c_delivery1_staff.DataSource = Enum.GetValues(typeof(Utile.Data.スタッフ名));
            c_delivery2_staff.DataSource = Enum.GetValues(typeof(Utile.Data.スタッフ名));
            c_delivery2_staff.SelectedIndex = -1;

            //セレクトデータ読み込み
            //gridviewに貼り付け


            //合計
            /*
            var work = int.Parse( t_subtotal.Text)
                + int.Parse(t_tax.Text) - int.Parse(t_discount.Text);
            
            t_total.Text = work.ToString();
            */


        }

        //再表示
        public override void PageRefresh()
        {
            
        }
        //発注入力検索表示
        private void b_order_Click(object sender, EventArgs e)
        {

        }
        //入金入力画面表示
        private void b_deposit_input_Click(object sender, EventArgs e)
        {

        }
        //写真選択画面表示
        private void b_photo_selection_Click(object sender, EventArgs e)
        {

        }
        //登録処理
        private void b_regist_Click(object sender, EventArgs e)
        {

        }
        //一つ前の画面に戻る
        private void b_return_Click(object sender, EventArgs e)
        {
            MainForm.Order_entry.PageRefresh();
            MainForm.backPage(this);

        }

        
    }
}
