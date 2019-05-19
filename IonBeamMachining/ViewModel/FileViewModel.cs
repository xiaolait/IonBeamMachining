using IonBeamMachining.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IonBeamMachining.ViewModel
{
    public class FileViewModel : ItemViewModelBase
    {
        public FileViewModel(string path, ItemViewModelBase parent) : base(path, parent)
        {
        }

        public string Extension { get; set; }

        public override void ImportItem()
        {
        }

        public override void DeleteItem()
        {
            Parent.Children.Remove(this);
            File.Delete(GetPath());
        }
    }
}
