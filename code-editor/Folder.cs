using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code_editor
{
    public class Folder
    {
        public string name;
        public string location;
        public List<Folder> folders;
        public List<File> files;

        public Folder(string name_, string location_)
        {
            name = name_;
            location = location_;
            folders = GetFolders();
            files = GetFiles();
        }

        private List<Folder> GetFolders()
        {
            List<Folder> folders = new List<Folder>();

            string[] directories = Directory.GetDirectories($"{location}");
            foreach(string directory in directories)
            {
                folders.Add(new Folder(Path.GetFileName(directory), directory));
            }

            return folders;
        }

        private List<File> GetFiles()
        {
            List<File> r = new List<File>();

            string[] files = Directory.GetFiles(location);

            foreach(string file in files)
            {
                r.Add(new File(Path.GetFileName(file)));
            }

            return r;
        }
    }
}
