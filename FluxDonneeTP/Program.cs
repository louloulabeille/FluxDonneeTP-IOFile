// See https://aka.ms/new-console-template for more information
using FluxDonneeTPDAL;
using Write;
using System.Runtime.Serialization;
using System.Text.Unicode;
using System.Text;
using Read;

Console.WriteLine("Hello, World!");

FluxDonneeTPDALDbContext context = new();
string p;
Ecriture ecriture = new("./", "Personnes.json");
Ecriture ecriture1 = new("./", "Personnes1.json");
Ecriture ecritureGzip = new("./", "logs.bin");
Ecriture ecriture2 = new("C:\\data", "monfichier.txt");

Lecture lecture = new("./", "Fichier.txt");
Lecture lectureGzip = new("./", "logs.bin");

ArchiveZip archive = new("c:\\data","data.zip");

HashSet<Personne> personnes = context.Personnes.ToHashSet();
p = Serialization.Instance.GetSerialization(personnes);

//Console.WriteLine(p);

ecriture.FichierEnregistrement(Encoding.UTF8.GetBytes(p));
ecriture1.FichierEnregistrement(p);
ecritureGzip.FichierGzip($"Enregistrement le {DateTime.Now:dd/MM/yyyy HH:mm:ss} :\n"+p);
ecriture2.FichierenregistrementRapide(p);
//ecritureGzip.FichierGzip(lecture.FichierLecture());

Console.WriteLine( lecture.FichierLecture());
//Console.WriteLine(lecture.FichierLecture2()); //beaucoup trop long à n'utiliser que pour des petits traitements
Console.WriteLine(lectureGzip.FichierLectureGzip());

archive.CreateArchive();

Console.ReadLine();
