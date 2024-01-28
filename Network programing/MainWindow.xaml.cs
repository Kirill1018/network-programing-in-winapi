using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
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

namespace Network_programing
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static string file_cont = string.Empty,
            file_path = string.Empty;
        private void file_Click(object sender, RoutedEventArgs e)
        {
            new OpenFileDialog().InitialDirectory = "";
            new OpenFileDialog().Filter = "";
            new OpenFileDialog().RestoreDirectory = true;
            if (new OpenFileDialog().ShowDialog() == true)
            {
                file_path = new OpenFileDialog().FileName;
                file_cont = new StreamReader(new OpenFileDialog().OpenFile()).ReadToEnd();
                byte[] infobuffer = new byte[new MemoryStream().Length];
                new MemoryStream().Close();
                new FileStream(file_path, FileMode.Open, FileAccess.Read).Read(infobuffer, infobuffer.Length, (int)new FileInfo(file_path).Length);
                new FileStream(file_path, FileMode.Open, FileAccess.Read).Close();
                new TcpClient("192.168.1.130", 2024).GetStream().Write(infobuffer, 0, infobuffer.Length);
            }
        }
    }
}