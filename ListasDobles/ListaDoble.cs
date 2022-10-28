using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ListasDobles {
    class ListaDoble {
        private Nodo primero = new Nodo();
        private Nodo ultimo = new Nodo();
        public ListaDoble() {
            this.primero = null;
            this.ultimo = null;
        }
        public void InsertarAlInicio(int num) {
            Nodo nuevo = new Nodo();
            nuevo.dato = num;
            nuevo.anterior = null;
            nuevo.siguiente = primero;
            if (primero != null)
                primero.anterior = nuevo;
            else ultimo = nuevo;
            primero = nuevo;
        }
        public void MostrarListaInicioFin() {
            Nodo auxiliar = this.primero;
            Console.Write("null <-");
            while (auxiliar != null) {
                if (auxiliar.siguiente == null)
                    Console.Write(auxiliar.dato + "-> null");
                else Console.Write(auxiliar.dato + "<->");
                auxiliar = auxiliar.siguiente;
            }
        }
        public void MostrarListaFinInicio() {
            Nodo auxiliar = ultimo;
            Console.Write("null <-");
            while (auxiliar != null) {
                if (auxiliar.anterior == null)
                    Console.Write(auxiliar.dato + "-> null");
                else Console.Write(auxiliar.dato + "<->");
                auxiliar = auxiliar.anterior;
            }

        }
        public void InsertarAlFinal(int num) {
            Nodo nuevo = new Nodo();
            nuevo.dato = num;
            nuevo.siguiente = null;
            if (this.primero == null) {
                nuevo.anterior = null;
                this.primero = nuevo;
            }
            else {
                ultimo.siguiente = nuevo;
                nuevo.anterior = ultimo;
            }
            ultimo = nuevo;
        }
        public int SumarElementosLista() {
            Nodo auxiliar = primero;
            int suma = 0;
            while (auxiliar != null) {
                suma += auxiliar.dato;
                auxiliar = auxiliar.siguiente;
            }
            return suma;

        }
        public void BuscarElemento(int num) {
            Nodo auxiliar = primero;
            bool band = false;
            while (auxiliar != null && band == false) {
                if (auxiliar.dato == num) {
                    Console.WriteLine(auxiliar.dato);
                    band = true;
                }
                else auxiliar = auxiliar.siguiente;
            }
            //return false;
        }

        //Ejercicio N°01
        public void Listar(string forma) {
            if (forma.ToLower() == "inicio")
                this.MostrarListaInicioFin();
            else if (forma.ToLower() == "fin")
                this.MostrarListaFinInicio();
            else Console.WriteLine("No se puede mostrar la lista de esa forma");
        }

        //Ejercicio N°02
        public ListaDoble Union(ListaDoble lista2) {
            Nodo auxiliar = this.primero;
            ListaDoble union = new ListaDoble();

            while (auxiliar != null) {
                union.InsertarAlFinal(auxiliar.dato);
                auxiliar = auxiliar.siguiente;
            }

            auxiliar = lista2.primero;
            while (auxiliar != null) {
                union.InsertarAlFinal(auxiliar.dato);
                auxiliar = auxiliar.siguiente;
            }

            return union;
        }
        public bool ElementoPresente(int num) {
            Nodo auxiliar = this.primero;

            while (auxiliar != null) {
                if (num == auxiliar.dato)
                    return true;
                auxiliar = auxiliar.siguiente;
            }
            return false;
        }
        public ListaDoble Interseccion(ListaDoble lista2) {
            Nodo auxiliar = this.primero;
            ListaDoble interseccion = new ListaDoble();
            while (auxiliar != null) {
                if (lista2.ElementoPresente(auxiliar.dato))
                    interseccion.InsertarAlFinal(auxiliar.dato);
                auxiliar = auxiliar.siguiente;
            }
            return interseccion;
        }
        public ListaDoble Diferencia(ListaDoble lista2) {
            Nodo auxiliar = this.primero;
            ListaDoble diferencia = new ListaDoble();

            while (auxiliar != null) {
                if (!lista2.ElementoPresente(auxiliar.dato))
                    diferencia.InsertarAlFinal(auxiliar.dato);
                auxiliar = auxiliar.siguiente;
            }

            auxiliar = lista2.primero;
            while (auxiliar != null) {
                if (!this.ElementoPresente(auxiliar.dato))
                    diferencia.InsertarAlFinal(auxiliar.dato);
                auxiliar = auxiliar.siguiente;
            }

            return diferencia;
        }

        //Ejercicio N°03
        public int CantidadElementos() {
            Nodo auxiliar = this.primero;
            int contador = 0;
            while (auxiliar != null) {
                contador++;
                auxiliar = auxiliar.siguiente;
            }
            return contador;
        }
        public bool IgualdadListas(ListaDoble lista2) {
            Nodo auxiliarI = this.primero;
            Nodo auxiliarJ = lista2.primero;

            while (auxiliarI != null && auxiliarJ != null) {
                if (auxiliarI.dato != auxiliarJ.dato)
                    return false;
                auxiliarI = auxiliarI.siguiente;
                auxiliarJ = auxiliarJ.siguiente;
            }
            return true;
        }
        public void Reporte(ListaDoble lista2) {
            int cantidadElementosI = this.CantidadElementos();
            int cantidadElementosJ = lista2.CantidadElementos();

            if (cantidadElementosI == cantidadElementosJ) {
                if (this.IgualdadListas(lista2))
                    Console.WriteLine("Las listas son iguales en tamaño y contenido");
                else
                    Console.WriteLine("Las listas son iguales en tamaño, pero no en contenido");
            }
            else {
                Console.WriteLine("Las listas no tienen el mismo tamaño ni contenido");
            }
        }

        //Ejercicio N°04
        public void InvertirLista() {
            Nodo auxiliarI = this.primero;
            Nodo auxiliarJ = this.ultimo;
            int i = 0, temporal;
            int cantidadElementos = this.CantidadElementos();

            if (cantidadElementos % 2 != 0) {
                while (auxiliarI != auxiliarJ) {
                    temporal = auxiliarI.dato;
                    auxiliarI.dato = auxiliarJ.dato;
                    auxiliarJ.dato = temporal;
                    auxiliarI = auxiliarI.siguiente;
                    auxiliarJ = auxiliarJ.siguiente;
                }
            }
            else {
                while (i < cantidadElementos / 2) {
                    temporal = auxiliarI.dato;
                    auxiliarI.dato = auxiliarJ.dato;
                    auxiliarJ.dato = temporal;
                    auxiliarI = auxiliarI.siguiente;
                    auxiliarJ = auxiliarJ.siguiente;
                    i++;
                }
            }
        }

        //Ejercicio N°05
        public int CantidadRepeticiones(int dato) {
            Nodo iterador = this.primero;
            int contador = 0;

            while (iterador != null) {
                if (dato == iterador.dato)
                    contador++;
                iterador = iterador.siguiente;
            }

            return contador;
        }

        //Ejercicio N°06
        public bool EsPrimo(int numero) {
            for (int i = 2; i < numero; i++) {
                if (numero % i == 0)
                    return false;
            }
            return true;
        }

        public static ListaDoble GenerarListaRandom() {
            ListaDoble listaRandom = new ListaDoble();
            Random rand = new Random();

            for (int i = 0; i < 10; i++)
                listaRandom.InsertarAlFinal(rand.Next(1, 1001));

            return listaRandom;
        }
        public void EliminarElementoPosicionX(int posicionAEliminar) {
            Nodo iterador;
            int posicionActual = 1;
            int cantidadElementos = this.CantidadElementos();

            if (cantidadElementos != 1) {
                if (posicionActual == posicionAEliminar) {
                    if (cantidadElementos != 1) {
                        this.primero = this.primero.siguiente;
                        this.primero.anterior = null;
                    }
                    else {
                        this.primero = null;
                        this.ultimo = null;
                    }
                }
                else {
                    iterador = this.primero.siguiente;
                    while (iterador != null) {
                        posicionActual++;
                        if (posicionActual == posicionAEliminar) {
                            if (posicionActual != cantidadElementos) {
                                iterador.anterior.siguiente = iterador.siguiente;
                                iterador.siguiente.anterior = iterador.anterior;
                            }
                            else {
                                iterador.anterior.siguiente = null;
                            }
                            break;
                        }
                        iterador = iterador.siguiente;
                    }
                }
            }
            else {
                this.primero = null;
                this.ultimo = null;
            }
        }
        public void EliminarNumerosPrimos() {
            Nodo iterador = this.primero;
            int posicion = 1;

            while (iterador != null) {
                if (this.EsPrimo(iterador.dato)) {
                    this.EliminarElementoPosicionX(posicion);
                }
                iterador = iterador.siguiente;
                posicion++;
            }
        }

    }
}
