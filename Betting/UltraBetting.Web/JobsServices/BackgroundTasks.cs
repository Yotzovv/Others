using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltraBetting.Data;
using UltraBetting.Service.Managers;

namespace UltraBetting.Api.JobsServices
{
    public class BackgroundTasks
    {
        private static readonly ILogger _logger;

        private static bool isProcessingDownloadXMLData;

        /// <summary>
        /// Jobs service thats being called minutely.
        /// Takes the responded XML from a url and stores the data in the db.
        /// </summary>
        /// <returns></returns>
        public static async Task ProcessDownloadXmlData()
        {
            if(BackgroundTasks.isProcessingDownloadXMLData)
            {
                // One at a time.
                return;
            }

            await BackgroundTasks.CollectXmlData();
        }

        /// <summary>
        /// Collects the XML from an url and stores it into the database.
        /// </summary>
        /// <returns></returns>
        private static async Task CollectXmlData()
        {
            try
            {
                BackgroundTasks.isProcessingDownloadXMLData = true;

                var db = new UltraBettingContext(GetBuilderOptions());

                await FeedManager.FeedDbFromXml(db);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            finally
            {
                BackgroundTasks.isProcessingDownloadXMLData = false;
            }
        }

        /// <summary>
        /// Return the builder options for our dbcontext.
        /// </summary>
        /// <returns></returns>
        private static DbContextOptions<UltraBettingContext> GetBuilderOptions()
        {
            var optionsBuilder = new DbContextOptionsBuilder<UltraBettingContext>();
            optionsBuilder.UseSqlServer("Server=(local)\\SQLEXPRESS;Database=UltraBetting;Trusted_Connection=True;Integrated Security=True;");

            return optionsBuilder.Options;
        }
    }
}
