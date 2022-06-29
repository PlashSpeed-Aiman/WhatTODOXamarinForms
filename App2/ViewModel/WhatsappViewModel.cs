using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App2.ViewModel
{
    public class WhatsappViewModel : BaseViewModel
    {
        public ICommand MessageCommand { get; }
        private string _whatsappname = String.Empty;
        private string _whatsapplink = "https://wa.me/";
        public string WhatsappName { get { return _whatsappname; } set { _whatsappname = value; OnPropertyChanged();OnPropertyChanged("WhatsappLink"); } }
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
        }

        public WhatsappViewModel()
        {
            //new Command<object>(async (o) => await MessageLink(o));
            MessageCommand = new Command(async () => await MessageLink());
            CopyCommand = new Command(async () =>  await CopyText());

        }

        private async Task CopyText()
        {
            await Clipboard.SetTextAsync(WhatsappLink);
        }

        private Task MessageLink()
        {
           Launcher.OpenAsync(new System.Uri(WhatsappLink));
           return Task.CompletedTask;
        }
    }
}
