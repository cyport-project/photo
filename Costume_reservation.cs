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
    public partial class Costume_reservation : UserControlExp
    {
        //入力チェック初期化
        private checkOperation chk;
        private modifyCheck mod;

        public List<DB.t_costume_reservation> costumeReservationList = new List<DB.t_costume_reservation>();

        //画面構成用データの取得


        public Costume_reservation()
        {
            InitializeComponent();
            chk = new checkOperation(this);

            mod = new modifyCheck();
            mod.add(d_Shooting_purpose);
            mod.add(d_facility);
            mod.add(t_name);
            mod.add(t_name_kana);
            mod.add(d_sex2);
            mod.add(d_height);
            mod.add(d_foot);
            mod.add(d_sleeve);
        }
        //
        //ページの初期化
        //
        public override void PageRefresh()
        {
            //TextBox項目の初期化の初期化（受付コード・受付時間・概要）
            
            //
            //   顧客データ表示部分の初期化の初期化
            //
            var customer = DB.m_customer.getSingle(MainForm.session_t_reception.customer_code);

            //本番用コード（本番のみ利用）
            d_customer_code.Text = customer.customer_code;
            d_customer_name.Text = customer.surname + customer.name;
            d_birthday.Text = customer.birthday.ToString("yyyy年MM月dd日");
            d_sex.Text = Enum.GetNames(typeof(Utile.Data.性別))[int.Parse(customer.sex)];
            d_customer_postal_code.Text = customer.postal_code;
            d_address1.Text = customer.address1;
            d_address2.Text = customer.address2;
            d_address3.Text = customer.address3;
            d_phone_number.Text = customer.phone_number1 + " " + customer.phone_number2 + " " + customer.phone_number3 ;

            //
            //   ComboBoxの初期化
            //
            d_Shooting_purpose.DataSource = Enum.GetValues(typeof(Utile.Data.撮影目的));
            d_sex2.DataSource = Enum.GetValues(typeof(Utile.Data.性別));

            //
            //    グリッドビューに格納
            //
            d_renral_result.Rows.Clear();
            d_renral_result.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            d_renral_result.RowTemplate.Height = 80;
            foreach (var cr in costumeReservationList)
            {
                var store = DB.m_store.getSingle(cr.store_code);
                var cos = DB.m_costume.getSingle(cr.store_code, cr.costume_code);

                var rental = cos.rental_store == "" ? "" : " > " + cos.rental_store;
                var store_name_and_rental = store.store_name + Environment.NewLine + rental;

                d_renral_result.Rows.Add(
                    true,
                    getImage(getImgPath(store.store_name, cr.costume_code, cos.image1)),
                    cr.costume_code,
                    store_name_and_rental,
                    cos.Class + Environment.NewLine +
                    cos.brand_name + Environment.NewLine +
                    cos.color + Environment.NewLine +
                    cos.handle + Environment.NewLine +
                    cos.size,
                    cos.price1.ToString() + Environment.NewLine +
                    cos.price2.ToString() + Environment.NewLine +
                    cos.price3.ToString(),
                    cos.costume_name,
                    cr.start_date.ToString(@"yyyy/MM/dd"),
                    cr.start_time.ToString(@"hh\:mm"),
                    cr.end_date.ToString(@"yyyy/MM/dd"),
                    cr.end_time.ToString(@"hh\:mm"),
                    cr.memo
                );

            }

            //
            //    個別情報格納
            //
            if(costumeReservationList[0].costume_reservation_code != "")
            {
                var cr = costumeReservationList[0];
                t_name.Text = cr.name;
                t_name_kana.Text = cr.name_kana;
                if(cr.sex != null)
                    d_sex2.SelectedIndex = int.Parse(cr.sex);
                else
                    d_sex2.SelectedIndex = -1;
                if (cr.birthday != null)
                {
                    dt_birthday.Value = cr.birthday.Value;
                    dt_birthday.Checked = true;
                }
                else
                {
                    dt_birthday.Value = dt_birthday.MinDate;
                    dt_birthday.Checked = false;
                }
                d_height.Text = cr.height.ToString();
                d_foot.Text = cr.foot.ToString();
                d_sleeve.Text = cr.sleeve.ToString();
                d_facility.Text = cr.facility;
                d_Shooting_purpose.SelectedIndex = Enum.GetNames(typeof(Utile.Data.撮影目的)).ToList().IndexOf(cr.shooting_purpose);
                if (cr.cancellation_date != null)
                {
                    d_Cancellation_date.Value = cr.cancellation_date.Value;
                    d_Cancellation_date.Checked = true;
                }
                else
                {
                    d_Cancellation_date.Value = d_Cancellation_date.MinDate;
                    d_Cancellation_date.Checked = false;
                }

            }
            else
            {
                t_name.Text = "";
                t_name_kana.Text = "";
                d_sex2.SelectedIndex = -1;
                dt_birthday.Value = dt_birthday.MinDate;
                d_height.Text = "";
                d_foot.Text = "";
                d_sleeve.Text = "";
                d_facility.Text = "";
                d_Shooting_purpose.SelectedIndex = -1;
                d_Cancellation_date.Value = d_Cancellation_date.MinDate;

            }

            //変更フラグリセット
            mod.reset();

        }
        private string getImgPath(string store_name, string costume_code, string image_name)
        {
            var root = (System.Configuration.ConfigurationManager.AppSettings["photo_root"].ToString());
            var imgdir = (System.Configuration.ConfigurationManager.AppSettings["Costume_Image"].ToString());
            var storePath = System.IO.Path.Combine(root, imgdir);
            storePath = System.IO.Path.Combine(storePath, store_name);
            var costumePath = System.IO.Path.Combine(storePath, costume_code);
            return System.IO.Path.Combine(costumePath, image_name);
        }
        private Bitmap getImage(string path)
        {

            Bitmap resizeBmp = null;
            if (System.IO.File.Exists(path))
            {
                //存在したら、サイズ変更
                Bitmap img = new Bitmap(path);

                //セルの高さに合わせて縮小する
                int resizeHeight = d_renral_result.RowTemplate.Height;
                int resizeWidth = (int)(img.Width * ((double)resizeHeight / (double)img.Height));

                resizeBmp = new Bitmap(resizeWidth, resizeHeight);

                Graphics g = Graphics.FromImage(resizeBmp);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, resizeBmp.Width, resizeBmp.Height);
            }

            return resizeBmp;
        }

        private void b_regist_Click(object sender, EventArgs e)
        {
            //入力チェック
            chk.clear();
            chk.addControl(d_Shooting_purpose);
            chk.addControl(d_facility);
            //chk.addControl(t_name);
            //chk.addControl(t_name_kana);
            //chk.addControl(d_sex2);
            //chk.addControl(d_height);
            //chk.addControl(d_foot);
            //chk.addControl(d_sleeve);
            if (chk.check("W00000", chk.checkControlImportant))
                return;

            //桁数チェック
            //20
            chk.clear();
            chk.addControl(d_facility);
            chk.addControl(t_name);
            if (chk.check("W00001", chk.checkTextboxLength, 20))
                return;
            //40
            chk.clear();
            chk.addControl(t_name_kana);
            if (chk.check("W00001", chk.checkTextboxLength, 40))
                return;
            //4
            chk.clear();
            chk.addControl(d_height);
            chk.addControl(d_foot);
            chk.addControl(d_sleeve);
            if (chk.check("W00001", chk.checkTextboxLength, 4))
                return;
            //フォーマットチェック
            chk.clear();
            chk.addControl(d_height);
            chk.addControl(d_foot);
            chk.addControl(d_sleeve);
            if (chk.check("W00003", chk.checkTextboxFormat, @"^\d{1,4}?\z", @"半角数字"))
                return;

            for (int i = 0 ; d_renral_result.Rows.Count > i ; i++)
            {
                if(costumeReservationList[i].costume_reservation_code == "")
                    costumeReservationList[i].costume_reservation_code = DB.t_costume_reservation.getNewcostume_reservation_code();

                costumeReservationList[i].memo = d_renral_result.Rows[i].Cells[11].Value==null ? "" : d_renral_result.Rows[i].Cells[11].Value.ToString();
                if(d_Cancellation_date.Checked)
                    costumeReservationList[i].cancellation_date = d_Cancellation_date.Value;
                else
                    costumeReservationList[i].cancellation_date = null;
                costumeReservationList[i].shooting_purpose = Enum.GetNames(typeof(Utile.Data.撮影目的)).ToList()[ d_Shooting_purpose.SelectedIndex];
                costumeReservationList[i].facility = d_facility.Text;
                costumeReservationList[i].name = t_name.Text;
                costumeReservationList[i].name_kana = t_name_kana.Text;
                if(d_sex2.SelectedIndex != -1)
                    costumeReservationList[i].sex = d_sex2.SelectedIndex.ToString();
                else
                    costumeReservationList[i].sex = null;
                if(dt_birthday.Checked)
                    costumeReservationList[i].birthday = dt_birthday.Value;
                else
                    costumeReservationList[i].birthday = null;
                if(d_height.Text != "")
                    costumeReservationList[i].height = int.Parse( d_height.Text);
                else
                    costumeReservationList[i].height = null;
                if (d_foot.Text != "")
                    costumeReservationList[i].foot = int.Parse(d_foot.Text);
                else
                    costumeReservationList[i].foot = null;
                if (d_sleeve.Text != "")
                    costumeReservationList[i].sleeve = int.Parse(d_sleeve.Text);
                else
                    costumeReservationList[i].sleeve = null;

                costumeReservationList[i].Command();

                var res = new DB.t_reservation();
                res.costume_reservation_code = costumeReservationList[i].costume_reservation_code;
                res.reservation_code = MainForm.session_t_reception.reception_code;
                res.facility_reservation_code = "        ";

                res.Command();
            }

            pageParent.PageRefresh();
            MainForm.backPage(this);

        }

        private void b_return_Click(object sender, EventArgs e)
        {
            mod.chackMessage("戻る処理");
            pageParent.PageRefresh();
            MainForm.backPage(this);

        }

        private void b_delete_Click(object sender, EventArgs e)
        {

            for (int i = 0; d_renral_result.Rows.Count > i; i++)
            {
                if ((bool)d_renral_result.Rows[i].Cells[0].Value)
                {
                    if (costumeReservationList[i].costume_reservation_code != "")
                    {
                        costumeReservationList[i].Command(delete:true);

                        var res = DB.t_reservation.getSingleCostume_reservation_code(costumeReservationList[i].costume_reservation_code);
                        if(res !=null)
                            res.Command(delete: true);
                    }
                }
            }

            pageParent.PageRefresh();
            MainForm.backPage(this);
        }
        private void d_renral_result_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 2)
            {
                MainForm.Costume_master.PageRefresh(d_renral_result.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                MainForm.sendPage(this, MainForm.Costume_master);
            }
        }
    }
}
