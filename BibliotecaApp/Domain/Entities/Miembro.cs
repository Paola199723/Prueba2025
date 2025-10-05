namespace BibliotecaApp.Domain.Entities
{
    public class Miembro
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public List<Libro> LibrosPrestados { get; set; } = new List<Libro>();
    }
}
