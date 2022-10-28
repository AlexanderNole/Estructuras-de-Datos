namespace Colas
{
    class NodoBoleto
    {
        public int asiento;
        public string nombre;
        public NodoBoleto? siguiente;
    }
    class ColaBoleto
    {
        private NodoBoleto? frente;
        private NodoBoleto? fin;

        public ColaBoleto()
        {
            frente = null;
            fin = null;
        }
        public void Enqueue(int asiento, string nombre)
        {
            NodoBoleto nuevo = new NodoBoleto();
            nuevo.asiento = asiento;
            nuevo.nombre = nombre;
            nuevo.siguiente = null;

            if (frente != null)
                fin.siguiente = nuevo;
            else frente = nuevo;

            fin = nuevo;
        }
        public void Print(string tiempoEspera)
        {
            NodoBoleto? auxiliar = frente;
            if (frente != null) {
                while (auxiliar != null) {
                    Console.WriteLine($"Nombre: {auxiliar.nombre}\n" +
                        $"Número de asiento: {auxiliar.asiento}\n");

                    auxiliar = auxiliar.siguiente;

                    if (auxiliar == null)
                        Console.WriteLine($"Su tiempo de espera es {tiempoEspera}");
                }
            } else {
                Console.WriteLine("Check In vacío");
            }
        }
        public (int, string) Dequeue()
        {
            int asiento = int.MinValue;
            string nombre = "";

            if (frente != null) {
                asiento = frente.asiento;
                nombre = frente.nombre;

                if (frente.siguiente == null)
                    fin = null;
                frente = frente.siguiente;
            }

            return (asiento, nombre);
        }
        public void Clear()
        {
            while (frente != null) {
                Dequeue();
            }
        }
        public int Count()
        {
            ColaBoleto auxiliar = new ColaBoleto();
            int contador = 0;

            while (this.frente != null) {
                (int asiento, string nombre) tupla = this.Dequeue();
                auxiliar.Enqueue(tupla.asiento, tupla.nombre);
                contador++;
            }
            while (auxiliar.frente != null) {
                (int, string) tupla = auxiliar.Dequeue();
                this.Enqueue(tupla.Item1, tupla.Item2);
            }
            return contador;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string nombre;
            char rpta;

            ColaBoleto colaNommal = new ColaBoleto();
            ColaBoleto colaExpress = new ColaBoleto();

            ColaNormal(colaNommal);
            ColaExpress(colaExpress);

            Console.Write("Ingrese su nombre: ");
            nombre = Console.ReadLine();

            Console.Write("Desea adquirir un pase express? s/n: ");
            rpta = Convert.ToChar(Console.ReadLine());

            if (rpta == 'S' || rpta == 's') {
                colaExpress.Enqueue(colaExpress.Count() + 1, nombre);
                colaExpress.Print("5 minutos");
            } else {
                colaNommal.Enqueue(colaNommal.Count() + 1, nombre);
                colaNommal.Print("40 minutos");
            }
        }
        static void ColaNormal(ColaBoleto cola)
        {
            cola.Enqueue(1, "a");
            cola.Enqueue(2, "b");
            cola.Enqueue(3, "c");
            cola.Enqueue(4, "d");
            cola.Enqueue(5, "e");
            cola.Enqueue(6, "f");
            cola.Enqueue(7, "g");
            cola.Enqueue(8, "h");
            cola.Enqueue(9, "h");
        }
        static void ColaExpress(ColaBoleto cola)
        {
            cola.Enqueue(1, "Alex");
            cola.Enqueue(2, "Daniel");
            cola.Enqueue(3, "Sebas");
        }
    }
}