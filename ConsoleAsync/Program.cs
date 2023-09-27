// See https://aka.ms/new-console-template for more information
using FluxDonneeTPDAL;
using Read;
using System.Text;
using Write;

Console.WriteLine("Hello, Utilisation de fonction Asynchrone.");


FluxDonneeTPDALDbContext context = new();
string p;
string retour;

Ecriture ecriture = new(Path.GetFullPath("c:\\data"),"AsyncTest.json");
Lecture lecture = new(Path.GetFullPath("c:\\data"), "Love.json");

HashSet<Personne> s = context.Personnes.ToHashSet<Personne>();
p = Serialization.Instance.GetSerialization(s);

await ecriture.FichierEnregistrementAsync(p);
ecriture.NomFichier = "Love.json";
await ecriture.FichierEnregistrementAsync(Encoding.UTF8.GetBytes(p));

retour = await lecture.FichierLecture2Async();
Console.WriteLine(retour);

Console.ReadLine();