using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfMultibleViews.Views
{
    /// <summary>
    /// Interaction logic for PeopleView.xaml
    /// </summary>
    public partial class PeopleView : UserControl
    {
        public ObservableCollection<PersonModel> PeopleList { get; set; } = new();

        public PeopleView()
        {
            InitializeComponent();

            // Set data context
            DataContext = this;

            PeopleList.Add(new PersonModel() { FirstName = "Maria", LastName = "Edström" });
            PeopleList.Add(new PersonModel() { FirstName = "Eva", LastName = "Edström" });
            PeopleList.Add(new PersonModel() { FirstName = "Bengt", LastName = "Edström" });
        }
    }
}
