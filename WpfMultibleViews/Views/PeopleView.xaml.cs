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

        public PersonModel? SelectedPerson { get; set; } = new ();

        public string EditFirstName { get; set; } = string.Empty;
        public string EditLastName { get; set; } = string.Empty;

        public PeopleView()
        {
            InitializeComponent();

            // Set data context
            DataContext = this;

            PeopleList.Add(new PersonModel() { FirstName = "Maria", LastName = "Edström" });
            PeopleList.Add(new PersonModel() { FirstName = "Eva", LastName = "Edström" });
            PeopleList.Add(new PersonModel() { FirstName = "Bengt", LastName = "Edström" });
        }

        private void UpdateBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedPerson is null)
            {
                return;
            }

            SelectedPerson.FirstName = EditFirstName;
            SelectedPerson.LastName = EditLastName;
        }

        private void AddBtn_OnClick(object sender, RoutedEventArgs e)
        {
            PeopleList.Add(new PersonModel() 
            { 
                FirstName = EditFirstName, 
                LastName = EditLastName
            });
        }

        private void RemoveBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var removePerson = PeopleList.Where(
                p => p.FirstName == FirstNameTxtB.Text 
                     && 
                     p.LastName == LastNameTxtb.Text
                     );
            PeopleList.Remove(removePerson.FirstOrDefault());

            if (SelectedPerson is null){ return;}

            PeopleList.Remove(SelectedPerson);
        }
    }
}
