using System.Data.Entity;
using System.IO;
using System.Security.AccessControl;
using DentalSystem.Contract.Repositories;
using DentalSystem.Entities.Context;

namespace DentalSystem.Repositories.Repositories
{
    public class BackUpRepository : IBackUpRepository
    {
        public void CreateBackUp(string path, string sqlServerName)
        {
            using (var context = new DentalSystemContext())
            {
                var folder = $@"{path}\DentalSystemDBBackUp".Replace(@"\\", @"\");
                var exists = Directory.Exists(folder);

                if (!exists) Directory.CreateDirectory(folder);

                var directoryInfo = new DirectoryInfo(folder);
                var directorySecurity = directoryInfo.GetAccessControl();
                //var currentUserIdentity = WindowsIdentity.GetCurrent();
                var fileSystemRule = new FileSystemAccessRule(sqlServerName,
                    FileSystemRights.FullControl,
                    InheritanceFlags.ObjectInherit |
                    InheritanceFlags.ContainerInherit,
                    PropagationFlags.None,
                    AccessControlType.Allow);

                directorySecurity.AddAccessRule(fileSystemRule);
                directoryInfo.SetAccessControl(directorySecurity);

                var dbName = context.Database.Connection.Database;
                var sqlCommand =
                    $@"BACKUP DATABASE [{dbName}] TO  
                        DISK = N'{folder}\Full Database Backup of {dbName}.bak' 
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