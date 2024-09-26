using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpPost(Name = "agregarProducto")]
        public bool Post([FromBody] Producto oproducto)
        {
            return ProductoData.Registrar(oproducto);
        }
        [HttpGet(Name = "listarProducto")]
        public List<Producto> Get()
        {
            return ProductoData.Listar();
        }
        [HttpGet("{id}",Name ="ListarPorId")]
        public Producto Get(int id)
        {
            return ProductoData.Obtener(id);
        }

        [HttpPut(Name = "editarProducto")]
        public bool Put([FromBody] Producto oproducto)
        {
            return ProductoData.Modificar(oproducto);
        }
        [HttpDelete(Name="eliminarProducto")]
        public bool Delete(int id)
        {
            return ProductoData.Eliminar(id);
        }
    }
}