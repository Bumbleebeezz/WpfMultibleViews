using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Common.DTOs;
using DataAccess.Services;
using WpfMultibleViews.Models;

namespace WpfMultibleViews.Views
{
    public partial class PeopleView : UserControl
    {
        private readonly PeopleRepository _peopleRepository;

        public ObservableCollection<PersonModel> PeopleList { get; set; } = new();
        public PersonModel? SelectedPerson { get; set; } = new ();
        public string EditFirstName { get; set; } = string.Empty;
        public string EditLastName { get; set; } = string.Empty;

        public PeopleView()
        {
            InitializeComponent();

            // Set data context
            DataContext = this;

            _peopleRepository = new PeopleRepository();

            PeopleList.Add(new PersonModel() { FirstName = "Maria", LastName = "Edström" });
            PeopleList.Add(new PersonModel() { FirstName = "Eva", LastName = "Edström" });
            PeopleList.Add(new PersonModel() { FirstName = "Bengt", LastName = "Edström" });

            var allPeople = _peopleRepository.GetAllPeople();
            foreach (var person in allPeople)
            {
                PeopleList.Add(new PersonModel()
                    {
                        ID = person.ID, 
                        FirstName = person.FirstName,
                        LastName = person.LastName

                    });
            }
        }

        private void UpdateBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (SelectedPerson is null)
            {
                return;
            }

            SelectedPerson.FirstName = EditFirstName;
            SelectedPerson.LastName = EditLastName;

            _peopleRepository.UpdatePersonLastname(SelectedPerson.ID,EditLastName);
        }

        private void AddBtn_OnClick(object sender, RoutedEventArgs e)
        {
            PeopleList.Add(new PersonModel() 
            { 
                FirstName = EditFirstName, 
                LastName = EditLastName
            });

            var personRecord = new PersonRecord("", EditFirstName,EditLastName);

            _peopleRepository.AddPerson(personRecord);
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

            _peopleRepository.DeletePerson(SelectedPerson.ID);

            PeopleList.Remove(SelectedPerson);
        }
    }
}
