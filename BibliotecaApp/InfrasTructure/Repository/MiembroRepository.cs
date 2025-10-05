using BibliotecaApp.Application.Interfaces;
using BibliotecaApp.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaApp.Infrastructure.Repositories
{
    public class MiembroRepository : IMiembroRepository
    {
        private readonly List<Miembro> _miembros = new()
        {
            new Miembro { Id = 1, Nombre = "Ana" },
            new Miembro { Id = 2, Nombre = "Carlos" },
            new Miembro { Id = 3, Nombre = "Lucía" }
        };

        public List<Miembro> ObtenerTodos() => _miembros;
        public Miembro? ObtenerPorId(int id) => _miembros.FirstOrDefault(m => m.Id == id);
        public void Agregar(Miembro miembro) => _miembros.Add(miembro);
        public void Actualizar(Miembro miembro)
        {
            var index = _miembros.FindIndex(m => m.Id == miembro.Id);
            if (index != -1)
                _miembros[index] = miembro;
        }
    }
}
