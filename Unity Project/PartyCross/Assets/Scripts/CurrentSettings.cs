using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSettings : MonoBehaviour
{
    public static bool PlayType;
    // Start is called before the first frame update
    void Start()
    {
        PlayType = false;
    }

    public static void IsSinglePlayer()
    {
        PlayType = false;
        Debug.Log(PlayType ? "true" : "false");
    }

    public static void IsMultiPlayer()
    {
        PlayType = true;
        Debug.Log(CurrentSettings.PlayType ? "true" : "false");
    } 
}
