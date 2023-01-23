using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using App2.Model;

namespace App2.ViewModel
{
    public class WhatsappViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set;}

        public ICommand MessageCommand { get; }
        private string _whatsappname = String.Empty;
        private string _whatsapplink = "https://wa.me/";
        private ObservableCollection<WhatsAppNumber> _listWhatsAppNumbers;
        
        public WhatsappViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            _listWhatsAppNumbers = new ObservableCollection<WhatsAppNumber>();
            //new Command<object>(async (o) => await MessageLink(o));
            MessageCommand = new Command(async () => await MessageLink());
            CopyCommand = new Command(async () =>  await CopyText());
            EditCommand = new Command(async () => await GotoPage2());

        }

        private async Task GotoPage2()
        {
            await Navigation.PushAsync(new EditPage());
        }

        public string WhatsappName { get { return _whatsappname; } set { _whatsappname = value; OnPropertyChanged();OnPropertyChanged("WhatsappLink"); } }

        public ObservableCollection<WhatsAppNumber> ListWhatsAppNumbers
        {
            get => _listWhatsAppNumbers;
            set
            {
                _listWhatsAppNumbers = value;
                OnPropertyChanged();
            }

        }
        public string WhatsappLink
        {
            get
            {
                _whatsappname = Regex.Replace(_whatsappname, "[^0-9.]", "");
                return _whatsapplink + "6"+ _whatsappname;
            }
        }
        
        public ICommand CopyCommand
        {
            get;
            private set;
        }

        public ICommand EditCommand
        {
            get;
        }
       

        private async Task CopyText()
        {
            _listWhatsAppNumbers.Add(new WhatsAppNumber
            {
                PhoneNumber = WhatsappLink
            });
            await Clipboard.SetTextAsync(WhatsappLink);
        }

        private Task MessageLink()
        {
           Launcher.OpenAsync(new System.Uri(WhatsappLink));
           return Task.CompletedTask;
        }
    }
}
