using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace WebApi.DbOperations{

public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookStoreDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
        {
            // Look for any book.
            if (context.Books.Any())
            {
                return;   // Data was already seeded
            }

            context.Books.AddRange(
               
        new Book{
              //  Id=1,
                Title="Lean Startup",
                GenreId=1,//Personal Growt
                PageCount=200,
                PublishDate=new DateTime(2001,06,12)
            },
             new Book{
               // Id=2,
                Title="Herland",
                GenreId=2,//Science
                PageCount=250,
                PublishDate=new DateTime(2015,05,25)
            },
             new Book{
               // Id=3,
                Title="Dune",
                GenreId=2,//Science
                PageCount=540,
                PublishDate=new DateTime(2015,12,24)
            });
            context.SaveChanges();
        };

            
        }
    }
}

