using System;


namespace ЛР__12
{
    class Program
    {
        static void Main(string[] args)
        {
            var Book = Reflector.Create<Book>(null);
            Reflector.AssemblyName(Book);
            Reflector.FieldsAndPropertiesInfo(Book);
            Reflector.Interfaces(Book);
            Reflector.MethodsByParameterType(Book, typeof(int));
            Reflector.PublicContructors(Book);
            Reflector.PublicMethods(Book);

            var Airline = Reflector.Create<Airline>(null);
            Reflector.AssemblyName(Airline);
            Reflector.FieldsAndPropertiesInfo(Airline);
            Reflector.Interfaces(Airline);
            Reflector.MethodsByParameterType(Airline, typeof(int));
            Reflector.PublicContructors(Airline);
            Reflector.PublicMethods(Airline);
            Reflector.Invoke(Airline, "print", null);
            
        }
    }
}
