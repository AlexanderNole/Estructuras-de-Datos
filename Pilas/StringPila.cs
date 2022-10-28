namespace Pilas {
    class StringPila {
        private StringNodo? inicio = new StringNodo();
        public StringPila() {
            inicio = null;
        }
        public void Push(string dato) {
            StringNodo nuevo = new StringNodo();
            nuevo.dato = dato;
            nuevo.siguiente = inicio;
            inicio = nuevo;
        }
        public void Mostrar() {
            StringNodo? auxiliar = inicio;
            if (inicio == null)
                Console.WriteLine("Pila vacía");
            while (auxiliar != null) {
                Console.Write($"{auxiliar.dato} ->");
                auxiliar = auxiliar.siguiente;
                if (auxiliar == null)
                    Console.WriteLine("null");
            }
        }
        public string Pop() {
            string dato = "";
            if (inicio != null) {
                dato = inicio.dato;
                inicio = inicio.siguiente;
            }
            return dato;
        }
        public void Clear() {
            while (inicio != null) {
                Pop();
            }
        }
        public string Top() {
            return inicio != null ? inicio.dato : "";
        }

        //EJERCICIO N°03
        public static string InvertirFrase(string dato) {
            string[] myStr = dato.Split();
            int tamaño = myStr.Length;

            StringPila pila = new StringPila();

            foreach (string str in myStr) {
                pila.Push(str);
            }

            for (int i = 0; i < tamaño; i++) {
                myStr[i] = pila.Pop();
            }
            return String.Join(" ", myStr);
        }
        public StringPila InvertirPila() {
            StringPila auxiliar = new StringPila();
            while (inicio != null) {
                auxiliar.Push(this.Pop());
            }
            return auxiliar;
        }
    }
}
