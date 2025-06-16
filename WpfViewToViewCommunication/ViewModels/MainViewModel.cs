using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WpfViewToViewCommunication.EventAggregators;
using WpfViewToViewCommunication.Services;
using WpfViewToViewCommunication.Views;

namespace WpfViewToViewCommunication.ViewModels;
public class MainViewModel : INotifyPropertyChanged
{
    private readonly EventAggregator _eventAggregator;
    private readonly IServiceProvider _serviceProvider;
    private readonly IDialogService _dialogService;

    private string _lastSavedPersonInfo;
    public string LastSavedPersonInfo
    {
        get => _lastSavedPersonInfo;
        set
        {
            _lastSavedPersonInfo = value;
            OnPropertyChanged();
        }
    }

    public ICommand ChangeBackgroundColorCommand { get; } // button presses
    public ICommand OpenPersonDialogCommand { get; } // button presses

    public Action<string> UpdateLastSavedPersonInfo { get; set; } // action needed to update anything on wpf

    public MainViewModel(EventAggregator eventAggregator, IServiceProvider serviceProvider, IDialogService dialogService)
    {
        _eventAggregator = eventAggregator;
        _serviceProvider = serviceProvider;
        _dialogService = dialogService;
        _eventAggregator.Subscribe<PersonSavedEvent>(OnPersonSaved);

        ChangeBackgroundColorCommand = new RelayCommand(ChangeBackgroundColor);
        OpenPersonDialogCommand = new RelayCommand(OpenPersonDialog);
    }

    private void ChangeBackgroundColor()
    {

    }

    private void OpenPersonDialog()
    {
        PersonDialogView dialog = _serviceProvider.GetRequiredService<PersonDialogView>();
        dialog.Owner = Application.Current.MainWindow;
        dialog.ShowDialog();
    }

    private void OnPersonSaved(PersonSavedEvent e)
    {
        LastSavedPersonInfo = $"Person saved: {e.Name}, Age: {e.Age}";
        UpdateLastSavedPersonInfo?.Invoke(LastSavedPersonInfo);
        _dialogService.ShowMessage(LastSavedPersonInfo);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

