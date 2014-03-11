namespace CloudOCR.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CloudOCR.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CloudOCR.Models.ApplicationDbContext context)
        {
            this.AddUserAndRoles();
        }

        bool AddUserAndRoles()
        {
            bool success = false;

            var idManager = new CloudOCR.Models.IdentityManager();
            success = idManager.CreateRole("Administrador");
            if (!success == true) return success;

            success = idManager.CreateRole("PermisoEdicion");
            if (!success == true) return success;

            success = idManager.CreateRole("Usuario");
            if (!success) return success;


            var newUser = new CloudOCR.Models.ApplicationUser()
            {
                UserName = "RSalas",
                FirstName = "Rene",
                LastName = "Salas",
                Email = "luresalo@gmail.com"
            };

            // Be careful here - you  will need to use a password which will 
            // be valid under the password rules for the application, 
            // or the process will abort:
            success = idManager.CreateUser(newUser, "123456**");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "Administrador");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "PermisoEdicion");
            if (!success) return success;

            success = idManager.AddUserToRole(newUser.Id, "Usuario");
            if (!success) return success;

            return success;
        }
    }
}
