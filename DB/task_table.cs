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
    [Table("m_task", Schema = "public")]

    public class m_task : base_table
    {
        [Key] // 主キーを設定。
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        //タスク区分
        [Column("task_class")] // データベース上のカラム名を入力。
        //[MaxLength(1)]
        public String task_class { get; set; }

        //タスク区分名
        [Column("task_name")] // データベース上のカラム名を入力。
        //[MaxLength(20)]
        public String task_name { get; set; }

        //表示色
        [Column("color")] // データベース上のカラム名を入力。
        //[MaxLength(20)]
        public String color { get; set; }

        //登録日
        [Column("registration_date")]
        public DateTime? registration_date { get; set; }

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

                var data = dbc.m_task.SingleOrDefault(x => x.task_class == this.task_class);

                if (data == null)
                {
                    //新規登録
                    this.registration_date = DateTime.Now.Date;
                    this.registration_staff = MainForm.session_m_staff.staff_name;
                    dbc.m_task.Add(this);
                }
                else
                {
                    if(delete_flag == "0")
                    {
                        data.delete_flag = this.delete_flag;
                        data.update_date = this.update_date;
                        data.update_staff = this.update_staff;
                    }
                    data.color = this.color;
                    data.task_class = this.task_class;
                    data.task_name = this.task_name;
                }

                dbc.SaveChanges();
            }

        }
        public static m_task getSingle(string code)
        {
            m_task s;
            using (var dbc = new DBConnect())
            {
                s = dbc.m_task.SingleOrDefault(x => x.task_class == code);

            }
            return s;
        }
        public static m_task getSingleName(string name)
        {
            m_task s;
            using (var dbc = new DBConnect())
            {
                s = dbc.m_task.SingleOrDefault(x => x.task_name == name);

            }
            return s;
        }

        public static List<string> getTaskNameList()
        {
            List<string> res = new List<string>();
            using(var dbc = new DBConnect())
            {
                var q = from t in dbc.m_task
                        where t.delete_flag == "0"
                        orderby t.task_class
                        select t.task_name;
                foreach(var item in q)
                {
                    res.Add(item);
                }
            }
            return res;
        }
    }
}
