using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql;



namespace 写真館システム.DB
{
        // テーブルの名前とスキーマ名を入力。
        //テーブルごとに生成する
        [Table("t_reception", Schema = "public")]

        //クラス名＝テーブル名
        public class t_reception : base_table
    {
            [Key] // 主キーを設定。
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            //受付コード
            [Column("reception_code")] // データベース上のカラム名を入力。
            //[MaxLength(8)]
            public String reception_code { get; set; }

            //受付年月日
            [Column("receipt_date")]
            public DateTime receipt_date { get; set; }

            //受付時間
            [Column("receipt_time")]
            public TimeSpan receipt_time { get; set; }

            //受付区分
            [Column("status")]
            //[MaxLength(1)]
            public String status { get; set; }

            //撮影人数
            [Column("photographers")]
            public int photographers { get; set; }

            //来店区分
            [Column("coming_store_category")]
            //[MaxLength(1)]
            public String coming_store_category { get; set; }

            //顧客コード
            [Column("customer_code")]
            //[MaxLength(8)]
            public String customer_code { get; set; }


            //対応店舗
            [Column("store")]
            //[MaxLength(30)]
            public String store { get; set; }

            //対応スタッフ
            [Column("staff")]
            //[MaxLength(20)]
            public String staff { get; set; }

            //対応内容
            [Column("memo")]
            //[MaxLength(255)]
            public String memo { get; set; }

            //苦情内容
            [Column("claim")]
            //[MaxLength(255)]
            public String claim { get; set; }

            //来店動機
            [Column("motivation")]
            //[MaxLength(1)]
            public String motivation { get; set; }

            //印刷除外フラグ
            [Column("noprint")]
            //[MaxLength(1)]
            public String noprint { get; set; }

            //登録日
            [Column("registration_date")]
            public DateTime registration_date { get; set; }

            //登録者
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

            //顧客テーブル参照
            //public virtual m_customer Customer { get; set; }
            //public virtual ICollection<t_shooting_data> Shooting_Data { get; set; }
            //public virtual ICollection<t_reception> Reception { get; set; }

        public void Command(bool delete = false)
        {

            using (var dbc = new DB.DBConnect())
            {
                //更新情報
                this.update_date = DateTime.Now.Date;
                this.update_staff = MainForm.session_m_staff.staff_name;

                var data = dbc.t_reception.SingleOrDefault(x => x.reception_code == this.reception_code);

                if (data == null)
                {
                    //新規登録
                    this.registration_date = DateTime.Now.Date;
                    this.registration_staff = MainForm.session_m_staff.staff_name;
                    dbc.t_reception.Add(this);
                }
                else
                {
                    data.claim = this.claim;
                    data.coming_store_category = this.coming_store_category;
                    data.customer_code = this.customer_code;
                    data.memo = this.memo;
                    data.motivation = this.motivation;
                    data.noprint = this.noprint;
                    data.photographers = this.photographers;
                    data.receipt_date = this.receipt_date;
                    data.receipt_time = this.receipt_time;
                    data.reception_code = this.reception_code;
                    data.staff = this.staff;
                    data.status = this.status;
                    data.store = this.store;
                    data.update_date = this.update_date;
                    data.update_staff = this.update_staff;
                }

                dbc.SaveChanges();
            }

        }

        public static t_reception getSingle(string code)
        {
            t_reception s;
            using (var dbc = new DBConnect())
            {
                s = dbc.t_reception.Single(x => x.reception_code == code);

            }
            return s;
        }


        public static string getMaxReceptioncode()
        {
            NpgsqlDataReader dataReader = null;
            string maxreceptioncode = null;

            using (var dbc = new DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select max(reception_code) as reception_code ");
                sb.Append(@"from t_reception ");
                
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                dataReader = command.ExecuteReader();

                dataReader.Read();
                maxreceptioncode = dataReader["reception_code"].ToString() != "" ? dataReader["reception_code"].ToString():"00000000";
            }
            return maxreceptioncode ;
        }
    }
    
}
