using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private List<string> PhoneNumbers = new List<string>();
        private SaveFileDialog SaveFileDialog;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog = new SaveFileDialog();
            SaveFileDialog.Filter = "Text Files | *.txt";
            SaveFileDialog.ShowDialog();
            System.IO.StreamWriter myWriter = new System.IO.StreamWriter(SaveFileDialog.FileName, true);
            foreach(string s in PhoneNumbers)
            {
                myWriter.WriteLine(s);
            }
            myWriter.Close();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MaskedTextBox box = widnowsFormHost1.Child as MaskedTextBox;
            PhoneNumbers.Add(box.Text);
            box.Clear();
        }
    }
}
