namespace ListasCircularesSimples {
    class Nodo {
        public int dato { get; set; }
        public Nodo? siguiente { get; set; }
    }
    class ListaCircularSimple {
        private Nodo? inicio = new Nodo();

        public ListaCircularSimple() {
            inicio = null;
        }
        public void InsertarInicio(int dato) {
            Nodo nuevo = new Nodo();
            Nodo? ultimo;
            nuevo.dato = dato;
            nuevo.siguiente = inicio;

            if (inicio == null)
                ultimo = nuevo;
            else {
                ultimo = inicio;
                while (ultimo.siguiente != inicio) {
                    ultimo = ultimo.siguiente;
                }
            }

            inicio = nuevo;
            ultimo.siguiente = inicio;
        }
        public void InsertarFinal(int dato) {
            Nodo nuevo = new Nodo();
            Nodo? ultimo;
            nuevo.dato = dato;

            if (inicio == null) {
                inicio = nuevo;
                ultimo = nuevo;
            }
            else {
                ultimo = inicio;
                while (ultimo.siguiente != inicio) {
                    ultimo = ultimo.siguiente;
                }
            }

            nuevo.siguiente = inicio;
            ultimo.siguiente = nuevo;
        }
        public void Listar() {
            Nodo? auxiliar = inicio;

            if (auxiliar != null) {
                do {
                    Console.WriteLine(auxiliar.dato);
                    auxiliar = auxiliar.siguiente;
                } while (auxiliar != inicio);
            }
            else Console.WriteLine("Lista vacía");
        }
        public int Count() {
            Nodo? auxiliar = inicio;
            int contador = 0;
            if (auxiliar != null) {
                do {
                    contador++;
                    auxiliar = auxiliar.siguiente;
                } while (auxiliar != inicio);
            }
            return contador;
        }
        public void EliminarTodo(int dato) {
            Nodo? auxiliar = inicio;
            Nodo? anterior = inicio;
            int contador = 0;

            do {
                anterior = anterior.siguiente;
            } while (anterior.siguiente != inicio);

            do {
                if (auxiliar.dato == dato) {
                    if (auxiliar != inicio) {
                        anterior.siguiente = auxiliar.siguiente;
                        inicio = anterior;
                        auxiliar = auxiliar.siguiente;
                    }
                    else {
                        anterior.siguiente = auxiliar.siguiente;
                        auxiliar = auxiliar.siguiente;
                    }
                    contador++;
                }
                else {
                    auxiliar = auxiliar.siguiente;
                    anterior = anterior.siguiente;
                }
            } while (auxiliar != inicio);

            if (contador == 0)
                Console.WriteLine("No existen elementos con ese valor");
            else Console.WriteLine("Elementos eliminados con éxito!!!");

        }
        public void EliminarUno(int dato) {
            Nodo? auxiliar = inicio;
            Nodo? anterior = inicio;
            bool band = false;

            do {
                anterior = anterior.siguiente;
            } while (anterior.siguiente != inicio);

            do {
                if (auxiliar.dato == dato && band == false) {
                    if (auxiliar == inicio) {
                        anterior.siguiente = auxiliar.siguiente;
                        inicio = anterior;
                        auxiliar = auxiliar.siguiente;
                    }
                    else {
                        anterior.siguiente = auxiliar.siguiente;
                        auxiliar = auxiliar.siguiente;
                    }
                    band = true;
                }
                else {
                    auxiliar = auxiliar.siguiente;
                    anterior = anterior.siguiente;
                }
            } while (auxiliar != inicio);

            if (band == false)
                Console.WriteLine("Elemento a eliminar no encontrado");
            else {
                Console.WriteLine("Elemento eliminado con éxito!!!");
            }
        }
    }

    class Program {
        static void Main(string[] args) {
            int elemento;
            int opcionMenu;
            char volverMenu;

            Console.Clear();
            ListaCircularSimple listaCircular = new ListaCircularSimple();
            do {
                Console.WriteLine("\tListas Circulares Simples\n");
                Console.WriteLine("1. Ingresar un elemento\n" +
                    "2. Buscar elemento y eliminar\n" +
                    "3. Cantidad de elementos de la lista\n" +
                    "4. Mostar elementos de la lista\n" +
                    "5. Eliminar todo los elementos con valor \"X\"");
                Console.Write("\n\tIngrese una opción: ");
                opcionMenu = Convert.ToInt32(Console.ReadLine());

                while (opcionMenu < 1 || opcionMenu > 6) {
                    Console.Write("\tIngrese solo una opción válida: ");
                    opcionMenu = Convert.ToInt32(Console.ReadLine());
                }

                switch (opcionMenu) {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Agregar un elemento");
                        Console.Write("\n\tElemento: "); elemento = Convert.ToInt32(Console.ReadLine());

                        listaCircular.InsertarFinal(elemento);

                        Console.WriteLine("\n\tElemento agregado con éxito!!!");
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Buscar elemento y eliminar");
                        Console.Write("\n\tElemento: "); elemento = Convert.ToInt32(Console.ReadLine());
                        listaCircular.EliminarUno(elemento);
                        break;

                    case 3:
                        Console.WriteLine("Cantidad de elementos de la lista: " + listaCircular.Count());
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Mostrar elementos de la lista");
                        listaCircular.Listar();
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("Eliminar todos los elementos con valor \"X\"");
                        Console.Write("\n\tElemento: "); elemento = Convert.ToInt32(Console.ReadLine());
                        listaCircular.EliminarTodo(elemento);
                        break;
                }

                Console.Write("Desea volver al menú principal? [S/N]: ");
                volverMenu = Convert.ToChar(Console.ReadLine());
                Console.Clear();
            } while (volverMenu == 's' || volverMenu == 'S');
        }
    }
}