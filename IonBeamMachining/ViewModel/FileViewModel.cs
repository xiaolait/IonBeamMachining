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
        public string Extension { get; set; }

        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Remove()
        {
            Parent.Children.Remove(this);
            File.Delete(GetPath());
        }
    }
}
