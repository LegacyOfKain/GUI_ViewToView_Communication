using System.Windows;

namespace WpfViewToViewCommunication.Services
{
    public class DialogService : IDialogService
    {
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}