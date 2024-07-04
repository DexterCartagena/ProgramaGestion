using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAPA_DATOS;
using System.Data;
using System.Windows.Forms;

namespace CAPA_NEGOCIO
{
    public class CN_PRODUCTBACK
    {
        CD_PRODUCTBACK cdproductback = new CD_PRODUCTBACK();
        public DataTable listRegistrosOficiales()
        {
            DataTable dt= new DataTable();
            try
            {
                dt = cdproductback.listRegistrosOficial();
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error CAPA-CN-cdproductback : " + ex.Message);
                return dt;
            }
        }
        public bool agregarProductBack(string item, string detalle, string creacion, string fin, int prioridad, int estadoof)
        {
            try
            {
                if (cdproductback.AgregarRegistroProductBack(item, detalle, creacion, fin, prioridad, estadoof))
                {
                    MessageBox.Show("Registro Exitoso");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error con el envio de datos, revise los datos ingresados");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error CAPA-CN-agregarProductBack : " + ex.Message);
                return false;
            }
        }
        public DataTable listPrioridad()
        {
            DataTable dt= new DataTable();
            try
            {
                dt = cdproductback.listPrioridad();
                return dt;
            }catch(Exception ex)
            {
                MessageBox.Show("Error CAPA-CN-listPrioridad : "+ex.Message);
                return dt;
            }
        }
        public bool modfRegProducBack(int cod, string item, string detalle, string creacion, string fin, int estado, int prioridad, int estadoof)
        {
            try
            {
                if (cdproductback.ModifRegProducBack(cod, item, detalle, creacion, fin, estado, prioridad, estadoof))
                {
                    MessageBox.Show("Modificacion Exitosa");
                    return true;
                }
                else
                {
                    MessageBox.Show("Error en el envio de datos, revise los datos ingresados");
                    return false;
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error CAPA-CN-modfRegProducBac : " + ex.Message);
                return false;
            }
        }
        public bool eliminarRegProducBack(int cod)
        {
            try
            {
                if (cdproductback.EliminarRegProducBack(cod))
                {
                    MessageBox.Show("Registro Eliminado");
                    return true;
                }
                else
                {
                    MessageBox.Show("El registro especificado, no se enuentra en los registros");
                    return false;
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Erro CAPA-CN-eliminarRegProducBack : " + ex.Message);
                return false;
            }
        }
    }
}
