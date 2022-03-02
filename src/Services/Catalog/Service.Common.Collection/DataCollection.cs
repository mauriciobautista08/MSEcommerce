using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Common.Collection
{
    public class DataCollection<T>
    {
        // Valida si tenemos records en el tabla Productos
        public bool HasItems
        {
            get
            {
                return Items != null && Items.Any();
            }
        }


        //Listado de Item que traigo de la paginación
        public IEnumerable<T> Items { get; set; }
        // Cantidad de registros 
        public int Total { get; set; }
        // La pagina en la que se encuentra, o donde esta paginando
        public int Page { get; set; }
        // Cantidad de paginas que se crearon a tra ves de la paginacion
        public int Pages { get; set; }
    }
}
