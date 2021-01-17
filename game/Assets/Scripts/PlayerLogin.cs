using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Microsoft.Maps.Unity;
public class PlayerLogin : MonoBehaviour
{
    private List<string> locations = new List<string> {"CN Tower", "New York", "University of Waterloo", "Toronto", "Boston", "California", "Tokyo", "Grand Canyon", "Silicon Valley", "Berlin"};
    void Start()
    {
        var rand = new System.Random();
        string username = rand.Next().ToString();
        string password = rand.Next().ToString();
        var connectionProperties = ConnectionScript.CreateUser(new ConnectionScript.UserCredentials { username = username, password = password });
        var index = rand.Next(0, locations.Count);
        var search = locations[index];
        var coordinates = ConnectionScript.GetCoordinates(search, connectionProperties);
        Debug.Log(coordinates);
        GameObject map = GameObject.FindGameObjectWithTag("map");
        MapRenderer rend = map.GetComponent<MapRenderer>();
        rend.Center = new Microsoft.Geospatial.LatLon(coordinates.lat, coordinates.lng);
        
    }
}
