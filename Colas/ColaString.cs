using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas {
    class NodoString {
        public string cadena;
        public int talla;
        public NodoString? siguiente;
    }
    class Pila {
        public NodoString? inicio  = new NodoString();
        
        public Pila() {
            inicio = null;
        }
        public void Push(string dato) {
            NodoString nuevo = new NodoString();
            nuevo.cadena = dato;
            nuevo.siguiente = inicio;
            inicio = nuevo;
        }
        public void Mostrar() {
            NodoString? auxiliar = inicio;
            if (inicio == null)
                Console.WriteLine("Pila vacía");
            while (auxiliar != null) {
                Console.Write($"{auxiliar.cadena} ->");
                auxiliar = auxiliar.siguiente;
                if (auxiliar == null)
                    Console.WriteLine("null");
            }
        }
        public string Pop() {
            string dato = "";
            if (inicio != null) {
                dato = inicio.cadena;
                inicio = inicio.siguiente;
            }
            return dato;
        }
        public void Clear() {
            while (inicio != null)
                Pop();
        }
        public string Top() {
            return inicio != null ? inicio.cadena : "";
        }
        //EJERCICIO N°01
    }
    class ColaString {
        private NodoString? frente = new();
        private NodoString? fin = new();

        public ColaString() {
            frente = null;
            fin = null;
        }
        public void Enqueue(string nombre, int talla) {
            NodoString nuevo = new() {
                cadena = nombre,
                talla = talla,
                siguiente = null
            };

            if (frente != null)
                fin.siguiente = nuevo;
            else frente = nuevo;
            fin = nuevo;
        }
        public void Mostrar() {
            NodoString? auxiliar = frente;
            if (frente != null) {
                while (auxiliar != null) {
                    Console.WriteLine($"{auxiliar.cadena}, {auxiliar.talla} ");
                    auxiliar = auxiliar.siguiente;
                }
            }
            else Console.WriteLine("Cola vacía");
        }
        public string Dequeue() {
            string nombre = string.Empty;
            if (frente != null) {
                nombre = frente.cadena;
                if (frente.siguiente == null)
                    fin = null;
                frente = frente.siguiente;
            }
            return nombre;
        }
        public void Clear() {
            while (frente != null) {
                Dequeue();
            }
        }
        public void BuscarCenicienta(int talla) {
            bool band = false;
            while (frente != null) {
                if (frente.talla == talla && !band) {
                    Console.WriteLine($"La cenicienta es: {frente.cadena}");
                    band = true;
                }
                frente = frente.siguiente;
            }
        }
        public static void Palindromo(string palabra) {
            ColaString cola = new ColaString();
            Pila pila = new Pila();
            bool band = false;

            for (int i = 0; i < palabra.Length; i++) {
                cola.Enqueue(palabra[i].ToString().ToLower(), i);
                pila.Push(palabra[i].ToString().ToLower());
            }

            while (cola.frente != null && pila.inicio != null && !band) {
                if (cola.Dequeue() != pila.Pop())
                    band = true;
            }

            if (band)
                Console.WriteLine($"La palabra {palabra} no es palindromo");
            else
                Console.WriteLine($"La palabra {palabra} es palindromo");
        }
    }

}
