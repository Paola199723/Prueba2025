using BibliotecaApp.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaApp.Application.Services
{
    public class BibliotecaService
    {
        private readonly List<Libro> _libros = new();
        private readonly List<Miembro> _miembros = new();

        public BibliotecaService()
        {
            // Cargamos algunos datos iniciales
            _libros.AddRange(new[]
            {
                new Libro { Id = 1, Titulo = "Cien años de soledad" },
                new Libro { Id = 2, Titulo = "El Principito" },
                new Libro { Id = 3, Titulo = "Don Quijote de la Mancha" }
            });

            _miembros.AddRange(new[]
            {
                new Miembro { Id = 1, Nombre = "Ana" },
                new Miembro { Id = 2, Nombre = "Luis" }
            });
        }

        public void MostrarLibros()
        {
            Console.WriteLine("\n📚 Lista de libros disponibles:");
            foreach (var libro in _libros)
            {
                string estado = libro.Prestado ? $"Prestado a {_miembros.FirstOrDefault(m => m.Id == libro.IdMiembroPrestamo)?.Nombre}" : "Disponible";
                Console.WriteLine($"  {libro.Id}. {libro.Titulo} - {estado}");
            }
        }

        public void PrestarLibro(int idLibro, int idMiembro)
        {
            var libro = _libros.FirstOrDefault(l => l.Id == idLibro);
            var miembro = _miembros.FirstOrDefault(m => m.Id == idMiembro);

            if (libro == null)
            {
                Console.WriteLine("El libro no existe.");
                return;
            }

            if (miembro == null)
            {
                Console.WriteLine("El miembro no existe.");
                return;
            }

            if (libro.Prestado)
            {
                Console.WriteLine("Este libro ya está prestado.");
                return;
            }

            libro.Prestado = true;
            libro.IdMiembroPrestamo = idMiembro;
            Console.WriteLine($" El libro '{libro.Titulo}' ha sido prestado a {miembro.Nombre}.");
        }

        public void DevolverLibro(int idLibro)
        {
            var libro = _libros.FirstOrDefault(l => l.Id == idLibro);
            if (libro == null)
            {
                Console.WriteLine("El libro no existe.");
                return;
            }

            if (!libro.Prestado)
            {
                Console.WriteLine("Este libro no estaba prestado.");
                return;
            }

            libro.Prestado = false;
            libro.IdMiembroPrestamo = null;
            Console.WriteLine($"El libro '{libro.Titulo}' ha sido devuelto.");
        }

        public void MostrarPrestamos()
        {
            var prestados = _libros.Where(l => l.Prestado).ToList();

            Console.WriteLine("\nLibros actualmente prestados:");
            if (!prestados.Any())
            {
                Console.WriteLine("Ninguno.");
                return;
            }

            foreach (var libro in prestados)
            {
                var miembro = _miembros.FirstOrDefault(m => m.Id == libro.IdMiembroPrestamo);
                Console.WriteLine($"  {libro.Titulo} → {miembro?.Nombre}");
            }
        }
    }
}
