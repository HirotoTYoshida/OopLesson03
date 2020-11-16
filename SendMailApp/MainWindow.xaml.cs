using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SendMailApp
{
    
    public partial class MainWindow : Window
    {
        SmtpClient sc = new SmtpClient();

        public MainWindow()
        {
            InitializeComponent();
            sc.SendCompleted += Sc_SendCompleted;
        }

        //送信完了イベント
        private void Sc_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("送信はキャンセルされました。");
            }
            else
            {
                MessageBox.Show(e.Error?.Message ?? "送信完了しました。");
            }
        }

        //メール送信処理
        private void btOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Config cf = Config.GetInstance();

                MailMessage msg = new MailMessage(cf.MailAddress, tbTo.Text);

                if (tbBcc.Text != "")
                {
                    msg.Bcc.Add(tbBcc.Text);
                    
                }
                if(tbCc.Text != "")
                {
                    msg.CC.Add(tbCc.Text);
                }

                msg.Subject = tbTitle.Text; //件名
                msg.Body = tbBody.Text;     //本文

                sc.Host = cf.Smtp;
                sc.Port = cf.Port;
                sc.EnableSsl = cf.Ssl;
                sc.Credentials = new NetworkCredential(cf.MailAddress, cf.PassWord); 
                sc.SendMailAsync(msg);

                foreach (var item in tbAthor.Items)
                {
                    msg.Attachments.Add(new Attachment(item.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //送信キャンセル処理
        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            sc.SendAsyncCancel();        
        }

        public void btConfig_Click(object sender, RoutedEventArgs e)
        {
            ConfigWindowShow(); //設定画面表示
        }

        //設定画面表示
        private static void ConfigWindowShow()
        {
            ConfigWindow configWindow = new ConfigWindow(); //設定画面のインスタンスを生成
            configWindow.ShowDialog();  //表示
        }

        //メインウィンドウがロードされるタイミングで呼び出される
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Config.GetInstance().DeSerialise();
            }
            catch (FileNotFoundException)
            {
                ConfigWindowShow();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        //メインウィンドウが閉じられるタイミングで呼び出される
        public void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Config.GetInstance().Serialise();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            var fod = new OpenFileDialog();

            if (fod.ShowDialog() == true)
            {
                tbAthor.Items.Add(fod.FileName);
            }
        }

        private void btDel_Click(object sender, RoutedEventArgs e)
        {
            tbAthor.Items.Clear();
        }
    }
}
