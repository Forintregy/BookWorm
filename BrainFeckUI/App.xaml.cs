using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace BrainFeckUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // Process unhandled exception
            MessageBox.Show("При выполнении кода возникла ошибка:" + e.Exception.Message);            // Prevent default unhandled exception processing
            e.Handled = true;
            System.Diagnostics.Process.Start(ResourceAssembly.Location);
            Current.Shutdown();
        }
    }
}
