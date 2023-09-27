using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Write
{
    public class ArchiveZip
    {
        public string Chemin { get; set; }
        public string Name { get; set; }

        public ZipArchiveMode Mode { get; set; } = ZipArchiveMode.Create;

        public ArchiveZip(string path, string name)
        {
            Chemin = path;
            Name = name;
        }

        public void CreateArchive() { 
        
            if(!Directory.Exists(Chemin)) { // si le répertoire de à archiver n'existe pas, on sort
                return;
            }

            if (File.Exists(Path.Combine(Chemin,Name))) { 
                Mode = ZipArchiveMode.Update;
            }

            //using FileStream file = new(Path + "\\" + Name, FileMode.OpenOrCreate);
            using ZipArchive zip = ZipFile.Open(Path.Combine(Chemin , Name), Mode);

            string[] tabFile =  Directory.GetFiles(Chemin);

            foreach (string tab in tabFile)
            {
                if (tab == Chemin + "\\" + Name) continue;
                //zip.CreateEntryFromFile(tab,tab.Substring(tab.LastIndexOf('\\')+1));
                zip.CreateEntryFromFile(tab, Path.GetFileName(tab));    //+ simple
                File.Delete(tab);
            }

        }

    }
}
