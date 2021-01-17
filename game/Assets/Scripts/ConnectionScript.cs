using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using UnityEngine;

internal static class ConnectionScript
{
    public const string SiteUrl = "https://vrspike-okxmbxloca-ue.a.run.app/";

    private static readonly HttpClient client = new HttpClient();

    static ConnectionScript()
    {
        client.BaseAddress = new Uri(SiteUrl);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    [Serializable]
    internal sealed class ConnectionProperties
    {
        public string uuid;

        public string token;
    }

    [Serializable]
    internal sealed class UserCredentials
    {
        public string username;

        public string password;
    }

    /// <summary>
    /// Connects a user to the server given a username and password.
    /// </summary>
    public static ConnectionProperties Connect(UserCredentials credentials)
    {
        try
        {
            var response = client.PostAsync("/login",
                new StringContent(JsonUtility.ToJson(credentials), Encoding.UTF8, "application/json"))
                .Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return JsonUtility.FromJson<ConnectionProperties>(result);
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }

        return null;
    }

    /// <summary>
    /// Creates a new user in the server given a username and password.
    /// </summary>
    public static ConnectionProperties CreateUser(UserCredentials credentials)
    {
        try
        {
            var response = client.PostAsync("/create-user",
                new StringContent(JsonUtility.ToJson(credentials), Encoding.UTF8, "application/json"))
                .Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return JsonUtility.FromJson<ConnectionProperties>(result);
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }

        return null;
    }

    [Serializable]
    internal sealed class Coordinates
    {
        public double lat;

        public double lng;
    }

    public static Coordinates GetCoordinates(string search, ConnectionProperties connectionProperties)
    {
        using (var jwtClient = new HttpClient())
        {
            jwtClient.BaseAddress = new Uri(SiteUrl);
            jwtClient.DefaultRequestHeaders.Accept.Clear();
            jwtClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            jwtClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", connectionProperties.token);

            try
            {
                var newSearch = search.Replace(" ", "%20");
                newSearch = newSearch.Replace("-", "%2D");
                newSearch = newSearch.Replace(".", "%2E");

                var response = jwtClient.GetAsync("/get-location?search=" + newSearch).Result;

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    return JsonUtility.FromJson<Coordinates>(result);
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

            return null;
        }
    }
}
