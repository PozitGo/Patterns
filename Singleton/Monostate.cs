using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    //В таком случае получается что все созданные объекты будут ссылаться на одни и те же значения, они будут общие у всех созданных объектов этого класса, ссылаясь на 1 место в памяти
    //Делается в том случае если раньше класс не использовался как Singleton, но в этом появилась надобность. Не рекомендуется ибо он нарушает принципы и путает разработчиков
    public class CheifExecutiveOfficer
    {
        //public string? Name;
        //public int Age;

        private static string? name;
        private static int age;

        public string? Name { get => name; set => name = value; } 
        public int Age { get => age; set => age = value; }
    }
}
