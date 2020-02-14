using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BrainFeckUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void GetCodeSample_Click(object sender, RoutedEventArgs e)
        {
            
            int getRandomIndex = rnd.Next(0, func.brainfuck.CodeExamples.CodeExamplesList.Count()-1);
            codeInputField.Text = func.brainfuck.CodeExamples.CodeExamplesList[getRandomIndex];
        }

        private void RunCode_Click(object sender, RoutedEventArgs e)
        {
            string input = codeInputField.Text;
            if (string.IsNullOrEmpty(input)) resultOutputField.Text = "Здесь ничего нет :( введите команду!";
            else resultOutputField.Text = func.brainfuck.Brainfuck.Run(codeInputField.Text);
        }

        private void CleanCodeInputField_Click(object sender, RoutedEventArgs e)
        {
            codeInputField.Text = "";
        }

        private void Hyperlink_GoToSite(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
