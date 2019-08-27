using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalsClassLibrary {    
    public class Antilopa : Animal {
        public Antilopa(int id, int count, string type, string name) { 
            ID = id;
            countFood = count;
            typeFood = type;
            nameAnimal = name;
        }
        public override void InfoFood() {
            Console.WriteLine($"Кол-во пищи: {countFood}\n" + $"Тип пищи {typeFood}");
        }
    }
}
