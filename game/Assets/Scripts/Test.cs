using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        // A way to connect given a username and password.
        var connectionProperties = ConnectionScript.Connect(new ConnectionScript.UserCredentials { username = "someThing", password = "otherThing" });
        Debug.Log("UUID: " + connectionProperties.uuid + " | Token: " + connectionProperties.token);

        // A way to add a user given a username and password.
        /*var connectionProperties2 = ConnectionScript.CreateUser(new ConnectionScript.UserCredentials { username = "fgnfgndfb", password = "ensrdgesf" });
        Debug.Log("UUID: " + connectionProperties2.uuid + " | Token: " + connectionProperties2.token);*/

        // A way to find the coordinates of searches.
        var search = "Toronto";
        var coordinates = ConnectionScript.GetCoordinates(search, connectionProperties);
        Debug.Log("Search: " + search + " | Lat: " + coordinates.lat + " | Lng: " + coordinates.lng);
    }
}
