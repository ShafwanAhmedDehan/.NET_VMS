using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLogicLayerGeneralUser.Service.SOSservice
{
    public class SOSsend
    {
        /*public static  string SOSsend01(string SOScontact)
        {
            var location = new GeoCoordinateWatcher();
            location.TryStart(false, TimeSpan.FromMilliseconds(20000));
            GeoCoordinate LocationCoordinate = location.Position.Location;
            if (LocationCoordinate.IsUnknown != true)
            {
                double Latitude = LocationCoordinate.Latitude;
                double Longitude = LocationCoordinate.Longitude;
                string result = "";
                WebRequest request = null;
                HttpWebResponse response = null;
                try
                {
                    String to = SOScontact;
                    String token = "838611234516924226255819434dff3b74545c106fa94d22105b";
                    String message = System.Uri.EscapeUriString("An Emergency Response Request is sent. Location : Latitude = " + Latitude + ". Longitude : "+Longitude+
                        " Please try to response");
                    String url = "http://api.greenweb.com.bd/api.php?token=" + token + "&to=" + to + "&message=" + message;
                    request = WebRequest.Create(url);

                    response = (HttpWebResponse)request.GetResponse();
                    Stream stream = response.GetResponseStream();
                    Encoding ec = System.Text.Encoding.GetEncoding("utf-8");
                    StreamReader reader = new
                    System.IO.StreamReader(stream, ec);
                    result = reader.ReadToEnd();
                    Console.WriteLine(result);
                    reader.Close();
                    stream.Close();
                    return result;
                }
                catch (Exception exp)
                {
                    return exp.ToString();
                }
                finally
                {
                    if (response != null)
                    {
                        response.Close();
                    }
                }
            }
            else
            {
                return ("Location Not Found");
            }
        }*/
        public static string SOSsend01 (string SOScontact)
        {
            string IP01;
            string IpURL = "https://api.my-ip.io/ip.txt";
            HttpClient client = new HttpClient();
            try
            {
                var IPresponse = client.GetAsync(IpURL).Result;
                if (IPresponse.IsSuccessStatusCode)
                {
                    IP01 = IPresponse.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return IPresponse.StatusCode.ToString();
                }
            }
            catch(Exception ex)
            {
                return ex.Message;
            }

            string apiUrl = $"https://api.ipbase.com/v2/info?apikey=ipb_live_QdgjDeQHCxx7X4Iag2NJy4e6yFiw96BcdQIXjZ4q&language=en&ip={IP01}";

            try
            {
                 var response = client.GetAsync(apiUrl).Result;

                 if (response.IsSuccessStatusCode)
                 {
                    var responseBody = response.Content.ReadAsStringAsync().Result;
                    JObject ResponseObject = JObject.Parse(responseBody);
                    double Longitude = (double)ResponseObject["data"]["location"]["longitude"];
                    double Latitude = (double)ResponseObject["data"]["location"]["latitude"];
                    string value = Longitude.ToString() + Latitude.ToString();
                    string result = "";
                    WebRequest request = null;
                    HttpWebResponse response01 = null;
                    try
                    {
                        String to = SOScontact;
                        String token = "838611234516924226255819434dff3b74545c106fa94d22105b";
                        String message = System.Uri.EscapeUriString("An Emergency Response Request is sent. Location : Latitude = " + Latitude + ". Longitude : " + Longitude +
                            " Please try to response");
                        String url = "http://api.greenweb.com.bd/api.php?token=" + token + "&to=" + to + "&message=" + message;
                        request = WebRequest.Create(url);

                        response01 = (HttpWebResponse)request.GetResponse();
                        Stream stream = response01.GetResponseStream();
                        Encoding ec = System.Text.Encoding.GetEncoding("utf-8");
                        StreamReader reader = new
                        System.IO.StreamReader(stream, ec);
                        result = reader.ReadToEnd();
                        reader.Close();
                        stream.Close();
                        return result;
                    }
                    catch (Exception exp)
                    {
                        return exp.ToString();
                    }
                    finally
                    {
                        if (response01 != null)
                        {
                            response01.Close();
                        }
                    }
                 }
                 else
                 {
                    return response.StatusCode.ToString();
                 }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
