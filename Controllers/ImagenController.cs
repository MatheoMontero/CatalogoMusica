using CatalogoImagenes.Data;
using CatalogoImagenes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace CatalogoImagenes.Controllers
{
    public class ImagenController : Controller
    {

        private readonly BD_Context _context;

        public ImagenController(BD_Context contexto)
        {
            _context = contexto;
        }

        public ActionResult Catalogo()
        {
            using (SqlConnection con = new(_context.Conexion))
            {
                List<Imagen> lista_imagenes = new();
                using SqlCommand cmd = new("sp_Obtener_Imagenes", con);
                {
                    {
                        cmd.CommandType=System.Data.CommandType.StoredProcedure;
                        con.Open();

                        var dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            lista_imagenes.Add(new Imagen
                            {
                                Id_Imagen = (int)dr["Id_Imagen"],
                                Nombre = dr["Nombre"].ToString(),
                                Image = dr["Imagen"].ToString(),
                                Fuente = dr["Fuente"].ToString()
                            });
                        }
                    }
                }

                ViewBag.cat = lista_imagenes;

                return View();
            }
        }
    }
}
