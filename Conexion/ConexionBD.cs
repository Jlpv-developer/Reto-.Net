namespace TiendaApi.Conexion
{
    public class ConexionBD
    {
        private string connectionString = string.Empty;
        public ConexionBD() {
            var constructor= new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            connectionString = constructor.GetSection("ConnectionStrings:Conexion").Value;
        }
        public string cadenaSQL()
        { return connectionString; }
    }
}
