using System;

namespace Projeto4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 , 7, 5, 7};

            Console.WriteLine("Metodo recursivo: " + Search(arr, 7));

            Console.WriteLine("Metodo iterativo: " + SearchIterativa(arr, 7));


            Console.ReadKey();
        }

        static int index = 0;

        static int cont = 0;

        public static int Search(int[] arr, int element)
        {            
            if (index == arr.Length)
            {
                return cont;
            }
            else
            {
                if (arr[index] == element)
                {
                    cont++;
                }
                index++;
                return Search(arr, element);
            }
        }

        public static int SearchIterativa(int[] arr, int element)
        {
            var resul = 0;
            foreach(int x in arr)
            {
                if (x == element)
                    resul++;
            }
            return resul;
        }

    }
}
