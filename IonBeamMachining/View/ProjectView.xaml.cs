using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace IonBeamMachining.View
{
    /// <summary>
    /// ProjectView.xaml 的交互逻辑
    /// </summary>
    public partial class ProjectView : UserControl
    {
        public ProjectView()
        {
            InitializeComponent();
        }

        private RadTreeViewItem _clickedElement;
        private void RadContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            // Find the tree item that is associated with the clicked context menu item 
            _clickedElement = (sender as RadContextMenu).GetClickedElement<RadTreeViewItem>();
        }

        private void Rename_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            _clickedElement.IsInEditMode = true;
        }
    }
}
