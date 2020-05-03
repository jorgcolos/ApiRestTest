using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task seedData(DataContext context, UserManager<AppUser> userManager)
        {
            var products = new List<Product>();
            var users = new List<AppUser>();
            var images = new List<Image>();


            if (!context.Products.Any())
            {
                images = new List<Image>
                {
                    new Image
                    {
                        IdCloudinary = "qnrbxcieshmymrcpoh1d",
                        Url  = "https://res.cloudinary.com/dkrlhurj9/image/upload/v1588468717/qnrbxcieshmymrcpoh1d.jpg",
                        IsMain = true
                    },
                    new Image
                    {
                        IdCloudinary = "nygbzw1ogeifginejcgx",
                        Url  = "https://res.cloudinary.com/dkrlhurj9/image/upload/v1588468744/nygbzw1ogeifginejcgx.jpg",
                        IsMain = false
                    },
                    new Image
                    {
                        IdCloudinary = "brcbugdrhijds5bqqvpz",
                        Url  = "https://res.cloudinary.com/dkrlhurj9/image/upload/v1588468765/brcbugdrhijds5bqqvpz.jpg",
                        IsMain = true
                    },
                    new Image
                    {
                        IdCloudinary = "w3hphsodt4gie7buvtoo",
                        Url  = "https://res.cloudinary.com/dkrlhurj9/image/upload/v1588468803/w3hphsodt4gie7buvtoo.jpg",
                        IsMain = false
                    },
                    new Image
                    {
                        IdCloudinary = "f6zh7jjzvfhgbtkcolr3",
                        Url  = "https://res.cloudinary.com/dkrlhurj9/image/upload/v1588468835/f6zh7jjzvfhgbtkcolr3.jpg",
                        IsMain = true
                    },
                    new Image
                    {
                        IdCloudinary = "daxhuvprrhnxjoynrjov",
                        Url  = "https://res.cloudinary.com/dkrlhurj9/image/upload/v1588468867/daxhuvprrhnxjoynrjov.jpg",
                        IsMain = true
                    },
                    new Image
                    {
                        IdCloudinary = "emmd4wq7b1uuzql02jc6",
                        Url  = "https://res.cloudinary.com/dkrlhurj9/image/upload/v1588468901/emmd4wq7b1uuzql02jc6.jpg",
                        IsMain = false
                    },
                    new Image
                    {
                        IdCloudinary = "ef2t8veexkf9vhqvnwdl",
                        Url  = "https://res.cloudinary.com/dkrlhurj9/image/upload/v1588468925/ef2t8veexkf9vhqvnwdl.jpg",
                        IsMain = true
                    }
                };
            }

            if (!context.Products.Any())
            {
                products = new List<Product>
                {
                    new Product
                    {
                        SKU = "CPU1",
                        Name = "Intel Core i7-9700K",
                        Quantity = 55,
                        Price = 379.99,
                        Description = "Intel Core i7-9700K Coffee Lake 8-Core 3.6 GHz (4.9 GHz Turbo) LGA 1151 (300 Series) 95W BX80684I79700K Desktop Processor Intel UHD Graphics 630",
                        Created = DateTime.Now,
                        Images =  images.Where(x => x.IdCloudinary == "qnrbxcieshmymrcpoh1d" || x.IdCloudinary == "nygbzw1ogeifginejcgx").ToList()
                    },
                    new Product
                    {
                        SKU = "CPU2",
                        Name = "Intel Core i5-9600K",
                        Quantity = 288,
                        Price = 199.99,
                        Description = "Intel Core i5-9600K Coffee Lake 6-Core 3.7 GHz (4.6 GHz Turbo) LGA 1151 (300 Series) 95W BX80684I59600K Desktop Processor Intel UHD Graphics 630",
                        Created = DateTime.Now,
                        Images =  images.Where(x => x.IdCloudinary == "brcbugdrhijds5bqqvpz"|| x.IdCloudinary == "w3hphsodt4gie7buvtoo").ToList()
                    },
                    new Product
                    {
                        SKU = "CPU3",
                        Name = "AMD RYZEN 7 3700X",
                        Quantity = 104,
                        Price = 308.99,
                        Description = "AMD RYZEN 7 3700X 8-Core 3.6 GHz (4.4 GHz Max Boost) Socket AM4 65W 100-100000071BOX Desktop Processor",
                        Created = DateTime.Now,
                        Images =  images.Where(x => x.IdCloudinary == "f6zh7jjzvfhgbtkcolr3").ToList()
                    },
                    new Product
                    {
                        SKU = "SSD1",
                        Name = "WD Blue 3D NAND 1TB",
                        Quantity = 144,
                        Price = 119.99,
                        Description = "WD Blue 3D NAND 1TB Internal SSD - SATA III 6Gb/s 2.5 Solid State Drive - WDS100T2B0A",
                        Created = DateTime.Now,
                        Images =  images.Where(x => x.IdCloudinary == "daxhuvprrhnxjoynrjov"|| x.IdCloudinary == "emmd4wq7b1uuzql02jc6").ToList()
                    },
                    new Product
                    {
                        SKU = "SSD2",
                        Name = "SAMSUNG 860 QVO Series 1TB",
                        Quantity = 41,
                        Price = 113.55,
                        Description = "SAMSUNG 860 QVO Series 2.5 1TB SATA III Internal Solid State Drive (SSD) MZ-76Q1T0B/AM",
                        Created = DateTime.Now,
                        Images =  images.Where(x => x.IdCloudinary == "ef2t8veexkf9vhqvnwdl").ToList()
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
                await context.SaveChangesAsync();
            }
            if (!userManager.Users.Any())
            {
                users = new List<AppUser>
                {
                    new AppUser
                    {
                        UserName = "jorge",
                        Email = "jorgcolos@gmail.com",
                        PhoneNumber = "22577777",
                        Name = "Jorge Herrera",
                        Birthday = DateTime.Parse("22/08/1989"),
                        Products = products.Where(x => x.SKU == "CPU1" || x.SKU == "CPU2" || x.SKU == "SSD1"|| x.SKU == "RAM2").ToList()
                    },
                    new AppUser
                    {
                        UserName = "efrain",
                        Email = "efrain@elaniin.com",
                        PhoneNumber = "71000000",
                        Name = "Efrain Ortiz",
                        Birthday = DateTime.Parse("01/01/1987"),
                        Products = products.Where(x => x.SKU == "CPU3" || x.SKU == "SSD2" || x.SKU == "RAM1").ToList()
                    },
                    new AppUser
                    {
                        UserName = "rony",
                        Email = "rony@elaniin.com",
                        PhoneNumber = "22777777",
                        Name = "Rony Almendarez",
                        Birthday = DateTime.Parse("02/02/1991")
                    },
                    new AppUser
                    {
                        UserName = "test",
                        Email = "test@email.com",
                        PhoneNumber = "12345678",
                        Name = "User Test",
                        Birthday = DateTime.Parse("04/04/1980")
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Elaniin@01");
                }
            }
        }

    }
}