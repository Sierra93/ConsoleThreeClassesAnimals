using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using AnimalsClassLibrary;

namespace ConsoleThreeCLassesAnimals {
    //    Построить три класса(базовый и 3 потомка), описывающих некоторых хищных животных(один из потомков), всеядных(второй потомок) и травоядных(третий потомок). Описать в базовом классе абстрактный метод для расчета количества и типа пищи, необходимого для пропитания животного в зоопарке.
    //a) Упорядочить всю последовательность животных по убыванию количества пищи.При совпадении значений – упорядочивать данные по алфавиту по имени. 
    //Вывести идентификатор животного, имя, тип и количество потребляемой пищи для всех элементов списка.
    //b) Вывести первые 5 имен животных из полученного в пункте а) списка.
    //c) Вывести последние 3 идентификатора животных из полученного в пункте а) списка.
    //d) Организовать запись и чтение коллекции в/из файл.
    //e) Организовать обработку некорректного формата входного файла.
    class Program {
        static void Main(string[] args) {
            // Инициализируем объекты значениями
            Cat cat = new Cat(
                1,
                10,
                "Мясо",
                "Кошка");

            Cat dog = new Cat(
                2,
                12,
                "Сосиска",
                "Собака");

            Human human = new Human(
                3,
                25,
                "Чебуреки",
                "Человек");

            Human coban = new Human(
                4,
                34,
                "Овощи",
                "Дикий кабан");

            Antilopa antilopa = new Antilopa(
                5,
                15,
                "Трава",
                "Антилопа");

            // С помощью up cast приводим объекты к общему типу
            Animal[] animals = new Animal[] {
                cat,
                dog,
                human,
                coban,
                antilopa
            };
            Console.WriteLine("Номера животных:");
            foreach (var elem in animals) {
                Console.WriteLine(elem.ID);
            }
            Console.WriteLine();

            Console.WriteLine("Кол-во пищи:");
            foreach (var elem in animals) {
                Console.WriteLine(elem.countFood);
            }
            // Сортируем по убыванию кол-ва пищи используя сортировку пузырьком
            Console.WriteLine("Кол-во пищи отсортированное по убыванию");
            for (int i = 0; i < animals.Length; i++) {
                for (int j = i + 1; j < animals.Length; j++) {
                    if (animals[i].countFood < animals[j].countFood) {
                        int tmp = animals[i].countFood;
                        animals[i].countFood = animals[j].countFood;
                        animals[j].countFood = tmp;
                    }
                }
                Console.WriteLine(animals[i].countFood);
            }
            Console.WriteLine();

            Console.WriteLine("Тип пищи:");
            foreach (var elem in animals) {
                Console.WriteLine(elem.typeFood);
            }
            Console.WriteLine();

            Console.WriteLine("Имена животных:");
            foreach (var elem in animals) {
                Console.WriteLine(elem.nameAnimal);
            }
            Console.WriteLine();

            // Берем 3 последние ID животных
            Console.WriteLine("Последние 3 ID животных");
            //for (int i = 0; i < animals.Length; i++) {
            //    var lastElemId = animals[i].ID;
            //    Console.WriteLine(lastElemId);              
            //}            
            List<object> objects = new List<object> {
                cat,
                dog,
                human,
                coban,
                antilopa
            };
            //IEnumerable obj = (from s in objects select s);
            // Работаем через перечислитель
            IEnumerable obj = objects.Skip(2);      // Пропускаем первые 2 элемента, чтобы взять оставшиеся 
            foreach (Animal lastElemId in obj) {
                Console.WriteLine(lastElemId.ID);
            }
            //Console.WriteLine(obj1);

            Console.WriteLine();
            // Записываем коллекцию в файл и читаем из нее  
            string readPath = @"C:\FFiles\write.txt";
            string writePath = @"C:\FFiles\write.txt";
            string text = "";
            try {
                using (StreamReader sr = new StreamReader(readPath, System.Text.Encoding.Default)) {
                    text = sr.ReadToEnd();
                    Console.WriteLine("Данные из файла\n" + text);
                }
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default)) {
                    sw.WriteLine(text);
                }

                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default)) {
                    for (int i = 0; i < animals.Length; i++) {
                        sw.WriteLine(animals[i].ID);
                        sw.WriteLine(animals[i].countFood);
                        sw.WriteLine(animals[i].nameAnimal);
                        sw.WriteLine(animals[i].typeFood);
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
