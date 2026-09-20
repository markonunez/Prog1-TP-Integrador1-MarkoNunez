Sistema de Gestión de Cafetería

Proyecto académico desarrollado en C# para la gestión de productos, pedidos y cálculo de precios en una cafetería.

Descripción

El sistema permite trabajar con distintos tipos de productos, gestionar pedidos y calcular sus precios finales según las características de cada producto.

El proyecto fue desarrollado aplicando conceptos de Programación Orientada a Objetos, estructuras de datos y pruebas unitarias.

Tecnologías

* C#
* .NET
* NUnit
* LINQ

Conceptos aplicados

* Programación Orientada a Objetos
* Clases abstractas
* Herencia
* Interfaces
* Polimorfismo
* Encapsulamiento
* Enumeraciones (`enum`)
* Colecciones (`List<T>`)
* LINQ
* Manejo de excepciones
* Validación de datos
* Testing unitario

Estructura del proyecto

PROYECTOLOGICA/
├── Bebida.cs
├── Comida.cs
├── IVendible.cs
├── ItemPedido.cs
├── Pedido.cs
├── Producto.cs
└── SistemaCafeteria.cs

PROYECTOLOGICATESTS/
└── UnitTest1.cs


PROYECTOLOGICA

Contiene la lógica principal del sistema, incluyendo la gestión de productos, pedidos y cálculo de precios.

PROYECTOLOGICATESTS

Contiene las pruebas unitarias utilizadas para verificar el comportamiento de las distintas funcionalidades del sistema.

Funcionalidades

* Gestión de productos.
* Diferenciación entre bebidas y comidas.
* Cálculo de precios según el tipo de producto.
* Creación y gestión de pedidos.
* Control del estado de los pedidos.
* Búsqueda y filtrado de productos.
* Cálculo del total de los pedidos.
* Cálculo de la recaudación.
* Validación de datos.
* Pruebas unitarias.

Testing

El proyecto incluye pruebas unitarias desarrolladas con NUnit para verificar diferentes comportamientos del sistema, incluyendo:

* Validación de productos.
* Cálculo de precios.
* Gestión de pedidos.
* Estados de los pedidos.
* Búsqueda y filtrado.
* Cálculo de totales y recaudación.

Objetivo

Aplicar conceptos de programación y diseño orientado a objetos mediante el desarrollo de un sistema de gestión, incorporando además pruebas unitarias para validar su funcionamiento.
