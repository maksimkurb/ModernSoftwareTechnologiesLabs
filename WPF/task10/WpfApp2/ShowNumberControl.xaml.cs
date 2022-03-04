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

namespace WpfApp2
{
    public partial class ShowNumberControl : UserControl
    {
        public ShowNumberControl()
        {
            InitializeComponent();
        }
        private int _currentNumber = 0;

        public int CurrentNumber
        {
            get => _currentNumber;
            set 
            {
                _currentNumber = value;
                numberDisplay.Content = _currentNumber;
            }
        }

        public static bool ValidateCurrentNumber(object value)
        {
            int x = Convert.ToInt32(value);
            return x >= 0 && x <= 500;
        }

        private static void CurrentNumberChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            ShowNumberControl s = depObj as ShowNumberControl;
            s.numberDisplay.Content = args.NewValue.ToString();
        }

        public static readonly DependencyProperty CurrentNumberProperty =
            DependencyProperty.Register("CurrentNumber", typeof(int), typeof(ShowNumberControl), 
                new PropertyMetadata(100, new PropertyChangedCallback(CurrentNumberChanged)), 
                new ValidateValueCallback(ValidateCurrentNumber));


    }
}
