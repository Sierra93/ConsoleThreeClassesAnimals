using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsClassLibrary {
    public abstract class Animal {
        public int ID { get; set; }
        public int countFood { get; set; }
        public string typeFood { get; set; }
        public string nameAnimal { get; set; }
        public abstract void InfoFood();    // Расчет кол-ва и типа пищи
    }
}
