using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class TareaBLL
    {
        BaseDeDatosEntities bde = new BaseDeDatosEntities();

        public void Add(string titulo, string cuerpo, int estado, int categoria, DateTime creacion, DateTime vencimiento)
        {
            Tarea tarea = new Tarea();
            tarea.Titulo = titulo;
            tarea.Cuerpo = cuerpo;
            tarea.IdCategoria = categoria;
            tarea.Estado = estado;
            tarea.FechaCreacion = creacion;
            tarea.FechaVencimiento = vencimiento;

            bde.Tarea.Add(tarea);
            bde.SaveChanges();
        }

        public List<Tarea> GetAll()
        {
            List<Tarea> tareas = new List<Tarea>();

            tareas = bde.Tarea.ToList();
            return tareas;
        }
    }
}
