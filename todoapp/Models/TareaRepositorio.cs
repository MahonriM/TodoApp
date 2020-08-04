using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using todoapp.Models;
using System.Data;
using System.Data.Sql;
using todoapp.Utilerias;
using System.Data.SqlClient;

namespace todoapp.Models
{
    public class TareaRepositorio : Itarea
    {
        public void ActualizarTask(Tarea tra)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id",tra.id));
            parametros.Add(new SqlParameter("@tarea", tra.tarea));
            BaseHelper.ejecutarConsulta("spupdatetask", CommandType.StoredProcedure, parametros);
        }

        public void agregarTarea(Tarea tr)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", tr.id));
            parametros.Add(new SqlParameter("@tarea", tr.tarea));
            BaseHelper.ejecutarConsulta("spaddtask", CommandType.StoredProcedure, parametros);

        }

        public void eliminarTarea(int id)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id", id));
            BaseHelper.ejecutarConsulta("spdelete", CommandType.StoredProcedure, parametros);

        }

        public List<Tarea> MostrarTareas()
        {
            List<Tarea> lstTareas = new List<Tarea>();
            DataTable tbl = new DataTable();
            tbl = BaseHelper.ejecutarSelect("spmostrartareas", CommandType.StoredProcedure);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                Tarea tarea1 = new Tarea();
                tarea1.id = int.Parse(tbl.Rows[i]["id"].ToString());
                tarea1.tarea = (tbl.Rows[i]["tarea"].ToString());
                lstTareas.Add(tarea1);
            }
            return lstTareas;

        }
        public Tarea obtenertarea(int id)
        {
            Tarea tarea;
            DataTable dttareas = new DataTable();
            List<SqlParameter> parametros = new List<SqlParameter>();

            parametros.Add(new SqlParameter("@id", id));
            dttareas = BaseHelper.ejecutarSelect("sptareaConsultarPorID", CommandType.StoredProcedure, parametros);
            if (dttareas.Rows.Count > 0)
            {
                tarea = new Tarea();
                tarea.id = int.Parse(dttareas.Rows[0]["id"].ToString());
                tarea.tarea = dttareas.Rows[0]["tarea"].ToString();
                return tarea;
            }
            else
            {

                return null;
            }
        }

    }
}