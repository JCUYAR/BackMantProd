namespace WebAPI.Domain.Commands.ProductoCommand
{
    public class AddProductoCommand
    {
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Estado { get; set; }
    }
}
