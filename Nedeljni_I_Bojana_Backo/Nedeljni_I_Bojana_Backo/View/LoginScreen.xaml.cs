﻿using Nedeljni_I_Bojana_Backo.ViewModel;
using System;
using System.Windows;

namespace Nedeljni_I_Bojana_Backo.View
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
            this.DataContext = new LoginScreenViewModel(this);
        }
    }
}
