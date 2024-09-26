using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using WebApi.Model;

namespace WebApi.Data
{
    public class ProductoData
    {
        public static bool Registrar(Producto oproducto)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarProducto", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", oproducto.nombre);
                cmd.Parameters.AddWithValue("@descripcion", oproducto.descripcion);
                cmd.Parameters.AddWithValue("@precio", oproducto.precio);
                cmd.Parameters.AddWithValue("@stock", oproducto.stock);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
        }
        public static bool Modificar(Producto oproducto)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))

            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarProducto", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", oproducto.id);
                cmd.Parameters.AddWithValue("@nombre", oproducto.nombre);
                cmd.Parameters.AddWithValue("@descripcion", oproducto.descripcion);
                cmd.Parameters.AddWithValue("@precio", oproducto.precio);
                cmd.Parameters.AddWithValue("@stock", oproducto.stock);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public static List<Producto> Listar()
        {
            List<Producto> olistProducto = new List<Producto>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerProductos", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            olistProducto.Add(new Producto()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                nombre = dr["nombre"].ToString(),
                                descripcion= dr["descripcion"].ToString(),
                                precio = Convert.ToInt32(dr["precio"]),
                                stock = Convert.ToInt32(dr["stock"])
                            });
                        }
                    }
                    return olistProducto;
                }
                catch (Exception ex)
                {

                    return olistProducto;
                }
            }
        }
        public static Producto Obtener(int id)
        {
            Producto oproducto = new Producto();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerProductoPorID", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oproducto = new Producto()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                nombre = dr["nombre"].ToString(),
                                descripcion = dr["descripcion"].ToString(),
                                precio = Convert.ToInt32(dr["precio"]),
                                stock = Convert.ToInt32(dr["stock"])
                            };
                        }
                    }
                    return oproducto;
                }
                catch (Exception ex)
                {

                    return oproducto;
                }
            }

        }
        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarProducto", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                try
                {
                
                    oConexion.Open();
                        cmd.ExecuteNonQuery();
                        return true;

                    }catch (Exception ex){
                        
                    return false;
                    }
                }
            }

        }
    }

