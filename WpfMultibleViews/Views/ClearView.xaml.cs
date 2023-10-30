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
using WpfMultibleViews.Managers;

namespace WpfMultibleViews.Views
{
    /// <summary>
    /// Interaction logic for ClearView.xaml
    /// </summary>
    public partial class ClearView : UserControl
    {
        public ClearView()
        {
            InitializeComponent();
        }

        private void ClearBtn_OnClick(object sender, RoutedEventArgs e)
        {
            CounterManager.CounterModel.Counter = 0;
        }
    }
}
