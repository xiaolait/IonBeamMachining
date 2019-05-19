using GalaSoft.MvvmLight.Command;
using IonBeamMachining.Common;
using IonBeamMachining.Model;
using IonBeamMachining.PopWin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IonBeamMachining.ViewModel
{
    public class ProjectListViewModel : ItemViewModelBase
    {
        public ProjectListViewModel() : base(System.IO.Directory.GetCurrentDirectory() + "\\workspace", null)
        {
            if (!Directory.Exists(Name)) Directory.CreateDirectory(Name);
            DirectoryInfo workspace = new DirectoryInfo(Name);
            var projects = workspace.GetDirectories();
            foreach (var project in projects) Children.Add(new ProjectViewModel(project.Name, this));
        }

        private RelayCommand _newProject;
        public RelayCommand NewProject
        {
            get
            {
                return _newProject
                    ?? (_newProject = new RelayCommand(
                    () =>
                    {
                        var newItem = new NewItem("新建工程");
                        newItem.ShowDialog();
                        if (newItem.DialogResult == false) return;
                        Directory.CreateDirectory($"{GetPath()}\\{newItem.Result}");
                        Children.Add(new ProjectViewModel(newItem.Result, this));
                    }));
            }
        }

        public override void DeleteItem()
        {
        }

        public override void ImportItem()
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() != DialogResult.OK) return;
            var srcDir = new DirectoryInfo(dialog.SelectedPath);
            var desDirPath = $"{GetPath()}\\{srcDir.Name}";
            if (Directory.Exists(desDirPath)) { MessageBox.Show("项目已存在！"); return; }
            var desDir = Directory.CreateDirectory(desDirPath);
            foreach (var file in srcDir.GetFiles()) file.CopyTo($"{desDir.FullName}\\{file.Name}");
            Children.Add(new ProjectViewModel(desDir.Name, this));
        }
    }
}
