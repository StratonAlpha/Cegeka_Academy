using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashCourse
{

    public class Set<T>
    {
        private List<T> Storage;
        private int size = 0;

        public Set()
        {
            Storage = new List<T>();
        }

        public T getStorageAt(int id)
        {
            return Storage[id];
        }

        public int getSize()
        {
            return size;
        }

        public void Insert (T item)
        {
            try
            {
                if (!Contains(item))
                {
                    Storage.Add(item);
                    size++;
                } else
                {
                    throw new DuplicateWaitObjectException("Error - Duplicate Input");
                }
            }
            catch (DuplicateWaitObjectException ex)
            {
                Console.WriteLine("Ai incercat sa adaugi un duplicat in lista");
                throw;
            }

        }

        public void Remove (T item)
        {
            bool removed = false;
            for(int i = 0; i < size; i++)
            {
                if(Storage[i].Equals(item))
                {
                    for(int j = i; j < size - 1; j++)
                    {
                        Storage[j] = Storage[j + 1];
                    }
                    size--;
                    removed = true;
                    break;
                }
            }
            if (removed)
            {
                Console.WriteLine("removed {0}", item);
            } 
            else
            {
                Console.WriteLine("{0} not found for removal", item);
            }

        }
        
        public bool Contains (T item)
        {
            bool found = false;
            for(int i = 0; i < size; i++)
            {
                if (Storage[i].Equals(item))
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public Set<T> Merge (Set<T> other)
        {
            Set<T> toReturn = new Set<T>();

            for(int i = 0; i < size; i++)
            {
                toReturn.Insert(Storage[i]);
            } 

            for(int i = 0; i< other.getSize(); i++)
            {
                toReturn.Insert(other.getStorageAt(i));
            }

            return toReturn;
        }

        public Set<T> Filter(Func<T, bool> item)
        {
            Set<T> subset = new Set<T>();
            for(int i = 0; i < size; i++)
            {
                if (item(Storage[i]))
                {
                    subset.Insert(Storage[i]);
                }
            }
            return subset;
        }

        public void printAll()
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"{Storage[i]}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Set<int> Test1 = new Set<int>();
            Set<int> Test2 = new Set<int>();
            Set<int> Test3 = new Set<int>();
            Set<int> Test4 = new Set<int>();

            Test1.Insert(0);
            Test1.Insert(1);
            Test1.Insert(2);
            Test1.Insert(3);
            Test1.Insert(4);
            Test1.Insert(5);

            Test2 = Test1.Filter(n => n % 2 == 0);
            Test2.printAll();

            Test3.Insert(1);
            Test3.Insert(3);

            if (Test1.Contains(1))
            {
                Console.WriteLine("T1.1 pass");
            }
            else
            {
                Console.WriteLine("T1.1 fail");
            }

            if (Test1.Contains(2))
            {
                Console.WriteLine("T1.2 pass");
            }
            else
            {
                Console.WriteLine("T1.2 fail");
            }
            Test4 = Test2.Merge(Test3);
            Test4.printAll();

            Test4.Remove(2);
            Test4.printAll();


            Console.WriteLine("\npress any key to exit the process...");
            // basic use of "Console.ReadKey()" method
            Console.ReadKey();
        }
    }

}
