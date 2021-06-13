using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UltraBetting.Data;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Net;
using System.IdentityModel.Tokens.Jwt;
using System.Xml.Serialization;
using UltraBetting.Data.Models;
using Newtonsoft.Json;
using UltraBetting.Service.Models;
using System.Dynamic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;
using UltraBetting.Service.Interfaces;

namespace UltraBetting.Service.Managers
{
    public class FeedManager : IFeedManager
    {
        private readonly UltraBettingContext dbContext;

        /// <summary>
        /// This url given in the task.
        /// </summary>
        private static readonly string url = @"https://sports.ultraplay.net/sportsxml?clientKey=b4dde172-4e11-43e4-b290-abdeb0ffd711&sportId=2357&days=2";

        public FeedManager(UltraBettingContext context)
        {
            this.dbContext = context;
        }

        public FeedManager()
        {
        }

        /// <summary>
        /// Gets the XML from the URL and stores it in the DB.
        /// </summary>
        /// <param name="db">The Database context</param>
        /// <returns></returns>
        public static async Task FeedDbFromXml(UltraBettingContext db)
        {
            var xml = await GetXml();

            await UpdateSports(db, xml);
        }

        /// <summary>
        /// Makes a request and collects the XML from the response.
        /// The URL is given in the task and is always the same.
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetXml()
        {
            string xml = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                xml = await reader.ReadToEndAsync();
            }

            return xml;
        }

        /// <summary>
        /// Maps XML to C# Models.
        /// </summary>
        /// <typeparam name="T">The base collection model</typeparam>
        /// <param name="xml">The XML to be mapped</param>
        /// <returns></returns>
        public static T Deserialize<T>(string xml) where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(xml))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        /// <summary>
        /// Saves the deserialized xml into the db.
        /// </summary>
        /// <param name="db"></param>
        /// <param name="xml"></param>
        /// <returns></returns>
        public static async Task UpdateSports(UltraBettingContext db, string xml)
        {
            var sportsCollection = Deserialize<SportsCollection>(xml);

            db.Sports.RemoveRange(db.Sports);

            db.Sports.AddRange(sportsCollection.Sports);

            await db.SaveChangesAsync();
        }
    }
}
