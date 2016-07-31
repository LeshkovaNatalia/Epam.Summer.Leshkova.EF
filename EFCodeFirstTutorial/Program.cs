using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new GalleryContext())
            {
                CategoryPhoto category = new CategoryPhoto() { Name = "Портрет" };
                ctx.CategoryPhotos.Add(category);
                ctx.SaveChanges();
                Console.WriteLine(ctx.Database.Connection.ConnectionString);
            }
            Console.ReadLine();
        }
    }
}
