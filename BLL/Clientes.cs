using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BLL
{
    public class Clientes
    {
        public static ENT.Result Add(ENT.Clientes clientes)
        {
            ENT.Result result = new ENT.Result();
            try
            {
                using (DAL.SeguritasEntities context = new DAL.SeguritasEntities())
                {
                    var query = context.ClientesAdd(clientes.Nombre);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No inserto correctamente.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ENT.Result Update(ENT.Clientes clientes)
        {
            ENT.Result result = new ENT.Result();
            try
            {
                using (DAL.SeguritasEntities context = new DAL.SeguritasEntities())
                {
                    var query = context.ClientesUpdate(clientes.IdClientes,clientes.Nombre);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "El cliente no se actualizo correctamente.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ENT.Result Delete(int IdClientes)
        {
            ENT.Clientes clientes = new ENT.Clientes();
            clientes.IdClientes = IdClientes;
            ENT.Result result = new ENT.Result();
            try
            {
                using (DAL.SeguritasEntities context = new DAL.SeguritasEntities())
                {
                    var query = context.ClientesDelete(clientes.IdClientes);
                    {

                        if (query > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se pudo eliminar correctamente.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ENT.Result GetAll()
        {

            ENT.Result result = new ENT.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DAL.Conexion.GetConnectionString()))
                {
                    string query = "ClientesGetAll";
                    using (SqlCommand ComandoGetAll = new SqlCommand())
                    {

                        ComandoGetAll.Connection = context;
                        ComandoGetAll.CommandText = query;

                        ComandoGetAll.CommandType = CommandType.StoredProcedure;

                        DataTable tabla = new DataTable();
                        SqlDataAdapter Adaptador = new SqlDataAdapter(query, context);
                        Adaptador.Fill(tabla);

                        if (tabla.Rows.Count > 0) 
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow Row in tabla.Rows)
                            {
                                ENT.Clientes clientes = new ENT.Clientes();
                                clientes.IdClientes = int.Parse(Row[0].ToString());
                                clientes.Nombre = Row[1].ToString();
                                clientes.FechaModificacion = Row[2].ToString();

                                result.Objects.Add(clientes);
                            }
                            result.Correct = true;

                        }
                        else
                        {

                            result.Correct = false;
                            result.ErrorMessage = " No se encontro el registro";
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

        }
        public static ENT.Result GetById(ENT.Clientes clientes)
        {
            ENT.Result result = new ENT.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DAL.Conexion.GetConnectionString()))
                {
                    string query = "ClientesGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdClientes", SqlDbType.VarChar);
                        collection[0].Value = clientes.IdClientes;
                        cmd.Parameters.AddRange(collection);
                        DataTable tableCliente = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableCliente);

                        if (tableCliente.Rows.Count > 0)
                        {
                            DataRow row = tableCliente.Rows[0];

                            ENT.Clientes Clientes = new ENT.Clientes();
                            Clientes.IdClientes = int.Parse(row[0].ToString());
                            Clientes.Nombre = row[1].ToString();
                            Clientes.FechaModificacion = row[2].ToString();

                            result.Object = Clientes; //boxing

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;
        }
    }
}
