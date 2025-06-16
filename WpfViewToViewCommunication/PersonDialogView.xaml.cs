using System.Windows;
using WpfViewToViewCommunication.Commands;

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
