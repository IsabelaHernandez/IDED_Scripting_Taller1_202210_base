using System.Collections.Generic;

namespace TestProject1
{
    internal class TestMethods
    {
        internal enum EValueType
        {
            Two,
            Three,
            Five,
            Seven,
            Prime
        }

        //-----1-----

        internal static Stack<int> GetNextGreaterValue(Stack<int> sourceStack)
        {
            //Stack<int> result = null;

            int[] arreglo_SourceStack = sourceStack.ToArray();
            Stack<int> copia_Stack;
            copia_Stack = new Stack<int>();

            for (int i = arreglo_SourceStack.Length - 1; i >= 0; i--) 
            {
                copia_Stack.Push(arreglo_SourceStack[i]);                
            }
       
            List<int> salidas;     
            List<int> pila_Final;
            Stack<int> result;

            salidas = new List<int>();         
            pila_Final = new List<int>(); //Al revés
            result = new Stack<int>();

            for (int i= copia_Stack.Count -1; i >= 0; i--)
            {
                int elemento = copia_Stack.Pop(); //Guardar primer elemento 
                salidas.Add(elemento); 

                int elemento_Mayor = elemento;

                for (int j = 0; j < salidas.Count; j++)
                
                {
                    if (salidas[j] > elemento_Mayor) elemento_Mayor = salidas[j];
                }

                if (elemento_Mayor == elemento)
                {
                    pila_Final.Add(-1);
                }

                else
                {
                    pila_Final.Add(elemento_Mayor);
                }
            }
            

            for (int i = pila_Final.Count - 1; i >= 0; i--)
            {
                result.Push(pila_Final[i]);
            }
                return result;
        }


        //-----2-----
        internal static Dictionary<int, EValueType> FillDictionaryFromSource(int[] sourceArr)
        {
            // Dictionary<int, EValueType> result = null;
            
            Dictionary<int, EValueType> result = new Dictionary<int, EValueType>();

            int[] copia;
            copia = new int[sourceArr.Length];
            sourceArr.CopyTo(copia, 0);

            for (int i= 0; i < copia.Length; i++)
            {
                if (copia[i] % 2 == 0) 
                {
                    result.Add(copia[i], EValueType.Two);
                }

                else if (copia[i] % 3 == 0)
                {
                    result.Add(copia[i], EValueType.Three);
                }

                else if (copia[i] % 5 == 0)
                {
                    result.Add(copia[i], EValueType.Five);
                }

                else if (copia[i] % 7 == 0)
                {
                    result.Add(copia[i], EValueType.Seven);
                }

                else
                {
                    result.Add(copia[i], EValueType.Prime);
                }
            }
          

            return result;
        }

        internal static int CountDictionaryRegistriesWithValueType(Dictionary<int, EValueType> sourceDict, EValueType type)
        {
            
            return 0;
        }

        internal static Dictionary<int, EValueType> SortDictionaryRegistries(Dictionary<int, EValueType> sourceDict)
        {
            Dictionary<int, EValueType> result = null;

            return result;
        }

        //-----3-----
        internal static Queue<Ticket>[] ClassifyTickets(List<Ticket> sourceList)
        {
            Queue<Ticket>[] result = null;

            return result;
        }

        internal static bool AddNewTicket(Queue<Ticket> targetQueue, Ticket ticket)
        {
            bool result = false;

            return result;
        }
    }
}