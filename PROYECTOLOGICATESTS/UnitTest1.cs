namespace PROYECTOLOGICATESTS;
[TestFixture]

public class Tests
{

    [Test]
    public void Constructor_NombreVacio_LanzaArgumentNullException()
    {
            string nombre="";
            decimal precio = (decimal)1000;

            Assert.Throws<ArgumentNullException>(() => 
            new Comida(nombre, precio, true)
            );
    }



    [Test]
    public void Constructor_PrecioCero_LanzaArgumentException()
        {
            string nombre = "Café";
            decimal precioInvalido = (decimal)0;
            int volumen = 200;

            Assert.Throws<ArgumentException>(() => 
            new Bebida(nombre, precioInvalido, volumen)
            );
        }

    [Test]
    public void BebidaConstructor_VolumenFueraDeRango_LanzaArgumentException()
    {
        string nombre = "cafe";
        decimal precio = (decimal)1500;
        int volumen = 1500;

        Assert.Throws<ArgumentException>(() => new Bebida(nombre, precio, volumen));
    }



    [Test]

    public void CalcularPrecioFinal_Bebida_AplicaIvaReducido()
    {
        Bebida bebida = new Bebida("té", 100, 250);

        decimal precioFinal = bebida.CalcularPrecioFinal();


        Assert.That(precioFinal, Is.EqualTo(110.5));
    }

    
    [Test]
    public void CalcularPrecioFinal_ComidaVegana_AplicaIvaReducido()
    {

        Comida comidaVegana = new Comida("tofu", 100, true);
        decimal precioFinal = comidaVegana.CalcularPrecioFinal();

        Assert.That(precioFinal, Is.EqualTo(110.5));
    }

        [Test]
    public void CalcularPrecioFinal_ComidaNoVegana_AplicaIvaNormal()
    {
        Comida comidaComun = new Comida("tostado", 100, false);
        decimal precioFinal = comidaComun.CalcularPrecioFinal();
        Assert.That(precioFinal, Is.EqualTo(121));
    }

[Test]

    public void AgregarProducto_EstadoPendiente_CalculaTotalCorrectamente()
    {
        Pedido pedido = new Pedido();
        Bebida cafe = new Bebida("Café", 100, 200);
        Comida medialuna = new Comida("Medialuna", 100, false);
        pedido.AgregarProducto(cafe, 2); 
        pedido.AgregarProducto(medialuna, 1);
        decimal total = pedido.CalcularTotal();

        Assert.That(total, Is.EqualTo(342));
    }

    [Test]
    public void AgregarProducto_EstadoNoPendiente_LanzaInvalidOperationException()
    {
        Pedido pedido = new Pedido();
        pedido.CambiarEstado(EstadoPedido.EnPreparacion);
        Bebida cafe = new Bebida("café", 1000, 200);

        Assert.Throws<InvalidOperationException>(() => pedido.AgregarProducto(cafe, 1));
    }


    [Test]
    public void AgregarAlMenu_NombreDuplicado_LanzaArgumentException()
    {
        SistemaCafeteria sistema = new SistemaCafeteria();
        Bebida cafe1 = new Bebida("Café", 1500, 200);
        Comida cafe2 = new Comida("Café", 2000, true);

        sistema.AgregarAlMenu(cafe1);

        Assert.Throws<ArgumentException>(() => sistema.AgregarAlMenu(cafe2));
    }



[Test]
        public void FiltrarBebidas_Menu_RetornaSoloBebidas()
        {
            SistemaCafeteria sistema = new SistemaCafeteria();
            sistema.AgregarAlMenu(new Bebida("Agua", 800, 500));
            sistema.AgregarAlMenu(new Comida("alfajor", 1200, false));
            sistema.AgregarAlMenu(new Bebida("Café", 1500, 250));

            var bebidas = sistema.FiltrarBebidas();

            Assert.That(bebidas.Count, Is.EqualTo(2));
        }

        [Test]
        public void BuscarProducto_ProductoNoExiste_LanzaArgumentException()
        {
            SistemaCafeteria sistema = new SistemaCafeteria();
            sistema.AgregarAlMenu(new Bebida("Café", 1500, 250));

            Assert.Throws<ArgumentException>(() => sistema.BuscarProducto("Jugo"));
        }

        [Test]
        public void ConsultarRecaudacion_VariosPedidos_SumaSoloLosEntregados()
        {
            SistemaCafeteria sistema = new SistemaCafeteria();
            
            Comida pancho = new Comida("Pancho", 1000, false);
            
            Pedido pedido1 = new Pedido();
            pedido1.AgregarProducto(pancho, 1);
            pedido1.CambiarEstado(EstadoPedido.Entregado);
            Pedido pedido2 = new Pedido();
            pedido2.AgregarProducto(pancho, 1);
            Pedido pedido3 = new Pedido();
            pedido3.AgregarProducto(pancho, 2);
            pedido3.CambiarEstado(EstadoPedido.Entregado);
            sistema.RegistrarPedido(pedido1);
            sistema.RegistrarPedido(pedido2);
            sistema.RegistrarPedido(pedido3);

            decimal recaudacion = sistema.ConsultarRecaudacion();

            Assert.That(recaudacion, Is.EqualTo(3630));
        }


}
