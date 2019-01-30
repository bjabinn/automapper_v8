using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Mappers;

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


            //----------------------------------------------------EJEMPLO 0: Como hacer un mapeo "a mano"


            //mapeo Entity -> Model
            //var authorModelArturo_aManurrio = new AuthorModel();
            //authorModelArturo_aManurrio.Name = authorEntidadArturo.Name;
            //authorModelArturo_aManurrio.Age = authorEntidadArturo.Age;
            //authorModelArturo_aManurrio.BooksCount = authorEntidadArturo.Books.Count;

            //Console.WriteLine($"{authorModelArturo_aManurrio.Name},{authorModelArturo_aManurrio.Age},{authorModelArturo_aManurrio.BooksCount}");



            //Flattering - Partiendo de un modelo complejo pasarlo a un modelo simple
            //----------------------------------------------------EJEMPLO 1: Mapeamos con automapper
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<AuthorEntity, AuthorModel>();
            //});

            //var authorModelArturoConMapper = Mapper.Map<AuthorEntity, AuthorModel>(authorEntidadArturo);

            //Console.WriteLine($"{authorModelArturoConMapper.Name},{authorModelArturoConMapper.Age},{authorModelArturoConMapper.BooksCount}");


            //---------------------EJEMPLO 2: Definición personalizada de propiedades o Projection
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<BookEntity, BookModel>()
            //        .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(entity => entity.Author.Name))
            //        .ForMember(dest => dest.FullTitle, opt => opt.MapFrom(entity => $"{entity.Title} {entity.Subtitle}"))
            //        .ForMember(dest => dest.TimeSent, opt => opt.Ignore());
            //});
            //IEnumerable<BookModel> libros = Mapper.Map<BookModel[]>(authorEntidadArturo.Books);
            //// El tipo de colecciones que soporta: IEnumrables, ICollection, IList, Array/

            //foreach (var elem in libros)
            //{
            //    Console.WriteLine($"{elem.Id} {elem.AuthorName}: Titulo:{elem.FullTitle}\n Num.Paginas:{elem.Pages}\n\n");
            //}
            //ATENCION: ResolveUsing = DEPRECATED


            //-------------------------------------EJEMPLO 3: Mapeo condicional por tipos de origen y destino
            //Address address = new Address()
            //{
            //    City = "Rota",
            //    Stae = "Cadiz",
            //    Country = "España"
            //};
            //var config = new MapperConfiguration(cfg => {
            //    cfg.AddConditionalObjectMapper().Where((s, d) => s.Name == "Address" && d.Name == "AddressDto");
            //    cfg.CreateMap<Address, AddressDTO>();
            //});
            //var mapper = config.CreateMapper();
            //AddressDTO dto = mapper.Map<Address, AddressDTO>(address);



            //-----------------------------------------------------------EJEMPLO 4: Conversiones por tipo y/o usando funciones
            //Mapper.Initialize(cfg => {
            //    cfg.CreateMap<string, int>().ConvertUsing(s => Convert.ToInt32(s));
            //    cfg.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());
            //    cfg.CreateMap<Source, Destination>(); 
            //}); 
            //Mapper.AssertConfigurationIsValid();

            //var source = new Source{ 
            //    Value1 = "5",
            //    Value2 = "01/01/2000",
            //};
            //Destination result = Mapper.Map<Source, Destination>(source); 



            //--------------------------------------------------EJEMPLO 5: Reverse Mapping and Unflattering
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.CreateMap<BookEntity, BookModel>()
            //    .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(entity => entity.Author.Name))
            //    .ReverseMap();
            //});

            //IEnumerable<BookModel> libros = Mapper.Map<BookModel[]>(authorEntidadArturo.Books);

            //var libroModelo = new BookModel();
            //libroModelo.Pages = 300;
            //libroModelo.Edition = 3;
            //libroModelo.AuthorName = authorEntidadArturo.Name;

            //var libroModelo_aEntidad = new BookEntity();

            //Mapper.Map(libroModelo, libroModelo_aEntidad);

            //Console.WriteLine($"{libroModelo_aEntidad.Id}");

            //------------------------------------------------------------------------------EJEMPLO 6: Nested types
            //buen ejemplo en https://dotnettutorials.net/lesson/automapper-with-nested-types/
            //Mapper.Initialize(cfg => 
            //{
            //    //cfg.CreateMap<Address, AddressDTO>();
            //    //.ForMember(dest => dest.EmpCity, act => act.MapFrom(src => src.City))
            //    //.ForMember(dest => dest.EmpStae, act => act.MapFrom(src => src.Stae));

            //    cfg.CreateMap<Employee, EmployeeDTO>();
            //        //.ForMember(dest => dest.Address, act => act.MapFrom(src => src.address));

            //});

            //Address empAddres = new Address()
            //{
            //    City = "Rota",
            //    Stae = "Cadiz",
            //    Country = "España"
            //};

            //Employee emp = new Employee();
            //emp.Name = "Jose";
            //emp.Salary = 20000;
            //emp.Department = "IT";
            //emp.address = empAddres;

            //var empDTO = Mapper.Map<Employee, EmployeeDTO>(emp);

            //Console.WriteLine("Nombre:" + empDTO.Name + ", Salario:" + empDTO.Salary +", Departmento:" + empDTO.Department);
            //Console.WriteLine("Ciudad:" + empDTO.Address.City + ", Provincia:" + empDTO.Address.Stae + ", Pais:" + empDTO.Address.Country);




            Console.ReadKey();

        }
    }
}
