using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.ProductDB
{
    public class ProductSeeder
    {
        public ProductSeeder(ProductContext dbcontext)
        {
            Product product1 = new Product();
            product1.Id = "MSOfficePro2019";
            product1.productName = "Microsoft Office Professional 2019";
            product1.productDescription = "Get one of the most complete editions of the Microsoft Office package, that includes all of the Microsoft office software, with all of the classic features and many improved functions. " +
                "The package includes 2019 versions of Word, Excel, PowerPoint, Outlook and additionally Publisher and Access, as well as Skype for Business, all with a one-buy lifetime license for one computer.";
            product1.unitPrice = 40.00;
            product1.productRating = 5;
            product1.imageURL = "../images/Office.jpg";
            dbcontext.Add(product1);


            Product product2 = new Product();
            product2.Id = "KaspAV2019";
            product2.productName = "Kaspersky Anti-Virus 2019";
            product2.productDescription = "Best antivirus for your Windows PC. Blocks the latest viruses, ransomware, spyware, cryptolockers & more – and helps stop cryptocurrency mining malware damaging your PC’s performance.";
            product2.unitPrice = 151.00;
            product2.productRating = 5;
            product2.imageURL = "../images/Kaspersky.png";
            dbcontext.Add(product2);

            Product product3 = new Product();
            product3.Id = "NortonSecurity";
            product3.productName = "Norton Security Deluxe";
            product3.productDescription = "Norton Security Deluxe provides comprehensive malware protection for up to 5 PCs, Mac, Android or iOS devices, plus Parental Control‡ to help protect your kids online, " +
                "Password Manager to store and manage your passwords and PC Cloud Backup4.";
            product3.unitPrice = 79.90;
            product3.productRating = 4;
            product3.imageURL = "../images/Norton.png";
            dbcontext.Add(product3);


            Product product4 = new Product();
            product4.Id = "MovaviVid";
            product4.productName = "Movavi Video Editor";
            product4.productDescription = "Movavi Video Editor is designed for anyone who wants to easily share sentiments through videos. " +
                "Create heart-warming wedding videos, engaging travel clips, memorable birthday films and home movies. With Movavi’s video software, you become the director of your own story.";
            product4.unitPrice = 49.90;
            product4.productRating = 3;
            product4.imageURL = "../images/Movavi.png";
            dbcontext.Add(product4);

            Product product5 = new Product();
            product5.Id = "3DS_Max";
            product5.productName = "3DS Max";
            product5.productDescription = "Produce professional-quality 3D animations, renders, and models with 3ds Max® software. An efficient and flexible toolset to help you create better 3D content in less time.";
            product5.unitPrice = 272.80;
            product5.productRating = 3.5;
            product5.imageURL = "../images/3DSMAX.png";
            dbcontext.Add(product5);

            Product product6 = new Product();
            product6.Id = "McAfeetp";
            product6.productName = "McAfee Total Protection";
            product6.productDescription = "McAfee Total Protection Is the Best Antivirus Software for PC, Laptop, Android and iOS devices with virus protection, spam filtering capabilities, " +
                "the ability to securely encrypt sensitive files and much, much more. Connect multiple devices and protect what matters most from hackers and cybercriminals.";
            product6.unitPrice = 272.80;
            product6.productRating = 4.5;
            product6.imageURL = "../images/McAfee.png";
            dbcontext.Add(product6);

            Product product7 = new Product();
            product7.Id = "Vegasms16";
            product7.productName = "VEGAS Movie Studio 16 Platinum";
            product7.productDescription = "VEGAS Movie Studio 16 offers our most user-friendly approach ever to creating beautiful videos. Work fast with interactive storyboards. Work confidently with automatic saves." +
                " Work smoothly with GPU and hardware acceleration. Powerful and intuitive – nothing helps you create like VEGAS Movie Studio 16!";
            product7.unitPrice = 59.99;
            product7.productRating = 2.5;
            product7.imageURL = "../images/vegasmovie.jpg"; 
            dbcontext.Add(product7);

            Product product8 = new Product();
            product8.Id = "PowerDirectorU";
            product8.productName = "PowerDirector 17 Ultra";
            product8.productDescription = "Take your video editing skills to the next level with PowerDirector – 10-time Winner of PC Magazine’s Editors’ Choice " +
                "and rated as one of the fastest and most capable consumer-level video-editing for Windows around.";
            product8.unitPrice = 135.99;
            product8.productRating = 2;
            product8.imageURL = "../images/powerdirector.jpg"; 
            dbcontext.Add(product8);

            Product product9 = new Product();
            product9.Id = "TRENDMICROIS";
            product9.productName = "TREND MICRO Internet Security";
            product9.productDescription = "Trend Micro Internet Security provides advanced online protection for your PC and Mac. This includes security against ransomware, viruses, malware, spyware, and identity theft. " +
                "Ensure that your online banking and shopping is secure with Pay Guard. New feature Fraud Buster adds an extra layer of security by guarding against scams and phishing emails.";
            product9.unitPrice = 34.00;
            product9.productRating = 4;
            product9.imageURL = "../images/trendmicro.jpg";
            dbcontext.Add(product9);

            Product product10 = new Product();
            product10.Id = "BullGuardP";
            product10.productName = "BullGuard Premium Protection";
            product10.productDescription = "BullGuard Premium Protection is the total online security solution for you, your family and your home network. Every device on your network is a potential back door, " +
                "giving bad guys access to everything across the whole network. Our NEW Home Network Scanner proactively protects your entire network and every device on it 24/7.";
            product10.unitPrice = 29.89;
            product10.productRating = 3;
            product10.imageURL = "../images/bullguard.jpg"; 
            dbcontext.Add(product10);


            Product product11 = new Product();
            product11.Id = "AdobePhotoshopCS2";
            product11.productName = "Adobe Photoshop CS2";
            product11.productDescription = "Adobe Photoshop CS2 software brings a new level of power, precision and control to the digital photography experience and to the overall creative process. " +
                "Photoshop CS2 integrates a new set of intuitive tools, including an enhanced Spot Healing Brush, for handling common photographic problems such as blemishes, red-eye, noise, blurring and lens distortion.";
            product11.unitPrice = 299.00;
            product11.productRating = 3.5;
            product11.imageURL = "../images/adobephotoshop.jpg"; 
            dbcontext.Add(product11);

            Product product12 = new Product();
            product12.Id = "AdobeCreativeSuite";
            product12.productName = "Adobe Creative Suite 5.5";
            product12.productDescription = "Adobe Creative Suite 5.5 Production Premium for Mac (Upgrade from Individual CS Programs) is a complete package of professional software programs that allow you to create, " +
                "manipulate, edit, enhance, package, and deliver images, graphics, audio, and video. To be able to use this upgrade to Creative Suite 5.5 Production Premium, you must own one of the following products for Mac OS X.";
            product12.unitPrice = 198.00;
            product12.productRating = 4.5;
            product12.imageURL = "../images/adobecreative.jpg";
            dbcontext.Add(product12);

            Product product13 = new Product();
            product13.Id = "VMwarevSphere6E";
            product13.productName = "VMware vSphere 6 Essentials";
            product13.productDescription = "VMware vSphere Essentials includes vCenter Server Essentials and ESXi for 3 hosts, plus the following features: vCenter agents and Update Manager. " +
                "vSphere Essentials is limited for use on up to 3 hosts and on servers with up to two processors only. The server hosts must be managed by the vCenter Server Essentials edition that is provided with this bundle, " +
                "and that same Center Server Essentials edition cannot be used to manage other server hosts not included with this edition.";
            product13.unitPrice = 679.99;
            product13.productRating = 4;
            product13.imageURL = "../images/vmware.jpg"; 
            dbcontext.Add(product13);

            Product product14 = new Product();
            product14.Id = "MicrosoftVisioProfessional";
            product14.productName = "Microsoft Visio Professional 2019";
            product14.productDescription = "Visio 2019 Professional from Microsoft is a next-generation diagramming tool that allows users to make sense of complex information with a series of easy-to-understand diagrams. " +
                "Create easy-to-understand diagrams and help simplify complex processes, systems, and networks with Microsoft Office Visio Professional 2019.";
            product14.unitPrice = 19.99;
            product14.productRating = 3.5;
            product14.imageURL = "../images/visiocdc.jpg"; // add link to image
            dbcontext.Add(product14);

             Product product15 = new Product();
            product15.Id = "MicrosoftProjectP2016";
            product15.productName = "Microsoft Project Professional 2016";
            product15.productDescription = "Microsoft Project Professional 2016 is a professional business tool that helps create business projects in collaboration with others. " +
                "It comprises all Project Standard features, and also resource management, collaboration tools, time-sheets, SharePoint task sync, etc.";
            product15.unitPrice = 24.99;
            product15.productRating = 4;
            product15.imageURL = "../images/msproject.png"; // add link to image
            dbcontext.Add(product15);

            dbcontext.SaveChanges();
        }
    }
}
