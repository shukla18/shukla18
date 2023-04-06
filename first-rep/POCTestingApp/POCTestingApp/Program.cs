// See https://aka.ms/new-console-template for more information

using POCTestingApp;
using System.Net;
using System.Text;

internal class Program
{
    static void Main(string[] args)
    {
        string url = string.Format("https://dog.ceo/api/breeds/image/random");
        string details = CallRestMethod(url);

        Console.WriteLine(details);

        RestClient.Get(url, null);

        Console.ReadLine();
    }
     

    static string CallRestMethod(string url)
    {
        HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
        webrequest.Method = "GET";
        webrequest.ContentType = "application/x-www-form-urlencoded";
        HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
        Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
        StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
        string result = string.Empty;
        result = responseStream.ReadToEnd();
        webresponse.Close();
        return result;
    }
}
