using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Npgsql;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;        // 参照を追加。
using System.ComponentModel.DataAnnotations.Schema; // 参照を追加。 
using System.Transactions;
using 写真館システム.DB;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace 写真館システム
{
    public partial class Login : UserControlExp
    {
        //DateTime? DateTimeToday;
        //入力チェック初期化
        private checkOperation chk;


        public String hashd_PW = "";
        public String hashd_pass = "";
        public String user = "";
        public String pass = "";

        public Login()
        {
            InitializeComponent();
            //必須項目チェック
            //入力チェック初期化
            chk = new checkOperation(this);
            //コントロールを追加
            chk.addControl(t_password);
            chk.addControl(t_login);
        }
        //
        //ページの初期化
        //
        public override void PageRefresh()
        {
            //TextBox項目の初期化の初期化
            t_login.Text = "";
            t_password.Text = "";
            //ログインIDにカーソルを持ってくる
            t_login.Focus();

        }


        private void b_Customer_serach_Click(object sender, EventArgs e)
        {
            this.PageRefresh();
            MainForm.sendPage(this, MainForm.Customer_search);

        }
        private void login()
        {

            //必須入力チェック
            if (chk.check("W00000", chk.checkControlImportant))
            {
                t_login.Text = null;
                t_password.Text = null;
                t_login.Focus();
                return;
            }

            //userとパスワードのデータ取得
            user = this.t_login.Text;
            pass = this.t_password.Text;

            //Loginパスワードのハッシュ化
            hashd_pass = GetHashString<SHA256CryptoServiceProvider>(pass);

            LoginSQL Loginforn = new LoginSQL(user, hashd_pass);
            if (Loginforn.login_Id != null)
            {
                //データベースからの取得
                MainForm.session_m_staff = m_staff.getSingle(Loginforn.staffCode);
                //一致した場合はメインメニューを表示
                MainForm.Main_menu.PageRefresh();
                MainForm.Header_Menu.Visible = true;
                MainForm.sendPage(MainForm.dispPage, MainForm.Main_menu);
            }
            else
            {
                DialogResult result = MessageBox.Show("正しいユーザとパスワードを入力してください。", "ログインエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {
                    this.t_login.Text = null;
                    this.t_password.Text = null;
                    this.t_login.Focus();
                }

            }
        }
        private void b_login_Click(object sender, EventArgs e)
        {
            login();
        }


        public static string GetHashString<T>(string text) where T : HashAlgorithm, new()
        {
            // 文字列をバイト型配列に変換する
            byte[] data = Encoding.UTF8.GetBytes(text);

            // ハッシュアルゴリズム生成
            T algorithm = new T();

            // ハッシュ値を計算する
            byte[] bs = algorithm.ComputeHash(data);

            // リソースを解放する
            algorithm.Clear();

            // バイト型配列を16進数文字列に変換
            StringBuilder result = new StringBuilder();
            foreach (byte b in bs)
            {
                result.Append(b.ToString("x2"));
            }
            return result.ToString();
        }

        private void b_clear_Click(object sender, EventArgs e)
        {
            t_login.Text = "";
            t_password.Text = "";
        }

        private void t_password_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                login();

            }
        }

    }
}
