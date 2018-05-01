using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndStuff : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		transform.localPosition = new Vector3(0, 0, 0);
        //transform.localScale = new Vector3(Screen.width, Screen.height, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Application.Quit();
        }
	}

    private void OnMouseDown()
    {
        
    }
}
