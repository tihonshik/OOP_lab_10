using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP_lab_10
{
    class Program
    {

        private static void Deal(object a, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                {
                    Student newStudent = e.NewItems[0] as Student;
                    Console.WriteLine("Add object: " + newStudent.Name + ".");
                    break;
                }
                case NotifyCollectionChangedAction.Remove:
                {
                    Student oldStudent = e.OldItems[0] as Student;
                    Console.WriteLine("Del object: " + oldStudent.Name + ".");
                    break;
                }
            }
        }


        static void Main(string[] args)
        {
            //1-z    ArrayList 
            ArrayList arrayList = new ArrayList();
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                arrayList.Add(random.Next(100));
            }
            arrayList.Add("string");
            arrayList.Add(new Student("Vasya"));
            int pointer = 3;
            arrayList.RemoveAt(pointer);
           

            Console.WriteLine("Size: " + arrayList.Count);

            foreach (var item in arrayList)
            {
                Console.WriteLine(item + " ");
            }
            Console.WriteLine(arrayList.Contains("string"));





            //2z     
            SortedList<int, char> sortedList = new SortedList<int, char>();
            int size = 5;
            for (int i = 0; i < size; i++)
            {
                sortedList.Add(i, Convert.ToChar(random.Next(1, 255)));
            }
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(sortedList.ElementAt(i));
            }
      
            int n = 2;

            for (int i = 0; i < n; i++)
            {
                sortedList.RemoveAt(1);
            }

            List<char> list = new List<char>();
            list.AddRange(sortedList.Values);
            foreach (char item in list)
            {
                Console.Write(item + " ");
            }
            list.Add('f');

            Console.WriteLine();

            Console.WriteLine(list.Contains('f'));



            //3z
            Vehicle Train_1 = new Train(50, 120, "super-train");
            Vehicle Train_2 = new Express(115, 260, "super-super-train");
            Vehicle Car_1 = new Car(6, 205, "super-car");
            Printer print = new Printer();

            SortedList<int, Vehicle> sortVeh = new SortedList<int, Vehicle>();
            int count = 0;
            sortVeh.Add(count++, Train_1);
            sortVeh.Add(count++, Train_2);
            sortVeh.Add(count++, Car_1);

            Console.WriteLine("\n\nРабота с пользовательским типом данных в качестве типа коллекций");
            foreach (Vehicle z in sortVeh.Values)
                Console.Write($"\n{z.name} {z.speed}");

            List<Vehicle> listVeh = new List<Vehicle>();
            listVeh.AddRange(sortVeh.Values);
            foreach (char item in list)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();




            //4z  ObservableCollection<T>
            ObservableCollection<Student> studentss = new ObservableCollection<Student>();
            studentss.CollectionChanged += Deal;
            for (int i = 0; i < 4; i++)
            {
                studentss.Add(new Student(Convert.ToString(random.Next(0, 255))));
            }
            studentss.Remove(new Student(Convert.ToString(random.Next(0, 255))));



        }



    }
}
