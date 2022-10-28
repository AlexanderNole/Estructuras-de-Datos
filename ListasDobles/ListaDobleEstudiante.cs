namespace ListasDobles {
    class ListaDobleEstudiante {
        private NodoEstudiante? primero = new();
        private NodoEstudiante? ultimo = new();

        public ListaDobleEstudiante() {
            primero = null;
            ultimo = null;
        }
        
        public void InsertarEstudiante(string codigo, string nombre, string apellidos, string correo, int nota) {
            NodoEstudiante iterador;
            NodoEstudiante nuevo = new() {
                codigo = codigo,
                nombre = nombre,
                apellidos = apellidos,
                correo = correo,
                nota = nota
            };
            if (this.primero == null) {
                nuevo.siguiente = nuevo.anterior = null;
                this.primero = this.ultimo = nuevo;
            }
            else {
                if(nota < 12) {
                    this.ultimo.siguiente = nuevo;
                    nuevo.siguiente = null;
                    nuevo.anterior = this.ultimo;
                    this.ultimo = nuevo;
                }
                else {
                    iterador = this.primero;
                    iterador.anterior = nuevo;
                    nuevo.siguiente = iterador;
                    nuevo.anterior = null;
                    this.primero = nuevo;
                }
            }
        }
        public void MostrarListaInicioFin() {
            NodoEstudiante? auxiliar = primero;
            //Console.Write("null <- ");
            while (auxiliar != null) {
                if (auxiliar.siguiente == null)
                    Console.Write("{0} {1} {2}",
                        auxiliar.nombre, auxiliar.apellidos, auxiliar.nota);
                else Console.WriteLine("{0} {1} {2}",
                        auxiliar.nombre, auxiliar.apellidos, auxiliar.nota);
                auxiliar = auxiliar.siguiente;
            }
        }
        public void MostrarListaFinInicio() {
            NodoEstudiante? auxiliar = ultimo;
            while (auxiliar != null) {
                if (auxiliar.anterior == null)
                    Console.Write("{0} {1} {2}",
                        auxiliar.nombre, auxiliar.apellidos, auxiliar.nota);
                else Console.Write("{0} {1} {2}",
                        auxiliar.nombre, auxiliar.apellidos, auxiliar.nota);
                auxiliar = auxiliar.anterior;
            }
        }
        public void Listar(string formato) {
            if (formato.ToLower() == "inicio")
                this.MostrarListaInicioFin();
            else if (formato.ToLower() == "fin")
                this.MostrarListaFinInicio();
            else Console.WriteLine("No se puede mostrar la lista de esa manera");
        }

        public int Cantidad(string condicion) {
            int desaprobados = 0, aprobados = 0;
            NodoEstudiante? auxiliar = primero;
            while (auxiliar != null) {
                if (auxiliar.nota < 12)
                    desaprobados++;
                else aprobados++;
                auxiliar = auxiliar.siguiente;
            }
            if (condicion.ToLower() == "aprobados")
                return aprobados;
            else return desaprobados;
        }
    
        public void BuscarEstudiante(string codigo) {
            NodoEstudiante? auxiliar = primero;
            bool band = false;
            while (auxiliar != null && band == false) {
                if (auxiliar.codigo == codigo) {
                    Console.WriteLine("Resultado...\n" +
                        $"\nNombre: {auxiliar.nombre}\n" +
                        $"Apellidos: {auxiliar.apellidos}\n" +
                        $"Correo: {auxiliar.correo}\n" +
                        $"Nota: {auxiliar.nota}\n");
                    band = true;
                }
                else auxiliar = auxiliar.siguiente;
            }
            if (band == false)
                Console.WriteLine("Estudiante no encontrado");
        }
        public void EliminarEstudiante(string codigo) {
            NodoEstudiante? auxiliar = primero;
            NodoEstudiante? anterior = null;
            bool band = false;
            while (auxiliar != null && band == false) {
                if (auxiliar.codigo.Equals(codigo)) {
                    if (anterior == null) {
                        primero = auxiliar.siguiente;
                        auxiliar.siguiente = null;
                    }
                    else {
                        anterior.siguiente = auxiliar.siguiente;
                        auxiliar.siguiente = null;
                    }
                    band = true;
                    Console.WriteLine("Estudiante eliminado con éxito");
                }
                anterior = auxiliar;
                auxiliar = auxiliar.siguiente;
            }
            if (band == false)
                Console.WriteLine("Estudiante no existente en la lista");
        }
    }
}

/*
 * codigo
 * nombre
 * apellidos
 * correo
 * nota
 */

/*
 * a) Agregar un estudiante.
 *b) Buscar un estudiante por código.
 *c) Eliminar un estudiante
 *d) Total de estudiantes aprobados
 *e) Total de Estudiante desaprobados.
 */
