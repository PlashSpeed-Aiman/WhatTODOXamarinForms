using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace App2.ViewModel
{
    public class WhatsappViewModel : BaseViewModel
    {
        public ICommand MessageCommand { get; }
        private string _whatsappname = String.Empty;
        private string _whatsapplink = "https://wa.me/";
        public string WhatsappName { get { return _whatsappname; } set { _whatsappname = value; OnPropertyChanged();OnPropertyChanged("WhatsappLink"); } }
        public string WhatsappLink => _whatsapplink + _whatsappname;
        public WhatsappViewModel()
        {
            //new Command<object>(async (o) => await MessageLink(o));
            MessageCommand = new Command(async () => await MessageLink());
            
        }

        private Task MessageLink()
        {
           Launcher.OpenAsync(new System.Uri(_whatsapplink+_whatsappname));
           return Task.CompletedTask;
        }
    }
}
