using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Net;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void SendHttpRequest (string url, string method, string headers, string body, out string response)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

        FillHeaders(headers, request);

        request.Method = method;

        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        {
            streamWriter.Write(body);
            streamWriter.Flush();
        }

        var httpResponse = (HttpWebResponse)request.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            response = streamReader.ReadToEnd();
        }
        httpResponse.Close();      
    }

    private static void FillHeaders(string headers, HttpWebRequest request)
    {
        try
        {
            var headersValues = headers.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < headersValues.Length; i++)
            {
                var header = headersValues[i].Split('=');
                var headerValue = header[1];

                SqlContext.Pipe.Send(String.Format("Parsed header {0} value is {1}", header[0], headerValue));

                if (header[0].Equals("Accept", StringComparison.InvariantCultureIgnoreCase))
                {
                    request.Accept = headerValue;
                }
                else if (header[0].Equals("Content-Type", StringComparison.InvariantCultureIgnoreCase))
                {
                    request.ContentType = headerValue;
                }
                else
                {
                    request.Headers.Add(header[0], headerValue);
                }
            }
        }
        catch (Exception ex)
        {         
            throw new Exception(String.Format("Ошибка чтения http заголовков\r\n: {0}", ex.ToString()));
        }
    }
}
