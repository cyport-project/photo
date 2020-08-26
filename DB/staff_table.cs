using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;        // 参照を追加。
using System.ComponentModel.DataAnnotations.Schema; // 参照を追加。
using Npgsql;
using System.Collections.Generic;
using System.Diagnostics;


namespace 写真館システム.DB
{
    // テーブルの名前とスキーマ名を入力。
    //テーブルごとに生成する
    [Table("m_staff", Schema = "public")]
    public class m_staff : base_table
    {
        //店舗コード
        [Column("store_code")] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String store_code { get; set; }

        //スタッフコード
        [Key] // 主キーを設定。
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("staff_code")] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String staff_code { get; set; }

        //スタッフ名
        [Column("staff_name")] // データベース上のカラム名を入力。
        //[MaxLength(20)]
        public String staff_name { get; set; }

        //スタッフ名カナ
        [Column("staff_name_kana")] // データベース上のカラム名を入力。
        //[MaxLength(20)]
        public String staff_name_kana { get; set; }

        //ログインID
        [Column("login_id")] // データベース上のカラム名を入力。
        //[MaxLength(20)]
        public String login_id { get; set; }

        //パスワード
        [Column("password")] // データベース上のカラム名を入力。
        //[MaxLength(20)]
        public String password { get; set; }

        //権限区分
        [Column("permission_class")] // データベース上のカラム名を入力。
        //[MaxLength(1)]
        public String permission_class { get; set; }

        //社員区分
        [Column("work_class")] // データベース上のカラム名を入力。
        //[MaxLength(1)]
        public String work_class { get; set; }

        //ステータス
        [Column("status")] // データベース上のカラム名を入力。
        //[MaxLength(1)]
        public String status { get; set; }

        //性別
        [Column("sex")] // データベース上のカラム名を入力。
        //[MaxLength(1)]
        public String sex { get; set; }


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
        //public virtual ICollection<m_staff_shift> Staff_Shift { get; set; }
        //public virtual m_store Store { get; set; }

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

                var data = dbc.m_staff.First(x => x.staff_code == this.staff_code && x.store_code == this.store_code);

                if (data == null)
                {
                    //新規登録
                    this.registration_date = DateTime.Now.Date;
                    this.registration_staff = MainForm.session_m_staff.staff_name;
                    dbc.m_staff.Add(this);
                }
                else
                {
                    if (delete_flag == "0")
                    {
                        data.login_id = this.login_id;
                        data.password = this.password;
                        data.permission_class = this.permission_class;
                        data.sex = this.sex;
                        data.staff_code = this.staff_code;
                        data.staff_name = this.staff_name;
                        data.staff_name_kana = this.staff_name_kana;
                        data.status = this.status;
                        data.store_code = this.store_code;
                        data.work_class = this.work_class;
                    }
                    data.update_date = this.update_date;
                    data.update_staff = this.update_staff;
                    data.delete_flag = this.delete_flag;
                }

