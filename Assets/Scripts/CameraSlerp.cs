using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSlerp : MonoBehaviour {
    public Transform LastBlock;
    public Vector3 CurPos;
	// Use this for initialization
	void Start () {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (LastBlock == null)
        {
            LastBlock = GameObject.FindWithTag("LastBlock").transform;
        }
        CurPos = transform.position;
    }

    void LateUpdate () {
        if (LastBlock != null)
        {
            transform.position = Vector3.Slerp(CurPos, new Vector3(LastBlock.position.x, LastBlock.position.y, -15), Time.deltaTime * 3);
        }
        if (Input.GetMouseButton(0))
        {
            LastBlock = GameObject.FindWithTag("LastBlock").transform;
        }
    }
}
