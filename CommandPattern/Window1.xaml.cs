using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows;

namespace CommandPattern
{
    /// <summary>
    /// Window1.xaml 的互動邏輯
    /// </summary>
    public partial class Window1 : Window
    {
        public FileLoader fileLoader;
        public List<IReciever> recievers;
        public string iniFileName;
        public ICommand command;
        public BackgroundWorker bw;
        delegate void ThreadsSynchronization(string content);
        public Window1()
        {
            InitializeComponent();
            fileLoader = new FileLoader();
            recievers = new List<IReciever>();
            command = new Command();
            bw= new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(DoWork);
            bw.RunWorkerAsync();
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string exeDir = System.IO.Path.GetDirectoryName(exePath);
            iniFileName = string.Format("{0}{1}", exeDir, @"\setting.ini");

        }
        public void LoadIni(object sender, RoutedEventArgs e)
        {
            command.RecmoveRecievers();
            itemBox.Text="";
            fileLoader.GetRecieverItems(iniFileName, ref recievers);
            int count = 0;
            foreach(IReciever reciever in recievers)
            {
                count = count + 1;
                itemBox.Text = itemBox.Text + "Test item " + count.ToString() + ": ";
                itemBox.Text = itemBox.Text + reciever.Name + "\r\n";
                command.AddReciever(reciever);
            }
        }
        public void Executed(object sender, RoutedEventArgs e)
        {
            command.Execute();
        }
        public void DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                string msg = "";
                foreach (IReciever reciever in this.recievers)
                {
                    msg = msg + reciever.Msg ;
                }
                 Dispatcher.BeginInvoke(new ThreadsSynchronization(SubThreadExcuteCode), new object[] { msg});
                //this.msgbox.Text = msg;
                System.Threading.Thread.Sleep(100);
            }
        }
        private void SubThreadExcuteCode(string content)
        {
            this.msgbox.Text = content;
        }
    }
}
