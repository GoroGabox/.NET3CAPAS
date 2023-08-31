using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class CategoriaBLL
    {
        BaseDeDatosEntities bde = new BaseDeDatosEntities();

        public void Add(string element)
        {
            //Validar duplicados
            if (this.Find(element)==false)
            {
                Categoria categoria = new Categoria();
                categoria.Nombre = element;

                bde.Categoria.Add(categoria);
                bde.SaveChanges();
            }
        }

        public List<Categoria> GetAll()
        {
            List<Categoria> categorias = new List<Categoria>();

            categorias = bde.Categoria.ToList();

            return categorias;
        }

        public bool Find(string nombre)
        {
            Categoria categoria = bde.Categoria.FirstOrDefault(c => c.Nombre == nombre);
            if (categoria== null)
            {
                return false;
            }
            return true;
        }
    }
}
