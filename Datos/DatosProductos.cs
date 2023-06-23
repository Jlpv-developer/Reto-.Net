using System.Data;
using System.Data.SqlClient;
using TiendaApi.Conexion;
using TiendaApi.Model;

namespace TiendaApi.Datos
{
    public class DatosProductos
    {
        ConexionBD cn = new ConexionBD();
        public async Task <List<ModeloProducto>> MostrarRecibo()
        {
            var lista = new List<ModeloProducto>();
            using(var sql= new SqlConnection(cn.cadenaSQL()))
                
            {
                using (var cmd = new SqlCommand("MostrarRecibo", sql))
                
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using(var item= await cmd.ExecuteReaderAsync()) 
                    {
                        while (await item.ReadAsync())
                        {
                            var mproductos = new ModeloProducto();
                            mproductos.id = (int)item["Id"];
                            mproductos.monto = (decimal)item["Monto"];
                            mproductos.titulo = (string)item["Titulo"];
                            mproductos.descripcion = (string)item["Descripcion"];
                            mproductos.nombres= (string)item["Nombres"];
                            mproductos.direccion = (string)item["Direccion"];
                            lista.Add(mproductos);
                        }
                    }
               }
            }
            return lista;
        }
        public async Task InsertarRecibo(ModeloProducto parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarRecibo", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue
                         ("@Descripcion",parametros.descripcion);
                    cmd.Parameters.AddWithValue("@Nombres", parametros.nombres);
                    cmd.Parameters.AddWithValue("@Titulo", parametros.titulo);
                    cmd.Parameters.AddWithValue
                        ("monto",parametros.monto);
                    cmd.Parameters.AddWithValue("@Direccion",parametros.direccion);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();


                }
            }
        }
    }
}
