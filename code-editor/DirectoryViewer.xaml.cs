using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace code_editor
{
    public partial class DirectoryViewer : UserControl
    {
        public string location = "C:\\Users\\fgrujic\\Documents\\rad\\moje\\code-editor";
        Folder currentDirectory;

        public DirectoryViewer()
        {
            InitializeComponent();
            currentDirectory = new Folder("", location);
            string[] text = LoopThroughFolders(currentDirectory);
            foreach (string item in text)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = new GridLength(20, GridUnitType.Pixel);
                directoryGrid.RowDefinitions.Add(rowDef);
            }
        }

        private string[] LoopThroughFolders(Folder folder)
        {
            List<string> ret = new List<string>();
            List<Folder> foldersToCircle = folder.folders.ToList();

            foreach(Folder folder2 in foldersToCircle)
            {
                ret.Add(folder2.name);
                List<string> returned = LoopThroughFolders(folder2).ToList();
                foreach(string _ in returned)
                {
                    ret.Add($"    {_}");
                }
            }

            foreach(File file in folder.files)
            {
                ret.Add(file.name);
            }

            return ret.ToArray();
        }
    }
}