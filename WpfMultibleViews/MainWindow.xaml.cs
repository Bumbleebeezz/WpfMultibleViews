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
using WpfMultibleViews.Models;

namespace WpfMultibleViews
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CounterModel CounterModel { get; set; } = new (); // Implicit instansiering

        public MainWindow()
        {
            InitializeComponent();

        }

        private void DecreaseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            CounterModel.Counter--;
            CounterTxtB.Text = CounterModel.Counter.ToString();
        }

        private void ClearBtn_OnClick(object sender, RoutedEventArgs e)
        {
            CounterModel.Counter = 0;
            CounterTxtB.Text = CounterModel.Counter.ToString();
        }

        private void IncreaseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            CounterModel.Counter++;
            CounterTxtB.Text = CounterModel.Counter.ToString();
        }
    }
}
