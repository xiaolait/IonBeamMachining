using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IonBeamMachining.Common;
using System.Collections.ObjectModel;
using System;
using System.IO;

namespace IonBeamMachining.ViewModel
{
    public class ProjectViewModel : ItemViewModelBase
    {
        public override void Add()
        {
            throw new NotImplementedException();
        }

        public override void Remove()
        {
            for (int i = Children.Count - 1; i >= 0; i--) Children[i].Remove();
            Parent.Children.Remove(this);
            Directory.Delete(GetPath());
        } 
    }
}