﻿using System.Windows;
using WpfViewToViewCommunication.Commands;

namespace WpfViewToViewCommunication;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        viewModel.UpdateLastSavedPersonInfo = UpdateLastSavedPersonInfoLabel;
    }

    public void UpdateLastSavedPersonInfoLabel(string info)
    {
        LastSavedPersonInfoLabel.Content = info;
    }
}