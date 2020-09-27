using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contactos.Directorio
{
    public class Contacto
    {
        public List<DatosContac> datosContacs;

        public Contacto()
        {
            this.datosContacs = new List<DatosContac>()
            {
                new DatosContac(){ IdContacto = 1, Nombre = "Jose Mendoza", Telefono= "8299174886"},
                new DatosContac(){ IdContacto = 2, Nombre = "Calos Medina", Telefono= "8295716230"},
                new DatosContac(){ IdContacto = 3, Nombre = "Pablo Perez", Telefono= "8094216872"},
                new DatosContac(){ IdContacto = 4, Nombre = "Fracis Fulgencio", Telefono= "8293804780"},
                new DatosContac(){ IdContacto = 5, Nombre = "Karen Perez", Telefono= "8297280833"},
                new DatosContac(){ IdContacto = 6, Nombre = "Juan Lopez", Telefono= "8095682222"},
                new DatosContac(){ IdContacto = 7, Nombre = "Carlos Trujillo", Telefono= "8093214567"},
                new DatosContac(){ IdContacto = 8, Nombre = "Estefany Duate ", Telefono= "8299097861"},
                new DatosContac(){ IdContacto = 9, Nombre = "Laura Martinez", Telefono= "8091112222"},
                new DatosContac(){ IdContacto = 10, Nombre = "Cesar Estrada", Telefono= "8499760125"}
            };
        }
    }
}
