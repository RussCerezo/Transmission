using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour {
    SpriteRenderer SRR;
    public Color StartColour, PulseColour, CurColour;
    public GameObject[] ObjectTiles;//To be removed and replaced with a system that fetches the selected object when clicked?
    public bool Pulsing = false, Activated = false, FirstContact = true, Receiver = false, Tile = false, Blocker = false, Core = false;
    public string Receiving, Type,ReceivingReceiver;
    float T;
    public GameObject EngineCore;
    public float RON = 0;
    public int WhatAmI;
    private void Awake()
    {
        EngineCore = GameObject.FindGameObjectWithTag("GenCore");
        SRR = GetComponent<SpriteRenderer>();
        CurColour = StartColour;
        StartCoroutine("RONDiminisher");
    }

    private IEnumerator RONDiminisher()
    {
        if (Receiver == false)
        {
            if (Tile == false)
            {

                    GetComponent<Animator>().speed = RON / 4;
                RON--;
            }
        }
        yield return new WaitForSeconds(5);
        StartCoroutine("RONDiminisher");
    }

    // Use this for initialization
    public void FlashPulse()
    {
        if (Receiver == false)
        {
            if (Activated == false)
            {
                StartCoroutine("Pinglet");
                Pulsing = true;
                if (FirstContact)
                {
                    FirstContact = false;
                }
            }
        }
    }

    IEnumerator Pinglet()
    {
        T = Time.time;
        CurColour = PulseColour;
        yield return new WaitForSeconds(0.1f);
        Pulsing = true;
    }

    private void Update()
    {
        if (Receiver == false)
        {
            if (RON >= 3)
        {
                if (Core)
                {
                    if (WhatAmI == 2)
                    {
                        EngineCore.GetComponent<LevelGenRefined>().Winning();
                        EngineCore.GetComponent<LevelGenRefined>().SunCore = true;
                    }
                    else if (WhatAmI == 3)
                    {
                        EngineCore.GetComponent<LevelGenRefined>().Winning();
                        GetComponent<Animator>().SetBool("FinalAnim", true);
                        EngineCore.GetComponent<LevelGenRefined>().EarthCore = true;
                    }
                    else if (WhatAmI == 4)
                    {
                        EngineCore.GetComponent<LevelGenRefined>().Winning();
                        GetComponent<Animator>().SetBool("FinalAnim", true);
                        EngineCore.GetComponent<LevelGenRefined>().GrowCore = true;
                    }
                    else if (WhatAmI == 5)
                    {
                        EngineCore.GetComponent<LevelGenRefined>().Winning();
                        EngineCore.GetComponent<LevelGenRefined>().LoveCore = true;
                    }
                }
            RON = 4;
        }
        if (RON < 0)
        {
            RON = 0;
        }

            if (Pulsing)
            {
                if (CurColour != StartColour)
                {
                    CurColour = Color.Lerp(PulseColour, StartColour, (Time.time - T));
                }
                else
                {
                    Pulsing = false;
                }
            }
            SRR.color = CurColour;
        }
        else
        {
            if (Blocker == false)
            {
                transform.parent.GetComponent<Pulse>().Receiving = ReceivingReceiver;
            }
        }
    }

    public void NotifyParent()
    {
        if (Blocker == false)
        {
            if (Tile == false)
            {
                if (Receiver == true)
                    transform.parent.GetComponent<Pulse>().MicCheck();
            }
        }
    }

    public void MicCheck()
    {
        if (Receiver == false)
        {
            if (Tile == false)
            {

                if (Receiving == Type)
                {
                    RON = 5;

                        GetComponent<Animator>().speed = RON / 4;

                }
                
            }
        }
    }
    private void LateUpdate()
    {

    }

    private void OnMouseOver()
    {
        if (Core == false)
        {
            if (Receiver == false)
            {
                if (FirstContact == false)
                {
                    if (Blocker == false)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            Activated = true;
                            Instantiate(ObjectTiles[(WhatAmI + 1)], transform.position, transform.rotation);
                            Destroy(gameObject);
                        }
                        if (Input.GetMouseButtonDown(1))
                        {
                            Activated = true;
                            transform.Rotate(0, 0, -90);
                        }

                        if (Input.GetMouseButtonDown(2))
                        {
                        }
                    }
                }
            }
        }
    }

}
