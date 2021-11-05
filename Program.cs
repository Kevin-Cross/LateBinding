using System;
using System.Globalization;
using System.Reflection;
using System.IO;
using System.Data;
using System.Drawing;
using System.Xml;


namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ReflectionTest();
            PersonTest();
            MathStuffTest();
            CustomAttributeTest();
            
        }
        static void ReflectionTest()
        {
            Console.WriteLine();
            Console.WriteLine("{0} ReflectionTest {0}", new string('=', 20));
            Console.WriteLine();

            Assembly asm = Assembly.LoadFrom("SharedLib");
            PrintModules(asm);
        }
       
        
       
        static void PersonTest()
        {
            Console.WriteLine();
            Console.WriteLine("{0} PersonTest {0}", new string('=', 20));
            Console.WriteLine();

            Assembly asm = Assembly.LoadFrom("SharedLib");
            dynamic p1 = asm.CreateInstance("SharedLib.Person");
            p1.LastName = "Smith";
            p1.FirstName = "Mike";
            p1.DOB = new DateTime(1980, 1, 1);
            Type enumType = asm.GetType("SharedLib.Person+Genders");
            p1.Gender = (dynamic)Enum.Parse(enumType, "Other");
            Console.WriteLine("{0,-15} {1,-15} {2,5} {3,5}", p1.LastName, p1.FirstName, p1.DOB, p1.Gender);

            dynamic p2 = asm.CreateInstance("SharedLib.Person", true, BindingFlags.Public | BindingFlags.CreateInstance | BindingFlags.Instance, null, new object[] {"Smith", "Jane", DateTime.Parse("1/1/2000"), (dynamic)Enum.Parse(enumType, "NotSupplied") }, null, null);
            Console.WriteLine("{0,-15} {1,-15} {2,5} {3,5}", p2.LastName, p2.FirstName, p2.DOB, p2.Gender);
        }
        static void MathStuffTest()
        {
            Console.WriteLine();
            Console.WriteLine("{0} MathStuffTest {0}", new string('=', 20));
            Console.WriteLine();

            Assembly asm = Assembly.LoadFrom("SharedLib");
            Type mathType = asm.GetType("SharedLib.MathStuff");
            var areaMethod = mathType.GetMethod("CircleArea", BindingFlags.Public | BindingFlags.Static);
            double area = (double)areaMethod.Invoke(null, new object[] { 12.34 });
            Console.WriteLine("The area of the circle is {0} square units.",area);
        }
        static void CustomAttributeTest()
        {
            Console.WriteLine();
            Console.WriteLine("{0} CustomAttributeTest {0}", new string('=', 20));
            Console.WriteLine();
            Assembly asm = Assembly.LoadFrom("SharedLib");
            Type mathType = asm.GetType("SharedLib.MathStuff");
            Type personType = asm.GetType("SharedLib.Person");
            Type pointType = asm.GetType("SharedLib.Point");
            Type utilitiesType = asm.GetType("SharedLib.Utilities");
            Type specialType = asm.GetType("SharedLib.SpecialClassAttribute");
            var attrs = mathType.GetCustomAttributes(specialType);
            foreach (dynamic attr in attrs)
            {
                Console.WriteLine($"{mathType.Name} has the special class ID of {attr.ID}");
            }
            attrs = personType.GetCustomAttributes(specialType);
            foreach (dynamic attr in attrs)
            {
                Console.WriteLine($"{personType.Name} has the special class ID of {attr.ID}");
            }
            attrs = utilitiesType.GetCustomAttributes(specialType);
            foreach (dynamic attr in attrs)
            {
                Console.WriteLine($"{utilitiesType.Name} has the special class ID of {attr.ID}");
            }
            attrs = pointType.GetCustomAttributes(specialType);
            foreach (dynamic attr in attrs)
            {
                Console.WriteLine($"{pointType.Name} has the special class ID of {attr.ID}");
            }
        }

        static void PrintModules(Assembly a)
        {
            foreach (Module m in a.GetModules())
            {
                Console.WriteLine(" Module: {0}", m);
                PrintTypes(m);
            }
        }
        static void PrintTypes(Module a)
        {
            foreach (Type t in a.GetTypes())
            {
                Console.WriteLine("  Type: {0}", t);
                PrintConstuctors(t);
                PrintEventInfo(t);
                PrintPropertyInfo(t);
                PrintMethodInfo(t);
            }
        }
        static void PrintConstuctors(Type a)
        {
            foreach (ConstructorInfo ci in a.GetConstructors())
            {
                Console.WriteLine("   Ctor: {0}", ci.Name);
                PrintParameter(ci);
                
            }
        }
        static void PrintParameter(ConstructorInfo a)
        {
            foreach(ParameterInfo pi in a.GetParameters())
            {
                Console.WriteLine("    Params: {0} {1}", pi.ParameterType, pi.Name);
            }
        }
        static void PrintFieldInfo(Type a)
        {
            foreach (EventInfo ei in a.GetEvents())
            {
                Console.WriteLine("    Event: {0} {1}", ei.EventHandlerType, ei.Name);
            }
        }
        static void PrintEventInfo(Type a)
        {
            foreach (FieldInfo fi in a.GetFields())
            {
                Console.WriteLine("    Field: {0} {1}", fi.FieldType, fi.Name);
            }
        }
        static void PrintPropertyInfo(Type a)
        {
            foreach (PropertyInfo pi in a.GetProperties())
            {
                Console.WriteLine("    Property: {0} {1}", pi.PropertyType, pi.Name);
            }
        }
        static void PrintMethodInfo(Type a)
        {
            foreach (MethodInfo mi in a.GetMethods())
            {
                Console.WriteLine("    Method: {0}", mi.Name);
                PrintParameterInfo(mi);
            }
        }
        static void PrintParameterInfo(MethodInfo a)
        {
            foreach (ParameterInfo pi in a.GetParameters())
            {
                Console.WriteLine("     Params: {0} {1}", pi.ParameterType, pi.Name);
            }
        }
    }
}

