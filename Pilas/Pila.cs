namespace Pilas {
    class Pila {
        private Nodo? inicio = new Nodo();
        public Pila() {
            inicio = null;
        }
        public void Push(int dato) {
            Nodo nuevo = new Nodo();
            nuevo.dato = dato;
            nuevo.siguiente = inicio;
            inicio = nuevo;
        }
        public void Mostrar() {
            Nodo? auxiliar = inicio;
            if (inicio == null)
                Console.WriteLine("Pila vacía");
            while (auxiliar != null) {
                Console.Write($"{auxiliar.dato} ->");
                auxiliar = auxiliar.siguiente;
                if (auxiliar == null)
                    Console.WriteLine("null");
            }
        }
        public int Pop() {
            int dato = int.MinValue;
            if (inicio != null) {
                dato = inicio.dato;
                inicio = inicio.siguiente;
            }
            return dato;
        }
        public void Clear() {
            while (inicio != null)
                Pop();
        }
        public int Top() {
            return inicio != null ? inicio.dato : int.MinValue;
        }
        //EJERCICIO N°01
        public static bool SonIguales(Pila pila1, Pila pila2) {
            while (pila1.inicio != null && pila2.inicio != null) {
                if (pila1.Pop() != pila2.Pop())
                    return false;
            }
            if (pila1 == null || pila2 == null)
                return false;
            return true;
        }
        //EJERCICIO N°02
        public int CantidadElementos() {
            int contador = 0;
            Pila auxiliar = new Pila();

            while (this.inicio != null) {
                auxiliar.Push(this.Pop());
                contador++;
            }   

            while(auxiliar.inicio != null) {
                this.Push(auxiliar.Pop());
            }

            return contador;
        }
        //EJERCICIO N°04
        public void MultiplicarPor(int num) {
            Pila auxiliar = this.InvertirPila();
            while (auxiliar.inicio != null) {
                this.Push(auxiliar.Pop() * num);
            }
        }
        //EJERCICIO N°05
        public void PushPosicion(int posicion, int dato) {
            int posicionActual = 1;
            Pila auxiliar = this.InvertirPila();
            while (auxiliar.inicio != null) {
                if (posicionActual == posicion)
                    this.Push(dato);
                this.Push(auxiliar.Pop());
                posicionActual++;
            }
        }
        //EJERCICIO N°06
        public int PopPosicion(int posicion) {
            int posicionActual = 1;
            int dato = int.MinValue;
            Pila auxiliar = this.InvertirPila();
            while (auxiliar.inicio != null) {
                if (posicionActual == posicion)
                    dato = auxiliar.Pop();
                else this.Push(auxiliar.Pop());
                posicionActual++;
            }
            return dato;
        }
        public Pila InvertirPila() {
            Pila auxiliar = new Pila();
            while (inicio != null) {
                auxiliar.Push(this.Pop());
            }
            return auxiliar;
        }
        public static int PostFija(string expresion) {
            Pila pila = new Pila();
            int operando1;
            int operando2;

            foreach (string linea in expresion.Split(" ")) {
                switch (linea) {
                    case "+":
                        pila.Push(pila.Pop() + pila.Pop());
                        break;
                    case "-":
                        pila.Push(pila.Pop() - pila.Pop());
                        break;
                    case "*":
                        pila.Push(pila.Pop() * pila.Pop());
                        break;
                    case "/":
                        operando2 = pila.Pop();
                        operando1 = pila.Pop();
                        pila.Push(operando1 / operando2);
                        break;
                    case "^":
                        operando2 = pila.Pop();
                        operando1 = pila.Pop();
                        pila.Push(operando1 ^ operando2);
                        break;
                    default:
                        pila.Push(Convert.ToInt32(linea));
                        break;
                }
            }
            return pila.Pop();
        }
    }
}
