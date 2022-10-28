using System.ComponentModel;

namespace ListasSimples {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("Listas enlazadas SIMPLES!");
            Lista lista = new Lista();
            lista.InsertarAlInicio(1);
            lista.InsertarAlInicio(2);
            lista.InsertarAlInicio(3);
            lista.InsertarAlInicio(4);
            lista.InsertarAlInicio(5);
            lista.InsertarAlInicio(6);
            lista.InsertarAlInicio(7);
            lista.InsertarAlInicio(8);
            lista.InsertarAlInicio(9);
            //lista.MostrarLista("par");
            //lista.MostrarLista("impar");
            lista.MostrarLista("Todo");

            lista.EliminarPorValor(2);
            lista.MostrarLista("todo");
        }
    }
}