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

            //Copia Stack
            int[] arreglo_SourceStack = sourceStack.ToArray(); 
            Stack<int> copia_Stack;
            copia_Stack = new Stack<int>();
            
            //Recorrer datos
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


            for (int i= copia_Stack.Count -1; i >= 0; i--) //Resultados
            {
                int elemento = copia_Stack.Pop(); //Guardar primer elemento 
                salidas.Add(elemento); 

                int elemento_Mayor = elemento;

                for (int j = 0; j < salidas.Count; j++) //Buscar si hay un numero mayor
                
                {
                    if (salidas[j] > elemento_Mayor) elemento_Mayor = salidas[j]; 
                }

                if (elemento_Mayor == elemento) 
                {
                    pila_Final.Add(-1); // -1 en el resultado
                }

                else
                {
                    pila_Final.Add(elemento_Mayor); // Este numero al resultado
                }
            }
            

            //Guardar en orden
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
            
            //Crear copia
            Dictionary<int, EValueType> result = new Dictionary<int, EValueType>();

            int[] copia;
            copia = new int[sourceArr.Length];
            sourceArr.CopyTo(copia, 0);

            for (int i= 0; i < copia.Length; i++) //Pruebas
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

            int result = 0; //Contador

           //Copia
            int[] llaves;
            llaves = new int[sourceDict.Count];
            sourceDict.Keys.CopyTo(llaves, 0);

            for (int i = 0; i < llaves.Length; i++) //Recorrer dict
            {
                if (sourceDict[llaves[i]] == type)
                {
                    result++; 
                }
            }
 
            return result;
        }

        internal static Dictionary<int, EValueType> SortDictionaryRegistries(Dictionary<int, EValueType> sourceDict)
        {
            //Dictionary<int, EValueType> result = null;

            Dictionary<int, EValueType> result = new Dictionary<int, EValueType>();

            //Arreglos
            int[] llaves;
            llaves = new int[sourceDict.Count];
            sourceDict.Keys.CopyTo(llaves, 0);

            EValueType[] valores;
            valores = new EValueType[sourceDict.Count];
            sourceDict.Values.CopyTo(valores, 0);

            for(int i = 0; i < llaves.Length; i++) // Ordenar valores
            {
                for (int j = 0; j < llaves.Length -1; j++)
                {
                    int llave_sgte;
                    EValueType valor_sgte; 

                    llave_sgte= llaves[j + 1];
                    valor_sgte=  valores[j + 1];

                    if (llaves[j] < llave_sgte)
                    {
                        llaves[j + 1] = llaves[j];
                        llaves[j] = llave_sgte;
                        valores[j + 1] = valores[j];
                        valores[j] = valor_sgte;
                        
                    }
                }
            }

            for (int i = 0; i < llaves.Length; i++) // Agregar resultados
            {
                result.Add(llaves[i], valores[i]);
            }

            return result;
        }

        //-----3-----
        internal static Queue<Ticket>[] ClassifyTickets(List<Ticket> sourceList)
        {
            //Queue<Ticket>[] result = null;

            //Copia
            Queue<Ticket>[] result = new Queue<Ticket>[3];

            Ticket[] copia;
            copia = new Ticket[sourceList.Count];
            sourceList.CopyTo(copia, 0);

            Queue<Ticket> fila_Pago;
            Queue<Ticket> fila_Subscripcion;
            Queue<Ticket> fila_Cancelacion; 

            fila_Pago = new Queue<Ticket>(); 
            fila_Subscripcion = new Queue<Ticket>();
            fila_Cancelacion = new Queue<Ticket>();

            for (int i = 0; i < copia.Length; i++) // Ordenar valores
            {
                for(int j = 0; j <copia.Length - 1; j++)
                {
                    int turno_sgte; 
                    Ticket ticket_sgte;

                    turno_sgte = copia[j + 1].Turn;
                    ticket_sgte = copia[j + 1];

                    if (copia[j].Turn > turno_sgte)
                    {
                        copia[j + 1] = copia[j];
                        copia[j] = ticket_sgte;
                    }
                }
                
            }

            for (int i= 0; i < copia.Length; i++) // Asignar turnos de fila
            {
                if (copia[i].RequestType == Ticket.ERequestType.Payment) fila_Pago.Enqueue(copia[i]);
                if (copia[i].RequestType == Ticket.ERequestType.Subscription) fila_Subscripcion.Enqueue(copia[i]);
                if (copia[i].RequestType == Ticket.ERequestType.Cancellation) fila_Cancelacion.Enqueue(copia[i]);
            }

            //Guardar
            result[0] = fila_Pago;
            result[1] = fila_Subscripcion;
            result[2] = fila_Cancelacion;

            return result;
        }

        internal static bool AddNewTicket(Queue<Ticket> targetQueue, Ticket ticket)
        {
            bool result = false;

            //Encontrar el RequestType
            Ticket.ERequestType tipo_fila;
            tipo_fila = targetQueue.Peek().RequestType;

            // Revisar que se cumplan las condiciones
            if (ticket.RequestType == tipo_fila && ticket.Turn > 0 && ticket.Turn < 100)
            {
                result = true; // Si se cumplen 
            }

            return result;
        }
    }
}