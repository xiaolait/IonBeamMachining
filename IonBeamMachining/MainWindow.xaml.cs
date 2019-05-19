using System.Windows;
using IonBeamMachining.ViewModel;
using Telerik.Windows.Controls;

namespace IonBeamMachining
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            StyleManager.ApplicationTheme = new FluentTheme();//new Office2016TouchTheme();//new Office2016Theme();//new MaterialTheme();//new FluentTheme();//new VisualStudio2013Theme();
            InitializeComponent();
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
    }
}