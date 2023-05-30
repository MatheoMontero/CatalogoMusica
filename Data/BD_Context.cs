namespace CatalogoImagenes.Data
{
    public class BD_Context
    {
        public BD_Context(string valor) => Conexion = valor;
        public string Conexion { get;}
    }
}
