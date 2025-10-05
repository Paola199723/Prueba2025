using BibliotecaApp.Domain.Entities;
using System.Collections.Generic;

namespace BibliotecaApp.Application.Interfaces
{
    public interface IMiembroRepository
    {
        List<Miembro> ObtenerTodos();
        Miembro? ObtenerPorId(int id);
        void Agregar(Miembro miembro);
        void Actualizar(Miembro miembro);
    }
}
