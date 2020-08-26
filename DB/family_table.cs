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
    [Table("m_family", Schema = "public")]

    //クラス名＝テーブル名
    public class m_family : base_table
    {
        [Key] // 主キーを設定。
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //顧客コード
        [Column("customer_code", Order = 0)] // データベース上のカラム名を入力。
        //[MaxLength(8)]
        public String customer_code { get; set; }

        [Key] // 主キーを設定。
        //枝番
        [Column("branch_number", Order = 1)] // データベース上のカラム名を入力。
        public int branch_number { get; set; }

        //続柄
        [Column("relationship")]
        //[MaxLength(4)]
        public String relationship { get; set; }

        //姓
        [Column("surname")]
        //[MaxLength(10)]
        public String surname { get; set; }

        //姓カナ
        [Column("surname_kana")]
        //[MaxLength(20)]
        public String surname_kana { get; set; }

        //名
        [Column("name")]
        //[MaxLength(10)]
        public String name { get; set; }

        //名カナ
        [Column("name_kana")]
        //[MaxLength(20)]
        public String name_kana { get; set; }

        //生年月日
        //[Column("birthday")]
        public DateTime? birthday { get; set; }

        //性別
        [Column("sex")]
        //[MaxLength(1)]
        public String sex { get; set; }

        //摘要
        [Column("remarks")]
        //[MaxLength(255)]
        public String remarks { get; set; }

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

        //リレショーン
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

                var data = dbc.m_family.SingleOrDefault(x => x.customer_code == this.customer_code
                                                 & x.branch_number == this.branch_number);

                if (data == null)
                {
                    //新規登録
                    this.registration_date = DateTime.Now.Date;
                    this.registration_staff = MainForm.session_m_staff.staff_name;
                    dbc.m_family.Add(this);
                }
                else
                {
                    if(delete_flag == "0")
                    {
                        data.birthday = this.birthday;
                        data.branch_number = this.branch_number;
                        data.customer_code = this.customer_code;
                        data.name = this.name;
                        data.name_kana = this.name_kana;
                        data.relationship = this.relationship;
                        data.remarks = this.remarks;
                        data.sex = this.sex;
                        data.surname = this.surname;
                        data.surname_kana = this.surname_kana;
                    }
                    data.delete_flag = this.delete_flag;
                    data.update_date = this.update_date;
                    data.update_staff = this.update_staff;
                }

                dbc.SaveChanges();
            }

        }
        public static List<m_family> getOnlyCode(string code)
        {
            List<m_family> res = new List<m_family>();
            NpgsqlDataReader dataReader = null;
            StringBuilder sb = new StringBuilder();
            using (var dbc = new DBConnect())
            {
                dbc.npg.Open();
                sb.Append(@"select * ");
                sb.Append(@"from m_family ");
                sb.Append(@"where m_family.delete_flag = '0' 
                                and m_family.customer_code = " + "'" + code + "'");
                sb.Append(@"order by m_family.customer_code,m_family.branch_number;");
                var command = new NpgsqlCommand(sb.ToString(), dbc.npg);
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    var family = new m_family();
                    family.customer_code = dataReader["customer_code"].ToString();
                    family.branch_number = int.Parse(dataReader["branch_number"].ToString());
                    family.relationship = dataReader["relationship"].ToString();
                    family.surname = dataReader["surname"].ToString();
                    family.surname_kana = dataReader["surname_kana"].ToString();
                    family.name = dataReader["name"].ToString();
                    family.name_kana = dataReader["name_kana"].ToString();
                    family.birthday = DateTime.Parse(dataReader["birthday"].ToString());
                    family.sex = dataReader["sex"].ToString();
                    family.remarks = dataReader["remarks"].ToString();
                    res.Add(family);
                }
            }
            return res;
        }
    }
}
