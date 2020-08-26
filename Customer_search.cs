using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Diagnostics;

namespace 写真館システム
{
    public partial class Customer_search : UserControlExp
    {
        //日付データの変数宣言
        DateTime? birthday_from;
        DateTime? birthday_to;
        DateTime? wedding_anniversary_from;
        DateTime? wedding_anniversary_to;
        DateTime? family_birthday_from;
        DateTime? family_birthday_to;

        //顧客リスト
        List<DB.m_customer> Customers = new List<DB.m_customer>();

        //受付登録時に渡す変数を宣言
        static public String customer_code = null;
        static public String surname = null;
        static public String name = null;
        static public DateTime birthday;
        static public String sex = null;
        static public String postal_code = null;
        static public String address1 = null;
        static public String address2 = null;
        static public String address3 = null;
        static public String mail_address = null;
        static public String phone_number1 = null;
        static public String phone_number2 = null;
        static public String phone_number3 = null;
        static public DateTime f_birthday;


        public Customer_search()
        {
            InitializeComponent();

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            //テキストの初期化
            t_customer_code.Text = null;
            t_customer_name.Text = null;
            t_Customer_name_kana.Text = null;
            t_family_name.Text = null;
            t_family_name_kana.Text = null;
            t_family_zokugara.Text = null;
            t_phone_number.Text = null;


            //コンボボックス初期化
            d_seibetsu.DataSource = Enum.GetValues(typeof(Utile.Data.性別));
            d_seibetsu.SelectedIndex = -1;

            d_DM_shipping.DataSource = Enum.GetValues(typeof(Utile.Data.DM発送));
            d_DM_shipping.SelectedIndex = -1;

            d_member_lank.DataSource = Enum.GetValues(typeof(Utile.Data.ランク));
            d_member_lank.SelectedIndex = -1;

            d_member_type.DataSource = Enum.GetValues(typeof(Utile.Data.会員種別));
            d_member_type.SelectedIndex = -1;

            d_family_seibetsu.DataSource = Enum.GetValues(typeof(Utile.Data.性別));
            d_family_seibetsu.SelectedIndex = -1;


            //日付の初期化
            birthday_from = null;
            birthday_to = null;
            wedding_anniversary_from = null;
            wedding_anniversary_to = null;
            family_birthday_from = null;
            family_birthday_to = null;

            Set_d_birthday_from(birthday_from);
            Set_d_birthday_to(birthday_to);
            Set_d_wedding_anniversary_from(wedding_anniversary_from);
            Set_d_wedding_anniversary_to(wedding_anniversary_to);
            Set_d_family_birthday_from(family_birthday_from);
            Set_d_family_birthday_to(family_birthday_to);

            //表の初期化
            dataGridView1.Rows.Clear();

        }

        private void Set_d_birthday_from(DateTime? DateTime)
        {
            if (DateTime == null)
            {
                d_birthday_from.Format = DateTimePickerFormat.Custom;
                d_birthday_from.CustomFormat = " ";
            }
            else
            {
                d_birthday_from.Format = DateTimePickerFormat.Long;
                d_birthday_from.Value = (DateTime)DateTime;
            }
        }

        private void Set_d_birthday_to(DateTime? DateTime)
        {
            if (DateTime == null)
            {
                d_birthday_to.Format = DateTimePickerFormat.Custom;
                d_birthday_to.CustomFormat = " ";
            }
            else
            {
                d_birthday_to.Format = DateTimePickerFormat.Long;
                d_birthday_to.Value = (DateTime)DateTime;
            }
        }

        private void Set_d_wedding_anniversary_from(DateTime? DateTime)
        {
            if (DateTime == null)
            {
                d_wedding_anniversary_from.Format = DateTimePickerFormat.Custom;
                d_wedding_anniversary_from.CustomFormat = " ";
            }
            else
            {
                d_wedding_anniversary_from.Format = DateTimePickerFormat.Long;
                d_wedding_anniversary_from.Value = (DateTime)DateTime;
            }

        }

