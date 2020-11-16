using System;
using System.Collections.Generic;
using System.Data;
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
using MessageBox = System.Windows.MessageBox;

namespace SendMailApp
{
    
    public partial class ConfigWindow : Window
    {
        public bool Change = false;

        public ConfigWindow()
        {
            InitializeComponent();
        }

        public bool Modified { get; set; }

        //設定ボタン
        private void btDefault_Click(object sender, RoutedEventArgs e)
        {
            Config cf = (Config.GetInstance()).getDefaultStatus();
            

            tbSmtp.Text = cf.Smtp;
            tbPort.Text = cf.Port.ToString();
            tbSender.Text = tbUserName.Text = cf.MailAddress;
            tbPassWord.Password = cf.PassWord;
            cbSsl.IsChecked = cf.Ssl;
        }

        //適用ボタン
        private void btApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (Config.GetInstance()).UpdateStatus(
                tbSmtp.Text,
                tbUserName.Text,
                tbPassWord.Password,
                int.Parse(tbPort.Text),
                cbSsl.IsChecked ?? false);
                ChangeOk(sender, e);
            }
            catch (Exception ex)
            {

                MessageBox.Show("値を入力してください");
            }

        }

        //OKボタン
        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            if (tbSmtp.Text == "" || tbUserName.Text == "" || tbPort.Text == "" || tbPassWord.Password == "" || tbSender.Text == "")
            {
                MessageBox.Show("未入力の項目があります。");

            }
            else
            {
                btApply_Click(sender, e);  
                this.Close();
            }
        }

        //キャンセルボタン
        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            if (Change == true)
            {
                MessageBoxResult result = MessageBox.Show("内容が変更されています。保存しますか？", "Daanger", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.Cancel)
                {
                    ChangeOk(sender, e);
                    this.Close();
                }
                else if (result == MessageBoxResult.OK)
                {
                    btApply_Click(sender, e);
                    this.Close();
                }
            }
            else
            {
                ChangeOk(sender, e);
                this.Close();
            }
        }

        //設定画面ロード時に一度だけ呼び出される
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Config cf = Config.GetInstance();
            tbSmtp.Text = cf.Smtp;
            tbPort.Text = cf.Port.ToString();
            tbSender.Text = tbUserName.Text = cf.MailAddress;
            tbPassWord.Password = cf.PassWord;
            cbSsl.IsChecked = cf.Ssl;
            ChangeOk(sender, e);
        }

        private void Config_TextChanged(object sender, TextChangedEventArgs e)
        {
            Change = true;
        }

        private void tbPassWord_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Change = true;
        }

        private void ChangeOk(object sender, RoutedEventArgs e)
        {
            Change = false;
        }
    }
}