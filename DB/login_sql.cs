using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace 写真館システム.DB
{

    public  class LoginSQL : DBConnect

    {
        //格納領域および返り値
        public string staffCode = null;
        public string login_Id = null;

        public LoginSQL(string LoginID, string hashd_pass)
        {

            using(var dbc = new DB.DBConnect())
            {
                var q = from t in dbc.m_staff
                        where t.login_id == LoginID & t.password == hashd_pass & t.delete_flag == "0"
                        select t;

                foreach(var data in q)
                {
                    staffCode = data.staff_code;
                    login_Id = data.login_id;
                }
            }
        }
        

 
    }
}
