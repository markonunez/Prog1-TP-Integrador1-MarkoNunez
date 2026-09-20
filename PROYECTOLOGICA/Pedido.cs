public enum EstadoPedido
{
    Pendiente,
    EnPreparacion,
    Listo,
    Entregado,
    Cancelado
}

public class Pedido
{
    public EstadoPedido EstadoDelPedido { get; private set; } = EstadoPedido.Pendiente;
    private readonly List<ItemPedido> ItemsPedido = new List<ItemPedido>();

    public void CambiarEstado(EstadoPedido nuevoEstado)
    {
        EstadoDelPedido = nuevoEstado;
    }

    public void AgregarProducto(Producto producto, int cantidad)
    {
        if (EstadoDelPedido != EstadoPedido.Pendiente)
        {
            throw new InvalidOperationException("El pedido debe estar pendiente para agregar un producto");
        }

        ItemPedido itemPedido = new ItemPedido(producto, cantidad);
        ItemsPedido.Add(itemPedido);
    }

    public decimal CalcularTotal()
    {
        var precios = ItemsPedido.Select(i => i.ProductoItem.CalcularPrecioFinal() * i.Cantidad);
        return precios.Sum();
    }
}
