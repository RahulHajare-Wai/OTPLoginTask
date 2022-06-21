using OTPLoginTask.Models.Notifications;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTPLoginTask.Databases
{
    public class NotificationDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public NotificationDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(NotificationModel).Name))
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(NotificationModel)).ConfigureAwait(false);

                initialized = true;
            }
        }

        public Task<List<NotificationModel>> getNotifications()
        {
            return Database.Table<NotificationModel>().ToListAsync();
        }

        public Task<int> SaveNotifications(NotificationModel notification)
        {
            return Database.InsertAsync(notification);
        }

        public Task<int> UpdateNotifications(NotificationModel notification)
        {
            return Database.UpdateAsync(notification);
        }

        public Task<int> DeleteNotifications(NotificationModel notification)
        {
            return Database.DeleteAsync(notification);
        }
    }
}
