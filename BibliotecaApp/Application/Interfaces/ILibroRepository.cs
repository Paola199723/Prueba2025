using BibliotecaApp.Domain.Entities;
using System.Collections.Generic;

namespace BibliotecaApp.Application.Interfaces
{
    public interface ILibroRepository
    {
        List<Libro> ObtenerTodos();
        Libro? ObtenerPorId(int id);
        void Agregar(Libro libro);
        void Actualizar(Libro libro);
    }
}
