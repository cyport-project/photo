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
    [Table("t_shooting_data", Schema = "public")]
    public class t_shooting_data : base_table
    {
        [Key] // 主キーを設定。
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //顧客コード
        [Column("customer_code", Order = 0)] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String customer_code { get; set; }

        [Key] // 主キーを設定。
        //撮影年月日
        [Column("shooting_date", Order = 1)] // データベース上のカラム名を入力。
        public DateTime shooting_date { get; set; }

        //フォルダー名
        [Column("folder")] // データベース上のカラム名を入力。
        //[MaxLength(255)]
        public String folder { get; set; }

        //セレクト区分
        [Column("select_class")] // データベース上のカラム名を入力。
        //[MaxLength(1)]
        public String select_class { get; set; }

        //画像数
        [Column("images")] // データベース上のカラム名を入力。
        public int images { get; set; }

        [Key] // 主キーを設定。
        //受付コード
        [Column("reception_code", Order = 2)] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String reception_code { get; set; }

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
        //public virtual m_customer Customer { get; set; }
        //public virtual t_reception Reception { get; set; }

        public void Command(bool delete = false)
        {

            using (var dbc = new DB.DBConnect())
            {
                //更新情報
                this.update_date = DateTime.Now.Date;
                this.update_staff = MainForm.session_m_staff.staff_name;

                var data = dbc.t_shooting_data.SingleOrDefault(x => x.customer_code == this.customer_code 
                                                        & x.shooting_date == this.shooting_date 
                                                        & x.reception_code == this.reception_code);

                if (data == null)
                {
                    //新規登録
                    this.registration_date = DateTime.Now.Date;
                    this.registration_staff = MainForm.session_m_staff.staff_name;
                    dbc.t_shooting_data.Add(this);
                }
                else
                {
                    data.customer_code = this.customer_code;
                    data.folder = this.folder;
                    data.images = this.images;
                    data.reception_code = this.reception_code;
                    data.select_class = this.select_class;
                    data.shooting_date = this.shooting_date;
                    data.update_date = this.update_date;
                    data.update_staff = this.update_staff;
                }

                dbc.SaveChanges();
            }

        }
        public static List<string> getPhotoDir(string code)
        {
            List<string> photoDir = new List<string>();
            using (var dbc = new DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select folder ");
                sb.Append(@"from public.t_shooting_data ");
                sb.Append(@"where reception_code = '@code' ".Replace("@code",code));
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                var dataReader = command.ExecuteReader();
                
                while(dataReader.Read())
                {
                    photoDir.Add((string)dataReader["folder"]);
                }
            }
            return photoDir;
        }

        //2番目の新しい撮影日を取得
        public static string getShootingDate(string code)
        {
            string res;
            using (var dbc = new DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select max(shooting_date) ");
                sb.Append(@"from public.t_shooting_data ");
                sb.Append(@"where customer_code = '@code' and shooting_date NOT IN 
                    (SELECT MAX(shooting_date) FROM public.t_shooting_data
                        where customer_code = '@code' )".Replace("@code",code));
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                var dataReader = command.ExecuteReader();

                dataReader.Read();
                res = dataReader["max"].ToString();
            }
            return res;
        }

        public static bool chkFolder(string folder)
        {
            bool res = true;
            using (var dbc = new DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select count(folder) as count ");
                sb.Append(@"from public.t_shooting_data ");
                sb.Append(@"where folder = '@folder' ".Replace("@folder", folder));
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                var dataReader = command.ExecuteReader();

                dataReader.Read();
                res = int.Parse(dataReader["count"].ToString()) == 0;
            }
            return res;
        }

        public static t_shooting_data getSingle(string customer_code, DateTime shooting_date, string reception_code)
        {
            t_shooting_data res;
            using (var dbc = new DBConnect())
            {
                res = dbc.t_shooting_data.SingleOrDefault(x => x.customer_code == customer_code
                                    && x.shooting_date == shooting_date
                                    && x.reception_code == reception_code);
            }
            return res;
        }
    }
}
