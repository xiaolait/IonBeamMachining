using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IonBeamMachining.Common;
using System.Collections.ObjectModel;
using System;
using System.IO;
using System.Windows;

namespace IonBeamMachining.ViewModel
{
    public class ProjectViewModel : ItemViewModelBase
    {
        public ProjectViewModel(string path, ItemViewModelBase parent) : base(path, parent)
        {
            var dir = new DirectoryInfo(GetPath());
            foreach (var file in dir.GetFiles()) Children.Add(new FileViewModel(file.Name, this) { Extension = file.Extension });
        }

        public override void ImportItem()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog()
            {
                //Filter = "Excel Files (*.sql)|*.sql"
            };
            if (dialog.ShowDialog() == false) return;
            var srcFile = new FileInfo(dialog.FileName);
            var desFilePath = $"{GetPath()}\\{srcFile.Name}";
            if (File.Exists(desFilePath)) { MessageBox.Show("文件已存在！"); return; }
            srcFile.CopyTo(desFilePath);
            Children.Add(new FileViewModel(srcFile.Name, this));
        }

        public override void DeleteItem()
        {
            for (int i = Children.Count - 1; i >= 0; i--) Children[i].DeleteItem();
            Parent.Children.Remove(this);
            Directory.Delete(GetPath());
        } 
    }
}