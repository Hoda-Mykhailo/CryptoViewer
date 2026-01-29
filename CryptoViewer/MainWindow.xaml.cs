using CryptoViewer.View;
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

namespace CryptoViewer
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new MainView());
            

        }

        private void SetTheme(string theme)
        {
            var dictionaries = Application.Current.Resources.MergedDictionaries;

            var oldTheme = dictionaries
                .FirstOrDefault(d => d.Source != null &&
                    (d.Source.OriginalString.Contains("Light.xaml") ||
                     d.Source.OriginalString.Contains("Dark.xaml")));

            if (oldTheme != null)
                dictionaries.Remove(oldTheme);

            dictionaries.Add(new ResourceDictionary
            {
                Source = new Uri($"Themes/{theme}.xaml", UriKind.Relative)
            });
        }

        private void DarkTheme_Click(object sender, RoutedEventArgs e)
        {
            SetTheme("Dark");
        }

        private void LightTheme_Click(object sender, RoutedEventArgs e)
        {
            SetTheme("Light");
        }
    }
}