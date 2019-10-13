using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PcComponentsShop.Domain.Core.Basic_Models;
using System.IO;

namespace PcComponentsShop.Infrastructure.Data.Contexts
{
    public class PcComponentsContext : DbContext
    {
        public DbSet<ComputerCase> ComputerCases { get; set; }
        public DbSet<MemoryModule> MemoryModules { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<PowerSupply> PowerSuppliess { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<SSDDrive> SSDDrives { get; set; }
        public DbSet<VideoCard> VideoCards { get; set; }
    }
    public class ComponentsInitializer : DropCreateDatabaseAlways<PcComponentsContext>
    {
        protected override void Seed(PcComponentsContext context)
        {
            string path;
            path = @"C:\Users\Алексей\Desktop\Корпуса.txt";
            context.ComputerCases.AddRange(ComponentsParser.GetComputerCases(path));
            path = @"C:\Users\Алексей\Desktop\Модули памяти.txt";
            context.MemoryModules.AddRange(ComponentsParser.GetMemoryModules(path));
            path = @"C:\Users\Алексей\Desktop\Материнские платы.txt";
            context.Motherboards.AddRange(ComponentsParser.GetMotherboards(path));
            path = @"C:\Users\Алексей\Desktop\Видеокарты.txt";
            context.VideoCards.AddRange(ComponentsParser.GetVideoCards(path));
            path = @"C:\Users\Алексей\Desktop\Процессоры.txt";
            context.Processors.AddRange(ComponentsParser.GetProcessors(path));
            path = @"C:\Users\Алексей\Desktop\Блоки питания.txt";
            context.PowerSuppliess.AddRange(ComponentsParser.GetPowerSupplies(path));
            path = @"C:\Users\Алексей\Desktop\SSD диски.txt";
            context.SSDDrives.AddRange(ComponentsParser.GetSSDDrives(path));
        }
    }
    public static class ComponentsParser
    {
        public static List<Good> FirstPartParser(string Path)
        {
            List<Good> goods = new List<Good>();
            StreamReader sr = new StreamReader(Path, Encoding.Default);
            string line;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                int pos = 0;
                if (line.Contains("name: "))
                {
                    string name = line.Substring(line.IndexOf(':') + 2, line.IndexOf(',') - line.IndexOf(':') - 2);
                    pos = "name: ".Length + name.Length;
                    string id = line.Substring(line.IndexOf(':', pos) + 2, line.IndexOf(',', pos + 1) - line.IndexOf(':', pos) - 2);
                    pos += "id: ".Length + id.Length + 2;
                    string price = line.Substring(line.IndexOf(':', pos) + 2, line.IndexOf(',', pos + 1) - line.IndexOf(':', pos) - 2);
                    pos += "price: ".Length + price.Length + 2;
                    string brand = line.Substring(line.IndexOf(':', pos) + 2, line.IndexOf(',', pos + 1) - line.IndexOf(':', pos) - 2);
                    pos += "brand: ".Length + brand.Length + 2;
                    string category = line.Substring(line.IndexOf(':', pos) + 2, line.IndexOf(',', pos + 1) - line.IndexOf(':', pos) - 2);
                    pos += "category: ".Length + category.Length + 3;
                    string imgSrc = line.Substring(pos + " imgSrc: ".Length, line.Length - pos - " imgSrc: ".Length - 1);
                    goods.Add(new Good() { FullName = name, Price = int.Parse(price), Brand = brand, Category = category, ImgSrc = imgSrc });
                }
            }
            sr.Close();
            return goods;
        }
        public static List<ComputerCase> GetComputerCases(string path)
        {
            List<ComputerCase> computerCases = new List<ComputerCase>();
            List<Good> goods = FirstPartParser(path);
            StreamReader sr = new StreamReader(path, Encoding.Default);
            int el = 0;
            ComputerCase m = new ComputerCase();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string fitem = "Тип корпуса: ";
                if (line.Contains(fitem))
                {
                    m = new ComputerCase();
                    m.CaseType = line.Substring(fitem.Length, line.Length - fitem.Length);
                }
                fitem = "Форм-фактор: ";
                if (line.Contains(fitem))
                    m.FormFactor = line.Substring(fitem.Length, line.Length - fitem.Length);
                fitem = "Блок питания: ";
                if (line.Contains(fitem))
                    m.PowerSupply = line.Substring(fitem.Length, line.Length - fitem.Length);
                fitem = "Особенности: ";
                if (line.Contains(fitem))
                    m.Features = line.Substring(fitem.Length, line.Length - fitem.Length);
                fitem = "Макс. высота кулера CPU: ";
                if (line.Contains(fitem))
                    m.MaxCpuCoolerHeight = int.Parse(line.Substring(fitem.Length, line.Length - fitem.Length).Replace("мм", "").Replace(" ",""));
                fitem = "Макс. длина видеокарты: ";
                if (line.Contains(fitem))
                    m.MaxVideoCardLength = int.Parse(line.Substring(fitem.Length, line.Length - fitem.Length).Replace("мм", "").Replace(" ", ""));
                if (line == "end" || line == "")
                {
                    m.FullName = goods[el].FullName;
                    m.Price = goods[el].Price;
                    m.Category = goods[el].Category;
                    m.Brand = goods[el].Brand;
                    m.ImgSrc = goods[el].ImgSrc;
                    computerCases.Add(m);
                    el++;
                }
            }
            sr.Close();
            return computerCases;
        }
        public static List<MemoryModule> GetMemoryModules(string path)
        {
            List<MemoryModule> MemoryModules = new List<MemoryModule>();
            List<Good> goods = FirstPartParser(path);
            StreamReader sr = new StreamReader(path, Encoding.Default);
            int el = 0;
            MemoryModule m = new MemoryModule();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string fitem = "Объем памяти: ";
                if (line.Contains(fitem))
                {
                    m = new MemoryModule();
                    m.MemoryCapacity = int.Parse(line.Substring(fitem.Length, line.Length - fitem.Length).Replace("ГБ", "").Replace(" ", ""));
                }
                fitem = "Тип памяти: ";
                if (line.Contains(fitem))
                    m.MemoryType = line.Substring(fitem.Length, line.Length - fitem.Length);
                fitem = "Рабочая частота: ";
                if (line.Contains(fitem))
                    m.OperatingFrequency = int.Parse(line.Substring(fitem.Length, line.Length - fitem.Length).Replace("МГц", "").Replace(" ", ""));
                fitem = "Рабочее напряжение: ";
                if (line.Contains(fitem))
                    m.OperatingVoltage = float.Parse(line.Substring(fitem.Length, line.Length - fitem.Length).Replace("В", "").Replace(" ", ""));
                fitem = "Тайминги: ";
                if (line.Contains(fitem))
                    m.Timings = line.Substring(fitem.Length, line.Length - fitem.Length);
                if (line == "end" || line == "")
                {
                    m.FullName = goods[el].FullName;
                    m.Price = goods[el].Price;
                    m.Category = goods[el].Category;
                    m.Brand = goods[el].Brand;
                    m.ImgSrc = goods[el].ImgSrc;
                    MemoryModules.Add(m);
                    el++;
                }
            }
            sr.Close();
            return MemoryModules;
        }
        public static List<Motherboard> GetMotherboards(string path)
        {
            List<Motherboard> motherboards = new List<Motherboard>();
            List<Good> goods = FirstPartParser(path);
            StreamReader sr = new StreamReader(path, Encoding.Default);
            int el = 0;
            Motherboard m = new Motherboard();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string fitem = "Сокет: ";
                if (line.Contains(fitem))
                {
                    m = new Motherboard();
                    m.Socket = line.Substring(fitem.Length, line.Length - fitem.Length);
                }
                fitem = "Форм-фактор: ";
                if (line.Contains(fitem))
                    m.FormFactor = line.Substring(fitem.Length, line.Length - fitem.Length);
                fitem = "Чипсет: ";
                if (line.Contains(fitem))
                    m.Chipset = line.Substring(fitem.Length, line.Length - fitem.Length);
                fitem = "Слоты памяти: ";
                if (line.Contains(fitem))
                    m.MemorySlots = line.Substring(fitem.Length, line.Length - fitem.Length);
                fitem = "Видеоинтерфейсы: ";
                if (line.Contains(fitem))
                    m.VideoInterfaces = line.Substring(fitem.Length, line.Length - fitem.Length);
                if (line == "end" || line == "")
                {
                    m.FullName = goods[el].FullName;
                    m.Price = goods[el].Price;
                    m.Category = goods[el].Category;
                    m.Brand = goods[el].Brand;
                    m.ImgSrc = goods[el].ImgSrc;
                    motherboards.Add(m);
                    el++;
                }
            }
            sr.Close();
            return motherboards;
        }
        public static List<VideoCard> GetVideoCards(string path)
        {
            List<VideoCard> VideoCards = new List<VideoCard>();
            List<Good> goods = FirstPartParser(path);
            StreamReader sr = new StreamReader(path, Encoding.Default);
            int el = 0;
            VideoCard m = new VideoCard();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string fitem = "Интерфейс: ";
                if (line.Contains(fitem))
                {
                    m = new VideoCard();
                    m.Interface = line.Substring(fitem.Length, line.Length - fitem.Length);
                }
                fitem = "Частота ядра: ";
                if (line.Contains(fitem))
                    m.CoreFrequency = int.Parse(line.Substring(fitem.Length, line.Length - fitem.Length).Replace("МГц", "").Replace(" ", ""));
                fitem = "Частота ядра (Boost): ";
                if (line.Contains(fitem))
                    m.CoreFrequencyBoost = int.Parse(line.Substring(fitem.Length, line.Length - fitem.Length).Replace("МГц", "").Replace(" ", ""));
                fitem = "Частота памяти: ";
                if (line.Contains(fitem))
                    m.MemoryFrequency = int.Parse(line.Substring(fitem.Length, line.Length - fitem.Length).Replace("МГц", "").Replace(" ", ""));
                fitem = "Разъёмы: ";
                if (line.Contains(fitem))
                    m.Connectors = line.Substring(fitem.Length, line.Length - fitem.Length);
                if (line == "end" || line == "")
                {
                    m.FullName = goods[el].FullName;
                    m.Price = goods[el].Price;
                    m.Category = goods[el].Category;
                    m.Brand = goods[el].Brand;
                    m.ImgSrc = goods[el].ImgSrc;
                    VideoCards.Add(m);
                    el++;
                }
            }
            sr.Close();
            return VideoCards;
        }
        public static List<Processor> GetProcessors(string path)
        {
            List<Processor> processors = new List<Processor>();
            List<Good> goods = FirstPartParser(path);
            StreamReader sr = new StreamReader(path, Encoding.Default);
            int el = 0;
            Processor m = new Processor();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string fitem = "Сокет: ";
                if (line.Contains(fitem))
                {
                    m = new Processor();
                    m.Socket = line.Substring(fitem.Length, line.Length - fitem.Length);
                }
                fitem = "Микроархитектура: ";
                if (line.Contains(fitem))
                    m.Microarchitecture = line.Substring(fitem.Length, line.Length - fitem.Length);
                fitem = "Ядро: ";
                if (line.Contains(fitem))
                    m.Kernel = line.Substring(fitem.Length, line.Length - fitem.Length);
                fitem = "Частота: ";
                if (line.Contains(fitem))
                    m.Frequency = float.Parse(line.Substring(fitem.Length, line.Length - fitem.Length).Replace("ГГц", "").Replace(" ", ""));
                fitem = "Количество ядер: ";
                if (line.Contains(fitem))
                    m.CoreAmount = int.Parse(line.Substring(fitem.Length, line.Length - fitem.Length-4).Replace(" ", ""));
                fitem = "Видеоядро: ";
                if (line.Contains(fitem))
                    m.GraphicsCore = line.Substring(fitem.Length, line.Length - fitem.Length);
                if (line == "end" || line == "")
                {
                    m.FullName = goods[el].FullName;
                    m.Price = goods[el].Price;
                    m.Category = goods[el].Category;
                    m.Brand = goods[el].Brand;
                    m.ImgSrc = goods[el].ImgSrc;
                    processors.Add(m);
                    el++;
                }
            }
            sr.Close();
            return processors;
        }
        public static List<PowerSupply> GetPowerSupplies(string path)
        {
            List<PowerSupply> powerSupplies = new List<PowerSupply>();
            List<Good> goods = FirstPartParser(path);
            StreamReader sr = new StreamReader(path, Encoding.Default);
            int el = 0;
            PowerSupply m = new PowerSupply();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string fitem = "Форм-фактор: ";
                if (line.Contains(fitem))
                {
                    m = new PowerSupply();
                    m.FormFactor = line.Substring(fitem.Length, line.Length - fitem.Length);
                }
                fitem = "Мощность: ";
                if (line.Contains(fitem))
                    m.Power = int.Parse(line.Substring(fitem.Length, line.Length - fitem.Length).Replace("Вт", "").Replace(" ", ""));
                fitem = "Сертификация: ";
                if (line.Contains(fitem))
                    m.Certification = line.Substring(fitem.Length, line.Length - fitem.Length);
                fitem = "Охлаждение: ";
                if (line.Contains(fitem))
                    m.Features = line.Substring(fitem.Length, line.Length - fitem.Length);
                fitem = "Особенности: ";
                if (line == "end" || line == "")
                {
                    m.FullName = goods[el].FullName;
                    m.Price = goods[el].Price;
                    m.Category = goods[el].Category;
                    m.Brand = goods[el].Brand;
                    m.ImgSrc = goods[el].ImgSrc;
                    powerSupplies.Add(m);
                    el++;
                }
            }
            sr.Close();
            return powerSupplies;
        }
        public static List<SSDDrive> GetSSDDrives(string path)
        {
            List<SSDDrive> sSDDrives = new List<SSDDrive>();
            List<Good> goods = FirstPartParser(path);
            StreamReader sr = new StreamReader(path, Encoding.Default);
            int el = 0;
            SSDDrive m = new SSDDrive();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string fitem = "Тип ячеек памяти: ";
                if (line.Contains(fitem))
                {
                    m = new SSDDrive();
                    m.CellMemoryType = line.Substring(fitem.Length, line.Length - fitem.Length);
                }
                fitem = "Ёмкость: ";
                if (line.Contains(fitem))
                    m.Capacity = line.Substring(fitem.Length, line.Length - fitem.Length);
                fitem = "Форм-фактор: ";
                if (line.Contains(fitem))
                    m.FormFactor = line.Substring(fitem.Length, line.Length - fitem.Length);
                fitem = "Интерфейс подключения: ";
                if (line.Contains(fitem))
                    m.ConnectionInterface = line.Substring(fitem.Length, line.Length - fitem.Length);
                fitem = "Скорость чтения: ";
                if (line.Contains(fitem))
                    m.ReadingSpeed = line.Substring(fitem.Length, line.Length - fitem.Length);
                if (line == "end" || line == "")
                {
                    m.FullName = goods[el].FullName;
                    m.Price = goods[el].Price;
                    m.Category = goods[el].Category;
                    m.Brand = goods[el].Brand;
                    m.ImgSrc = goods[el].ImgSrc;
                    sSDDrives.Add(m);
                    el++;
                }
            }
            sr.Close();
            return sSDDrives;
        }
    }
}
