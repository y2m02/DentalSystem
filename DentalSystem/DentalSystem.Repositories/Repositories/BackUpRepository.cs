using System.Data.Entity;
using System.IO;
using DentalSystem.Contract.Repositories;
using DentalSystem.Entities.Context;

namespace DentalSystem.Repositories.Repositories
{
    public class BackUpRepository : IBackUpRepository
    {
        public void CreateBackUp(string path)
        {
            using (var context = new DentalSystemContext())
            {
                var exists = Directory.Exists(path);

                if (!exists)
                {
                    Directory.CreateDirectory(path);
                }

                var dbName = context.Database.Connection.Database;
                var sqlCommand =
                    $@"BACKUP DATABASE [{dbName}] TO  
                        DISK = N'{path}\Full Database Backup of {dbName}.bak' 
                        WITH NOFORMAT, 
                        NOINIT,  
                        NAME = N'Full Database Backup of {dbName}', 
                        SKIP, NOREWIND, NOUNLOAD,  
                        STATS = 10";
                context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sqlCommand);
            }
        }
    }
}