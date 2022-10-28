using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Tracing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas
{
    class PriorityNode
    {
        public int dato;
        public int prioridad;
        public PriorityNode? siguiente;
    }
    class PriorityQueue
    {
        public PriorityNode? frente = new PriorityNode();
        private PriorityNode? fin = new PriorityNode();

        public PriorityQueue()
        {
            frente = null;
            fin = null;
        }
        public void EnqueuePriority(int dato, int prioridad)
        {
            PriorityQueue auxiliar = new PriorityQueue();
            PriorityNode valor;
            bool insertado = false;

            if (this.frente != null) {
                while (this.frente != null) {
                    valor = this.DequeuePriority();
                    if (!insertado && valor.prioridad >= prioridad) {
                        auxiliar.EnqueuePriorityData(dato, prioridad);
                        insertado = true;
                    }
                    auxiliar.EnqueuePriorityData(valor.dato, valor.prioridad);

                    if (this.frente == null && !insertado)
                        auxiliar.EnqueuePriorityData(dato, prioridad);
                }

                while (auxiliar.frente != null) {
                    valor = auxiliar.DequeuePriority();
                    this.EnqueuePriorityData(valor.dato, valor.prioridad);
                }
            } else
                this.EnqueuePriorityData(dato, prioridad);
        }

        public PriorityNode DequeuePriority()
        {
            PriorityNode? auxiliar = this.frente;

            if (this.frente == this.fin)
                this.fin = null;
            this.frente = this.frente.siguiente;

            return auxiliar;
        }
        private void EnqueuePriorityData(int valor, int prioridad)
        {
            PriorityNode nuevo = new PriorityNode();
            nuevo.dato = valor;
            nuevo.prioridad = prioridad;
            nuevo.siguiente = null;

            if (this.frente == null)
                this.frente = nuevo;
            else
                this.fin.siguiente = nuevo;

            this.fin = nuevo;
        }
        public void Mostrar()
        {
            PriorityNode? auxiliar = frente;
            if (frente != null) {
                while (auxiliar != null) {
                    Console.WriteLine($"Prioridad: {auxiliar.prioridad} Dato: {auxiliar.dato}");
                    auxiliar = auxiliar.siguiente;

                    if (auxiliar == null)
                        Console.WriteLine();
                }
            } else Console.WriteLine("Cola vacía");
        }
        public void Clear()
        {
            while (frente != null) {
                DequeuePriority();
            }
        }
    }
    class NodoInt
    {
        public int dato;
        public NodoInt? siguiente;

    }
    class ColaInt
    {
        private NodoInt? frente = new NodoInt();
        private NodoInt? fin = new NodoInt();

        public ColaInt()
        {
            frente = null;
            fin = null;
        }

        public void Enqueue(int num)
        {
            NodoInt nuevo = new NodoInt();
            nuevo.dato = num;
            nuevo.siguiente = null;

            if (frente != null)
                fin.siguiente = nuevo;
            else frente = nuevo;

            fin = nuevo;
        }
        public void Mostrar()
        {
            NodoInt? auxiliar = frente;
            if (frente != null) {
                while (auxiliar != null) {
                    Console.Write($"{auxiliar.dato} ");
                    auxiliar = auxiliar.siguiente;

                    if (auxiliar == null)
                        Console.WriteLine();
                }
            } else Console.WriteLine("Cola vacía");
        }
        public int Count()
        {
            ColaInt auxiliar = new ColaInt();
            int contador = 0;

            while (this.frente != null) {
                auxiliar.Enqueue(this.Dequeue());
                contador++;
            }

            while (auxiliar.frente != null) {
                this.Enqueue(auxiliar.Dequeue());
            }
            return contador;

        }
        public int Dequeue()
        {
            int dato = int.MinValue;

            if (frente != null) {
                dato = frente.dato;
                if (frente.siguiente == null)
                    fin = null;
                frente = frente.siguiente;
            }

            return dato;

        }
        public void Clear()
        {
            while (frente != null) {
                Dequeue();
            }
        }
        public static ColaInt UnirColas(ColaInt[] colas)
        {
            ColaInt colaFinal = new ColaInt();
            NodoInt? auxiliar;
            foreach (ColaInt cola in colas) {
                auxiliar = cola.frente;

                while (auxiliar != null) {
                    colaFinal.Enqueue(auxiliar.dato);
                    auxiliar = auxiliar.siguiente;
                }
            }
            return colaFinal;
        }
        public static ColaInt[] SepararEnColas(ColaInt cola)
        {
            int valor;
            NodoInt aux = cola.frente;
            ColaInt infantes = new ColaInt();
            ColaInt ninios = new ColaInt();
            ColaInt adolescentes = new ColaInt();
            ColaInt jovenes = new ColaInt();
            ColaInt adultos = new ColaInt();
            ColaInt adultosMayores = new ColaInt();

            while (aux != null) {
                valor = aux.dato;

                if (valor >= 0 && valor <= 6)
                    infantes.Enqueue(valor);
                else if (valor >= 7 && valor <= 14)
                    ninios.Enqueue(valor);
                else if (valor >= 15 && valor <= 18)
                    adolescentes.Enqueue(valor);
                else if (valor >= 19 && valor <= 35)
                    jovenes.Enqueue(valor);
                else if (valor >= 36 && valor <= 50)
                    adultos.Enqueue(valor);
                else
                    adultosMayores.Enqueue(valor);
            }
            ColaInt[] colas = new ColaInt[] { infantes, ninios, adolescentes, jovenes, adultos, adultosMayores };
            return colas;
        }
        public void EliminarValor(int dato)
        {
            int valor;
            ColaInt auxiliar = new ColaInt();

            while (this.frente != null) {
                valor = this.Dequeue();
                if (valor != dato)
                    auxiliar.Enqueue(valor);
            }

            while (auxiliar.frente != null) {
                this.Enqueue(auxiliar.Dequeue());
            }
        }
        public static int InvertirEntero(string numero)
        {
            char[] elementos = numero.ToCharArray();
            int tamaño = elementos.Length;
            ColaInt cola = new ColaInt();

            for (int i = tamaño - 1; i >= 0; i--) {
                cola.Enqueue(int.Parse(elementos[i].ToString()));
            }

            numero = "";
            for (int i = 0; i < tamaño; i++) {
                numero += cola.Dequeue().ToString();
            }

            return Convert.ToInt32(numero);
        }
    }
}
