namespace ListasDobles {
    class Program {
        static void Main(string[] args) {
            int nota;
            int opcionMenu;
            char volverMenu;

            string codigo;
            string nombre;
            string apellidos;
            string correo;

            ListaDobleEstudiante lista = new();
            Console.WriteLine("Registro de Estudiantes");
            do {
                Console.WriteLine(
                    "1. Agregar un estudiante\n" +
                    "2. Buscar un estudiante por código\n" +
                    "3. Eliminar un estudiante\n" +
                    "4. Total de estudiantes aprobados\n" +
                    "5. Total de estudiantes desaprobados\n" +
                    "6. Mostrar registro");
                Console.Write("\n\tIngrese una opción: ");

                opcionMenu = Convert.ToInt32(Console.ReadLine());
                while (opcionMenu < 1 || opcionMenu > 6) {
                    Console.Write("\tIngrese solo una opción valida: ");
                    opcionMenu = Convert.ToInt32(Console.ReadLine());
                }

                switch (opcionMenu) {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Agregar un estudiante:");
                        Console.Write("\n\tCódigo: "); codigo = Console.ReadLine();
                        Console.Write("\tNombre: "); nombre = Console.ReadLine();
                        Console.Write("\tApellidos: "); apellidos = Console.ReadLine();
                        Console.Write("\tCorreo: "); correo = Console.ReadLine();
                        Console.Write("\tNota: "); nota = Convert.ToInt32(Console.ReadLine());

                        lista.InsertarEstudiante(codigo, nombre, apellidos, correo, nota);

                        Console.WriteLine("\n\tEstudiante agregado con éxito!!!");
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Buscar un estudiante:");
                        Console.Write("\n\tCódigo: "); codigo = Console.ReadLine();
                        lista.BuscarEstudiante(codigo);
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Eliminar un estudiante por código:");
                        Console.Write("\n\tCódigo: "); codigo = Console.ReadLine();
                        lista.EliminarEstudiante(codigo);
                        break;

                    case 4:
                        Console.WriteLine("\n\tEstudiantes aprobados: " + lista.Cantidad("aprobados"));
                        break;

                    case 5:
                        Console.WriteLine("\n\tEstudiantes desaprobados: " + lista.Cantidad("desaprobados"));
                        break;

                    case 6:
                        Console.WriteLine("\tMostrar registro");
                        lista.Listar("inicio");
                        break;
                }

                Console.Write("\nDesea volver al menú principal? [S/N]: ");
                volverMenu = Convert.ToChar(Console.ReadLine());
                Console.Clear();

            } while (volverMenu == 's' || volverMenu == 'S');
        }
    }
}