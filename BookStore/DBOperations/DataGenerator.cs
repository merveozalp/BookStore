using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



namespace BookStore.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider )
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }
                context.Books.AddRange(new PutBookModel
                {
                    //Id = 1,
                    Title = "Çalıkuşu",
                    GenreId = 1,
                    PageCount = 200,
                    PublishDate = new DateTime(2001, 06, 12)

                },
            new PutBookModel
            {
               //Id = 2,
                Title = "Suç Ve Ceza",
                GenreId = 1,
                PageCount = 200,
                PublishDate = new DateTime(2001, 06, 12)

            },
            new PutBookModel
            {
               //Id = 3,
                Title = "Outlife",
                GenreId = 1,
                PageCount = 200,
                PublishDate = new DateTime(2001, 06, 12)

            }); // Database veri yoksa veri eklemesi yapacak
                context.SaveChanges();
            }
        }
    }
}
