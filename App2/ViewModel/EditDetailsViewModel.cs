using App2.Model;

namespace App2.ViewModel
{
    public class EditDetailsViewModel
    {
        private WhatsAppNumber _whatsAppNumber;
        public EditDetailsViewModel(WhatsAppNumber appNumber)
        {
            this._whatsAppNumber = appNumber;
            appNumber.Name = "AIMAN";
        }
        
    }
}