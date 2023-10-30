using System.Windows;
using System.Windows.Controls;
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
