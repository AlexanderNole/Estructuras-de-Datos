using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ListasSimples {
    class Lista {
        private Nodo inicio = new Nodo();
        public Lista() {
            inicio = null;
        }

        //OPERACIONES BÁSICAS
        public void InsertarAlInicio(int num) {
            Nodo nuevo = new Nodo();
            nuevo.dato = num;
            nuevo.siguiente = inicio;
            inicio = nuevo;
        }
        public void InsertarAlFinal(int num) {
            Nodo auxiliar;
            Nodo nuevo = new Nodo();
            nuevo.dato = num;
            nuevo.siguiente = null;
            if (inicio == null)
                inicio = nuevo;
            else {
                auxiliar = inicio;
                while (auxiliar.siguiente != null) {
                    auxiliar = auxiliar.siguiente;
                }
                auxiliar.siguiente = nuevo;
            }
        }
        public void MostrarLista(string valor) {
            Nodo auxiliar = inicio;
            while (auxiliar != null) {
                if ((valor.ToLower() == "par" && auxiliar.dato % 2 == 0) ||
                    (valor.ToLower() == "impar" && auxiliar.dato % 2 != 0) ||
                    (valor.ToLower() != "par" && valor.ToLower() != "impar")) {
                    Console.Write($"{auxiliar.dato} ->");
                }
                auxiliar = auxiliar.siguiente;

                if (auxiliar == null)
                    Console.Write("null");
            }
        }
        public void EliminarPorValor(int valorNodo) {
            Nodo auxiliar = inicio;
            Nodo anterior = null;
            bool band = false;

            while (auxiliar != null && band == false) {
                if (auxiliar.dato == valorNodo) {
                    if (anterior == null) {
                        inicio = auxiliar.siguiente;
                        auxiliar.siguiente = null;
                    }
                    else {
                        anterior.siguiente = auxiliar.siguiente;
                        auxiliar.siguiente = null;
                    }
                    band = true;
                    Console.WriteLine("Elemento eliminado con éxito");
                }
                anterior = auxiliar;
                auxiliar = auxiliar.siguiente;
            }
        }
        public void Ordenar(string manera) {
            bool band = true;
            while (band) {
                Nodo auxiliar = inicio;
                Nodo siguiente = auxiliar.siguiente;
                int contador = 0;
                while (siguiente != null) {
                    if ((manera.ToLower() == "ascendente" && auxiliar.dato > siguiente.dato) ||
                        (manera.ToLower() == "descendente" && auxiliar.dato < siguiente.dato)) {
                        contador++;
                        int intercambio = auxiliar.dato;
                        auxiliar.dato = siguiente.dato;
                        siguiente.dato = intercambio;
                    }
                    auxiliar = auxiliar.siguiente;
                    siguiente = siguiente.siguiente;
                }
                if (contador == 0)
                    band = false;
            }
        }

        // Problema N°01
        public int Sumatoria() {
            int suma = 0;
            Nodo auxiliar = inicio;
            while (auxiliar != null) {
                suma += auxiliar.dato;
                auxiliar = auxiliar.siguiente;
            }
            return suma;
        }
        public void MostrarNotasMayoresOIgualesA16() {
            Nodo auxiliar = inicio;
            Console.WriteLine($"\nNúmeros que son mayores o iguales que 16");
            while (auxiliar != null) {
                if (auxiliar.dato >= 16)
                    Console.Write($"{auxiliar.dato} ->");
                auxiliar = auxiliar.siguiente;
                if (auxiliar == null)
                    Console.Write("null");
            }
        }
    }
}
