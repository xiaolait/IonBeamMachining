using IonBeamMachining.Common;
using IonBeamMachining.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IonBeamMachining.Service
{
    public class WorkspaceService
    {
        private string _workspacePath = "workspace";

        public ObservableCollection<ItemModelBase> GetProjects()
        {
            var projectModelList = new ObservableCollection<ItemModelBase>();

            if (!Directory.Exists(_workspacePath)) Directory.CreateDirectory(_workspacePath);
            DirectoryInfo workspace = new DirectoryInfo(_workspacePath);
            var projects = workspace.GetDirectories();
            foreach(var project in projects)
            {
                var projectModel = new ProjectViewModel() { Name = project.Name, Path = project.FullName };
                var files = project.GetFiles();
                foreach(var file in files)
                {
                    var fileModel = new FileViewModel() { Name = file.Name, Path = file.FullName, Extension = file.Extension };
                    projectModel.Children.Add(fileModel);
                }
                projectModelList.Add(projectModel);
            }
            return projectModelList;
        }
    }
}
