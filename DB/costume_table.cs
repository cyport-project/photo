using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;        // 参照を追加。
using System.ComponentModel.DataAnnotations.Schema; // 参照を追加。
using Npgsql;

namespace 写真館システム.DB
{
    // テーブルの名前とスキーマ名を入力。
    //テーブルごとに生成する
    [Table("m_costume", Schema = "public")]
    public class m_costume : base_table
    {
        [Key] // 主キーを設定。
        //店舗コード
        [Column("store_code", Order = 0)] // データベース上のカラム名を入力。
        public String store_code { get; set; }


        [Key] // 主キーを設定。
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        //衣装コード
        [Column("costume_code", Order = 1)] // データベース上のカラム名を入力。
        public String costume_code { get; set; }

        //衣装名
        [Column("costume_name")] // データベース上のカラム名を入力。
        public String costume_name { get; set; }

        //サイズ
        [Column("size")] // データベース上のカラム名を入力。
        public String size { get; set; }

        //性別
        [Column("sex")] // データベース上のカラム名を入力。
        public String sex { get; set; }

        //ブランド名
        [Column("brand_name")] // データベース上のカラム名を入力。
        public String brand_name { get; set; }

        //ランク
        [Column("rank")] // データベース上のカラム名を入力。
        public String rank { get; set; }

        //使用可否
        [Column("usability")] // データベース上のカラム名を入力。
        public String usability { get; set; }

        //価格1
        [Column("price1")] // データベース上のカラム名を入力。
        public int price1 { get; set; }

        //価格2
        [Column("price2")] // データベース上のカラム名を入力。
        public int price2 { get; set; }

        //価格3
        [Column("price3")] // データベース上のカラム名を入力。
        public int price3 { get; set; }

        //色
        [Column("color")] // データベース上のカラム名を入力。
        public String color { get; set; }

        //対象年齢
        [Column("target_age")] // データベース上のカラム名を入力。
        public int target_age { get; set; }

        //摘要
        [Column("remarks")] // データベース上のカラム名を入力。
        public String remarks { get; set; }

        //画像ファイル名1
        [Column("image1")] // データベース上のカラム名を入力。
        public String image1 { get; set; }

        //画像ファイル名2
        [Column("image2")] // データベース上のカラム名を入力。
        public String image2 { get; set; }

        //画像ファイル名3
        [Column("image3")] // データベース上のカラム名を入力。
        public String image3 { get; set; }

        //画像ファイル名4
        [Column("image4")] // データベース上のカラム名を入力。
        public String image4 { get; set; }

        //分類
        [Column("class")] // データベース上のカラム名を入力。
        public String Class { get; set; }

        //見た目
        [Column("appearance")] // データベース上のカラム名を入力。
        public String appearance { get; set; }

        //柄
        [Column("handle")] // データベース上のカラム名を入力。
        public String handle { get; set; }

        //ステータス
        [Column("status")] // データベース上のカラム名を入力。
        public String status { get; set; }

        //貸出店舗
        [Column("rental_store")] // データベース上のカラム名を入力。
        public String rental_store { get; set; }

        //お客様表示用
        [Column("customer_display")]
        public String customer_display { get; set; }

        //お客様表示用
        [Column("initial_use_count")]
        public int initial_use_count { get; set; }

        //登録日
        [Column("registration_date")]
        public DateTime registration_date { get; set; }

        //登録者
        [Column("registration_staff")]
        public string registration_staff { get; set; }

        //更新日
        [Column("update_date")]
        public DateTime? update_date { get; set; }

        //更新者
        [Column("update_staff")]
        public string update_staff { get; set; }

