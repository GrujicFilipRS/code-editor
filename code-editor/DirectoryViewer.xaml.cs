using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace code_editor
{
    public partial class DirectoryViewer : UserControl
    {
        public string location = "D:\\Projects\\code-editor";
        Folder currentDirectory;

        public DirectoryViewer()
        {
            InitializeComponent();
            currentDirectory = new Folder("", location);

            // Making RadioButtons for all the files found inside
            string[] text = LoopThroughFolders(currentDirectory);
            var indexedText = text.Select((name, index) => (index, name));

            foreach (var (index, item) in indexedText)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = new GridLength(20, GridUnitType.Pixel);
                directoryGrid.RowDefinitions.Add(rowDef);
                RadioButton radioButton = new RadioButton
                {
                    Content = item,
                    GroupName = "FileSelected",
                    Foreground = Brushes.White
                };

                Grid.SetRow(radioButton, index);
                directoryGrid.Children.Add(radioButton);
            }
        }

        private string[] LoopThroughFolders(Folder folder)
        {
            List<string> ret = new List<string>();
            List<Folder> foldersToCircle = folder.folders.ToList();

            foreach(Folder folder2 in foldersToCircle)
            {
                ret.Add(folder2.name);

                if (!folder2.opened) continue;

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