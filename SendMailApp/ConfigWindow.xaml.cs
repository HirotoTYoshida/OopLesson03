using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SendMailApp {
    /// <summary>
    /// ConfigWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfigWindow : Window {
        public ConfigWindow() {
            InitializeComponent();
        }

        private void btDefault_Click(object sender, RoutedEventArgs e)
        {
            Config cf = (Config.GetInstance()).getDefaultStatus();
            tbSmtp.Text = cf.Smtp;
            tbPort.Text = cf.Port.ToString();
            tbSender.Text = tbUserName.Text = cf.MailAddress;
            tbPassWord.Password = cf.PassWord;
            cbSsl.IsChecked = cf.Ssl;
        }

        //適用（更新）
        private void btApply_Click(object sender, RoutedEventArgs e)
        {
            (Config.GetInstance()).UpdateStatus(
                tbSmtp.Text,
                tbUserName.Text,
                tbPassWord.Password,
                int.Parse(tbPort.Text),
                cbSsl.IsChecked ?? false);  //更新処理を呼び出す

            
        }

        //OKボタン
        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbSmtp.Text == "" || tbPort.Text == "" || tbPassWord.Password == "" ||
                tbSender.Text == "" || tbUserName.Text == "")
            {
                AlertMessage();
            }
            else
            {
                btApply_Click(sender, e);   //更新処理を呼び出す
                this.Close();
            }
        }

        //キャンセルボタン
        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            if (DataCheck())
            {
                AlertMessage();
            }
            else if (ComparisionData())
            {
                SaveMessage(sender, e);
            }
            else
            {
                this.Close();
            }
        }
        

        //ロード時に一度だけ呼び出される
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Config cf = (Config.GetInstance()).getDefaultStatus();
            tbSmtp.Text = cf.Smtp;
            tbPort.Text = cf.Port.ToString();
            tbSender.Text = tbUserName.Text = cf.MailAddress;
            tbPassWord.Password = cf.PassWord;
            cbSsl.IsChecked = cf.Ssl;
        }

        //は
        private bool DataCheck()
        {
            if (tbSmtp.Text == "" || tbPort.Text == "" || tbPassWord.Password == "" ||
                tbSender.Text == "" || tbUserName.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AlertMessage() 
        {

            var result = MessageBox.Show("すべての項目を入力してください。", "エラー",
               MessageBoxButton.OK);

           
        }
        //

        private bool ComparisionData()
        {
            Config cf = Config.GetInstance();
            if (cf.Smtp != tbSmtp.Text || cf.MailAddress != tbSender.Text ||
                cf.PassWord != tbPassWord.Password || cf.Port != int.Parse(tbPort.Text) ||
                cf.MailAddress != tbUserName.Text)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        private void SaveMessage(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("ファイルを上書きしますか？", "質問",
                MessageBoxButton.OKCancel);

            if (result == MessageBoxResult.OK)
            {
                btApply_Click(sender, e);
                this.Close();
            }
            else if (result == MessageBoxResult.Cancel)
            {
                this.Close();
            }
        }

    }
}
