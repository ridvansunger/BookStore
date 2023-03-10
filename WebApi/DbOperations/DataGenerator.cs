using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using WebApi.Entities;

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

            context.Genres.AddRange(
                new Genre{
                    Name="Personal Growth",

                },
                new Genre{
                    Name="Science",

                },
                new Genre{
                    Name="Romance",

                }
            );

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

            context.Authors.AddRange(
                new Author 
                    {
                        Name = "Samet",
                        LastName = "Şahin",
                        DateOfBirth = new DateTime(1999,06,07),
                        BookId = 1

                    
                    },
                    new Author 
                    {
                        Name = "Remziye",
                        LastName = "Akın",
                        DateOfBirth = new DateTime(1999,11,24),
                        BookId = 2
                        
                    },
                    new Author 
                    {
                        Name = "Batu",
                        LastName = "Ok",
                        DateOfBirth = new DateTime(1999,10,24),
                       // BookId = 3
                        
                    }
            );


            context.SaveChanges();



        };

            
        }
    }
}

