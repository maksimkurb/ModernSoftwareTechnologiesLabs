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
    public partial class MainWindow : Window
    {
        private bool isDataDirty = false;
        public MyWindow myWindow { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            lbl.Content = "Добрый день!";
            setBut.IsEnabled = false;
            retBut.IsEnabled = false;
            Top = 25;
            Left = 25;
        }

        private void SetText_TextChanged(object sender, TextChangedEventArgs e)
        {
            setBut.IsEnabled = true;
            isDataDirty = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(this.isDataDirty)
            {
                String msg = "Данные были изменены, но не сохранены!\nЗакрыть окно без сохранения?";
                MessageBoxResult result = MessageBox.Show(msg, "Контроль данных", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if(result == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void New_Win_Click(object sender, RoutedEventArgs e)
        {
            if(myWindow == null)
            {
                myWindow = new MyWindow();
            }
            Point location = New_Win.PointToScreen(new Point(0, 0));
            myWindow.Left = location.X + New_Win.Width;
            myWindow.Top = location.Y;
            myWindow.Owner = this;
            myWindow.Show();
        }

        private void setBut_Handler(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var sw = new System.IO.StreamWriter("username.txt"))
                {
                    sw.WriteLine(setText.Text);
                    retBut.IsEnabled = true;
                    isDataDirty = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void retBut_Handler(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var sr = new System.IO.StreamReader("username.txt"))
                {
                    retLabel.Content = $"Привет, {sr.ReadToEnd()}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement fe = e.Source as FrameworkElement;

            switch(fe.Name)
            {
                case "setBut":
                    setBut_Handler(sender, e);
                    break;
                case "retBut":
                    retBut_Handler(sender, e);
                    break;
            }
            e.Handled = true;
        }
    }
}