        //削除フラグ
        [Column("delete_flag")]
        public string delete_flag { get; set; }

 
        public void Command(bool delete = false)
        {

            using (var dbc = new DB.DBConnect())
            {
                //削除フラグ
                if (delete == true)
                {
                    this.delete_flag = "1";
                }
                else if(delete == false)
                {
                    this.delete_flag = "0";
                }
                    
                //更新情報
                this.update_date = DateTime.Now.Date;
                this.update_staff = MainForm.session_m_staff.staff_name;
                var data = dbc.m_costume.SingleOrDefault(x => x.store_code == this.store_code & x.costume_code == this.costume_code);

                if (data == null)
                {
                    //新規登録
                    this.registration_date = DateTime.Now.Date;
                    this.registration_staff = MainForm.session_m_staff.staff_name;
                    dbc.m_costume.Add(this);
                }
                else
                {
                    if (delete_flag == "0")
                    {
                        data.appearance = this.appearance;
                        data.brand_name = this.brand_name;
                        data.Class = this.Class;
                        data.color = this.color;
                        data.costume_code = this.costume_code;
                        data.costume_name = this.costume_name;
                        data.handle = this.handle;
                        data.image1 = this.image1;
                        data.image2 = this.image2;
                        data.image3 = this.image3;
                        data.image4 = this.image4;
                        data.price1 = this.price1;
                        data.price2 = this.price2;
                        data.price3 = this.price3;
                        data.rank = this.rank;
                        data.remarks = this.remarks;
                        data.rental_store = this.rental_store;
                        data.sex = this.sex;
                        data.size = this.size;
                        data.status = this.status;
                        data.store_code = this.store_code;
                        data.target_age = this.target_age;
                        data.usability = this.usability;
                        data.customer_display = this.customer_display;
                        data.initial_use_count = this.initial_use_count;
                    }
                    data.update_date = this.update_date;
                    data.update_staff = this.update_staff;
                    data.delete_flag = this.delete_flag;
                }

                dbc.SaveChanges();
            }

        }

       
        public static m_costume getSingle(string storeCode,string costumeCode)
        {
            m_costume s = null;
            using (var dbc = new DBConnect())
            {
               
                if (costumeCode == null)
                {
                    s = dbc.m_costume.SingleOrDefault(x => x.store_code == storeCode);

                }else if(costumeCode != null)
                {
                    s = dbc.m_costume.SingleOrDefault(x => x.store_code == storeCode & x.costume_code == costumeCode);
                }

            }
            return s;
        }
        public static m_costume getFirst(string storeCode, string costumeCode)
        {
            m_costume s = null;
            using (var dbc = new DBConnect())
            {
                if (costumeCode == null)
                {
                    s = dbc.m_costume.FirstOrDefault(x => x.store_code == storeCode);

                }
                else if (costumeCode != null)
                {
                    s = dbc.m_costume.FirstOrDefault(x => x.store_code == storeCode & x.costume_code == costumeCode);
                }

            }
            return s;
        }

        public static List<DB.m_costume> GetAllTable()
        {
            List<DB.m_costume> costume = new List<m_costume>();
            using(var dbc = new DBConnect())
            {
                dbc.npg.Open();

                StringBuilder sb = new StringBuilder();
                sb.Append(@"select * ");
                sb.Append(@"from m_costume ");
                sb.Append(@"where delete_flag = '0' ");
                sb.Append(@"order by store_code asc, costume_code asc ");
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                NpgsqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    var data = new DB.m_costume();
                    data.appearance = dataReader["appearance"].ToString();
                    data.brand_name = dataReader["brand_name"].ToString();
                    data.Class = dataReader["class"].ToString();
                    data.color = dataReader["color"].ToString();
                    data.costume_code = dataReader["costume_code"].ToString();
                    data.costume_name = dataReader["costume_name"].ToString();
                    data.customer_display = dataReader["customer_display"].ToString();
                    data.delete_flag = dataReader["delete_flag"].ToString();
                    data.handle = dataReader["handle"].ToString();
                    data.image1 = dataReader["image1"].ToString();
                    data.image2 = dataReader["image2"].ToString();
                    data.image3 = dataReader["image3"].ToString();
                    data.image4 = dataReader["image4"].ToString();
                    data.price1 = int.Parse(dataReader["price1"].ToString());
                    data.price2 = int.Parse(dataReader["price2"].ToString());
                    data.price3 = int.Parse(dataReader["price3"].ToString());
                    data.rank = dataReader["rank"].ToString();
                    data.registration_date = DateTime.Parse( dataReader["registration_date"].ToString());
                    data.registration_staff = dataReader["registration_staff"].ToString();
                    data.remarks = dataReader["remarks"].ToString();
                    data.rental_store = dataReader["rental_store"].ToString();
                    data.sex = dataReader["sex"].ToString();
                    data.size = dataReader["size"].ToString();
                    data.status = dataReader["status"].ToString();
                    data.store_code = dataReader["store_code"].ToString();
                    data.target_age = int.Parse(dataReader["target_age"].ToString());
                    data.update_date = DateTime.Parse( dataReader["update_date"].ToString());
                    data.update_staff = dataReader["update_staff"].ToString();
                    data.usability = dataReader["usability"].ToString();
                    data.initial_use_count = int.Parse(dataReader["initial_use_count"].ToString());

                    costume.Add(data);
                }
                
            }
            return costume;
        }

    }
}
