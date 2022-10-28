namespace Bicolas
{
    class NodoString
    {
        public string dato;
        public NodoString? siguiente;
        public NodoString? anterior;
    }
    class BicolaString
    {
        public NodoString? frente = new NodoString();
        private NodoString? fin = new NodoString();

        public BicolaString()
        {
            frente = null;
            fin = null;
        }

        public void EnqueueEnd(string dato)
        {
            NodoString nuevo = new NodoString();
            nuevo.dato = dato;
            nuevo.siguiente = null;

            if (frente == null) {
                nuevo.anterior = null;
                frente = nuevo;
            } else {
                fin.siguiente = nuevo;
                nuevo.anterior = fin;
            }

            fin = nuevo;
        }
        public void Mostrar()
        {
            NodoString? auxiliar = frente;
            if (auxiliar == null)
                Console.WriteLine("Bicola vacía");

            while (auxiliar != null) {
                Console.Write($"{auxiliar.dato} ->");
                auxiliar = auxiliar.siguiente;
                if (auxiliar == null)
                    Console.WriteLine("null");
            }
        }
        public void EnqueueFront(string dato)
        {
            NodoString nuevo = new NodoString();
            nuevo.dato = dato;
            nuevo.anterior = null;

            if (frente != null) {
                frente.anterior = nuevo;
                nuevo.siguiente = frente;
            } else {
                nuevo.siguiente = null;
                fin = nuevo;
            }

            frente = nuevo;
        }
        public string DequeueFront()
        {
            string dato = "";
            NodoString? auxiliar = frente;

            if (frente != null) {
                dato = auxiliar.dato;

                if (frente.siguiente == null) {
                    frente = null;
                    fin = null;
                } else {
                    frente = frente.siguiente;
                    frente.anterior = null;
                }
            }

            return dato;
        }
        public string DequeueEnd()
        {
            string dato = "";
            NodoString? auxiliar = fin;

            if (frente != null) {
                dato = auxiliar.dato;

                if (frente.siguiente == null) {
                    frente = null;
                    fin = null;
                } else {
                    fin = fin.anterior;
                    fin.siguiente = null;
                }
            }

            return dato;
        }
        public void Clear()
        {
            while (frente != null) {
                DequeueFront();
            }
        }
        public bool EsPalindromo()
        {
            while (this.frente != null) {
                if (this.DequeueFront() != this.DequeueEnd())
                    return false;

                if (this.frente == this.fin)
                    break;
            }
            return true;
        }
        public static int CantidadPalindromos(BicolaString bicola)
        {
            int cantidadPalindromos = 0;
            string cadena;
            BicolaString? auxiliar;

            while (bicola.frente != null) {
                auxiliar = new BicolaString();
                cadena = auxiliar.DequeueFront();

                for (int i = 0; i < cadena.Length; i++)
                    auxiliar.EnqueueEnd(cadena[i].ToString());

                if (auxiliar.EsPalindromo())
                    cantidadPalindromos++;
            }

            return cantidadPalindromos;
        }
        public static void ASteal(BicolaString bicola1, BicolaString bicola2)
        {
            Random rand = new Random();

            while (bicola1.frente != null || bicola2.frente != null) {
                if (rand.Next(1, 3) == 1) {
                    if (bicola1.frente != null) {
                        Console.Write("Desencolando Bicola 1: ");
                        Console.WriteLine(bicola1.DequeueFront());
                    } else {
                        Console.WriteLine("Bicola 1 robando");
                        bicola1.EnqueueEnd(bicola2.DequeueFront());
                    }
                } else {
                    if (bicola2.frente != null) {
                        Console.Write("Desencolando Bicola 2: ");
                        Console.WriteLine(bicola2.DequeueFront());
                    } else {
                        Console.WriteLine("Bicola 2 robando");
                        bicola2.EnqueueFront(bicola1.DequeueFront());
                    }
                }
            }
            Console.WriteLine("Las bicolas se encuentran vacías.");
        }

    }

    class NodoInt
    {
        public int dato;
        public NodoInt? siguiente;
        public NodoInt? anterior;
    }
    class BicolaInt
    {
        private NodoInt? frente = new NodoInt();
        private NodoInt? fin = new NodoInt();

        public BicolaInt()
        {
            frente = null;
            fin = null;
        }

        public void EnqueueEnd(int dato)
        {
            NodoInt nuevo = new NodoInt();
            nuevo.dato = dato;
            nuevo.siguiente = null;

            if (frente == null) {
                nuevo.anterior = null;
                frente = nuevo;
            } else {
                fin.siguiente = nuevo;
                nuevo.anterior = fin;
            }

            fin = nuevo;
        }
        public void Mostrar()
        {
            NodoInt? auxiliar = frente;
            if (auxiliar == null)
                Console.WriteLine("Bicola vacía");

            while (auxiliar != null) {
                Console.Write($"{auxiliar.dato} ->");
                auxiliar = auxiliar.siguiente;
                if (auxiliar == null)
                    Console.WriteLine("null");
            }
        }
        public void EnqueueFront(int dato)
        {
            NodoInt nuevo = new NodoInt();
            nuevo.dato = dato;
            nuevo.anterior = null;

            if (frente != null) {
                frente.anterior = nuevo;
                nuevo.siguiente = frente;
            } else {
                nuevo.siguiente = null;
                fin = nuevo;
            }

            frente = nuevo;
        }
        public int DequeueFront()
        {
            int dato = int.MinValue;
            NodoInt? auxiliar = frente;

            if (frente != null) {
                dato = auxiliar.dato;

                if (frente.siguiente == null) {
                    frente = null;
                    fin = null;
                } else {
                    frente = frente.siguiente;
                    frente.anterior = null;
                }
            }

            return dato;
        }
        public int DequeueEnd()
        {
            int dato = int.MinValue;
            NodoInt? auxiliar = fin;

            if (frente != null) {
                dato = auxiliar.dato;

                if (frente.siguiente == null) {
                    frente = null;
                    fin = null;
                } else {
                    fin = fin.anterior;
                    fin.siguiente = null;
                }
            }

            return dato;
        }
        public void Clear()
        {
            while (frente != null) {
                DequeueFront();
            }
        }
        public void EliminarElemento(int elemento)
        {
            BicolaInt auxiliar = new BicolaInt();
            int dato;

            while (this.frente != null) {
                dato = this.DequeueEnd();
                if (dato != elemento) {
                    auxiliar.EnqueueFront(dato);
                }
            }
            while (auxiliar.frente != null) {
                this.EnqueueFront(auxiliar.DequeueFront());
            }
        }
        public int CantidadNaturales()
        {
            int cantidadNaturales = 0;

            while (this.frente != null) {
                if (DequeueFront() >= 0)
                    cantidadNaturales++;
            }

            return cantidadNaturales;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BicolaString bicola1 = new BicolaString();
            BicolaString bicola2 = new BicolaString();
            Random rand = new Random();

            bicola1.EnqueueFront("Tarea 1");
            bicola2.EnqueueFront("tarea 2");
            bicola2.EnqueueFront("tarea 3");
            bicola2.EnqueueFront("tarea 4");
            bicola2.EnqueueFront("tarea 5");
            bicola2.EnqueueFront("tarea 6");

            bicola1.Mostrar();
            bicola2.Mostrar();

            BicolaString.ASteal(bicola1, bicola2);


        }
    }
}