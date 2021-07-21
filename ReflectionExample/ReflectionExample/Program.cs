using System;
using System.Linq;
using System.Reflection;

namespace ReflectionExample
{
    class Program
    {
        private static int a = 1, b = 2, c = 5;

        public static void Resultado()
        {
            Console.WriteLine("Operacion a realizar:  a+b+c Ejecutando: {0}+{1}+{2}={3}", a, b, c, (a + b + c));
        }

        static void Main(string[] args)
        {            

            Resultado();
            Console.WriteLine("Ingrese el nombre de variable a modificar");

            string varName = Console.ReadLine();
            Type t = typeof(Program);
            FieldInfo fieldInfo = t.GetField(varName, BindingFlags.NonPublic | BindingFlags.Static);

            if (fieldInfo != null)
            {
                Console.WriteLine("El valor actual de la variable: " + fieldInfo.Name + " es: " + fieldInfo.GetValue(t) + ". Ingresa el nuevo valor:");
                string newValue = Console.ReadLine();
                int newInt;
                if (int.TryParse(newValue, out newInt))
                {
                    fieldInfo.SetValue(t, newInt);
                    Resultado();
                }
                else
                {
                    Console.WriteLine("El nuevo valor no es un entero válido");
                }                
            }
            else 
            {
                Console.WriteLine("No se encontro la variable a modificar");
            }
            Console.ReadKey();
            ReadDll();
            Console.ReadKey();
        }

        public static void ReadDll()
        {
            var assemblyCollections = Assembly.LoadFrom("Collections.dll");
            Console.WriteLine("Listando tipos dentro del ensamblado");
            foreach (Type type in assemblyCollections.GetTypes())
            {                
                Console.WriteLine("Type: {0}", type.FullName);
                if (type.FullName.Contains("Student"))
                {
                    Console.WriteLine("\tUtilizando un tipo en especifico");
                    var p = assemblyCollections.CreateInstance(type.FullName, true);
                    FieldInfo[] campos = type.GetFields();
                    MethodInfo[] metodos = type.GetMethods();

                    Console.WriteLine("\tLectura de campos definidos en: {0}", type.Name );
                    for (int i = 0; i < campos.Length; i++) {
                        Console.WriteLine("\t\tField - Nombre: {0}, tipo: {1}", campos[i].Name, campos[i].FieldType.Name );
                        if (campos[i].FieldType.Name == "Int32")
                        {
                            campos[i].SetValue(p, 10);
                        }
                        if (campos[i].FieldType.Name == "String")
                        {
                            campos[i].SetValue(p, "Pedro");
                        }
                    }

                    Console.WriteLine("\tLectura de metodos definidos en: {0}", type.Name);
                    for (int i = 0; i < metodos.Length; i++)
                    {
                        Console.WriteLine("\t\tMetodo - Nombre {0}, Parametros {1}, Retorno {2}",
                            metodos[i].Name,
                            string.Join(",", ((from o in (metodos[i].GetParameters())
                                               select o.ToString()).ToArray())),                           
                            metodos[i].ReturnType.Name
                            );
                     
                        if (metodos[i].ReturnType.Name == "String")
                        {
                            Console.WriteLine("\t\tInvocando el método {0}  = {1}", metodos[i].Name, metodos[i].Invoke(p,null));
                        }
                        
                    }                    
                }
            }
        }
        
    }
   
}
