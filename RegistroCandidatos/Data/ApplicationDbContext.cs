using Microsoft.EntityFrameworkCore;

namespace RegistroCandidatos.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        //Insertar aqui los modelos para que puedan ser afectados por las migraciones.




    }
}
