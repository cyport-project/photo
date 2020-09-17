using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.IO;
using Npgsql;

namespace 写真館システム
{
    public partial class Customer_information : UserControlExp
    {
        public DB.m_customer customer;
        public DB.m_member member;
        public List<DB.m_family> familyList;

        //入力チェック
        private checkOperation chk;

        //変更チェック
        private modifyCheck mod;

        //受付登録時に渡す変数を宣言
        static public String customer_code = null;
        static public String surname = null;
        static public String name = null;
        static public DateTime? birthday;
        static public String sex = null;
        static public String postal_code = null;
        static public String address1 = null;
        static public String address2 = null;
        static public String address3 = null;
        static public String mail_address = null;
        static public String phone_number1 = null;
        static public String phone_number2 = null;
        static public String phone_number3 = null;

        public Customer_information()
        {
            InitializeComponent();

            //入力チェック初期化
            chk = new checkOperation(this);

            //変更チェック初期化
            mod = new modifyCheck();
            mod.add(co_Membership_type);
            mod.add(co_Rank);
            mod.add(co_Registered_store);
            mod.add(co_Sex);
            mod.add(co_Visit_motive);
            mod.add(t_Address2);
            mod.add(t_Apartment_mansion);
            mod.add(t_Customer_code);
            mod.add(t_surname_kana);
            mod.add(t_surname);
            mod.add(t_Fax);
            mod.add(t_Free_item1);
            mod.add(t_Free_item2);
            mod.add(t_Free_item3);
            mod.add(t_Phone_number1);
            mod.add(t_Phone_number2);
            mod.add(t_Phone_number3);
            mod.add(t_Postal_code);
            mod.add(t_Pref_city_town_village_name);
            mod.add(t_Registration_officer);
            mod.add(t_Remark);
            mod.add(da_Birthday);
            mod.add(da_Customer_wedding_anniversary);
            mod.add(da_Registration_date);
            mod.add(dataGridView1);
            
        }
        //
        //ページの初期化（新規追加）
        //
        public override void PageRefresh()
        {
            customer = new DB.m_customer();
            member = new DB.m_member();
            familyList = new List<DB.m_family>();

            //Comboboxの設定
            co_Sex.DataSource = Enum.GetValues(typeof(Utile.Data.性別));
            co_Visit_motive.DataSource = Enum.GetValues(typeof(Utile.Data.来店動機));
            co_Registered_store.DataSource = DB.m_store.getStoreNameList();
            co_Rank.DataSource = Enum.GetValues(typeof(Utile.Data.ランク));
            co_Membership_type.DataSource = Enum.GetValues(typeof(Utile.Data.会員種別));

            //データを設定
            t_Pref_city_town_village_name.Text = "";
            t_Address2.Text = "";
            t_Apartment_mansion.Text = "";
            da_Birthday.Value = DateTime.Now.Date;
            t_Customer_code.Text = "";
            ch_DM_Available.Checked = false;
            t_Fax.Text = "";
            t_Free_item1.Text = "";
            t_Free_item2.Text = "";
            t_Free_item3.Text = "";
            t_mail.Text = "";
            t_name.Text = "";
            t_name_kana.Text = "";
            t_Phone_number1.Text = "";
            t_Phone_number2.Text = "";
            t_Phone_number3.Text = "";
            t_Postal_code.Text = "";
            co_Visit_motive.SelectedIndex = 0;
            t_Remark.Text = "";
            ch_Sample.Checked = false;
            co_Sex.SelectedIndex = 0;
            t_surname.Text = "";
            t_surname_kana.Text = "";
            da_Customer_wedding_anniversary.Value = DateTime.Now.Date;

            da_Registration_date.Value = da_Registration_date.MinDate;
            co_Membership_type.SelectedIndex = 0;
            co_Rank.SelectedIndex = 0;
            t_Registration_officer.Text = "";
            co_Registered_store.SelectedIndex = 0;
            
            dataGridView1.Rows.Clear();

            //変更チェックリセット
            mod.reset();

            //入力チェックリセット
            chk.clear();

            //一覧クリア
            dataGridView2.Rows.Clear();
            dataGridView4.Rows.Clear();
            listView1.Items.Clear();
        }

