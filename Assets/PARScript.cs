using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PARScript : MonoBehaviour {
    private int PAR;
	// Use this for initialization
	void Awake () {
        //Looking back at this from an awake/not exhasted perspective - wow. I could have done this -way- better.
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            PAR = 2;
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            PAR = 11;
        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            PAR = 8;
        }
        if (SceneManager.GetActiveScene().name == "Level4")
        {
            PAR = 13;
        }
        if (SceneManager.GetActiveScene().name == "Level5")
        {
            PAR = 20;
        }
        if (SceneManager.GetActiveScene().name == "Level6")
        {
            PAR = 25;
        }
        if (SceneManager.GetActiveScene().name == "Level7")
        {
            PAR = 30;
        }
        if (SceneManager.GetActiveScene().name == "Level8")
        {
            PAR = 30;
        }
        if (SceneManager.GetActiveScene().name == "Level9")
        {
            PAR = 50;
        }
        if (SceneManager.GetActiveScene().name == "Level10")
        {
            PAR = 35;
        }
        if (SceneManager.GetActiveScene().name == "Level11")
        {
            PAR = 45;
        }
        if (SceneManager.GetActiveScene().name == "Level12")
        {
            PAR = 45;
        }
        if (SceneManager.GetActiveScene().name == "Level13")
        {
            PAR = 43;
        }
        if (SceneManager.GetActiveScene().name == "Level14")
        {
            PAR = 70;
        }
        if (SceneManager.GetActiveScene().name == "Level15")
        {
            PAR = 60;
        }


        GetComponent<UnityEngine.UI.Text>().text = ("" + PAR);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