        private void Set_d_wedding_anniversary_to(DateTime? DateTime)
        {
            if (DateTime == null)
            {
                d_wedding_anniversary_to.Format = DateTimePickerFormat.Custom;
                d_wedding_anniversary_to.CustomFormat = " ";
            }
            else
            {
                d_wedding_anniversary_to.Format = DateTimePickerFormat.Long;
                d_wedding_anniversary_to.Value = (DateTime)DateTime;
            }
        }

        private void Set_d_family_birthday_from(DateTime? DateTime)
        {
            if (DateTime == null)
            {
                d_family_birthday_from.Format = DateTimePickerFormat.Custom;
                d_family_birthday_from.CustomFormat = " ";
            }
            else
            {
                d_family_birthday_from.Format = DateTimePickerFormat.Long;
                d_family_birthday_from.Value = (DateTime)DateTime;
            }

        }

        private void Set_d_family_birthday_to(DateTime? DateTime)
        {
            if (DateTime == null)
            {
                d_family_birthday_to.Format = DateTimePickerFormat.Custom;
                d_family_birthday_to.CustomFormat = " ";
            }
            else
            {
                d_family_birthday_to.Format = DateTimePickerFormat.Long;
                d_family_birthday_to.Value = (DateTime)DateTime;
            }
        }

        public override void PageRefresh()
        {
            //テキストの初期化
            t_customer_code.Text = null;
            t_customer_name.Text = null;
            t_Customer_name_kana.Text = null;
            t_family_name.Text = null;
            t_family_name_kana.Text = null;
            t_family_zokugara.Text = null;
            t_phone_number.Text = null;


            //コンボボックス初期化
            d_seibetsu.DataSource = Enum.GetValues(typeof(Utile.Data.性別));
            d_seibetsu.SelectedIndex = -1;

            d_DM_shipping.DataSource = Enum.GetValues(typeof(Utile.Data.DM発送));
            d_DM_shipping.SelectedIndex = -1;

            d_member_lank.DataSource = Enum.GetValues(typeof(Utile.Data.ランク));
            d_member_lank.SelectedIndex = -1;

            d_member_type.DataSource = Enum.GetValues(typeof(Utile.Data.会員種別));
            d_member_type.SelectedIndex = -1;

            d_family_seibetsu.DataSource = Enum.GetValues(typeof(Utile.Data.性別));
            d_family_seibetsu.SelectedIndex = -1;


            //日付の初期化
            birthday_from = null;
            birthday_to = null;
            wedding_anniversary_from = null;
            wedding_anniversary_to = null;
            family_birthday_from = null;
            family_birthday_to = null;

            Set_d_birthday_from(birthday_from);
            Set_d_birthday_to(birthday_to);
            Set_d_wedding_anniversary_from(wedding_anniversary_from);
            Set_d_wedding_anniversary_to(wedding_anniversary_to);
            Set_d_family_birthday_from(family_birthday_from);
            Set_d_family_birthday_to(family_birthday_to);

            //表の初期化
            dataGridView1.Rows.Clear();
        }

