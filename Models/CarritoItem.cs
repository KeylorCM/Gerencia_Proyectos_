using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gerencia_Proyectos_.Models
{
    public class CarritoItem
    {
        private MenuProductos _producto;
        private int _cantidad;


        public CarritoItem()
        {

        }

        public CarritoItem(MenuProductos producto, int cantidad)
        {
            this.Producto1 = producto;
            this.Cantidad1 = cantidad;
            //
        }

        public MenuProductos Producto { get => Producto1; set => Producto1 = value; }
        public int Cantidad { get => Cantidad1; set => Cantidad1 = value; }
        public MenuProductos Producto1 { get => _producto; set => _producto = value; }
        public int Cantidad1 { get => _cantidad; set => _cantidad = value; }
    }
}