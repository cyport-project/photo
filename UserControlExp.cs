using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 写真館システム
{
    public partial class UserControlExp : UserControl, IUserControl
    {

        //ページの名前
        public String pageName;

        //親ページを格納
        public UserControlExp pageParent;

        public virtual void PageRefresh()
        {
            // 実装したユーザコントロールにPageRefreshのオーバーライドが無い場合発生する。
            throw new NotImplementedException();
        }

        public class checkOperation
        {

            public delegate bool chackDelegate(Control con, out string msg, string msgCode, params object[] args);
            public delegate bool uniquChackDelegate(Control[] con, out string msg, string msgCode, params object[] args);

            private List<Control> controlList;
            private ErrorProvider errorProvider;

            /// <summary>コンストラクタ</summary>
            /// <param name="_UserControlExp">親クラス</param>
            public checkOperation(UserControlExp _UserControlExp)
            {
                //親クラスのerrorProviderを初期化
                _UserControlExp.components = new System.ComponentModel.Container();
                _UserControlExp.errorProvider = new System.Windows.Forms.ErrorProvider(_UserControlExp.components);
                ((System.ComponentModel.ISupportInitialize)(_UserControlExp.errorProvider)).BeginInit();
                _UserControlExp.errorProvider.ContainerControl = _UserControlExp;

                this.errorProvider = _UserControlExp.errorProvider;
                controlList = new List<Control>();
            }

            /// <summary>チェックするコントロールを追加</summary>
            /// <param name="con">追加するコントロール</param>
            public void addControl(Control con)
            {
                controlList.Add(con);
            }

            /// <summary>チェックの実行</summary>
            /// <param name="msgCode">メッセージコード</param>
            /// <param name="del">デリゲート関数</param>
            public bool check(string msgCode, chackDelegate del, params object[] args)
            {
                string msg = null;
                bool checkFlg = false;
                foreach (Control con in controlList)
                {
                    bool res = del(con, out msg, msgCode, args);
                    checkFlg = res || checkFlg;
                    if (res)
                    {
                        errorProvider.SetError(con, msg);
                        con.Focus();
                    }
                    else
                    {
                        errorProvider.SetError(con, null);
                    }
                }

                if (checkFlg)
                    Utile.Message.showMessageOK(msgCode, msg);

                return checkFlg;

            }

            /// <summary>重複チェックの実行</summary>
            /// <param name="msgCode">メッセージコード</param>
            /// <param name="del">デリゲート関数</param>
            public bool UniquCheck(string msgCode, uniquChackDelegate del, params object[] args)
            {
                string msg = null;
                bool checkFlg = false;

                int size = controlList.Count;
                //入力が1つの場合
                if (size > 1)
                {
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = i + 1; j < size; j++)
                        {
                            Control[] tmp = new[] { controlList[i], controlList[j] };
                            bool res = del(tmp, out msg, msgCode, args);

                            checkFlg = res || checkFlg;
                            if (res)
                            {
                                errorProvider.SetError(controlList[i], msg);
                                errorProvider.SetError(controlList[j], msg);
                                controlList[i].Focus();
                            }
                            else
                            {
                                errorProvider.SetError(controlList[i], null);
                                errorProvider.SetError(controlList[j], null);
                            }
                        }
                    }
                }
                else
                {
                    checkFlg = true;
                }

                if (checkFlg)
                    Utile.Message.showMessageOK(msgCode, msg);

                return checkFlg;

            }
            /// <summary>エラー表示のクリア</summary>
            public void clear()
            {
                foreach (Control con in controlList)
                {
                    errorProvider.SetError(con, null);
                }
                controlList.Clear();
            }

            //　以下チェックようのデリゲート先を記述
            /* 共通チェック */
            /// <summary>
            /// コントロールの必須チェック
            /// </summary>
            /// <param name="con">コントロール</param>
            /// <returns>OK：false　NG：true</returns>
            public bool checkControlImportant(Control con, out string msg, string msgCode, params object[] args)
            {
                bool res = false;
                if (con.GetType() == typeof(TextBox))
                {
                    if (((TextBox)con).TextLength == 0)
                        res = true;
                }
                else if (con.GetType() == typeof(ComboBox))
                {
                    if (((ComboBox)con).Text.Length == 0)
                        res = true;
                }
                msg = Utile.Message.message[msgCode];
                return res;
            }
            /// <summary>
            /// テキストボックスの桁数チェック
            /// </summary>
            /// <param name="con">コントロール</param>
            /// <param name="args[0]">桁数</param>
            /// <returns>OK：false　NG：true</returns>
            public bool checkTextboxLength(Control con, out string msg, string msgCode, params object[] args)
            {
                bool res = false;
                if (con.GetType() == typeof(TextBox))
                {
                    if (((TextBox)con).TextLength > (int)args[0])
                        res = true;
                }
                msg = Utile.Message.message[msgCode].Replace("@桁数", args[0].ToString());
                return res;
            }
            /// <summary>
            /// テキストボックスのフォーマットチェック
            /// </summary>
            /// <param name="con">コントロール</param>
            /// <param name="args[0]">正規表現の文字列</param>
            /// <param name="args[1]">メッセージ用の文字列</param>
            /// <returns>OK：false　NG：true</returns>
            public bool checkTextboxFormat(Control con, out string msg, string msgCode, params object[] args)
            {
                bool res = false;
                msg = Utile.Message.message[msgCode].Replace("@フォーマット", args[1].ToString());
                if (con.GetType() == typeof(TextBox))
                {
                    if(((TextBox)con).Text == "")
                        return res;
                    
                    if (!System.Text.RegularExpressions.Regex.IsMatch(
                        ((TextBox)con).Text,
                        (string)args[0],
                        System.Text.RegularExpressions.RegexOptions.ECMAScript))
                        res = true;
                }
                return res;
            }


            /// <summary>
            /// 画像ファイルの破損チェック
            /// </summary>
            /// <param name="con">コントロール</param>
            /// <returns>OK：false　NG：true</returns>
            public bool checkTextboxFile(Control con, out string msg, string msgCode, params object[] args)
            {
                bool res = true;
                msg = Utile.Message.message[msgCode];
                return res;
            }

            /// <summary>
            /// テキストボックスの重複チェック
            /// </summary>
            /// <param name="con">コントロール</param>
            /// <returns>OK：false　NG：true</returns>
            public bool checkTextUniqueFormat(Control[] con, out string msg, string msgCode, params object[] args)
            {
                bool res = false;
                if (con[0].Text.Equals("") || con[1].Text.Equals(""))
                {
                    res = false;
                }
                else
                {
                    res = (con[0].Text.Equals(con[1].Text));
                }
                msg = Utile.Message.message[msgCode];
                return res;
            }


        }

        /****************************
         *以下自動生成 
        /****************************/
        private ErrorProvider errorProvider;
        private System.ComponentModel.IContainer components;
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;

            // 
            // UserControlExp
            // 
            this.Name = "UserControlExp";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

    }
    public interface IUserControl
    {

        //ページリフレッシュの抽象メセッド
        void PageRefresh();
    }

    public class modifyCheck
    {
        public List<Control> controlList;
        public Dictionary<string, object> controlCloneList;

        public modifyCheck()
        {
            controlList = new List<Control>();
            controlCloneList = new Dictionary<string, object>();
        }

        public void add(Control con)
        {
            controlList.Add(con);
            addClone(con);
        }
        private void addClone(Control con)
        {
            if (con.GetType() == typeof(TextBox))
            {
                controlCloneList.Add(con.Name, ((TextBox)con).Text);
            }
            else if (con.GetType() == typeof(ComboBox))
            {
                controlCloneList.Add(con.Name, ((ComboBox)con).SelectedIndex);
            }
            else if (con.GetType() == typeof(DateTimePicker))
            {
                controlCloneList.Add(con.Name, ((DateTimePicker)con).Value);
            }
            else if (con.GetType() == typeof(CheckBox))
            {
                controlCloneList.Add(con.Name, ((CheckBox)con).Checked);
            }
            else if (con.GetType() == typeof(DataGridView))
            {
                var dgv = (DataGridView)con;
                StringBuilder sb = new StringBuilder();
                foreach (var row in dgv.Rows.Cast<DataGridViewRow>())
                {
                    foreach (var cell in row.Cells.Cast<DataGridViewCell>())
                    {
                        sb.Append(cell.Value);
                    }
                }
                controlCloneList.Add(con.Name, sb.ToString());
            }
        }
        public bool chack()
        {
            bool flg = true;

            foreach (var con in controlList)
            {
                if (con.GetType() == typeof(TextBox))
                {
                    if (controlCloneList[((TextBox)con).Name].ToString() != ((TextBox)con).Text)
                        flg = false;
                }
                else if (con.GetType() == typeof(ComboBox))
                {
                    if ((int)(controlCloneList[((ComboBox)con).Name]) != ((ComboBox)con).SelectedIndex)
                        flg = false;
                }
                else if (con.GetType() == typeof(DateTimePicker))
                {
                    if ((DateTime)(controlCloneList[((DateTimePicker)con).Name]) != ((DateTimePicker)con).Value)
                        flg = false;
                }
                else if (con.GetType() == typeof(CheckBox))
                {
                    if ((bool)(controlCloneList[((CheckBox)con).Name]) != ((CheckBox)con).Checked)
                        flg = false;
                }
                else if (con.GetType() == typeof(DataGridView))
                {
                    var dgv = (DataGridView)con;
                    StringBuilder sb = new StringBuilder();
                    foreach (var row in dgv.Rows.Cast<DataGridViewRow>())
                    {
                        foreach (var cell in row.Cells.Cast<DataGridViewCell>())
                        {
                            sb.Append(cell.Value);
                        }
                    }
                    if ((string)(controlCloneList[((DataGridView)con).Name]) != sb.ToString())
                        flg = false;
                }
            }

            return flg;
        }

        public void clear()
        {
            controlList.Clear();
            controlCloneList.Clear();
        }

        public void reset()
        {
            controlCloneList.Clear();
            foreach (var con in controlList)
            {
                addClone(con);
            }
        }

        public bool chackMessage(string syori)
        {
            if (chack() == false)
            {
                DialogResult result = MessageBox.Show(Utile.Message.message["W00004"].Replace("@処理", syori),
                                                        "警告",
                                                        MessageBoxButtons.OKCancel,
                                                        MessageBoxIcon.Exclamation,
                                                        MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Cancel)
                    return false;
            }
            return true;
        }
    }
}
