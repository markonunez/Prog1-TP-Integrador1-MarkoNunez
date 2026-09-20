public class SistemaCafeteria
{
    List<Producto> Menu=new List<Producto>();
    List<Pedido> Pedidos=new List<Pedido>();

    public void AgregarAlMenu(Producto producto)
    {
        List<Producto> ProductoYaExistente=Menu.Where(p=>p.Nombre==producto.Nombre).ToList();
        if(ProductoYaExistente.Count>0){
            throw new ArgumentException("ya existe un producto con ese nombre en el menu");
        }
        Menu.Add(producto);
    }

    public List<Producto> ListarMenu()
    {
        return Menu;  
//solo devuelve el  menú para luego ser listado en la capa de presentación, no es correcto imprimir en la capa de lógica de negocio  
    }

    public List<Producto> FiltrarBebidas()
    {
        List<Producto> Bebidas=Menu.Where(t=>t is Bebida).ToList();
        return Bebidas;
    }

    public List<Producto> FiltrarComidas()
    {
        List<Producto> Comidas=Menu.Where(t=>t is Comida).ToList();
        return Comidas;
    }

    public Producto BuscarProducto(string nombreProducto)
    {
        Producto productoBuscado=Menu.FirstOrDefault(p=>p.Nombre==nombreProducto);
        if (productoBuscado == null)
        {
            throw new ArgumentException("no existe un producto con ese nombre en el menú");
        }
        return productoBuscado;
    }   

    public void RegistrarPedido(Pedido pedido)
    {
        Pedidos.Add(pedido);
    }
    
    public decimal ConsultarRecaudacion()
    {
        decimal suma=0;
        foreach(Pedido p in Pedidos)
        {
            if(p.EstadoDelPedido==EstadoPedido.Entregado){
                suma=suma+p.CalcularTotal();
            }
        }
        return suma;
    }
    
}