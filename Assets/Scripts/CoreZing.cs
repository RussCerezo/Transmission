using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreZing : MonoBehaviour {
    public string Sending;
    AudioSource AS;
    // Use this for initialization
    void Start () {
        AS = GetComponent<AudioSource>();
        StartCoroutine("Zing");
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Zing()
    {
        
        StartCoroutine("TriggerOther");
        yield return new WaitForSeconds(1f);
        this.tag = "Untagged";
    }

    IEnumerator TriggerOther()
    {
        
        yield return new WaitForSeconds(3f);
        StartCoroutine("Zing");
        AS.Play();
        for (int i = 0; i < 4; i++)
        {
            Vector2 dirfire = transform.position;
            if (i == 0) { dirfire = -Vector2.up; }
            else if (i == 1) { dirfire = Vector2.up; }
            else if (i == 2) { dirfire = Vector2.left; }
            else if (i == 3) { dirfire = -Vector2.left; }
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dirfire);
            hit.collider.GetComponent<Pulse>().FlashPulse();
            hit.collider.GetComponent<Pulse>().ReceivingReceiver = Sending;
            hit.collider.GetComponent<Pulse>().NotifyParent();

        }
    }
}
