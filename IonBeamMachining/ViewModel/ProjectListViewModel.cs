using IonBeamMachining.Common;
using IonBeamMachining.Model;
using IonBeamMachining.PopWin;
using IonBeamMachining.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IonBeamMachining.ViewModel
{
    public class ProjectListViewModel : ItemViewModelBase
    {
        public ProjectListViewModel()
        {
            Name = System.IO.Directory.GetCurrentDirectory() + "\\workspace";
            if (!Directory.Exists(Name)) Directory.CreateDirectory(Name);
            DirectoryInfo workspace = new DirectoryInfo(Name);
            var projects = workspace.GetDirectories();
            foreach (var project in projects)
            {
                var projectViewModel = new ProjectViewModel() { Parent = this, Name = project.Name};
                var files = project.GetFiles();
                foreach (var file in files)
                {
                    var fileViewModel = new FileViewModel() { Parent = projectViewModel, Name = file.Name, Extension = file.Extension };
                    projectViewModel.Children.Add(fileViewModel);
                }
                Children.Add(projectViewModel);
            }
        }

        public override void Add()
        {
            var newItem = new NewItem("新建工程");
            newItem.ShowDialog();
            if (newItem.DialogResult == false) return;
            Directory.CreateDirectory($"{GetPath()}\\{newItem.Result}");
            Children.Add(new ProjectViewModel() { Parent = this, Name = newItem.Result });
        }

        public override void Remove()
        {
        }
    }
}
