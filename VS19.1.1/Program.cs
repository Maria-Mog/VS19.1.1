using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS19._1._1
{
    class Computer
    {
        public int Id { get; set; }
        public string CodNeme { get; set; }
        public string TypeProcessor { get; set; }
        public double SpeedProcessor { get; set; }
        public int Ram { get; set; }
        public int VolumeDisk { get; set; }
        public int MemoryVideoCard { get; set; }
        public int Cost { get; set; }
        public string CU { get; set; }
        public int Quantity { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listComputers = new List<Computer>()
            {
                new Computer (){Id = 1, CodNeme ="Lenovo ThinkCentre M720", TypeProcessor="Intel Celeron G4900T", SpeedProcessor=3.2, Ram=4, VolumeDisk = 128, MemoryVideoCard=32, Cost=33500, CU="руб", Quantity=5},
                new Computer (){Id = 2, CodNeme ="Acer Aspire TC-885", TypeProcessor="Intel Core i5 9400F", SpeedProcessor=2.9, Ram=8, VolumeDisk = 1024, MemoryVideoCard=4, Cost=40000, CU="руб", Quantity=12},
                new Computer (){Id = 3, CodNeme ="Intel NUC BXNUC10i7FNHN2", TypeProcessor="Intel Core i7 10710U", SpeedProcessor=1.1, Ram=64, VolumeDisk = 1024, MemoryVideoCard=4, Cost=56000, CU="руб.", Quantity=45},
                new Computer (){Id = 4, CodNeme ="Apple Mac mini", TypeProcessor="Apple", SpeedProcessor=1.1, Ram=16, VolumeDisk = 512, MemoryVideoCard=4, Cost=56000, CU="руб.", Quantity=14},
                new Computer (){Id = 5, CodNeme ="Dell Inspiron 5000", TypeProcessor="Intel Core i5 8400", SpeedProcessor=2.8, Ram=8, VolumeDisk = 1024, MemoryVideoCard=6, Cost=45000, CU="руб.", Quantity=32},
                new Computer (){Id = 6, CodNeme ="HP Omen Obelisk", TypeProcessor="Intel Core i5 8400", SpeedProcessor=2.8, Ram=8, VolumeDisk = 1024, MemoryVideoCard=3, Cost=30000, CU="руб.", Quantity=32},
                new Computer (){Id = 7, CodNeme ="Acer Predator Orion 5000", TypeProcessor="Intel Core i7 8700K", SpeedProcessor=3.7, Ram=32, VolumeDisk = 3000, MemoryVideoCard=8, Cost=262000, CU="руб.", Quantity=4},
                new Computer (){Id = 8, CodNeme ="MSI Trident X", TypeProcessor="Intel Core i7 9700K", SpeedProcessor=3.8, Ram=16, VolumeDisk = 2500, MemoryVideoCard=4, Cost=178000, CU="руб.", Quantity=8},
            };
            //все компьютеры с указанным процессором. Название процессора запросить у пользователя;
            Console.WriteLine("=========== все компьютеры с указанным процессором ===========\n");
            Console.WriteLine("Тип процессора:");
            string typeProcessor = Console.ReadLine();
            bool rez = listComputers.Any(c => c.TypeProcessor == typeProcessor);
            if (rez)
            {
                Console.WriteLine("Данный процессор есть");
            }
            else
            {
                Console.WriteLine("Нет такого процессора");
            }
            List<Computer> computers = (from c in listComputers
                                        where c.TypeProcessor == typeProcessor
                                        select c)
                                        .ToList();
            foreach (Computer c in computers)
            {
                Console.WriteLine($"{c.Id}. Марка: {c.CodNeme}.   Тип процессора: {c.TypeProcessor}.  Частота процессора ГГц: {c.SpeedProcessor}.  Объем ОЗУ Гб: {c.Ram}.   Объем жесткого диска Гб: {c.VolumeDisk}.   Объем видеопамяти Гб: {c.MemoryVideoCard}.   Цена: {c.Cost} {c.CU}");
            }
            Console.ReadKey();
            //все компьютеры с объемом ОЗУ не ниже, чем указано. Объем ОЗУ запросить у пользователя
            Console.WriteLine("\n=========== все компьютеры с объемом ОЗУ не ниже, чем указано ===========\n");
            Console.WriteLine("Объем ОЗУ Гб:");
            int ram = Convert.ToInt32(Console.ReadLine());
            bool rez1 = listComputers.Any(c => c.Ram >= ram);
            if (rez1)
            {
                Console.WriteLine("Вывод запроса");
            }
            else
            {
                Console.WriteLine("Нет таких характеристик");
            }
            List<Computer> computers1 = listComputers
                .Where(c => c.Ram >= ram)
                .ToList();
            foreach (Computer c in computers1)
            {
                Console.WriteLine($"{c.Id}. Марка: {c.CodNeme}.   Тип процессора: {c.TypeProcessor}.   Частота процессора ГГц: {c.SpeedProcessor}.   Объем ОЗУ Гб: {c.Ram}.   Объем жесткого диска Гб: {c.VolumeDisk}.   Объем видеопамяти Гб: {c.MemoryVideoCard}.   Цена: {c.Cost} {c.CU}");
            }
            Console.ReadKey();
            //вывести весь список, отсортированный по увеличению стоимости;
            Console.WriteLine("\n=========== вывести весь список, отсортированный по увеличению стоимости ===========\n");
            List<Computer> computers2 = (from c in listComputers
                                         orderby c.Cost ascending
                                         select c)
                                        .ToList();
            foreach (Computer c in computers2)
            {
                Console.WriteLine($"{c.Id}. Марка: {c.CodNeme}. Цена: {c.Cost} {c.CU}");
            }
            Console.ReadKey();
            //вывести весь список, сгруппированный по типу процессора
            Console.WriteLine("\n=========== вывести весь список, сгруппированный по типу процессора ===========\n");
            //var compGr = listComputers.GroupBy(c => c.TypeProcessor)
            //    .Select(p => new { TypeProcessor = p.Key, Count = p.Count() });
            var compGr1 = from comp in listComputers
                          group comp by comp.TypeProcessor into p
                          select new
                          {
                              TypeProcessor = p.Key,
                              Count = p.Count(),
                              Computers = from c in p select c
                          };
            foreach (var group in compGr1)
            {
                Console.WriteLine($"{group.TypeProcessor} {group.Count}");
            }            
            Console.ReadKey();
            //найти самый дорогой и самый бюджетный компьютер
            Console.WriteLine("\n=========== найти самый дорогой и самый бюджетный компьютер ===========\n");
            List<Computer> computers4 = (from c in listComputers
                                         orderby c.Cost ascending
                                         select c)
                                        .ToList();
            Computer compMin = computers4
                .First();
            Computer compMax = computers4
                .Last();
            Console.WriteLine($"Минимальная стоимость: {compMin.Id}.  Марка: {compMin.CodNeme}.   Цена: {compMin.Cost} {compMin.CU}");
            Console.WriteLine($"Максимальная стоимость: {compMax.Id}. Марка: {compMax.CodNeme}.   Цена: {compMax.Cost} {compMax.CU}");
            Console.ReadKey();
            //есть ли хотя бы один компьютер в количестве не менее 30 штук
            Console.WriteLine("\n=========== есть ли хотя бы один компьютер в количестве не менее 30 штук ===========\n");
            List<Computer> computers5 = listComputers
                .Where(c => c.Quantity >= 30)
                .ToList();
            bool rez2 = listComputers.Any(c => c.Quantity >= 30);
            if (rez2)
            {
                Console.WriteLine("Есть компьютер в количестве не менее 30шт.");
            }
            else
            {
                Console.WriteLine("Нет компьютера в количестве не менее 30шт.");
            }
                
            foreach (Computer c in computers5)
            {
                Console.WriteLine($"{c.Id}. Марка: {c.CodNeme}.    Количество: {c.Quantity}.");
            }
            Console.ReadKey();
        }
    }
}
