using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadixMethod
{
    class Example
    {

        private int[] arreglo1 = { 3, 6, 9, 5, 1, 4, 7, 2, 1, 3 };//Creamos los arreglos desordenados a ordenar 
        private int[] arreglo2 = { 8, 3, 9, 3, 11, 7, 1, 27, 12 };
        private int[] arreglo3 = { 10, 40, 36, 5, 24, 2, 5, 8 };
        private int[] arreglo4 = { 55, 42, 0, 3, 0, 1, 2, 4, 7 };
        private int[] arreglo5 = { 25, 108, 1024, 12, 351, 251, 39 };
        private List<int> k = new List<int>();//
        private IList<IList<int>> digitos = new List<IList<int>>();//Creamos una lista de listas donde guardaremos los arreglos
        private int maxLength = 0;


        public void InsertarValores()//Mandamos los valores a test mehtod
        {
            Prueba(arreglo1, 1);
            Prueba(arreglo2, 2);
            Prueba(arreglo3, 3);
            Prueba(arreglo4, 4);
            Prueba(arreglo5, 5);
        }
       
        public void Prueba(int[] array, int num)//Los recibe en sus PARAMETERS
        {
            for (int i = 0; i < 10; i++)//Un ciclo para agregarle listas a la lista digios
            {
                digitos.Add(new List<int>());
            }
            for (int i = 0; i < array.Length; i++)
            {

                if (maxLength < array[i].ToString().Length)//Una condicion iterativa a traves de los valores del arreglo
                    maxLength = array[i].ToString().Length;
            }
            RadixSort(array, num);
        }

        public void RadixSort(int[] array, int num)
        {
            for (int i = 0; i < maxLength; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    int digit = (int)((array[j] % Math.Pow(10, i + 1)) / Math.Pow(10, i));//A technique  para conseguir los digito y le arregamos los valores del arreglo actual

                    digitos[digit].Add(array[j]);//El digito sera la posicion de la lista de digitos, donde iremos agregando os valores del arreglo mientras itera
                }

                int index = 0;
                for (int k = 0; k < digitos.Count; k++)
                {
                    IList<int> selDigit = digitos[k];

                    for (int l = 0; l < selDigit.Count; l++)
                    {
                        array[index++] = selDigit[l];
                    }
                }
                ClearDigits();
            }
            printSortedData(array, num);
        }
        private void ClearDigits()
        {
            for (int k = 0; k < digitos.Count; k++)
            {
                digitos[k].Clear();
            }
        }


        public void printSortedData(int[] ordenado, int num)
        {
            Console.WriteLine("Arreglo ordenado {0}: ",num);
            for (int i = 0; i < ordenado.Length; i++)
            {
                Console.WriteLine(ordenado[i]);
            }
        }
        static void Main(string[] args)
        {
            Example radix = new Example();
            radix.InsertarValores();
            Console.ReadLine();
        }
    }
}