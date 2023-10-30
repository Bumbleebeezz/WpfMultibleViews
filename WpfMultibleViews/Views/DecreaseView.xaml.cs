using System.Windows;
using System.Windows.Controls;
using WpfMultibleViews.Managers;
using WpfMultibleViews.Models;

namespace WpfMultibleViews.Views
{
    /// <summary>
    /// Interaction logic for DecreaseView.xaml
    /// </summary>
    public partial class DecreaseView : UserControl
    {
        public DecreaseView()
        {
            InitializeComponent();
        }

        private void DecreaseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            CounterManager.CounterModel.Counter--;
        }
    }
}
