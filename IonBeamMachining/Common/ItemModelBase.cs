using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IonBeamMachining.Common
{
    public class ItemModelBase
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }
        public string Path { get; set; }
        public ObservableCollection<ItemModelBase> Children { get; set; } = new ObservableCollection<ItemModelBase>(); 

        private void Rename()
        {
            if (Path == null) return;
            var file = new System.IO.FileInfo(Path);
            file.MoveTo($"{file.DirectoryName}\\{_name}");
        }
    }
}