                dbc.SaveChanges();
            }

        }

        public static m_staff getSingle(string staffCode)
        {
            m_staff s = null;
            using (var dbc = new DBConnect())
            {
                s = dbc.m_staff.SingleOrDefault(x => x.staff_code == staffCode);
            }
            return s;
        }

        public static m_staff getSingle2(string storeCode, string staffCode)
        {
            m_staff s = null;
            using (var dbc = new DBConnect())
            {
                s = dbc.m_staff.Single(x => x.store_code == storeCode & x.staff_code == staffCode);
            }
            return s;
        }

        public static m_staff getSingleName(string store_code, string name)
        {
            m_staff s;
            using (var dbc = new DBConnect())
            {
                s = dbc.m_staff.SingleOrDefault(x => x.staff_name == name & x.store_code == store_code);

            }
            return s;
        }

        public static m_staff getFirst(string storeCode,string staffCode)
        {
            m_staff s = null;
            using (var dbc = new DBConnect())
            {
                s = dbc.m_staff.Single(x => x.store_code == storeCode & x.staff_code == staffCode);
            }
            return s;
        }

        public static m_staff getFirstStaff(string staffCode)
        {
            m_staff s = null;
            using (var dbc = new DBConnect())
            {
                s = dbc.m_staff.Single(x => x.staff_code == staffCode);
            }
            return s;
        }

        public static List<string> getStaffNameList(string store_code)
        {
            List<string> res = new List<string>();
            using (var dbc = new DBConnect())
            {
                var q = from t in dbc.m_staff
                        where t.delete_flag == "0" & t.store_code == store_code
                        orderby t.store_code
                        select t.staff_name;
                foreach (var item in q)
                {
                    res.Add(item);
                }

            }
            return res;
        }


        public static List<Staff_master.StaffDBArray> GetAllTable()
        {
            List<Staff_master.StaffDBArray> StaffDBList = new List<Staff_master.StaffDBArray>();
            NpgsqlDataReader dataReader = null;
            using (var dbc = new DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select * ");
                sb.Append(@"from m_staff ");
                sb.Append(@"where m_staff.delete_flag = '0' ");
                sb.Append(@"order by m_staff.store_code asc, m_staff.staff_code asc;");
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                dataReader = command.ExecuteReader();

                //totalPage変更
                while (dataReader.Read() == true)
                {
                    StaffDBList.Add(new Staff_master.StaffDBArray
                    {
                        tenpo = "",
                        staff_store_code = dataReader["store_code"].ToString(),
                        staff_code = dataReader["staff_code"].ToString(),
                        staff_name = dataReader["staff_name"].ToString(),
                        staff_name_kana = dataReader["staff_name_kana"].ToString(),
                        login_id = dataReader["login_id"].ToString(),
                        password = null,
                        hash_password = dataReader["password"].ToString(),
                        kengen = dataReader["permission_class"].ToString(),
                        employment = dataReader["work_class"].ToString(),
                        status = dataReader["status"].ToString(),
                        seibetu = dataReader["sex"].ToString(),
                        registration_date = DateTime.Parse(dataReader["registration_date"].ToString()),
                        registration_staff = dataReader["registration_staff"].ToString(),
                        update_date = DateTime.Parse(dataReader["update_date"].ToString()),
                        update_staff = dataReader["update_staff"].ToString(),
                        delete_flag = dataReader["delete_flag"].ToString()
                    });
                }
            }
            return StaffDBList;
        }
        
         public static List<m_staff> GetlistAllTable()
        {
            NpgsqlDataReader dataReader = null;
            var res = new List<m_staff>();
            using (var dbc = new DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select store_code, staff_code, staff_name, staff_name_kana, login_id, password, permission_class, work_class, status,sex ");
                sb.Append(@"from m_staff ");
                sb.Append(@"where m_staff.delete_flag = '0' ");
                sb.Append(@"order by m_staff.store_code asc, m_staff.staff_code asc ,m_staff.registration_date asc;");
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    m_staff staff = new m_staff();
                    staff.store_code = dataReader["store_code"].ToString();
                    staff.staff_code = dataReader["staff_code"].ToString();
                    staff.staff_name = dataReader["staff_name"].ToString();
                    staff.staff_name_kana = dataReader["staff_name_kana"].ToString();
                    staff.login_id = dataReader["login_id"].ToString();
                    staff.password = dataReader["password"].ToString();
                    staff.permission_class = dataReader["permission_class"].ToString();
                    staff.work_class = dataReader["work_class"].ToString();
                    staff.status = dataReader["status"].ToString();
                    staff.sex = dataReader["sex"].ToString();
                    res.Add(staff);
                }
                
            }
            return res;
        }
        public static Dictionary<string, string> getStaffList(string store_code)
        {
            var res = new Dictionary<string, string>();
            using (var dbc = new DB.DBConnect())
            {
                dbc.npg.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append(@"select staff_code, staff_name ");
                sb.Append(@"from m_staff ");
                sb.Append(@"where m_staff.delete_flag = '0' and m_staff.store_code = :store_code ");
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                //command.Parameters.Add(new NpgsqlParameter("@store_code", store_code));
                command.Parameters.Add(new NpgsqlParameter("store_code", NpgsqlTypes.NpgsqlDbType.Varchar));
                command.Parameters["store_code"].Value = store_code;

                Debug.WriteLine(store_code);
                Debug.WriteLine(sb.ToString());
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    res.Add(dataReader["staff_code"].ToString(), dataReader["staff_name"].ToString());
                }
            }
            return res;
        }
    }
}
    

