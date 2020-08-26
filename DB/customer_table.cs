using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace 写真館システム.DB
{
       // テーブルの名前とスキーマ名を入力。
       //テーブルごとに生成する
       [Table("m_customer", Schema = "public")]

        //クラス名＝テーブル名
        public class m_customer : base_table
        {
            //顧客コード
            [Key] // 主キーを設定。
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            [Column("customer_code")] // データベース上のカラム名を入力。
            //[MaxLength(8)]
            public String customer_code { get; set; }

            //顧客姓
            [Column("surname")]
            //[MaxLength(10)]
            public String surname { get; set; }

            //顧客姓
            [Column("surname_kana")]
            //[MaxLength(20)]
            public String surname_kana { get; set; }

            //顧客名
            [Column("name")]
            //[MaxLength(10)]
            public String name { get; set; }

            //顧客名カナ
            [Column("name_kana")]
            //[MaxLength(20)]
            public String name_kana { get; set; }

            //生年月日
            [Column("birthday")]
            public DateTime birthday { get; set; }

            //性別
            [Column("sex")]
            //[MaxLength(1)]
            public String sex { get; set; }

            //DM送付区分
            [Column("dm_delivery")]
            //[MaxLength(1)]
            public String dm_delivery { get; set; }

            //サンプル可否
            [Column("sample_availability")]
            //[MaxLength(1)]
            public String sample_availability { get; set; }

            //郵便番号
            [Column("postal_code")]
            //[MaxLength(8)]
            public String postal_code { get; set; }

            //県・市区町村
            [Column("address1")]
            //[MaxLength(60)]
            public String address1 { get; set; }

            //番地
            [Column("address2")]
            //[MaxLength(60)]
            public String address2 { get; set; }

            //アパート・マンション
            [Column("address3")]
            //[MaxLength(60)]
            public String address3 { get; set; }

            //メールアドレス
            [Column("mail_address")]
            //[MaxLength(255)]
            public String mail_address { get; set; }

            //電話番号１
            [Column("phone_number1")]
            //[MaxLength(13)]
            public String phone_number1 { get; set; }

            //電話番号２
            [Column("phone_number2")]
            //[MaxLength(13)]
            public String phone_number2 { get; set; }

            //電話番号３
            [Column("phone_number3")]
            public String phone_number3 { get; set; }

            //FAX
            [Column("fax_number") ]
            //[MaxLength(13)]
            public String fax_number { get; set; }

            //結婚記念日
            [Column("wedding_anniversary")]
            public DateTime wedding_anniversary { get; set; }

            //摘要
            [Column("remarks")]
            //[MaxLength(255)]
            public String remarks { get; set; }

            //自由項目１
            [Column("free_item1")]
            //[MaxLength(60)]
            public String free_item1 { get; set; }

            //自由項目２
            [Column("free_item2")]
            //[MaxLength(60)]
            public String free_item2 { get; set; }

            //自由項目３
            [Column("free_item3")]
            //[MaxLength(60)]
            public String free_item3 { get; set; }

            //来店理由
            [Column("reasons")]
            //[MaxLength(30)]
            public String reasons { get; set; }

            //登録日
            [Column("registration_date")]
            public DateTime registration_date { get; set; }

            //更新者
            [Column("registration_staff")]
            //[MaxLength(20)]
            public String registration_staff { get; set; }

            //更新日
            [Column("update_date")]
            public DateTime? update_date { get; set; }

            //更新者
            [Column("update_staff")]
            //[MaxLength(20)]
            public String update_staff { get; set; }

            //削除フラグ
            [Column("delete_flag")]
            //[MaxLength(1)]
            public String delete_flag { get; set; }

            //受付テーブル参照
            //public virtual ICollection<t_reception> Reception { get; set; }
            //public virtual ICollection<m_member> Member { get; set; }
            //public virtual ICollection<t_shooting_data> Shooting_Data { get; set; }
            //public virtual ICollection<m_family> Family { get; set; }

        public void Command(bool delete = false)
        {

            using (var dbc = new DB.DBConnect())
            {
                //削除フラグ
                if (delete)
                    this.delete_flag = "1";
                else
                    this.delete_flag = "0";

                //更新情報
                this.update_date = DateTime.Now.Date;
                this.update_staff = MainForm.session_m_staff.staff_name;
                var data = dbc.m_customer.SingleOrDefault(x => x.customer_code == this.customer_code);

                if (data == null)
                {
                    //新規登録
                    this.registration_date = DateTime.Now.Date;
                    this.registration_staff = MainForm.session_m_staff.staff_name;
                    dbc.m_customer.Add(this);
                }
                else
                {
                    if(delete_flag == "0")
                    {
                        data.address1 = this.address1;
                        data.address2 = this.address2;
                        data.address3 = this.address3;
                        data.birthday = this.birthday;
                        //data.customer_code = this.customer_code;
                        data.dm_delivery = this.dm_delivery;
                        data.fax_number = this.fax_number;
                        data.free_item1 = this.free_item1;
                        data.free_item2 = this.free_item2;
                        data.free_item3 = this.free_item3;
                        data.mail_address = this.mail_address;
                        data.name = this.name;
                        data.name_kana = this.name_kana;
                        data.phone_number1 = this.phone_number1;
                        data.phone_number2 = this.phone_number2;
                        data.phone_number3 = this.phone_number3;
                        data.postal_code = this.postal_code;
                        data.reasons = this.reasons;
                        data.remarks = this.remarks;
                        data.sample_availability = this.sample_availability;
                        data.sex = this.sex;
                        data.surname = this.surname;
                        data.surname_kana = this.surname_kana;
                        data.wedding_anniversary = this.wedding_anniversary;
                    }
                    data.update_date = this.update_date;
                    data.update_staff = this.update_staff;
                    data.delete_flag = this.delete_flag;
                }

                dbc.SaveChanges();
            }

        }
        public static m_customer getSingle(string code)
        {
            m_customer s;
            using (var dbc = new DBConnect())
            {
                s = dbc.m_customer.SingleOrDefault(x => x.customer_code == code);

            }
            return s;
        }
    }
}
