using System;
using System.Collections.Generic;
using AutoMapper;

namespace automapper
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //--------seteamos las variables

            var authorEntidadArturo = new AuthorEntity();
            authorEntidadArturo.Name = "Arturo Perez Reverte";
            authorEntidadArturo.Age = 50;
            var book1 = new BookEntity
            {
                Id = 1,
                Title = "Fargo",
                Subtitle = "Subtitulo1",
                Pages = 100,
                Edition = 1,
                Author = authorEntidadArturo
            };
            var book2 = new BookEntity
            {
                Id = 2,
                Title = "Fargo2",
                Subtitle = "Subtitulo2",
                Pages = 200,
                Edition = 2,
                Author = authorEntidadArturo
            };
            var book3 = new BookEntity
            {
                Id = 3,
                Title = "Fargo3",
                Subtitle = "Subtitulo3",
                Pages = 300,
                Edition = 3,
                Author = authorEntidadArturo
            };

            authorEntidadArturo.Books = new List<BookEntity>() { book1, book2, book3 };
            //authorEntidadArturo.Books.Add(book1);
            //authorEntidadArturo.Books.Add(book2);
            //authorEntidadArturo.Books.Add(book3);


            //----------------------------------------------------EJEMPLO 1: Como hacer un mapeo "a mano"


            //mapeo Entity -> Model
            //var authorModelArturo_aManurrio = new AuthorModel();
            //authorModelArturo_aManurrio.Name = authorEntidadArturo.Name;
            //authorModelArturo_aManurrio.Age = authorEntidadArturo.Age;
            //authorModelArturo_aManurrio.BooksCount = authorEntidadArturo.Books.Count;

            //Console.WriteLine($"{authorModelArturo_aManurrio.Name},{authorModelArturo_aManurrio.Age},{authorModelArturo_aManurrio.BooksCount}");


            //Flattering - Partiendo de un modelo complejo pasarlo a un modelo simple

            //----------------------------------------------------EJEMPLO 2: Mapeamos con automapper
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<AuthorEntity, AuthorModel>();
            //});

            //var authorModelArturoConMapper = Mapper.Map<AuthorEntity, AuthorModel>(authorEntidadArturo);

            //Console.WriteLine($"{authorModelArturoConMapper.Name},{authorModelArturoConMapper.Age},{authorModelArturoConMapper.BooksCount}");

            //--------------------------------------------------EJEMPLO 3: Definición personalizada de propiedades o Projection
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<BookEntity, BookModel>()
            //        .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(entity => entity.Author.Name))
            //        .ForMember(dest => dest.FullTitle, opt => opt.MapFrom(entity => entity.Title + " " + entity.Subtitle))
            //        .ForMember(dest => dest.TimeSent, opt => opt.Ignore());
            //});
            //IEnumerable<BookModel> libros = Mapper.Map<BookModel[]>(authorEntidadArturo.Books);
            /// El tipo de colecciones que soporta: IEnumrables, ICollection, IList, Array/

            //foreach (var elem in libros)
            //{
            //    Console.WriteLine($"{elem.Id} {elem.AuthorName}: Titulo:{elem.FullTitle}\n Num.Paginas:{elem.Pages}\n\n");
            //}
            //ATENCION: ResolveUsing = DEPRECATED


            //--------------------------------------------------EJEMPLO 4: Reverse Mapping and Unflattering
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<BookEntity, BookModel>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(entity => entity.Author.Name))
                .ReverseMap();
            });

            IEnumerable<BookModel> libros = Mapper.Map<BookModel[]>(authorEntidadArturo.Books);

            var libroModelo = new BookModel();
            libroModelo.Pages = 300;
            libroModelo.Edition = 3;
            libroModelo.AuthorName = authorEntidadArturo.Name;

            var libroModelo_aEntidad = new BookEntity();

            Mapper.Map(libroModelo, libroModelo_aEntidad);

            Console.WriteLine($"{libroModelo_aEntidad.Id}");



            //--------------------------------------------------EJEMPLO 5: Nested types
            //buen ejemplo en https://dotnettutorials.net/lesson/automapper-with-nested-types/



            Console.ReadKey();

        }
    }
}