        private void b_return_Click(object sender, EventArgs e)
        {
            pageParent.PageRefresh();
            MainForm.backPage(this);
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            //表,変数の初期化
            dataGridView1.Rows.Clear();


            //結果格納クエリーの初期化
            NpgsqlDataReader customerReader = null;

            using (var db = new DB.DBConnect())
            {

                //条件文の設定
                String strSQLWHERE = "c.delete_flag = '0'";

                //顧客コード
                strSQLWHERE += t_customer_code.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
                strSQLWHERE += t_customer_code.Text != "" ? "c.customer_code LIKE" + "'%" + t_customer_code.Text + "%'" : "";

                //お客様姓名
                strSQLWHERE += t_customer_name.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
                strSQLWHERE += t_customer_name.Text != "" ? "c.surname || c.name LIKE " + "'%" + t_customer_name.Text + "%'" : "";

                //お客様姓名 カナ
                strSQLWHERE += t_Customer_name_kana.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
                strSQLWHERE += t_Customer_name_kana.Text != "" ? "c.surname_kana || c.name_kana LIKE " + "'%" + t_Customer_name_kana.Text + "%'" : "";

                //電話番号
                strSQLWHERE += t_phone_number.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
                strSQLWHERE += t_phone_number.Text != "" ? "c.phone_number1 LIKE " + "'%" + t_phone_number.Text + "%'" : "";

                //性別
                strSQLWHERE += d_seibetsu.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
                strSQLWHERE += d_seibetsu.Text != "" ? "c.sex = " + "'" + d_seibetsu.SelectedIndex + "'" : "";

                //DM発送可
                strSQLWHERE += d_DM_shipping.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
                strSQLWHERE += d_DM_shipping.Text != "" ? "c.dm_delivery = " + "'" + d_DM_shipping.SelectedIndex + "'" : "";

                //結婚記念日
                strSQLWHERE += wedding_anniversary_from != null && strSQLWHERE.Length > 0 ? " and " : "";
                strSQLWHERE += wedding_anniversary_from != null ? "c.wedding_anniversary >= " + "'" + wedding_anniversary_from + "'" : "";
                strSQLWHERE += wedding_anniversary_to != null && strSQLWHERE.Length > 0 ? " and " : "";
                strSQLWHERE += wedding_anniversary_to != null ? "c.wedding_anniversary <= " + "'" + wedding_anniversary_to + "'" : "";

                //生年月日
                strSQLWHERE += birthday_from != null && strSQLWHERE.Length > 0 ? " and " : "";
                strSQLWHERE += birthday_from != null ? "c.birthday >= " + "'" + birthday_from + "'" : "";
                strSQLWHERE += birthday_to != null && strSQLWHERE.Length > 0 ? " and " : "";
                strSQLWHERE += birthday_to != null ? "c.birthday <= " + "'" + birthday_to + "'" : "";

                if (c_member_search.Checked)
                {
                    //ランク
                    string member_lank = d_member_lank.SelectedIndex.ToString();
                    strSQLWHERE += d_member_lank.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
                    strSQLWHERE += d_member_lank.Text != "" ? "m.rank = " + "'" + member_lank + "'" : "";

                    //会員種別
                    string membership_type = (d_member_type.SelectedIndex + 1).ToString();
                    strSQLWHERE += d_member_type.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
                    strSQLWHERE += d_member_type.Text != "" ? "m.rank = " + "'" + membership_type + "'" : "";

                }

                if (c_family_search.Checked)
                {
                    //家族続柄
                    strSQLWHERE += t_family_zokugara.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
                    strSQLWHERE += t_family_zokugara.Text != "" ? "f.relationship LIKE " + "'%" + t_family_zokugara.Text + "%'" : "";

                    //お客様家族姓名
                    strSQLWHERE += t_family_name.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
                    strSQLWHERE += t_family_name.Text != "" ? "f.surname || f.name LIKE " + "'%" + t_family_name.Text + "%'" : "";

                    //お客様家族姓名かな
                    strSQLWHERE += t_family_name_kana.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
                    strSQLWHERE += t_family_name_kana.Text != "" ? "f.surname_kana || f.name_kana LIKE " + "'%" + t_family_name_kana.Text + "%'" : "";

                    //家族生年月日
                    strSQLWHERE += family_birthday_from != null && strSQLWHERE.Length > 0 ? " and " : "";
                    strSQLWHERE += family_birthday_from != null ? "f.birthday >= " + "'" + family_birthday_from + "'" : "";
                    strSQLWHERE += family_birthday_to != null && strSQLWHERE.Length > 0 ? " and " : "";
                    strSQLWHERE += family_birthday_to != null ? "f.birthday <= " + "'" + family_birthday_to + "'" : "";

                    //家族性別
                    strSQLWHERE += d_family_seibetsu.Text != "" && strSQLWHERE.Length > 0 ? " and " : "";
                    strSQLWHERE += d_family_seibetsu.Text != "" ? "f.sex = " + "'" + d_family_seibetsu.SelectedIndex + "'" : "";
                }
                strSQLWHERE = strSQLWHERE.Length > 0 ? " WHERE " + strSQLWHERE : "";


                //DBオープン
                db.npg.Open();
                StringBuilder sb = new StringBuilder();


                //SQL文の生成
                //家族情報を検索に含めてしまうと、一意に決まらないために
                //家族検索時だけ家族情報をリンクするように変更。
                if (c_family_search.Checked)
                {
                    sb.Append(@"SELECT 
                            c.customer_code	as customer_code,							
                            c.surname as surname,							
                            c.surname_kana as surname_kana,			
                            c.name as name,	
                            c.name_kana as name_kana,
                            c.birthday as birthday,				
                            c.sex as sex,			
                            c.dm_delivery as dm_delivery, 								
                            c.sample_availability as sample_availability,
                            c.postal_code as postal_code,				
                            c.address1 as address1,								
                            c.address2 as address2,								
                            c.address3 as address3,								
                            c.mail_address	as mail_address,
                            c.phone_number1 as phone_number1,
                            c.phone_number2 as phone_number2,								
                            c.phone_number3 as phone_number3,								
                            c.fax_number as fax_number, 								
                            c.wedding_anniversary as wedding_anniversary,
                            c.remarks as remarks,								
                            c.free_item1 as free_item1,								
                            c.free_item2 as free_item2,								
                            c.free_item3 as free_item3,								
                            c.reasons as reasons,
                            c.delete_flag,
                            m.date as dateofregistration,
                            m.rank as rank,
                            m.membership_type as membership_type,								
                            f.relationship as relationship,		
                            f.surname as f_surname,		
                            f.surname_kana as f_surname_kana,					
                            f.name as f_name,			
                            f.name_kana as f_name_kana,						
                            f.birthday as f_birthday,			
                            f.sex as f_sex,
                            r.status as status
                            ");
                    sb.Append(@"FROM
                            m_customer AS c
                            LEFT JOIN m_member AS m ON
                            c.customer_code = m.customer_code
                            LEFT JOIN m_family AS f ON
                            c.customer_code = f.customer_code
                            LEFT JOIN (
                            SELECT status,customer_code from t_reception 
                            WHERE status = '3') AS r ON 
                            c.customer_code = r.customer_code
                            ");
                    sb.Append(@strSQLWHERE);
                    sb.Append(@" ORDER BY c.customer_code");

                }
                else
                {
                    sb.Append(@"SELECT 
                            c.customer_code	as customer_code,							
                            c.surname as surname,							
                            c.surname_kana as surname_kana,			
                            c.name as name,	
                            c.name_kana as name_kana,
                            c.birthday as birthday,				
                            c.sex as sex,			
                            c.dm_delivery as dm_delivery, 								
                            c.sample_availability as sample_availability,
                            c.postal_code as postal_code,				
                            c.address1 as address1,								
                            c.address2 as address2,								
                            c.address3 as address3,								
                            c.mail_address	as mail_address,
                            c.phone_number1 as phone_number1,
                            c.phone_number2 as phone_number2,								
                            c.phone_number3 as phone_number3,								
                            c.fax_number as fax_number, 								
                            c.wedding_anniversary as wedding_anniversary,
                            c.remarks as remarks,								
                            c.free_item1 as free_item1,								
                            c.free_item2 as free_item2,								
                            c.free_item3 as free_item3,								
                            c.reasons as reasons,
                            c.delete_flag,
                            m.date as dateofregistration,
                            m.rank as rank,
                            m.membership_type as membership_type,
                            r.status as status
                            ");
                    sb.Append(@"FROM
                            m_customer AS c
                            LEFT JOIN m_member AS m ON
                            c.customer_code = m.customer_code
                            LEFT JOIN (
                            SELECT status,customer_code from t_reception 
                            WHERE status = '3' group by customer_code,status) AS r ON 
                            c.customer_code = r.customer_code
                            ");
                    sb.Append(@strSQLWHERE);
                    sb.Append(@" ORDER BY c.customer_code");
                }
                var command = new NpgsqlCommand(sb.ToString(), db.npg);

                customerReader = command.ExecuteReader();
                if (customerReader.HasRows)
                {
                    while (customerReader.Read())
                    {
                        //内規情報フラグ
                        var naiki = customerReader["status"].ToString() == "3" ? "★" : "";
                        //顧客コード
                        var customer_code = customerReader["customer_code"].ToString();
                        //名前
                        var fullname = customerReader["surname"].ToString() + customerReader["name"].ToString();
                        //名前カナ
                        var fullname_kana = customerReader["surname_kana"].ToString() + customerReader["name_kana"].ToString();
                        //電話番号
                        var phone_number = customerReader["phone_number1"].ToString();
                        //誕生日
                        DateTime.TryParse(customerReader["birthday"].ToString(), out DateTime birthday);
                        //性別
                        int intVal1 = int.Parse(customerReader["sex"].ToString());
                        var sex = (Utile.Data.性別)Enum.ToObject(typeof(Utile.Data.性別), intVal1);
                        //DM送付区分
                        int intVal2 = int.Parse(customerReader["dm_delivery"].ToString());
                        var dm_delivery = (Utile.Data.DM発送)Enum.ToObject(typeof(Utile.Data.DM発送), intVal2);
                        //郵便番号
                        var postal_code = customerReader["postal_code"].ToString();
                        //住所
                        var adress_123 = customerReader["address1"].ToString() + customerReader["address2"].ToString() + customerReader["address3"].ToString();
                        //結婚記念日
                        DateTime.TryParse(customerReader["wedding_anniversary"].ToString(), out DateTime wedding_anniversary);
                        //登録日
                        DateTime.TryParse(customerReader["dateofregistration"].ToString(), out DateTime dateofregistration);
                        var strdateofregistration = customerReader["dateofregistration"].ToString() != "" ? dateofregistration.ToShortDateString() : "";
                        //ランク
                        int.TryParse(customerReader["rank"].ToString(), out int intVal3);
                        var rank = (Utile.Data.ランク)Enum.ToObject(typeof(Utile.Data.ランク), intVal3);
                        var strrank = strdateofregistration != "" ? rank.ToString() : "";
                        //会員種別
                        int.TryParse((customerReader["membership_type"].ToString()), out int intVal4);
                        var membership_type = Enum.ToObject(typeof(Utile.Data.会員種別), intVal4).ToString() ;
                        var strmembership_type = strdateofregistration !="" ? membership_type.ToString() : "";

                        //家族検索時のみ
                        string family_name = "";
                        string relationship = "";
                        string family_sex = "";
                        string family_birth = "";

                        if (c_family_search.Checked == true)
                        {
                            //家族名前
                            family_name = customerReader["f_surname"].ToString() + customerReader["f_name"].ToString();
                            //続柄
                            relationship = customerReader["relationship"].ToString();
                            //性別
                            int.TryParse(customerReader["f_sex"].ToString(), out int intVal5);
                            family_sex = family_name != ""?(string)Enum.ToObject(typeof(Utile.Data.性別), intVal5).ToString():"";
                            if (DateTime.TryParse(customerReader["f_birthday"].ToString(), out DateTime f_birthday))
                            {
                                family_birth = f_birthday.ToShortDateString();
                            }
                            else
                            {
                                family_birth = "";
                            }
                        }


                        dataGridView1.Rows.Add(
                            naiki,
                            customer_code,
                            fullname,
                            fullname_kana,
                            phone_number,
                            birthday.ToShortDateString(),
                            dm_delivery,
                            sex,
                            postal_code,
                            adress_123,
                            wedding_anniversary.ToShortDateString(),
                            strdateofregistration,
                            strrank,
                            strmembership_type,
                            family_name,
                            relationship,
                            family_sex,
                            family_birth
                        );

                        //セッションデータへの引継ぎ用のリスト作成
                        DB.m_customer m_Customer = new DB.m_customer();

                        m_Customer.customer_code = customerReader["customer_code"].ToString();
                        m_Customer.surname = customerReader["surname"].ToString();
                        m_Customer.surname_kana = customerReader["surname_kana"].ToString();
                        m_Customer.name = customerReader["name"].ToString();
                        m_Customer.name_kana = customerReader["name_kana"].ToString();
                        m_Customer.birthday = DateTime.Parse(customerReader["birthday"].ToString());
                        m_Customer.sex = customerReader["sex"].ToString();
                        m_Customer.dm_delivery = customerReader["dm_delivery"].ToString();
                        m_Customer.sample_availability = customerReader["sample_availability"].ToString();
                        m_Customer.postal_code = customerReader["postal_code"].ToString();
                        m_Customer.address1 = customerReader["address1"].ToString();
                        m_Customer.address2 = customerReader["address2"].ToString();
                        m_Customer.address3 = customerReader["address3"].ToString();
                        m_Customer.mail_address = customerReader["mail_address"].ToString();
                        m_Customer.phone_number1 = customerReader["phone_number1"].ToString();
                        m_Customer.phone_number2 = customerReader["phone_number2"].ToString();
                        m_Customer.phone_number3 = customerReader["phone_number3"].ToString();
                        m_Customer.fax_number = customerReader["fax_number"].ToString();
                        m_Customer.wedding_anniversary = DateTime.Parse(customerReader["wedding_anniversary"].ToString());
                        m_Customer.remarks = customerReader["remarks"].ToString();
                        m_Customer.free_item1 = customerReader["free_item1"].ToString();
                        m_Customer.free_item2 = customerReader["free_item2"].ToString();
                        m_Customer.free_item3 = customerReader["free_item3"].ToString();
                        m_Customer.reasons = customerReader["reasons"].ToString();

                        Customers.Add(m_Customer);

                    }
                }
                else
                {
                    MessageBox.Show("検索結果が0件でした。", "お知らせ", MessageBoxButtons.OK);
                }
            }


        }


        //csv
        private void b_csv_Click(object sender, EventArgs e)
        {

        }


        private void b_print_Click(object sender, EventArgs e)
        {
            //顧客情報の登録
            string table = "Customer_Information";
            Utile.RepoerDB rdb = new Utile.RepoerDB(table);
            rdb.deleteAll();

            for (var i = 0; i < dataGridView1.RowCount; i++)
            {

                var families = DB.m_family.getOnlyCode(dataGridView1.Rows[i].Cells[1].Value.ToString());
                if (families.Any(x=>x!=null))
                {
                    foreach (var family in families)
                    {
                        Dictionary<string, string> dataitem = new Dictionary<string, string>();
                        dataitem.Add("customerCode", dataGridView1.Rows[i].Cells[1].Value.ToString());
                        var customer = DB.m_customer.getSingle(dataGridView1.Rows[i].Cells[1].Value.ToString());
                        dataitem.Add("customerSurNameKana", customer.surname_kana);
                        dataitem.Add("customerNamekana", customer.name_kana);
                        dataitem.Add("customerSurName", customer.surname);
                        dataitem.Add("customerName", customer.name);
                        dataitem.Add("customerBirthday", customer.birthday.ToLongDateString());
                        dataitem.Add("customerAge", getAge(customer.birthday).ToString());
                        dataitem.Add("customerSex", Enum.GetName(typeof(Utile.Data.性別), int.Parse(customer.sex)));
                        dataitem.Add("customerPostalNumber", customer.postal_code);
                        dataitem.Add("customerAddress1", customer.address1);
                        dataitem.Add("customerAddress2", customer.address2);
                        dataitem.Add("customerAddress3", customer.address3);
                        dataitem.Add("customerPhoneNumber1", customer.phone_number1);
                        dataitem.Add("customerPhoneNumber2", customer.phone_number2);
                        dataitem.Add("customerPhoneNumber3", customer.phone_number3);
                        dataitem.Add("customerFAX", customer.fax_number);
                        dataitem.Add("customerEMail", customer.mail_address);
                        var member = DB.m_member.getSingle(dataGridView1.Rows[i].Cells[1].Value.ToString());

                        if (member != null)
                        {

                            dataitem.Add("memberType", Enum.GetName(typeof(Utile.Data.会員種別), int.Parse(member.membership_type)));
                            dataitem.Add("memberJoinDate", member.date.ToLongDateString());

                        }

                        dataitem.Add("familySurnameKana", family.surname_kana);
                        dataitem.Add("familyNameKana", family.name_kana);
                        dataitem.Add("familySurname", family.surname);
                        dataitem.Add("familyName", family.name);
                        dataitem.Add("familyBirthday", family.birthday.Value.ToLongDateString());
                        dataitem.Add("familyAge", getAge(family.birthday.Value).ToString());
                        dataitem.Add("familySex", Enum.GetName(typeof(Utile.Data.性別), int.Parse(family.sex)));

                        rdb.insert(dataitem);

                    }
                }
                else
                {
                    Dictionary<string, string> dataitem = new Dictionary<string, string>();
                    dataitem.Add("customerCode", dataGridView1.Rows[i].Cells[1].Value.ToString());
                    var customer = DB.m_customer.getSingle(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    dataitem.Add("customerSurNameKana", customer.surname_kana);
                    dataitem.Add("customerNamekana", customer.name_kana);
                    dataitem.Add("customerSurName", customer.surname);
                    dataitem.Add("customerName", customer.name);
                    dataitem.Add("customerBirthday", customer.birthday.ToLongDateString());
                    dataitem.Add("customerAge", getAge(customer.birthday).ToString());
                    dataitem.Add("customerSex", Enum.GetName(typeof(Utile.Data.性別), int.Parse(customer.sex)));
                    dataitem.Add("customerPostalNumber", customer.postal_code);
                    dataitem.Add("customerAddress1", customer.address1);
                    dataitem.Add("customerAddress2", customer.address2);
                    dataitem.Add("customerAddress3", customer.address3);
                    dataitem.Add("customerPhoneNumber1", customer.phone_number1);
                    dataitem.Add("customerPhoneNumber2", customer.phone_number2);
                    dataitem.Add("customerPhoneNumber3", customer.phone_number3);
                    dataitem.Add("customerFAX", customer.fax_number);
                    dataitem.Add("customerEMail", customer.mail_address);

                    var member = DB.m_member.getSingle(dataGridView1.Rows[i].Cells[1].Value.ToString());
                    if (member != null)
                    {
                        dataitem.Add("memberType", Enum.GetName(typeof(Utile.Data.会員種別), int.Parse(member.membership_type)));
                        dataitem.Add("memberJoinDate", member.date.ToLongDateString());
                    }
                    rdb.insert(dataitem);
                }
            }
        

            PrintForm p = new PrintForm();

            p.PrintReport.Load(@"./Asset/Format/Customer_infomation.flxr", "顧客情報 レポート");
            p.c1FlexViewer.DocumentSource = p.PrintReport;
            p.Show();

        }

        //年齢計算
        private int getAge(DateTime birthday)
        {
            int age = DateTime.Now.Year - birthday.Year;
            if (DateTime.Now.Month < birthday.Month ||
               (DateTime.Now.Month == birthday.Month &&
                DateTime.Now.Day < birthday.Day))
            {
                age--;
            }
            return age;
        }

        private void d_birthday_from_ValueChanged(object sender, EventArgs e)
        {
            birthday_from = d_birthday_from.Value;
            Set_d_birthday_from(birthday_from);
        }

        private void d_birthday_from_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                birthday_from = null;
                Set_d_birthday_from(birthday_from);
            }
        }

        private void d_birthday_from_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 0 || e.Y > d_birthday_from.Height)
            {
                //［↓］キーを送信して、カレンダーをプルダウンさせる
                SendKeys.SendWait("%{DOWN}");
            }
        }

        private void d_birthday_to_ValueChanged(object sender, EventArgs e)
        {
            birthday_to = d_birthday_to.Value;
            Set_d_birthday_to(birthday_to);
        }

        private void d_birthday_to_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                birthday_to = null;
                Set_d_birthday_to(birthday_to);
            }
        }

