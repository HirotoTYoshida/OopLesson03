using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace SendMailApp {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        
        SmtpClient sc = new SmtpClient();

        public MainWindow() {
            InitializeComponent();
            sc.SendCompleted += Sc_SendCompleted;
        }

    
            //送信完了イベント
            private void Sc_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) {
            if(e.Cancelled) {
                MessageBox.Show("送信はキャンセルされました。");
            } else {
                MessageBox.Show(e.Error?.Message ?? "送信完了！");
            }
        }

        //メール送信処理
        private void btOk_Click(object sender, RoutedEventArgs e) {
            try {

                Config cf = (Config.GetInstance()).getDefaultStatus();
                MailMessage msg = new MailMessage(cf.MailAddress, tbTo.Text);
                if (tbCc.Text != "")
                    msg.CC.Add(tbCc.Text);

                if (tbBcc.Text != "")
                    msg.Bcc.Add(tbBcc.Text);
                
                msg.Subject = tbTitle.Text; //件名
                msg.Body = tbBody.Text;//本文

                sc.Host = cf.Smtp;//SMTPサーバーの設定
                sc.Port = cf.Port;
                sc.EnableSsl = cf.Ssl;
                sc.Credentials = new NetworkCredential(cf.MailAddress,cf.PassWord);

                //sc.Send(msg);   //送信
                sc.SendMailAsync(msg);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        //送信キャンセル処理
        private void btCancel_Click(object sender, RoutedEventArgs e) {
            sc.SendAsyncCancel();
        }

        //設定画面表示
        private void btConfig_Click(object sender, RoutedEventArgs e)
        {
            ConfigWindowShow(); //設定画面
        }

        private static void ConfigWindowShow()
        {
            ConfigWindow configWindow = new ConfigWindow();
            configWindow.ShowDialog();　//表示
        }

        //メインウィンドウがロードされるタイミングで呼び出される
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Config.GetInstance().DeSerialise(); //逆シリアル化　XML　→　オブジェクト
            }
            catch (FileNotFoundException)
            {
                ConfigWindowShow(); //ファイルが存在しないので設定画面を先に表示
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                Config.GetInstance().Serialise(); //シリアル化　XML　→　オブジェクト
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
