using System;

namespace Pilas {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("El resultado de la expresion postfija 58+9* es: " + Pila.PostFija("5 8 + 9 *"));

        }
    }
}