        //
        //ページ初期化（編集）
        //
        public void PageRefreshForEdit()
        {
            //一覧クリア
            dataGridView2.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView1.Rows.Clear();
            listView1.Items.Clear();

            //Comboboxの設定
            co_Sex.DataSource = Enum.GetValues(typeof(Utile.Data.性別));
            co_Visit_motive.DataSource = Enum.GetValues(typeof(Utile.Data.来店動機));
            co_Registered_store.DataSource = DB.m_store.getStoreNameList();
            co_Rank.DataSource = Enum.GetValues(typeof(Utile.Data.ランク));
            co_Membership_type.DataSource = Enum.GetValues(typeof(Utile.Data.会員種別));

            //データを設定
            t_Pref_city_town_village_name.Text = customer.address1;
            t_Address2.Text = customer.address2;
            t_Apartment_mansion.Text  = customer.address3;
            da_Birthday.Value = customer.birthday;
            t_Customer_code.Text = customer.customer_code;
            ch_DM_Available.Checked = (int.Parse(customer.dm_delivery) == (int)Utile.Data.DM送付区分.送付可 ? true : false);
            t_Fax.Text = customer.fax_number;
            t_Free_item1.Text = customer.free_item1;
            t_Free_item2.Text = customer.free_item2;
            t_Free_item3.Text = customer.free_item3;
            t_mail.Text = customer.mail_address;
            t_name.Text = customer.name;
            t_name_kana.Text = customer.name_kana;
            t_Phone_number1.Text = customer.phone_number1;
            t_Phone_number2.Text = customer.phone_number2;
            t_Phone_number3.Text = customer.phone_number3;
            t_Postal_code.Text = customer.postal_code;
            co_Visit_motive.SelectedIndex = (int)Enum.Parse(typeof(Utile.Data.来店動機), customer.reasons);
            t_Remark.Text = customer.remarks;
            ch_Sample.Checked = (int.Parse(customer.sample_availability) == (int)Utile.Data.サンプル可否.送付可 ? true : false);
            co_Sex.SelectedIndex = int.Parse(customer.sex);
            t_surname.Text = customer.surname;
            t_surname_kana.Text = customer.surname_kana;
            da_Customer_wedding_anniversary.Value = customer.wedding_anniversary;
            if(member == null)
            {
                da_Registration_date.Value = da_Registration_date.MinDate;
                co_Membership_type.SelectedIndex = 0;
                co_Rank.SelectedIndex = 0;
                t_Registration_officer.Text = "";
                co_Registered_store.SelectedIndex = 0;
            }
            else
            {
                da_Registration_date.Value = member.date;
                co_Membership_type.SelectedIndex = int.Parse(member.membership_type);
                co_Rank.SelectedIndex = int.Parse(member.rank);
                t_Registration_officer.Text = member.staff;
                co_Registered_store.SelectedIndex = co_Registered_store.FindStringExact(DB.m_store.getSingleName(member.store).store_name);
            }

            //最終利用店舗
            using(var dbc = new DB.DBConnect())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("select rec.store ");
                sb.Append("from m_customer as cus ");
                sb.Append("left join t_reception as rec ");
                sb.Append("on rec.customer_code = cus.customer_code ");
                sb.Append("where cus.customer_code = @customer_code ");
                sb.Append("and cus.delete_flag = '0' ");
                sb.Append("order by rec.receipt_date desc limit 1 ");

                dbc.npg.Open();

                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                command.Parameters.Add(new NpgsqlParameter("@customer_code", customer.customer_code));
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    l_Last_use_store.Text = dataReader["store"].ToString();
                }
                
            }

            foreach (var family in familyList)
            {
                dataGridView1.Rows.Add(
                    family.relationship,
                    family.surname,
                    family.name,
                    family.surname_kana,
                    family.name_kana,
                    family.birthday.Value.ToString("yyyy/MM/dd"),
                    Enum.GetName(typeof(Utile.Data.性別), int.Parse(family.sex)),
                    family.remarks
                );
            }
            
            //変更チェックリセット
            mod.reset();

            //入力チェックリセット
            chk.clear();

