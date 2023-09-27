using System.IO.Compression;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Write
{

    public class Ecriture
    {
        public string Path { get; set; }

        public string NomFichier { get; set; }

        public FileMode Mode { get; set; } = FileMode.OpenOrCreate;

        public Ecriture(string chemin, string nomfichier) { 
            Path = chemin;
            NomFichier = nomfichier;
        }

        public virtual void FichierEnregistrement(byte[] bytes)
        {
            try
            {
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
                if (!File.Exists(Path+"\\"+ NomFichier))
                {
                    Mode = FileMode.CreateNew;
                }

                using FileStream file = new(Path + "\\" + NomFichier, Mode);
                file.Write(bytes);
                file.Flush();
                file.Close();

            }
            catch
            {
                Console.WriteLine("Erreur lors de l'écriture dans le fichier");
            }
        }

        public async virtual Task FichierEnregistrementAsync(byte[] bytes)
        {
            try
            {
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
                if (!File.Exists(Path + "\\" + NomFichier))
                {
                    Mode = FileMode.CreateNew;
                }

                using FileStream file = new(Path + "\\" + NomFichier, Mode);
                await file.WriteAsync(bytes);
                file.Flush();
                file.Close();

            }
            catch
            {
                Console.WriteLine("Erreur lors de l'écriture dans le fichier");
            }
        }

        public virtual void FichierEnregistrement (string ligne)
        {
            try
            {
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory (Path);
                }
                if (!File.Exists(Path + "\\" + NomFichier))
                {
                    Mode = FileMode.CreateNew;
                }

                using FileStream file = new(Path+"\\"+NomFichier,Mode);
                using StreamWriter writer = new(file);

                writer.WriteLine(ligne);
                //file.Seek(0, SeekOrigin.Begin); //pour remettre le flux à l'origine
                writer.Close();
            }
            catch {
                Console.WriteLine("Erreur lors de l'écriture dans le fichier.");
            }
        }

        public async virtual Task FichierEnregistrementAsync(string ligne)
        {
            try
            {
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
                if (!File.Exists(Path + "\\" + NomFichier))
                {
                    Mode = FileMode.CreateNew;
                }

                using FileStream file = new(Path + "\\" + NomFichier, Mode);
                using StreamWriter writer = new(file);
                await writer.WriteLineAsync(ligne);

                //file.Seek(0, SeekOrigin.Begin); //pour remettre le flux à l'origine
                writer.Close();
            }
            catch
            {
                Console.WriteLine("Erreur lors de l'écriture dans le fichier.");
            }
        }

        public virtual void FichierGzip(string ligne)
        {
            try
            {

                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
                if (!File.Exists(Path + "\\" + NomFichier))
                {
                    Mode = FileMode.CreateNew;
                }
                

                using FileStream file = new(Path + "\\" + NomFichier, Mode);
                using GZipStream writer = new(file,CompressionLevel.Optimal);
                byte[] buffer = Encoding.UTF8.GetBytes(ligne);
                
                writer.Write(buffer,0,buffer.Length);
                writer.Close();
                file.Close();

            } catch { Console.WriteLine("Erreur lors de l'écriture dans le fichier."); }
        }

        public async virtual Task FichierGzipAsync(string ligne)
        {
            try
            {

                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(Path);
                }
                if (!File.Exists(Path + "\\" + NomFichier))
                {
                    Mode = FileMode.CreateNew;
                }


                using FileStream file = new(Path + "\\" + NomFichier, Mode);
                using GZipStream writer = new(file, CompressionLevel.Optimal);
                byte[] buffer = Encoding.UTF8.GetBytes(ligne);

                await writer.WriteAsync(buffer.AsMemory(0, buffer.Length));
                //writer.Write(buffer, 0, buffer.Length);
                writer.Close();
                file.Close();

            }
            catch { Console.WriteLine("Erreur lors de l'écriture dans le fichier."); }
        }

        public void FichierenregistrementRapide(string ligne)
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            if (!File.Exists(Path + "\\" + NomFichier))
            {
                Mode = FileMode.CreateNew;
            }
            else
            {
                File.Delete(Path + "\\" + NomFichier);
                Mode = FileMode.CreateNew;
            }

            File.WriteAllText(Path + "\\" + NomFichier, ligne);
            Console.WriteLine(File.ReadAllText(Path + "\\" + NomFichier));
        }

        public async Task FichierenregistrementRapideAsync(string ligne)
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
            if (!File.Exists(Path + "\\" + NomFichier))
            {
                Mode = FileMode.CreateNew;
            }
            else
            {
                File.Delete(Path + "\\" + NomFichier);
                Mode = FileMode.CreateNew;
            }

            await File.WriteAllTextAsync(Path + "\\" + NomFichier, ligne);
            //File.WriteAllText(Path + "\\" + NomFichier, ligne);
            Console.WriteLine(File.ReadAllText(Path + "\\" + NomFichier));
        }
    }
}