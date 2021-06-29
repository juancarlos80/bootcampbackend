using System;


namespace AnonymousTypes
{
    

    class Anonymous
    {

        public object getData()
        {
            return new { Name = "pepe", EmailID = "pepe@gmail.com" };
        }

        private static T Cast<T>(T typeHolder, Object x)
        {            
            return (T)x;
        }

        static void Main(string[] args)
        {

            Anonymous anony = new Anonymous();
            dynamic anonymousDynamicData = anony.getData();
            Console.WriteLine(string.Format("{0} {1}", anonymousDynamicData.Name, anonymousDynamicData.EmailID) );

            object anonymousData = anony.getData();

            var obj = new { Name = "", EmailID = "" };
            obj = Cast(obj, anonymousData);

            Console.WriteLine(string.Format("{0} {1}", obj.Name, obj.EmailID));
            
        }
        

    }
}
