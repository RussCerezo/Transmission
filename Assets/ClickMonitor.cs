using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMonitor : MonoBehaviour {
    public int clicks;
    public float Times;
    private float FirstClickTime, StartTime;

    // Use this for initialization
    void Start () {
        StartTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        float CurTime = Time.time - StartTime;
		if (Input.GetMouseButtonDown(0))
        {
            clicks++;
            if (clicks == 1)
            {
                FirstClickTime = CurTime;
            }
        }
        Times = CurTime - FirstClickTime;
	}
}
