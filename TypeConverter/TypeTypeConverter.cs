using System;
using System.Reflection;
using AutoMapper;

namespace automapper
{
    public class TypeTypeConverter : ITypeConverter<string, Type> { 
        public Type Convert(string source, Type destination, ResolutionContext context) { 
            return Assembly.GetExecutingAssembly().GetType(source); 
        } 
    }
}
