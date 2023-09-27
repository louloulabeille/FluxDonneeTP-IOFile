using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text;
using System;
using System.IO;

namespace Read
{
    public class Lecture
    {
        public string PathFichier { get; set; }

        public string NomFichier { get; set; }

        public FileMode Mode { get; set; } = FileMode.Open;

        public Lecture (string path, string nomFichier)
        {
            PathFichier = path;
            NomFichier = nomFichier;
        }

        public string FichierLecture()
        {
            int retour;
            int offset = 0;
            string chaineRetour= string.Empty;
            

            using FileStream reader = new (Path.Combine(PathFichier , NomFichier), Mode);

            do
            {
                byte[] flux = new byte[1024];
                retour = reader.Read(flux, offset, 1024);
                //chaineRetour += Encoding.UTF8.GetString(flux, offset, retour); c'est pareil
                chaineRetour += Encoding.UTF8.GetString(flux[0..retour]);

                //offset += 1024;
            } while (retour > 0);

            return chaineRetour;
        }

        public async Task<string> FichierLEctureAsync ()
        {
            int retour;
            int offset = 0;
            string chaineRetour = string.Empty;


            using FileStream reader = new(Path.Combine(PathFichier , NomFichier), Mode);

            do
            {
                byte[] flux = new byte[1024];
                retour = await reader.ReadAsync(flux.AsMemory(offset, 1024));
                //chaineRetour += Encoding.UTF8.GetString(flux, offset, retour); c'est pareil
                chaineRetour += Encoding.UTF8.GetString(flux[0..retour]);

                //offset += 1024;
            } while (retour > 0);

            return chaineRetour;
        }

        public string FichierLecture2()
        {
            string? retour;
            string chaineRetour = string.Empty;

            using FileStream file = new(Path.Combine(PathFichier , NomFichier), Mode);
            using StreamReader reader = new(file);
            do
            {
                retour = reader.ReadLine();
                chaineRetour += retour;
            } while (!string.IsNullOrEmpty(retour));
            reader.Close();
            file.Close();

            return chaineRetour;
        }

        public async Task<string> FichierLecture2Async()
        {
            string? retour;
            string chaineRetour = string.Empty;

            using FileStream file = new(Path.Combine(PathFichier , NomFichier), Mode);
            using StreamReader reader = new(file);
            do
            {
                retour = await reader.ReadLineAsync();
                chaineRetour += retour;
            } while (!string.IsNullOrEmpty(retour));
            reader.Close();
            file.Close();

            return chaineRetour;
        }

        public string FichierLectureGzip()
        {
            string chaineRetour = String.Empty;
            int retour;

            using FileStream file = new(Path.Combine(PathFichier , NomFichier), Mode);
            using GZipStream reader = new(file,CompressionMode.Decompress);
            do
            {
                byte[] flux = new byte[1024];
                retour = reader.Read(flux, 0, 1024);

                chaineRetour += Encoding.UTF8.GetString(flux[0..retour]);
            } while (retour > 0);

            reader.Close();
            file.Close();

            return chaineRetour;
        }

        public async Task<string> FichierLectureGzipAsync()
        {
            string chaineRetour = String.Empty;
            int retour;

            using FileStream file = new(Path.Combine(PathFichier ,NomFichier), Mode);
            using GZipStream reader = new(file, CompressionMode.Decompress);
            do
            {
                byte[] flux = new byte[1024];
                //retour = reader.Read(flux, 0, 1024);
                retour = await reader.ReadAsync(flux.AsMemory(0, 1024));

                chaineRetour += Encoding.UTF8.GetString(flux[0..retour]);
            } while (retour > 0);

            reader.Close();
            file.Close();

            return chaineRetour;
        }
    }
}