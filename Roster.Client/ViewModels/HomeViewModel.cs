using Roster.Client.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Roster.Client.ViewModels
{
    public class HomeViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string title = "Roster App";
        public string Title
        {
            get { return title; }
            set
            {
                if (value != title)
                {
                    title = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public ObservableCollection<Person> People { get; private set; }

        public Command UpdateApplicationCommand { get; set; }

        public HomeViewModel()
        {
            UpdateApplicationCommand = new Command(execute: () => this.Title = "Roster App (v2.0)");

            People = new ObservableCollection<Person>
            {
                new Person { Name = "Delores Feil", Company = "Legros Group"},
                new Person { Name = "Ann Zboncak", Company = "Ledner - Ferry" },
                new Person { Name = "Jaime Lesch", Company = "Herzog and Sons" }
            };
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
