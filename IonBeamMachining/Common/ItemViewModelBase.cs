using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IonBeamMachining.Common
{
    public abstract class ItemViewModelBase : ViewModelBase
    {

        public ItemViewModelBase Parent { get; set; }
        public ObservableCollection<ItemViewModelBase> Children { get; set; } = new ObservableCollection<ItemViewModelBase>();

        public ItemViewModelBase(string path, ItemViewModelBase parent)
        {
            _path = path;
            Parent = parent;
        }

        private string _path;
        public string Name {
            get { return _path; }
            set {
                if (_path != null)
                {
                    var path = GetPath();
                    var file = new System.IO.FileInfo(GetPath());
                    file.MoveTo($"{file.DirectoryName}\\{value}");
                }
                _path = value;
                RaisePropertyChanged();
            }
        }

        private RelayCommand _delete;
        public RelayCommand Delete
        {
            get
            {
                return _delete
                    ?? (_delete = new RelayCommand(
                    () => DeleteItem()));
            }
        }
        public abstract void DeleteItem();

        private RelayCommand _import;
        public RelayCommand Import
        {
            get
            {
                return _import
                    ?? (_import = new RelayCommand(
                    () => ImportItem()));
            }
        }
        public abstract void ImportItem();

        public string GetPath()
        {
            if (Parent != null)
                return $"{Parent.GetPath()}\\{Name}";
            else return Name;
        }
    }
}