        private void d_birthday_to_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 0 || e.Y > d_birthday_to.Height)
            {
                //［↓］キーを送信して、カレンダーをプルダウンさせる
                SendKeys.SendWait("%{DOWN}");
            }
        }

        private void d_wedding_anniversary_from_ValueChanged(object sender, EventArgs e)
        {
            wedding_anniversary_from = d_wedding_anniversary_from.Value;
            Set_d_wedding_anniversary_from(wedding_anniversary_from);
        }

        private void d_wedding_anniversary_from_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                wedding_anniversary_from = null;
                Set_d_wedding_anniversary_from(wedding_anniversary_from);
            }
        }

        private void d_wedding_anniversary_from_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 0 || e.Y > d_wedding_anniversary_from.Height)
            {
                //［↓］キーを送信して、カレンダーをプルダウンさせる
                SendKeys.SendWait("%{DOWN}");
            }
        }

        private void d_wedding_anniversary_to_ValueChanged(object sender, EventArgs e)
        {
            wedding_anniversary_to = d_wedding_anniversary_to.Value;
            Set_d_wedding_anniversary_to(wedding_anniversary_to);
        }

        private void d_wedding_anniversary_to_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                wedding_anniversary_to = null;
                Set_d_wedding_anniversary_to(wedding_anniversary_to);
            }
        }

        private void d_wedding_anniversary_to_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 0 || e.Y > d_wedding_anniversary_to.Height)
            {
                //［↓］キーを送信して、カレンダーをプルダウンさせる
                SendKeys.SendWait("%{DOWN}");
            }
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void d_family_birthday_from_ValueChanged(object sender, EventArgs e)
        {
            family_birthday_from = d_family_birthday_from.Value;
            Set_d_family_birthday_from(family_birthday_from);
        }

        private void d_family_birthday_from_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                family_birthday_from = null;
                Set_d_family_birthday_from(family_birthday_from);
            }
        }

        private void d_family_birthday_from_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 0 || e.Y > d_family_birthday_from.Height)
            {
                //［↓］キーを送信して、カレンダーをプルダウンさせる
                SendKeys.SendWait("%{DOWN}");
            }
        }

        private void d_family_birthday_to_ValueChanged(object sender, EventArgs e)
        {
            family_birthday_to = d_family_birthday_to.Value;
            Set_d_family_birthday_to(family_birthday_to);
        }

        private void d_family_birthday_to_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                family_birthday_to = null;
                Set_d_family_birthday_to(family_birthday_to);
            }
        }

        private void d_family_birthday_to_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Y < 0 || e.Y > d_family_birthday_to.Height)
            {
                //［↓］キーを送信して、カレンダーをプルダウンさせる
                SendKeys.SendWait("%{DOWN}");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                        
            //リストの位置の特定
            String selected_code = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            int IntVal = Customers.FindIndex(0, x => x.customer_code == selected_code);

            //セッションデータに情報をセット
            customer_code = Customers[IntVal].customer_code;
            surname = Customers[IntVal].surname;
            name = Customers[IntVal].name;
            birthday = Customers[IntVal].birthday;
            sex = Customers[IntVal].sex;
            postal_code = Customers[IntVal].postal_code;
            address1 = Customers[IntVal].address1;
            address2 = Customers[IntVal].address2;
            address3 = Customers[IntVal].address3;
            mail_address = Customers[IntVal].mail_address;
            phone_number1 = Customers[IntVal].phone_number1;
            phone_number2 = Customers[IntVal].phone_number2;
            phone_number3 = Customers[IntVal].phone_number3;

        }

        private void d_seibetsu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Delete)
            {
                d_seibetsu.SelectedIndex = -1;

            }

        }

        private void d_DM_shipping_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Delete)
            {
                d_DM_shipping.SelectedIndex = -1;
            }
        }

        private void d_member_lank_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Delete)
            {
                d_member_lank.SelectedIndex = -1;
            }
        }

        private void d_member_type_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Delete)
            {
                d_member_type.SelectedIndex = -1;
            }
        }

        private void d_family_seibetsu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Delete)
            {
                d_family_seibetsu.SelectedIndex = -1;
            }
        }

        private void b_SignUp_Click(object sender, EventArgs e)
        {
            MainForm.Customer_information.PageRefresh();
            MainForm.sendPage(this, MainForm.Customer_information);
        }

        private void dataGridView1CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(pageParent.Name == MainForm.Customer_information.Name)
            {

                MainForm.Customer_information.customer = DB.m_customer.getSingle(customer_code);
                MainForm.Customer_information.member = DB.m_member.getSingle(customer_code);
                using(var dbc = new DB.DBConnect())
                {
                    MainForm.Customer_information.familyList = new List<DB.m_family>();
                    var q = from t in dbc.m_family
                            where t.customer_code == customer_code && t.delete_flag == "0"
                            select t;
                    foreach(var data in q)
                    {
                        MainForm.Customer_information.familyList.Add(data);
                    }
                }
                MainForm.Customer_information.PageRefreshForEdit();
                MainForm.sendPage(this, MainForm.Customer_information);
                MainForm.Customer_information.pageParent = MainForm.Main_menu;
            }
            else
            {
                MainForm.Reception.pageParent = this;
                MainForm.Reception.PageRefresh();
                MainForm.sendPage(this, MainForm.Reception);
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }
    }
}
