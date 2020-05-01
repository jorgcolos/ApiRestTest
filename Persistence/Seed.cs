using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static void seedData(DataContext context)
        {
            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        SKU = "CPU1",
                        Name = "Intel Core i7-9700K",
                        Quantity = 55,
                        Price = 379.99,
                        Description = "Intel Core i7-9700K Coffee Lake 8-Core 3.6 GHz (4.9 GHz Turbo) LGA 1151 (300 Series) 95W BX80684I79700K Desktop Processor Intel UHD Graphics 630",
                        Created = DateTime.Now
                    },
                    new Product
                    {
                        SKU = "CPU2",
                        Name = "Intel Core i5-9600K",
                        Quantity = 288,
                        Price = 199.99,
                        Description = "Intel Core i5-9600K Coffee Lake 6-Core 3.7 GHz (4.6 GHz Turbo) LGA 1151 (300 Series) 95W BX80684I59600K Desktop Processor Intel UHD Graphics 630",
                        Created = DateTime.Now
                    },
                    new Product
                    {
                        SKU = "CPU3",
                        Name = "AMD RYZEN 7 3700X",
                        Quantity = 104,
                        Price = 308.99,
                        Description = "AMD RYZEN 7 3700X 8-Core 3.6 GHz (4.4 GHz Max Boost) Socket AM4 65W 100-100000071BOX Desktop Processor",
                        Created = DateTime.Now
                    },
                    new Product
                    {
                        SKU = "SSD1",
                        Name = "WD Blue 3D NAND 1TB",
                        Quantity = 144,
                        Price = 119.99,
                        Description = "WD Blue 3D NAND 1TB Internal SSD - SATA III 6Gb/s 2.5 Solid State Drive - WDS100T2B0A",
                        Created = DateTime.Now
                    },
                    new Product
                    {
                        SKU = "SSD2",
                        Name = "SAMSUNG 860 QVO Series 1TB",
                        Quantity = 41,
                        Price = 113.55,
                        Description = "SAMSUNG 860 QVO Series 2.5 1TB SATA III Internal Solid State Drive (SSD) MZ-76Q1T0B/AM",
                        Created = DateTime.Now
                    },
                    new Product
                    {
                        SKU = "RAM1",
                        Name = "G.SKILL TridentZ RGB Series 16GB",
                        Quantity = 68,
                        Price = 100.99,
                        Description = "G.SKILL TridentZ RGB Series 16GB (2 x 8GB) 288-Pin DDR4 SDRAM DDR4 3200 (PC4 25600) Desktop Memory Model F4-3200C16D-16GTZR",
                        Created = DateTime.Now
                    },
                    new Product
                    {
                        SKU = "RAM2",
                        Name = "G.SKILL Ripjaws V Series 16GB",
                        Quantity = 420,
                        Price = 72.49,
                        Description = "G.SKILL Ripjaws V Series 16GB (2 x 8GB) 288-Pin DDR4 SDRAM DDR4 3200 (PC4 25600) Desktop Memory Model F4-3200C16D-16GVKB",
                        Created = DateTime.Now
                    }
                };
                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}