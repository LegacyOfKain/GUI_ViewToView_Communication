using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfViewToViewCommunication.EventAggregators;

namespace WpfViewToViewCommunication.ViewModels;
public class PersonDialogViewModel : INotifyPropertyChanged
{
    private string _name;
    private int _age;
    private readonly EventAggregator _eventAggregator;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    public int Age
    {
        get => _age;
        set
        {
            _age = value;
            OnPropertyChanged();
        }
    }

    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }
    public Action CloseAction { get; set; }

    public PersonDialogViewModel(EventAggregator eventAggregator)
    {
        _eventAggregator = eventAggregator;
        SaveCommand = new RelayCommand(Save, CanSave);
        CancelCommand = new RelayCommand(Cancel);
    }

    private bool CanSave() => !string.IsNullOrWhiteSpace(Name) && Age > 0;

    private void Save()
    {
        _eventAggregator.Publish(new PersonSavedEvent(Name, Age));
        CloseAction?.Invoke();
    }

    private void Cancel()
    {
        CloseAction?.Invoke();
    }

    public event EventHandler<bool> CloseRequested;

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}