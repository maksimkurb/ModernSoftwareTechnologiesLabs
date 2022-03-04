using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsDataDirty { get; set; }
        public MyWindow? MyWindowInstance { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            WelcomeLabel.Content = "Добрый день!";
            SetBut.IsEnabled = false;
            RetBut.IsEnabled = false;
            IsDataDirty = false;
        }

        private void setBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var sw = new System.IO.StreamWriter("username.txt"))
                {
                    sw.WriteLine(SetText.Text);
                    RetBut.IsEnabled = true;
                    IsDataDirty = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void retBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var sr = new System.IO.StreamReader("username.txt"))
                {
                    RetLabel.Content = $"Привет, {sr.ReadToEnd()}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void setText_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetBut.IsEnabled = true;
            IsDataDirty = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.IsDataDirty)
            {
                string msg = "Данные были изменены, но не сохранены!\n Закрыть окно без сохранения ?";
                MessageBoxResult result = MessageBox.Show(msg, "Контроль данных", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MyWindowInstance == null)
                MyWindowInstance = new MyWindow();
            MyWindowInstance.Owner = this;
            var location = this.PointToScreen(new Point(0, 0));
            MyWindowInstance.Left = location.X + this.Width;
            MyWindowInstance.Top = location.Y;
            MyWindowInstance.Show();
        }

    }
}
