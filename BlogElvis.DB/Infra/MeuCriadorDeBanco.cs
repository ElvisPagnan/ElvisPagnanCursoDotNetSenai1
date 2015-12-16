using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogElvis.DB.Infra
{
    class MeuCriadorDeBanco:DropCreateDatabaseIfModelChanges<ConexaoBanco>
    {
        protected override void Seed(ConexaoBanco context)
        {
            context.Usuarios.Add(new Classes.Usuario { Login = "ADM", Nome = "Administrator", Senha = "admin" });
            base.Seed(context);
        }

    }
}
