using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using todoapp.Models;
namespace todoapp.Models
{
    public interface Itarea
    {
        List<Tarea> MostrarTareas();
        void agregarTarea(Tarea tr);
        void eliminarTarea(int id);
        void ActualizarTask(Tarea tra);
        Tarea obtenertarea(int id);

    }
}