            //一覧の設定
            using (var dbc = new DB.DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select to_char(rec.receipt_date, 'yyyy/mm/dd') as receipt_date ");
                sb.Append(@", rec.store ");
                sb.Append(@", to_char(fr.start_date, 'yyyy/mm/dd') || ' ' || to_char(fr.start_time, 'hh:mm') || ' ~ ' || to_char(fr.end_date, 'yyyy/mm/dd') || ' ' || to_char(fr.end_time, 'hh:mm') as date ");
                sb.Append(@", fac.facility_name ");
                sb.Append(@", cus.surname || ' ' || cus.name as name ");
                sb.Append(@", cus.sex ");
                sb.Append(@", fr.shooting_purpose ");
                sb.Append(@"from t_reception as rec ");
                sb.Append(@"left join t_reservation as res ");
                sb.Append(@"on rec.reception_code = res.reception_code ");
                sb.Append(@"left join t_facility_reservation as fr ");
                sb.Append(@"on fr.facility_reservation_code = res.facility_reservation_code ");
                sb.Append(@"left join m_facility as fac ");
                sb.Append(@"on fac.facility_code = fr.facility_code ");
                sb.Append(@"left join m_customer as cus ");
                sb.Append(@"on cus.customer_code = rec.customer_code "); 
                sb.Append(@"where rec.customer_code = @customer_code ");
                sb.Append(@"and cus.delete_flag = '0' ");
                sb.Append(@"order by rec.receipt_date, rec.store, fr.start_date, fr.start_time, fr.end_date, fr.end_time, fac.facility_name, cus.surname, cus.name, cus.sex, fr.shooting_purpose ASC ");

                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                command.Parameters.Add(new NpgsqlParameter("@customer_code", customer.customer_code));
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    dataGridView2.Rows.Add(
                        dataReader["receipt_date"],
                        dataReader["store"],
                        dataReader["date"],
                        dataReader["facility_name"],
                        dataReader["name"],
                        Enum.GetName(typeof(Utile.Data.性別), int.Parse(dataReader["sex"].ToString())),
                        dataReader["shooting_purpose"]
                        );
                }
            }

            using (var dbc = new DB.DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select to_char(rec.receipt_date, 'yyyy/mm/dd') || ' ' || to_char(rec.receipt_time, 'hh:mm') as date ");
                sb.Append(@", rec.store ");
                sb.Append(@", rec.staff ");
                sb.Append(@", cus.surname || ' ' || cus.name as name ");
                sb.Append(@", rec.status ");
                sb.Append(@", rec.memo ");
                sb.Append(@"from t_reception as rec ");
                sb.Append(@"left join m_customer as cus ");
                sb.Append(@"on cus.customer_code = rec.customer_code ");
                sb.Append(@"where rec.customer_code = @customer_code ");
                sb.Append(@"and rec.customer_code = @customer_code ");
                sb.Append(@"and cus.delete_flag = '0' ");
                sb.Append(@"order by rec.receipt_date, rec.receipt_time, rec.store, rec.staff, cus.surname, cus.name, rec.status, rec.memo ASC ");

                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                command.Parameters.Add(new NpgsqlParameter("@customer_code", customer.customer_code));
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    dataGridView4.Rows.Add(
                        dataReader["date"],
                        dataReader["store"],
                        dataReader["staff"],
                        dataReader["name"],
                        Enum.GetName(typeof(Utile.Data.受付ステータス), int.Parse(dataReader["status"].ToString())),
                        dataReader["memo"]
                        );
                }

            }

            //写真挿入
            var photo_root = System.Configuration.ConfigurationManager.AppSettings["photo_root"];
            var Secondary_Select = System.Configuration.ConfigurationManager.AppSettings["Secondary_Select"];
            var Secondary_Select_dir = System.IO.Path.Combine(photo_root, Secondary_Select);

            List<string[]> photoPathList = new List<string[]>();

            using (var dbc = new DB.DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select sel.folder_name ");
                sb.Append(@"from t_reception as rec ");
                sb.Append(@"left join t_selection as sel ");
                sb.Append(@"on sel.reception_code = rec.reception_code ");
                sb.Append(@"where rec.customer_code = @customer_code ");
                sb.Append(@"group by sel.folder_name ");

                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                command.Parameters.Add(new NpgsqlParameter("@customer_code", customer.customer_code));
                var dataReader = command.ExecuteReader();
                int index = 0;
                while (dataReader.Read())
                {
                    var path = System.IO.Path.Combine(Secondary_Select_dir, dataReader["folder_name"].ToString().Trim());
                    if (File.Exists(path))
                    {
                        foreach (string p in System.IO.Directory.GetFiles(path, "*", System.IO.SearchOption.AllDirectories))
                        {
                            //サムネイル作成
                            Size ts = new Size();
                            PointF tp = new PointF();
                            Bitmap img = new Bitmap(p);
                            if (img.Size.Width > img.Size.Height)
                            {
                                ts = new Size(img.Size.Width, img.Size.Width);
                                tp = new PointF(0, (img.Size.Width - img.Size.Height) / 2);
                            }
                            else
                            {
                                ts = new Size(img.Size.Height, img.Size.Height);
                                tp = new PointF((img.Size.Height - img.Size.Width) / 2, 0);
                            }
                            Bitmap tb = new Bitmap(ts.Width, ts.Height);
                            Graphics tg = Graphics.FromImage(tb);
                            tg.Clear(Color.White);
                            tg.DrawImage(img, tp.X, tp.Y, img.Width, img.Height);
                            img.Dispose();
                            tg.Dispose();

                            this.imageList1.Images.Add("", tb);
                            tb.Dispose();

                            ListViewItem lvi = new ListViewItem("");
                            lvi.ImageIndex = index++;
                            this.listView1.Items.Add(lvi);
                        }
                    }
                }

            }

        }

        private void b_customer_search_Click(object sender, EventArgs e)
        {
            if (!mod.chackMessage("顧客検索への遷移"))
                return;

            MainForm.Customer_search.PageRefresh();
            MainForm.sendPage(this, MainForm.Customer_search);

        }

        private void b_Reception_Click(object sender, EventArgs e)
        {
            if (!mod.chackMessage("受付登録への遷移"))
                return;
            if(customer_code == null)
            {
                Utile.Message.showMessageOK("W09006");
                return;
            }
            MainForm.Reception.pageParent = this;
            MainForm.Reception.PageRefresh();
            MainForm.sendPage(MainForm.Main_menu, MainForm.Reception);
            this.Visible = false;


        }

        private void touroku_Click(object sender, EventArgs e)
        {
            //新規登録時の重複チェック
            if(mod.controlCloneList[t_Customer_code.Name].ToString() == "")
            {
                using(var dbc = new DB.DBConnect())
                {
                //                    var q = from t in dbc.t_facility_reservation
                //                            where t.facility_reservation_code.Trim() == t_Customer_code.Text
                var q = from t in dbc.m_customer
                        where t.customer_code == t_Customer_code.Text
                        select t;
                    //登録済みコードかチェック
                    if(q.ToList().Count != 0)
                    {
                        if(Utile.Message.showMessageOKCancel("W09007") == DialogResult.Cancel)
                            return;
                    }

                }
            }

            //入力チェック
            chk.clear();
            //　必須チェック
            chk.addControl(t_Customer_code);
            chk.addControl(t_name);
            chk.addControl(t_name_kana);
            chk.addControl(da_Birthday);
            chk.addControl(t_Postal_code);
            chk.addControl(t_Pref_city_town_village_name);
            chk.addControl(t_Address2);
            chk.addControl(t_surname);
            chk.addControl(t_surname_kana);
            if (chk.check("W00000", chk.checkControlImportant))
                return;
            chk.clear();

            //　フォーマットチェック
            //　　電話番号
            chk.addControl(t_Phone_number1);
            chk.addControl(t_Phone_number2);
            chk.addControl(t_Phone_number3);
            chk.addControl(t_Fax);
            if (chk.check("W00003", chk.checkTextboxFormat, @"\A0\d{1,4}-\d{1,4}-\d{4}\z", "000-0000-0000"))
                return;
            chk.clear();
            
            //　　メールアドレス
            chk.addControl(t_mail);
            if (chk.check("W00003", chk.checkTextboxFormat, @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", "aaa@bbbb.com"))
                return;
            chk.clear();
            
            //　　郵便番号
            chk.addControl(t_Postal_code);
            if (chk.check("W00003", chk.checkTextboxFormat, @"\A\d\d\d-\d\d\d\d\z", "000-0000"))
                return;
            chk.clear();

            //　桁数チェック
            //　　8
            chk.addControl(t_Customer_code);
            chk.addControl(t_Postal_code);
            if (chk.check("W00001", chk.checkTextboxLength, 8))
                return;
            chk.clear();
            //　　10
            chk.addControl(t_name);
            chk.addControl(t_surname);
            if (chk.check("W00001", chk.checkTextboxLength, 10))
                return;
            chk.clear();
            //　　13
            chk.addControl(t_Phone_number1);
            chk.addControl(t_Phone_number2);
            chk.addControl(t_Phone_number3);
            chk.addControl(t_Fax);
            if (chk.check("W00001", chk.checkTextboxLength, 13))
                return;
            chk.clear();
            //　　20
            chk.addControl(t_name_kana);
            chk.addControl(t_surname_kana);
            if (chk.check("W00001", chk.checkTextboxLength, 20))
                return;
            chk.clear();
            //　　60
            chk.addControl(t_Pref_city_town_village_name);
            chk.addControl(t_Address2);
            chk.addControl(t_Apartment_mansion);
            chk.addControl(t_Free_item1);
            chk.addControl(t_Free_item2);
            chk.addControl(t_Free_item3);
            if (chk.check("W00001", chk.checkTextboxLength, 60))
                return;
            chk.clear();
            //　　255
            chk.addControl(t_mail);
            chk.addControl(t_Remark);
            if (chk.check("W00001", chk.checkTextboxLength, 225))
                return;
            chk.clear();


            //変数に挿入
            address1 = customer.address1 = t_Pref_city_town_village_name.Text;
            address2 = customer.address2 = t_Address2.Text;
            address3 = customer.address3 = t_Apartment_mansion.Text;
            birthday = customer.birthday = da_Birthday.Value;
            customer_code = customer.customer_code = t_Customer_code.Text;
            customer.dm_delivery = (ch_DM_Available.Checked ? (int)Utile.Data.DM送付区分.送付可 : (int)Utile.Data.DM送付区分.送付不可).ToString();
            customer.fax_number = t_Fax.Text;
            customer.free_item1 = t_Free_item1.Text;
            customer.free_item2 = t_Free_item2.Text;
            customer.free_item3 = t_Free_item3.Text;
            mail_address = customer.mail_address = t_mail.Text;
            name = customer.name = t_name.Text;
            customer.name_kana = t_name_kana.Text;
            phone_number1 = customer.phone_number1 = t_Phone_number1.Text;
            phone_number2 = customer.phone_number2 = t_Phone_number2.Text;
            phone_number3 =  customer.phone_number3 = t_Phone_number3.Text;
            postal_code = customer.postal_code = t_Postal_code.Text;
            customer.reasons = co_Visit_motive.SelectedItem.ToString();
            customer.remarks = t_Remark.Text;
            customer.sample_availability = (ch_Sample.Checked ? (int)Utile.Data.サンプル可否.送付可 : (int)Utile.Data.サンプル可否.送付不可).ToString();
            sex = customer.sex = (co_Sex.SelectedIndex == (int)Utile.Data.性別.女 ? (int)Utile.Data.性別.女 : (int)Utile.Data.性別.男).ToString();
            surname = customer.surname = t_surname.Text;
            customer.surname_kana = t_surname_kana.Text;
            customer.wedding_anniversary = da_Customer_wedding_anniversary.Value;

            if(da_Registration_date.Value != da_Registration_date.MinDate)
            {
                member = new DB.m_member();
                member.customer_code = t_Customer_code.Text;
                member.date = da_Registration_date.Value;
                member.membership_type = co_Membership_type.SelectedIndex.ToString();
                member.rank = co_Rank.SelectedIndex.ToString();
                member.staff = MainForm.session_m_staff.staff_name;
                member.store = DB.m_store.getSingle( MainForm.session_m_staff.store_code).store_name;
            }

            foreach (var family in familyList)
            {
                family.Command(delete: true);
            }
            familyList.Clear();
            
            foreach (var family in dataGridView1.Rows.Cast<DataGridViewRow>())
            {
                if (family.Cells["続柄"].Value == null
                    && family.Cells["姓"].Value == null
                    && family.Cells["姓カナ"].Value == null
                    && family.Cells["名"].Value == null
                    && family.Cells["名カナ"].Value == null
                    && family.Cells["誕生日"].Value == null
                    && family.Cells["性別"].Value == null
                    && family.Cells["備考"].Value == null)
                    continue;
                DB.m_family data = new DB.m_family();
                data.customer_code = t_Customer_code.Text;
                data.branch_number = family.Index;

                if (family.Cells["続柄"].Value != null)
                    data.relationship = family.Cells["続柄"].Value.ToString();
                else
                {
                    Utile.Message.showMessageOK("I09003");
                    return;
                }
                if (family.Cells["姓"].Value != null)
                    data.surname = family.Cells["姓"].Value.ToString();
                else
                {
                    Utile.Message.showMessageOK("I09003");
                    return;
                }
                if (family.Cells["姓カナ"].Value != null)
                    data.surname_kana = family.Cells["姓カナ"].Value.ToString();
                else
                {
                    Utile.Message.showMessageOK("I09003");
                    return;
                }
                if (family.Cells["名"].Value != null)
                    data.name = family.Cells["名"].Value.ToString();
                else
                {
                    Utile.Message.showMessageOK("I09003");
                    return;
                }
                if (family.Cells["名カナ"].Value != null)
                    data.name_kana = family.Cells["名カナ"].Value.ToString();
                else
                {
                    Utile.Message.showMessageOK("I09003");
                    return;
                }
                DateTime tmp = DateTime.MinValue;
                if (family.Cells["誕生日"].Value != null )
                    if(DateTime.TryParse(family.Cells["誕生日"].Value.ToString(), out tmp))
                        data.birthday = tmp;
                    else
                    {
                        Utile.Message.showMessageOK("I09004");
                        return;
                    }
                else
                {
                    Utile.Message.showMessageOK("I09003");
                    return;
                }
                if (family.Cells["性別"].Value != null)
                    if (Utile.Data.性別.女.ToString() == family.Cells["性別"].Value.ToString() || Utile.Data.性別.男.ToString() == family.Cells["性別"].Value.ToString())
                        data.sex = (family.Cells["性別"].Value.ToString() == Utile.Data.性別.女.ToString() ? (int)Utile.Data.性別.女 : (int)Utile.Data.性別.男).ToString();
                    else
                    {
                        Utile.Message.showMessageOK("I09005");
                        return;
                    }
                else
                {
                    Utile.Message.showMessageOK("I09003");
                    return;
                }
                if (family.Cells["備考"].Value != null)
                    data.remarks = family.Cells["備考"].Value.ToString();
                else
                {
                    data.remarks = null;
                }

                familyList.Add(data);
            }

            customer.Command();
            if(da_Registration_date.Value != da_Registration_date.MinDate)
                member.Command();
            foreach(var family in familyList)
            {
                family.Command();
            }

            //変更チェックリセット
            mod.reset();

            Utile.Message.showMessageOK("I09001");
        }

        private void b_delete_Click(object sender, EventArgs e)
        {
            if (!mod.chackMessage("削除"))
                return;

            if(DB.m_customer.getSingle(customer.customer_code) != null)
            {
                customer.Command(delete:true);
                if(member != null)
                    member.Command(delete: true);
                foreach (var family in familyList)
                {
                    family.Command(delete: true);
                }
            }
            else
            {
                Utile.Message.showMessageOK("W09000");
                return;
            }
            PageRefresh();
            Utile.Message.showMessageOK("I09002");
        }

        private void b_Return_Click(object sender, EventArgs e)
        {
            if (!mod.chackMessage("戻る処理"))
                return;

            MainForm.Main_menu.PageRefresh();
            MainForm.sendPage(this, MainForm.Main_menu);
        }

        private void b_Postal_code_search_Click(object sender, EventArgs e)
        {
            string Address;         //住所
            Boolean blnFlag = false;  //見つかったかどうかのフラグ

            //郵便番号が入力されていないとき
            if (t_Postal_code.Text == "")
            {
                MessageBox.Show("郵便番号が入力されていません。");
                this.t_Postal_code.Focus();
                return; //処理を抜ける
            }
            //マウスカーソルを砂時計にする
            Cursor.Current = Cursors.WaitCursor;
            string sKey = t_Postal_code.Text;
            //文字列の前後のスペースをとる
            sKey = sKey.Trim(' ');
            //Microsoft.VisualBasic名前空間のStrConv関数を使って、
            //全角文字を半角文字に変換
            sKey = Strings.StrConv(sKey, VbStrConv.Narrow, 0);
            // 文字列の長さを取得する
            int iLength = sKey.Length;
            if (iLength == 8)　//"-"が含まれている
            {
                // 先頭文字目の後から '-' を検索し、見つかった位置を取得する
                int iFind = sKey.IndexOf('-', 0);
                //左から3文字+"-"文字以降をtmpZip変数に代入
                sKey = sKey.Substring(0, 3) + sKey.Substring(iFind + 1);
            }
            try
            {
                //StreamReaderオブジェクトの作成
                StreamReader sr = new StreamReader("Asset\\KEN_ALL.CSV",
                                                Encoding.Default);
                //1行ずつ読み込み
                string dat;
                while ((dat = sr.ReadLine()) != null)
                {
                    string tmpZip;

                    //カンマで区切られた文字列を取得
                    string[] sbuf = dat.Split(',');
                    //配列の3番目が郵便番号
                    tmpZip = sbuf[2].Trim('"');

                    //入力された郵便番号と比較
                    if (sKey == tmpZip)
                    {
                        //住所を作成
                        //都道府県名+市区町村名+町域名
                        Address = sbuf[6].Trim('"') +
                                  sbuf[7].Trim('"') +
                                  sbuf[8].Trim('"');

                        //テキストボックスに住所を表示
                        t_Pref_city_town_village_name.Text = Address;
                        blnFlag = true; //フラグをTrueにして
                        break;          //ループを抜ける
                    }
                    Application.DoEvents();
                }
                //ファイルを閉じる
                sr.Close();
            }
            catch (Exception ex)
            {
                //ファイルエラーが発生
                MessageBox.Show(ex.Message, "ファイルエラー",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                return; //処理を抜ける
            }
            finally
            {
                //マウスカーソルをデフォルトにする
                Cursor.Current = Cursors.Default;

            }
            if (blnFlag == false)
            {
                MessageBox.Show("該当の郵便番号は見つかりませんでした。",
                                "郵便番号検索",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void b_Address_search_Click(object sender, EventArgs e)
        {

            string PostalCode;         //住所
            Boolean blnFlag = false;  //見つかったかどうかのフラグ

            //郵便番号が入力されていないとき
            if (t_Pref_city_town_village_name.Text == "")
            {
                MessageBox.Show("住所が入力されていません。");
                this.t_Postal_code.Focus();
                return; //処理を抜ける
            }
            //マウスカーソルを砂時計にする
            Cursor.Current = Cursors.WaitCursor;
            string sKey = t_Pref_city_town_village_name.Text;
            //文字列の前後のスペースをとる
            sKey = sKey.Trim(' ');

            try
            {
                //StreamReaderオブジェクトの作成
                StreamReader sr = new StreamReader("Asset\\KEN_ALL.CSV",
                                                Encoding.Default);
                //1行ずつ読み込み
                string dat;
                while ((dat = sr.ReadLine()) != null)
                {
                    string tmpAdd;

                    //カンマで区切られた文字列を取得
                    string[] sbuf = dat.Split(',');
                    //都道府県名+市区町村名+町域名
                    tmpAdd = sbuf[6].Trim('"') +
                            sbuf[7].Trim('"') +
                            sbuf[8].Trim('"');

                    //入力された郵便番号と比較
                    if (sKey == tmpAdd)
                    {
                        //郵便番号を作成
                        //都道府県名+市区町村名+町域名
                        PostalCode = sbuf[2].Trim('"').Insert(3,"-");

                        //テキストボックスに住所を表示
                        t_Postal_code.Text = PostalCode;
                        blnFlag = true; //フラグをTrueにして
                        break;          //ループを抜ける
                    }
                    Application.DoEvents();
                }
                //ファイルを閉じる
                sr.Close();
            }
            catch (Exception ex)
            {
                //ファイルエラーが発生
                MessageBox.Show(ex.Message, "ファイルエラー",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                return; //処理を抜ける
            }
            finally
            {
                //マウスカーソルをデフォルトにする
                Cursor.Current = Cursors.Default;

            }
            if (blnFlag == false)
            {
                MessageBox.Show("該当の住所は見つかりませんでした。",
                                "住所検索",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void da_Birthday_ValueChanged(object sender, EventArgs e)
        {
            l_age.Text = GetAge(da_Birthday.Value, DateTime.Now.Date).ToString() + "歳";
        }

        private static int GetAge(DateTime birthDate, DateTime today)
        {
            int age = today.Year - birthDate.Year;
            //誕生日がまだ来ていなければ、1引く
            if (today.Month < birthDate.Month ||
                (today.Month == birthDate.Month &&
                today.Day < birthDate.Day))
            {
                age--;
            }

            return age;
        }

        private void b_Family_delete_Click(object sender, EventArgs e)
        {
            var rcount = dataGridView1.Rows.Count;
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                if(rcount-1 > r.Index)
                    dataGridView1.Rows.RemoveAt(r.Index);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void l_Fax_Click(object sender, EventArgs e)
        {

        }

        private void l_Cutoner_name_rubi_Click(object sender, EventArgs e)
        {

        }
    }
}
