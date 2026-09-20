public class ItemPedido
{
    public Producto ProductoItem { get; private set; }
    public int Cantidad { get; private set; }

    public ItemPedido(Producto producto, int cantidad)
    {
        ProductoItem = producto ?? throw new ArgumentNullException(nameof(producto));

        if (cantidad <= 0)
        {
            throw new ArgumentException("La cantidad debe ser mayor a 0", nameof(cantidad));
        }

        Cantidad = cantidad;
    }
}
