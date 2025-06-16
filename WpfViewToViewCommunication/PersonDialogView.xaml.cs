using System.Windows;
using WpfViewToViewCommunication.ViewModels;

namespace WpfViewToViewCommunication.Views
{
    public partial class PersonDialogView : Window
    {
        public PersonDialogView(PersonDialogViewModel personDialogViewModel)
        {
            InitializeComponent();
            DataContext = personDialogViewModel;
            personDialogViewModel.CloseAction = Close;
        }
    }
}
