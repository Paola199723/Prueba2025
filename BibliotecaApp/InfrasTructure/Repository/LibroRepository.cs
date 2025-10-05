using BibliotecaApp.Application.Interfaces;
using BibliotecaApp.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaApp.Infrastructure.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private readonly List<Libro> _libros = new()
        {
            new Libro { Id = 1, Titulo = "Clean Code", Autor = "Robert C. Martin" },
            new Libro { Id = 2, Titulo = "El Quijote", Autor = "Miguel de Cervantes" },
            new Libro { Id = 3, Titulo = "1984", Autor = "George Orwell" }
        };

        public List<Libro> ObtenerTodos() => _libros;
        public Libro? ObtenerPorId(int id) => _libros.FirstOrDefault(l => l.Id == id);
        public void Agregar(Libro libro) => _libros.Add(libro);
        public void Actualizar(Libro libro)
        {
            var index = _libros.FindIndex(l => l.Id == libro.Id);
            if (index != -1)
                _libros[index] = libro;
        }
    }
}
