using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace wsa_webapi
{
    public class SqlHelper
    {
        public static string GetAnnotationImage(string annotationid)
        {
            using(var conn = new SqlConnection(GlobalProperties.DBConnectionString))
            {
                conn.Open();

                Guid id;
                if (string.IsNullOrEmpty(annotationid) || !Guid.TryParse(annotationid, out id))
                    return "";

                var cmd = new SqlCommand($"select 'data:' + mimetype + ';base64,' + documentbody as documentbody from annotation where annotationid='{annotationid}'", conn);
                return $"{cmd.ExecuteScalar()}";
            }
        }

        public static List<string> GetAnnotationImagesById(string sid)
        {
            using (var conn = new SqlConnection(GlobalProperties.DBConnectionString))
            {
                conn.Open();

                Guid id;
                if (string.IsNullOrEmpty(sid) || !Guid.TryParse(sid, out id))
                    return new List<string>();

                List<string> imgs = new List<string>();
                var cmd = new SqlCommand($"select 'data:' + mimetype + ';base64,' + documentbody as documentbody from annotation where objectid='{sid}'", conn);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while(reader.Read())
                    {
                        imgs.Add(reader.GetString(0));
                    }
                }
                reader.Close();

                return imgs;
            }
        }
    }
}
