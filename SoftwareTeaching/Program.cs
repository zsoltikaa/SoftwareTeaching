Console.ForegroundColor = ConsoleColor.Green;

const string DIR = "D:\\programming_folders\\source\\repos\\SoftwareTeaching\\";

List<Hallgatok> hallgatok = [];

using (StreamReader reader = new StreamReader($"{DIR}course.txt"))
{
    string line;

    while ((line = reader.ReadLine()) != null) 
    {
        hallgatok.Add(new Hallgatok(line));
    }
}

// 1. feladat
Console.WriteLine($"Hallgatok szama: {hallgatok.Count}");

// 2. feladat
var f2 = hallgatok.Average(a => a.BackendEredmeny);
Console.WriteLine($"Hallgatok atlaga backend fejlesztes modulbol: {f2}");

// 3. feladat
var f3 = hallgatok.OrderByDescending(h => h.HalozatEredmeny + h.MobilEredmeny + h.FrontendEredmeny + h.BackendEredmeny).First();
Console.WriteLine($"Az osztalyelso: {f3}");

// 4. feladat
var f4 = (double)hallgatok.Count(h => h.Nem == 'm') / hallgatok.Count * 100;
Console.WriteLine($"A ferfiak aranya a kepzesen: {f4:f2}%");

// 5. feladat
var f5 = hallgatok.Where(h => h.Nem == 'f').OrderByDescending(h => h.FrontendEredmeny + h.BackendEredmeny).First();
Console.WriteLine($"A legjobb noi webfejleszto: {f5}");

// 6. feladat
var f6 = hallgatok.Where(h => h.Befizetes == 2600).ToList();
Console.WriteLine($"Elofinanszirozta a teljes osszeget: ");
foreach (var item in f6)
{
    Console.WriteLine($"\t{item.Nev}");
}

// 7. feladat
Console.Write("Adj meg egy nevet: ");
string nev = Console.ReadLine();

var hallgato = hallgatok.FirstOrDefault(h => h.Nev.Equals(nev));

if (hallgato != null)
{

    bool kellJavitoVizsga = false;
    if (hallgato.HalozatEredmeny < 51)
    {
        Console.WriteLine("Javitovizsga szukseges halozatbol.");
        kellJavitoVizsga = true;
    }
    if (hallgato.MobilEredmeny < 51)
    {
        Console.WriteLine("Javitovizsga szukseges mobilfejlesztesbol.");
        kellJavitoVizsga = true;
    }
    if (hallgato.FrontendEredmeny < 51)
    {
        Console.WriteLine("Javitovizsga szukseges frontend fejlesztesbol.");
        kellJavitoVizsga = true;
    }
    if (hallgato.BackendEredmeny < 51)
    {
        Console.WriteLine("Javitovizsga szukseges backend fejlesztesbol.");
        kellJavitoVizsga = true;
    }

    if (!kellJavitoVizsga)
    {
        Console.WriteLine("Nincs szukseg javitovizsgara. ");
    }

}

else
{
    Console.WriteLine("Nincs ilyen nev a hallgatok kozott. ");
}

// 8. feladat
var f8 = hallgatok.Where(h => h.HalozatEredmeny == 100 || h.MobilEredmeny == 100 || h.FrontendEredmeny == 100 || h.BackendEredmeny == 100 && h.HalozatEredmeny >= 51 && h.MobilEredmeny >= 51 && h.FrontendEredmeny >= 51 && h.BackendEredmeny >= 51).Count();
Console.WriteLine($"A 100%-os es javitovizsga nelkuli hallgatok szama: {f8}");

// 9. feladat
var halozatJavito = hallgatok.Count(h => h.HalozatEredmeny < 51);
var mobilJavito = hallgatok.Count(h => h.MobilEredmeny < 51);
var frontendJavito = hallgatok.Count(h => h.FrontendEredmeny < 51);
var backendJavito = hallgatok.Count(h => h.BackendEredmeny < 51);

Console.WriteLine($"Halozatbol javitovizsgat kell tennie: {halozatJavito}");
Console.WriteLine($"Mobilfejlesztesbol javitovizsgat kell tennie: {halozatJavito}");
Console.WriteLine($"Frontend fejlesztesbol javitovizsgat kell tennie: {frontendJavito}");
Console.WriteLine($"Backend fejlesztesbol javitovizsgat kell tennie: {backendJavito}");

// 10. feladat
var rendezettHallgatok = hallgatok.OrderBy(h => h.CsaladNev()).ToList();

using (StreamWriter writer = new($"{DIR}output.txt"))
{
    foreach (var item in rendezettHallgatok)
    {
        writer.WriteLine(item);
    }
}