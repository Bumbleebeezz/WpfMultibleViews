using System.Windows;
using System.Windows.Controls;
using WpfMultibleViews.Managers;

namespace WpfMultibleViews.Views
{
    /// <summary>
    /// Interaction logic for IncreaseView.xaml
    /// </summary>
    public partial class IncreaseView : UserControl
    {
        public IncreaseView()
        {
            InitializeComponent();
        }

        private void IncreaseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            CounterManager.CounterModel.Counter++;
        }
    }
}
