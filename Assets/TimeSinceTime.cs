using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSinceTime : MonoBehaviour
{

    GameObject Eng;
    // Use this for initialization
    void Awake()
    {
        Eng = GameObject.FindGameObjectWithTag("GenCore");
        GetComponent<UnityEngine.UI.Text>().text = ("Time: " + Eng.GetComponent<ClickMonitor>().Times);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
