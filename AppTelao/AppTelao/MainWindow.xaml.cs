using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


using System.Windows.Threading;

namespace AppTelao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
                
        Thread tServer;
        Servidor servidor;

        string tweet = "";
        string usuario = "";
        string userTweet = "";

        bool atualizar = false;

        // 0...4
        const int maxTweets = 4;
        int contador = 0;
        

        public void NovoTweet(string s)
        {

            userTweet = s;

            if (Listas.NovoTweet(userTweet))
            {
                bool nome = true;               

                atualizar = true;
                usuario = "";
                tweet = "";

                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ' ')
                    {
                        nome = false;
                    }
                    if (nome)
                    {
                        usuario += s[i];
                    }
                    else
                    {
                        tweet += s[i];
                    }
                }
            }
            else
            {
                atualizar = false;
            }

        }

        private void Window_LayoutUpdated(object sender, EventArgs e)
        {
            if (atualizar)
            {
                if (contador == 0)
                {
                    labelUser0.Content = usuario;
                    labelTweet0.Content = tweet;
                                       
                }
                else if (contador == 1)
                {
                    labelUser1.Content = usuario;
                    labelTweet1.Content = tweet;
                }
                else if (contador == 2)
                {
                    labelUser2.Content = usuario;
                    labelTweet2.Content = tweet;
                }
                else if (contador == 3)
                {
                    labelUser3.Content = usuario;
                    labelTweet3.Content = tweet;
                }
                else if (contador == 4)
                {
                    labelUser4.Content = usuario;
                    labelTweet4.Content = tweet;
                }
                

                contador++;
                if (contador > maxTweets)
                {
                    contador = 0;
                }

                atualizar = false;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
                   

            servidor = new Servidor(this);

            tServer = new Thread(servidor.Up);
            tServer.Start();
            Thread.Sleep(200);

            labelUser0.Content = "";
            labelUser1.Content = "";
            labelUser2.Content = "";
            labelUser3.Content = "";
            labelUser4.Content = "";


            labelTweet0.Content = "";
            labelTweet1.Content = "";
            labelTweet2.Content = "";
            labelTweet3.Content = "";
            labelTweet4.Content = "";
        }
      

        

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tServer.Abort();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            labelUser0.Width = ActualWidth;
            labelUser1.Width = ActualWidth;
            labelUser2.Width = ActualWidth;
            labelUser3.Width = ActualWidth;
            labelUser4.Width = ActualWidth;

            labelTweet0.Width = ActualWidth;
            labelTweet1.Width = ActualWidth;
            labelTweet2.Width = ActualWidth;
            labelTweet3.Width = ActualWidth;
            labelTweet4.Width = ActualWidth;
        }

        /*/
        private void animacao()
        {
            //animation = new DoubleAnimation(0, TimeSpan.FromSeconds(2));
            //animation.AutoReverse = true;
            
            DoubleAnimation a = new DoubleAnimation(0, TimeSpan.FromSeconds(2));
            a.IsAdditive = false;
            labelTest.Opacity = 100;
            labelTest.BeginAnimation(Image.OpacityProperty, a);           
            
            //labelTest.
            //DoubleAnimation a = new DoubleAnimation(1, TimeSpan.FromSeconds(0.00001));
            //labelTest.BeginAnimation(Image.OpacityProperty, a);
            //labelTest.BeginAnimation(Image.OpacityProperty, animation);
            //animation.Freeze
        }
        /*/
    }
}
