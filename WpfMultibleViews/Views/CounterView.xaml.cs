using System.Windows.Controls;
using WpfMultibleViews.Managers;

namespace WpfMultibleViews.Views
{
    /// <summary>
    /// Interaction logic for CounterView.xaml
    /// </summary>
    public partial class CounterView : UserControl
    {
        public CounterView()
        {
            InitializeComponent();

            CounterManager.CounterModel.CounterChanged +=
                () => CounterTxtB.Text = CounterManager.CounterModel.Counter.ToString();
        }
    }
}
