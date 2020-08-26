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
    //店舗カレンダー情報
    // テーブルの名前とスキーマ名を入力。
    //テーブルごとに生成する
    [Table("t_calendar_information", Schema = "public")]
    public class t_calendar_information : base_table
    {
        [Key] // 主キーを設定。
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //店舗コード
        [Column("store_code",Order = 0)] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String store_code { get; set; }

        [Key] // 主キーを設定
        //年月日
        [Column("date", Order = 1)] // データベース上のカラム名を入力。
        public DateTime date { get; set; }

        //お知らせ
        [Column("notice")] // データベース上のカラム名を入力。
        //[MaxLength(90)]
        public String notice { get; set; }

        //休日区分
        [Column("holiday_class")] // データベース上のカラム名を入力。
        //[MaxLength(1)]
        public String holiday_class { get; set; }

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

        //リレーション
        //public virtual m_store Store { get; set;}

        public void Command(bool delete = false)
        {

            using (var dbc = new DB.DBConnect())
            {

                //更新情報
                this.update_date = DateTime.Now.Date;
                this.update_staff = MainForm.session_m_staff.staff_name;

                var data = dbc.t_calendar_information.SingleOrDefault(x => x.store_code == this.store_code & 
                                                                            x.date == this.date);

                if (data == null)
                {
                    //新規登録
                    this.registration_date = DateTime.Now.Date;
                    this.registration_staff = MainForm.session_m_staff.staff_name;

                    dbc.t_calendar_information.Add(this);
                }
                else
                {
                    data.date = this.date;
                    data.holiday_class = this.holiday_class;
                    data.notice = this.notice;
                    data.store_code = this.store_code;
                    data.update_date = this.update_date;
                    data.update_staff = this.update_staff;
                }

                dbc.SaveChanges();
            }

        }

        public static t_calendar_information getSingle(string store_code, DateTime date)
        {
            t_calendar_information data = null;
            using (var dbc = new DB.DBConnect())
            {
                data = dbc.t_calendar_information.SingleOrDefault(x => x.store_code == store_code &
                                                                            x.date == date);
            }

            return data;
        }

        public static List<t_calendar_information> getCalenderInfoAllList()
        {
            NpgsqlDataReader dataReader = null;
            var res = new List<t_calendar_information>();
            using (var dbc = new DB.DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select store_code,date,notice,holiday_class ");
                sb.Append(@"from t_calendar_Information ");
                sb.Append(@"order by store_code,date");
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    t_calendar_information calendar_Information = new t_calendar_information();
                    calendar_Information.store_code = dataReader["store_code"].ToString();
                    calendar_Information.date = DateTime.Parse(dataReader["date"].ToString());
                    calendar_Information.notice = dataReader["notice"].ToString();
                    calendar_Information.holiday_class = dataReader["holiday_class"].ToString();

                    res.Add(calendar_Information);
                }
            }
            return res;
        }


    }
}
