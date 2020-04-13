using GalleryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GalleryAPI.DB
{
    public class DBSeeder
    {
        public DBSeeder(ProductDbContext dbcontext)
        {
            // Create mock products
            Product product1 = new Product();
            product1.Id = Guid.NewGuid().ToString();
            product1.Name = ".NET Charts";
            product1.UnitPrice = 99;
            product1.Description = "Brings powerful charting capabilities to your .NET applications.";
            product1.Photo = "~/assets/Charts.jpg";
            dbcontext.Add(product1);

            Product product2 = new Product();
            product2.Id = Guid.NewGuid().ToString();
            product2.Name = ".NET PayPal";
            product2.UnitPrice = 69;
            product2.Description = "Integrate your .NET apps with PayPal the easy way!";
            product2.Photo = "~/assets/PayPal.jpg";
            dbcontext.Add(product2);

            Product product3 = new Product();
            product3.Id = Guid.NewGuid().ToString();
            product3.Name = ".NET ML";
            product3.UnitPrice = 254;
            product3.Description = "Supercharged .NET machine learning libraies.";
            product3.Photo = "~/assets/ML.jpg";
            dbcontext.Add(product3);

            Product product4 = new Product();
            product4.Id = Guid.NewGuid().ToString();
            product4.Name = ".NET Analytics";
            product4.UnitPrice = 134;
            product4.Description = "Performs data mining and analytics easily in .NET.";
            product4.Photo = "~/assets/Analytics.jpg";
            dbcontext.Add(product4);

            Product product5 = new Product();
            product5.Id = Guid.NewGuid().ToString();
            product5.Name = ".NET Logger";
            product5.UnitPrice = 75;
            product5.Description = "Logs and aggregates events easily in your .NET apps.";
            product5.Photo = "~/assets/Logger.jpg";
            dbcontext.Add(product5);

            Product product6 = new Product();
            product6.Id = Guid.NewGuid().ToString();
            product6.Name = ".NET Numerics";
            product6.UnitPrice =177;
            product6.Description = "Powerful numerical methods for your .NET simulations.";
            product6.Photo = "~/assets/Numerics.jpg";
            dbcontext.Add(product6);

            Product product7 = new Product();
            product7.Id = Guid.NewGuid().ToString();
            product7.Name = ".NET Blazor";
            product7.UnitPrice = 177;
            product7.Description = "Develop with reusable UI components that can take advantage of WebAssembly for near-native performance";
            product7.Photo = "~/assets/Blazor.jpg";
            dbcontext.Add(product7);

            Product product8 = new Product();
            product8.Id = Guid.NewGuid().ToString();
            product8.Name = ".NET API";
            product8.UnitPrice = 188;
            product8.Description = "Develop RESTful HTTP services with ASP.NET Core web API";
            product8.Photo = "~/assets/API.jpg";
            dbcontext.Add(product8);

            Product product9 = new Product();
            product9.Id = Guid.NewGuid().ToString();
            product9.Name = ".NET WebUI";
            product9.UnitPrice = 199;
            product9.Description = "Develop page-focused web apps with a clean separation of concerns";
            product9.Photo = "~/assets/WebUI.jpg";
            dbcontext.Add(product9);

            Product product10 = new Product();
            product10.Id = Guid.NewGuid().ToString();
            product10.Name = ".NET MVC";
            product10.UnitPrice = 210;
            product10.Description = "Develop web apps using the Model-View-Controller design pattern";
            product10.Photo = "~/assets/MVC.jpg";
            dbcontext.Add(product10);

            Product product11 = new Product();
            product11.Id = Guid.NewGuid().ToString();
            product11.Name = ".NET RealTime";
            product11.UnitPrice = 211;
            product11.Description = "Add real-time functionality to your web app, enable server-side code to push content instantly";
            product11.Photo = "~/assets/RealTime.jpg";
            dbcontext.Add(product11);

            Product product12 = new Product();
            product12.Id = Guid.NewGuid().ToString();
            product12.Name = ".NET gPRC";
            product12.UnitPrice = 212;
            product12.Description = "Develop contract-first, high-performance services with gRPC in ASP.NET Core";
            product12.Photo = "~/assets/gPRC.jpg";
            dbcontext.Add(product12);

            Product product13 = new Product();
            product13.Id = Guid.NewGuid().ToString();
            product13.Name = ".NET DataDrive";
            product13.UnitPrice = 213;
            product13.Description = "Create data-driven web apps in ASP.NET Core";
            product13.Photo = "~/assets/DataDrive.jpg";
            dbcontext.Add(product13);

            Product product14 = new Product();
            product14.Id = Guid.NewGuid().ToString();
            product14.Name = ".NET Overview";
            product14.UnitPrice = 214;
            product14.Description = "Learn about .NET Core";
            product14.Photo = "~/assets/Overview.jpg";
            dbcontext.Add(product14);

            Product product15 = new Product();
            product15.Id = Guid.NewGuid().ToString();
            product15.Name = ".NET Concepts";
            product15.UnitPrice = 215;
            product15.Description = "Learn the fundamental concepts of .NET";
            product15.Photo = "~/assets/Concepts.jpg";
            dbcontext.Add(product15);

            Product product16 = new Product();
            product16.Id = Guid.NewGuid().ToString();
            product16.Name = ".NET Develop";
            product16.UnitPrice = 216;
            product16.Description = "Start developing with .NET";
            product16.Photo = "~/assets/Develop.jpg";
            dbcontext.Add(product16);

            Product product17 = new Product();
            product17.Id = Guid.NewGuid().ToString();
            product17.Name = ".NET Architect";
            product17.UnitPrice = 217;
            product17.Description = "Read foundational development and architectural guidance for .NET";
            product17.Photo = "~/assets/Architect.jpg";
            dbcontext.Add(product17);

            Product product18 = new Product();
            product18.Id = Guid.NewGuid().ToString();
            product18.Name = ".NET Charts II";
            product18.UnitPrice = 218;
            product18.Description = "Brings more powerful charting capabilities to your .NET applications.";
            product18.Photo = "~/assets/Charts.jpg";
            dbcontext.Add(product18);

            Product product19 = new Product();
            product19.Id = Guid.NewGuid().ToString();
            product19.Name = ".NET PayPal II";
            product19.UnitPrice = 219;
            product19.Description = "Integrate more your .NET apps with PayPal the easy way!";
            product19.Photo = "~/assets/PayPal.jpg";
            dbcontext.Add(product19);

            Product product20 = new Product();
            product20.Id = Guid.NewGuid().ToString();
            product20.Name = ".NET ML II";
            product20.UnitPrice = 220;
            product20.Description = "Supercharged more .NET machine learning libraies.";
            product20.Photo = "~/assets/ML.jpg";
            dbcontext.Add(product20);

            Product product21 = new Product();
            product21.Id = Guid.NewGuid().ToString();
            product21.Name = ".NET Analytics II";
            product21.UnitPrice = 221;
            product21.Description = "Performs more data mining and analytics easily in .NET.";
            product21.Photo = "~/assets/Analytics.jpg";
            dbcontext.Add(product21);

            Product product22 = new Product();
            product22.Id = Guid.NewGuid().ToString();
            product22.Name = ".NET Logger II";
            product22.UnitPrice = 75;
            product22.Description = "Integrated version of logs and aggregates events easily in your .NET apps.";
            product22.Photo = "~/assets/Logger.jpg";
            dbcontext.Add(product22);

            Product product23 = new Product();
            product23.Id = Guid.NewGuid().ToString();
            product23.Name = ".NET Numerics II";
            product23.UnitPrice = 223;
            product23.Description = "Integrated version of powerful numerical methods for your .NET simulations.";
            product23.Photo = "~/assets/Numerics.jpg";
            dbcontext.Add(product23);

            Product product24 = new Product();
            product24.Id = Guid.NewGuid().ToString();
            product24.Name = ".NET Blazor II";
            product24.UnitPrice = 224;
            product24.Description = "Integrated version of developing with reusable UI components that can take advantage of WebAssembly for near-native performance";
            product24.Photo = "~/assets/Blazor.jpg";
            dbcontext.Add(product24);

            Product product25 = new Product();
            product25.Id = Guid.NewGuid().ToString();
            product25.Name = ".NET API II";
            product25.UnitPrice = 188;
            product25.Description = "Integrated version of developing RESTful HTTP services with ASP.NET Core web API";
            product25.Photo = "~/assets/API.jpg";
            dbcontext.Add(product25);

            Product product26 = new Product();
            product26.Id = Guid.NewGuid().ToString();
            product26.Name = ".NET WebUI II";
            product26.UnitPrice = 226;
            product26.Description = "Integrated version of developing page-focused web apps with a clean separation of concerns";
            product26.Photo = "~/assets/WebUI.jpg";
            dbcontext.Add(product26);

            Product product27 = new Product();
            product27.Id = Guid.NewGuid().ToString();
            product27.Name = ".NET MVC II";
            product27.UnitPrice = 227;
            product27.Description = "Integrated version of developing web apps using the Model-View-Controller design pattern";
            product27.Photo = "~/assets/MVC.jpg";
            dbcontext.Add(product27);

            Product product28 = new Product();
            product28.Id = Guid.NewGuid().ToString();
            product28.Name = ".NET RealTime II";
            product28.UnitPrice = 228;
            product28.Description = "Integrated version of adding real-time functionality to your web app, enable server-side code to push content instantly";
            product28.Photo = "~/assets/RealTime.jpg";
            dbcontext.Add(product28);

            Product product29 = new Product();
            product29.Id = Guid.NewGuid().ToString();
            product29.Name = ".NET gPRC II";
            product29.UnitPrice = 229;
            product29.Description = "Integrated version of developingp contract-first, high-performance services with gRPC in ASP.NET Core";
            product29.Photo = "~/assets/gPRC.jpg";
            dbcontext.Add(product29);

            Product product30 = new Product();
            product30.Id = Guid.NewGuid().ToString();
            product30.Name = ".NET DataDrive II";
            product30.UnitPrice = 230;
            product30.Description = "Integrated version of creating data-driven web apps in ASP.NET Core";
            product30.Photo = "~/assets/DataDrive.jpg";
            dbcontext.Add(product30);

            Product product31 = new Product();
            product31.Id = Guid.NewGuid().ToString();
            product31.Name = ".NET Overview II";
            product31.UnitPrice = 231;
            product31.Description = "Learn more about .NET Core";
            product31.Photo = "~/assets/Overview.jpg";
            dbcontext.Add(product31);

            Product product32 = new Product();
            product32.Id = Guid.NewGuid().ToString();
            product32.Name = ".NET Concepts II";
            product32.UnitPrice = 215;
            product32.Description = "Learn more fundamental concepts of .NET";
            product32.Photo = "~/assets/Concepts.jpg";
            dbcontext.Add(product32);

            Product product33 = new Product();
            product33.Id = Guid.NewGuid().ToString();
            product33.Name = ".NET Develop II";
            product33.UnitPrice = 233;
            product33.Description = "Integrated version of starting developing with .NET";
            product33.Photo = "~/assets/Develop.jpg";
            dbcontext.Add(product33);

            Product product34 = new Product();
            product34.Id = Guid.NewGuid().ToString();
            product34.Name = ".NET Architect II";
            product34.UnitPrice = 234;
            product34.Description = "Read more foundational development and architectural guidance for .NET";
            product34.Photo = "~/assets/Architect.jpg";
            dbcontext.Add(product34);

/*            Product product = new Product();
            product.Id = Guid.NewGuid().ToString();
            product.Name = "";
            product.UnitPrice = 177;
            product.Description = "";
            product.Photo = "~/assets/.jpg";
            dbcontext.Add(product);*/



            dbcontext.SaveChanges();
        }
    }
}
