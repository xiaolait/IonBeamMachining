using GalaSoft.MvvmLight;
using IonBeamMachining.Common;

namespace IonBeamMachining.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public ItemViewModelBase SelectedItem;
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            
        }
    }
}