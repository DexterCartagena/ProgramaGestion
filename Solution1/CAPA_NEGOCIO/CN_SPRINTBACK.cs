using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CAPA_DATOS;
using System.Windows.Forms;

namespace CAPA_NEGOCIO
{
    public class CN_SPRINTBACK
    {
        CD_SPRINTBACK cdsprintback = new CD_SPRINTBACK();


        public DataTable ListRegSprintBack()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = cdsprintback.ListSprintBack();
                return dt;

            }catch(Exception ex)
            {
                MessageBox.Show("Error capa CN-ListRegSprintBack : " + ex.Message);
                return dt;
            }
        }
        public DataTable listPrioridad()
        {
            DataTable dt2= new DataTable();
            try
            {
                dt2 = cdsprintback.listPrioridad();
                return dt2;
            }catch(Exception ex)
            {
                MessageBox.Show("ERROR CAPA-CN listPrioridad : " + ex.Message);
                return dt2;
            }
        }
        public DataTable listArea()
        {
            DataTable dt3 = new DataTable();
            try
            {
                dt3 = cdsprintback.listArea();
                return dt3;
            }catch(Exception ex)
            {
                MessageBox.Show("ERROR CAPA-CN listArea : " + ex.Message);
                return dt3;
            }
        }
        public DataTable listEncargado()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = cdsprintback.listEncargado();
                return dt;
            }catch(Exception ex)
            {
                MessageBox.Show("ERROR CAPA-CN listEncrgado : " + ex.Message);
                return dt;
            }
        }
        //public bool agregarRegSprint(int codrdp, int prioridad, string detalle, int area, int encargado, string inicio, string fin, int estado, int estadoof)
        //{
        //    try
        //    {
        //        if(cdsprintback.)
        //    }catch(Exception ex)
        //    {

        //    }
        //}
    }
}
