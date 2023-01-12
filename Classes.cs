using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDerivedTables
{
    public class Animal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Cattle : Animal
    {
        public int HornsCount { get; set; }
    }

    public class Fish : Animal
    {
        public int FlippersCount { get; set; }
    }
}
