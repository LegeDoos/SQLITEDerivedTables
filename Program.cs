// See https://aka.ms/new-console-template for more information
using SQLDerivedTables;
using SQLite;

Console.WriteLine("Test opslag derived tables");


using (var conn = new SQLiteConnection("database.sqlite"))
{
    // create table
    conn.CreateTable<Cattle>();
    // insert data with autoincrement
    conn.Insert(new Cattle() { Name = "Cattle 1", HornsCount = 10 });
    conn.Insert(new Cattle() { Name = "Cattle 2", HornsCount = 20 });
    conn.Insert(new Cattle() { Name = "Cattle 3", HornsCount = 30 });

    foreach (var item in conn.Table<Cattle>().ToList())
    {
        Console.WriteLine($"Cattle Id = {item.Id}; Name = {item.Name}; Hornscount = {item.HornsCount}");
    }

    // create other table
    conn.CreateTable<Fish>();
    // insert data with autoincrement
    conn.Insert(new Fish() { Name = "Fish 1", FlippersCount = 6 });
    conn.Insert(new Fish() { Name = "Fish 2", FlippersCount = 7 });
    conn.Insert(new Fish() { Name = "Fish 3", FlippersCount = 8 });

    // kijk of animal bestaat
    try
    {
        foreach (var item in conn.Table<Animal>().ToList())
        {
            Console.WriteLine($"Animal Id = {item.Id}; Name = {item.Name}; ");
        }

    }
    catch (Exception)
    {
        Console.WriteLine("Tabel animal bestaat niet dus het worden echt aparte tabellen!");
    }

    // try animal
    conn.CreateTable<Animal>();
    Animal a = new Fish() { Name = "Fish 4", FlippersCount = 6 };
    conn.Insert(a);

    foreach (var item in conn.Table<Animal>().ToList())
    {
        Console.WriteLine($"Animal Id = {item.Id}; Name = {item.Name}; ");
    }

}


