using BibliotecaApp.Application.Interfaces;
using BibliotecaApp.Domain.Entities;
using System;

namespace BibliotecaApp.Application.Services
{
    public class BibliotecaService
    {
        private readonly ILibroRepository _libroRepository;
        private readonly IMiembroRepository _miembroRepository;

        public BibliotecaService(ILibroRepository libroRepository, IMiembroRepository miembroRepository)
        {
            _libroRepository = libroRepository;
            _miembroRepository = miembroRepository;
        }

        public void PrestarLibro(int idLibro, int idMiembro)
        {
            var libro = _libroRepository.ObtenerPorId(idLibro);
            var miembro = _miembroRepository.ObtenerPorId(idMiembro);

            if (libro == null)
            {
                Console.WriteLine("❌ Libro no encontrado.");
                return;
            }

            if (miembro == null)
            {
                Console.WriteLine("❌ Miembro no encontrado.");
                return;
            }

            if (!libro.Disponible)
            {
                Console.WriteLine("⚠️ El libro no está disponible.");
                return;
            }

            libro.Disponible = false;
            miembro.LibrosPrestados.Add(libro);

            _libroRepository.Actualizar(libro);
            _miembroRepository.Actualizar(miembro);

            Console.WriteLine($"✅ {miembro.Nombre} ha tomado prestado el libro \"{libro.Titulo}\".");
        }

        public void DevolverLibro(int idLibro, int idMiembro)
        {
            var libro = _libroRepository.ObtenerPorId(idLibro);
            var miembro = _miembroRepository.ObtenerPorId(idMiembro);

            if (libro == null || miembro == null)
            {
                Console.WriteLine("❌ Libro o miembro no encontrado.");
                return;
            }

            if (miembro.LibrosPrestados.RemoveAll(l => l.Id == idLibro) > 0)
            {
                libro.Disponible = true;
                _libroRepository.Actualizar(libro);
                Console.WriteLine($"📚 {miembro.Nombre} devolvió el libro \"{libro.Titulo}\".");
            }
            else
            {
                Console.WriteLine("⚠️ El miembro no tenía ese libro prestado.");
            }
        }

        public void ListarLibros()
        {
            var libros = _libroRepository.ObtenerTodos();
            Console.WriteLine("\n📖 Catálogo de libros:");
            foreach (var libro in libros)
            {
                Console.WriteLine($"[{libro.Id}] {libro.Titulo} - {libro.Autor} | Disponible: {libro.Disponible}");
            }
        }

        public void ListarMiembros()
        {
            var miembros = _miembroRepository.ObtenerTodos();
            Console.WriteLine("\n👤 Lista de miembros:");
            foreach (var miembro in miembros)
            {
                Console.WriteLine($"[{miembro.Id}] {miembro.Nombre} - Libros prestados: {miembro.LibrosPrestados.Count}");
            }
        }
    }
}
