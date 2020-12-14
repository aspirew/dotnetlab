using System;
using System.Collections;
using System.Collections.Generic;

namespace lab7
{
    class Program
    {
        public class ListOfArrayList<T> : IEnumerable<T>, IList<T> where T: struct{
            List<T[]> listOfArrays;
            public int BufferSize { get; }

            public ListOfArrayList(int size)
            {
                listOfArrays = new List<T[]>();
                BufferSize = size;
                AddBuffer();
            }
            public int Count { get; private set; } = 0;
            public bool IsReadOnly => false;

            public T this[int index] {
                get
                {
                    if (index >= 0 && index < Count)
                    {
                        var coor = getCoordinatesOfPos(index);
                        return listOfArrays[coor.Item1][coor.Item2];
                    }
                    else throw new ArgumentOutOfRangeException();
                }
                set
                {
                    if (index >= 0 && index < Count)
                    {
                        var coor = getCoordinatesOfPos(index);
                        listOfArrays[coor.Item1][coor.Item2] = value;
                    }
                    else throw new ArgumentOutOfRangeException();
                }
            }

            private void AddBuffer()
            {
                listOfArrays.Add(new T[BufferSize]);
            }

            public void Add(T item)
            {

                    var coor = getCoordinatesOfPos(Count);
                    if (coor.Item1 >= listOfArrays.Count)
                        AddBuffer();
                    listOfArrays[coor.Item1][coor.Item2] = item;
                    Count++;
            }

            public bool Remove(T item)
            {
                    for(int i = 0; i < Count; i++)
                    {
                        var coor = getCoordinatesOfPos(i);
                        T elem = listOfArrays[coor.Item1][coor.Item2];
                        if (EqualityComparer<T>.Default.Equals(item, elem))
                        {
                            shiftList(i);
                            return true;
                        }
                    }
                return false;
            }

            public void RemoveAt(int index)
            {
                if(index >= 0 && index < Count)
                {
                    shiftList(index);
                }
            }

            public bool Contains(T item)
            {
                for (int i = 0; i < Count; i++)
                {
                    var coor = getCoordinatesOfPos(i);
                    T elem = listOfArrays[coor.Item1][coor.Item2];
                    if (EqualityComparer<T>.Default.Equals(item, elem))
                    {
                        return true;
                    }
                }
                return false;
            }

            public int IndexOf(T item)
            {
                for (int i = 0; i < Count; i++)
                {
                    var coor = getCoordinatesOfPos(i);
                    T elem = listOfArrays[coor.Item1][coor.Item2];
                    if (EqualityComparer<T>.Default.Equals(item, elem))
                    {
                        return i;
                    }
                }
            return -1;
            }

            public void Trim()
            {
                for (int i = listOfArrays.Count; i > Count / BufferSize + 1; i--)
                {
                    listOfArrays.RemoveAt(i - 1);
                }
            }

            private void shiftList(int pos)
            {

                for(int i = pos; i < Count - 1; i++)
                {
                    var coor = getCoordinatesOfPos(i);
                    var coor2 = getCoordinatesOfPos(i + 1);
                    listOfArrays[coor.Item1][coor.Item2] = listOfArrays[coor2.Item1][coor2.Item2];
                }

                Count--;

            }

            private (int, int) getCoordinatesOfPos(int pos)
            {
                return (pos / BufferSize, pos % BufferSize);
            }

            public void Clear()
            {
                listOfArrays = new List<T[]>();
                AddBuffer();
            }

            public override string ToString()
            {
                string res = "";
                for (int i = 0; i < Count; i++)
                {
                    var index = getCoordinatesOfPos(i);
                    if (index.Item2 == 0) res += "\n";
                    res += listOfArrays[index.Item1][index.Item2] + " ";
                }
                return res;
            }

            private List<T> flattenList()
            {
                List<T> flatList = new List<T>();
                for(int i = 0; i < Count; i++)
                {
                    var coor = getCoordinatesOfPos(i);
                    flatList.Add(listOfArrays[coor.Item1][coor.Item2]);
                }

                return flatList;
            }

            public void Insert(int index, T item)
            {
                throw new NotImplementedException();
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            public IEnumerator<T> GetEnumerator()
            {
                return flattenList().GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }

            public static ListOfArrayList<T> operator+ (ListOfArrayList<T> a, IEnumerable<T> collection)
            {
                ListOfArrayList<T> newList = (ListOfArrayList<T>)a.MemberwiseClone();

                foreach (T elem in collection)
                {
                    newList.Add(elem);
                }

                return newList;
            }

        }

        static void Main(string[] args)
        {
            ListOfArrayList<int> lista = new ListOfArrayList<int>(4);
            lista.Add(5);
            lista.Add(7);
            lista.Add(2);
            lista.Add(-5);
            lista.Add(8);
            lista.Add(5);
            lista.Add(9);
            lista.Add(-3);
            lista.Add(0);
            lista.Remove(7);
            lista.Add(7);
            lista.RemoveAt(4);
            lista.Add(2);

            Console.WriteLine(lista.ToString());

            foreach (int elem in lista)
            {
                Console.WriteLine(elem);
            }


            List<int> lista2 = new List<int>();
            lista2.Add(54);
            lista2.Add(99);
            lista2.Add(12);
            lista2.Add(443);

            ListOfArrayList<int> lista3 = lista + lista2;

            Console.WriteLine(lista3.ToString());

        }
    }
}
