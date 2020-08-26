using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;        // 参照を追加。
using System.ComponentModel.DataAnnotations.Schema; // 参照を追加。

namespace 写真館システム.DB
{
    // テーブルの名前とスキーマ名を入力。
    //テーブルごとに生成する
    [Table("m_member", Schema = "public")]
    public class m_member : base_table
    {
        [Key] // 主キーを設定。
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //顧客コード
        [Column("customer_code")] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String customer_code { get; set; }

        //会員登録日
        [Column("date")]
        public DateTime date { get; set; }

        //登録担当者
        [Column("staff")] // データベース上のカラム名を入力。
        //[MaxLength(20)]
        public String staff { get; set; }

        //登録店舗
        [Column("store")] // データベース上のカラム名を入力。
        //[MaxLength(30)]
        public String store { get; set; }

        //ランク
        [Column("rank")] // データベース上のカラム名を入力。
        //[MaxLength(1)]
        public String rank { get; set; }

        //会員種別
        [Column("membership_type")] // データベース上のカラム名を入力。
        //[MaxLength(1)]
        public String membership_type { get; set; }

        //登録日
        [Column("registration_date")]
        public DateTime registration_date { get; set; }

        //登録者
        [Column("registration_staff")]
        //[MaxLength(20)]
        public string registration_staff { get; set; }

        //更新日
        [Column("update_date")]
        public DateTime? update_date { get; set; }

        //更新者
        [Column("update_staff")]
        //[MaxLength(20)]
        public string update_staff { get; set; }

        //削除フラグ
        [Column("delete_flag")]
        //[MaxLength(20)]
        public string delete_flag { get; set; }

        //リレーション
        //public virtual m_customer Customer { get; set; }

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

                var data = dbc.m_member.SingleOrDefault(x => x.customer_code == this.customer_code);

                if (data == null)
                {
                    //新規登録
                    this.registration_date = DateTime.Now.Date;
                    this.registration_staff = MainForm.session_m_staff.staff_name;
                    dbc.m_member.Add(this);
                }
                else
                {
                    if(delete_flag == "0")
                    {

                        data.customer_code = this.customer_code;
                        data.date = this.date;
                        data.membership_type = this.membership_type;
                        data.rank = this.rank;
                        data.staff = this.staff;
                        data.store = this.store;
                    }
                    data.delete_flag = this.delete_flag;
                    data.update_date = this.update_date;
                    data.update_staff = this.update_staff;
                }

                dbc.SaveChanges();
            }

        }
        public static m_member getSingle(string code)
        {
            m_member s;
            using (var dbc = new DBConnect())
            {
                s = dbc.m_member.SingleOrDefault(x => x.customer_code == code);

            }
            return s;
        }
    }
}
