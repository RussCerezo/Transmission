using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGenRefined : MonoBehaviour {

    [Tooltip("10 = A, 11 = B, 12 = C, 13 = D, 14 = E, 15 = F, 16 = G, 17 = H, 18 = I, 19 = J, 20 = K, 21 = L, 22 = M, 23 = N, 24 = O, 25 = P, 26 = Q, 27 = R, 28 = S, 29 = T, 30 = U, 31 = V, 32 = W, 33 = X, 34 = Y, 35 = Z, 36 = a, 37 = b, 38 = c, 36 = d, 37 = e, 38 = f, 39 = g, 40 = h, 41 = i, 42 = j, 43 = k, 44 = l, 45 = m, 46 = n, 47 = o, 48 = p, 49 = q, 50 = r, 51 = s, 52 = t, 53 = u, 54 = v, 55 = w, 56 = x, 57 = y, 58 = z")]
    public GameObject[] Objects;
    public GameObject WinText, ZoomToMe;
    public int columncount, rowcount;
    public string LevelName;
    public int ObjNumber = 0, WinCount = 0,WinNeeds = 1;
    public bool SunCore, EarthCore, GrowCore, LoveCore;

    
    public void Winning()
    {
        //WinText = GameObject.FindGameObjectWithTag("END");
        if (SunCore == true && EarthCore == false && GrowCore == false && LoveCore == false)
        {
            WinCount = 1;
        }
        if (EarthCore == true && SunCore == true && GrowCore == false && LoveCore == false)
        {
            WinCount = 2;
        }
        if (GrowCore == true && EarthCore == true && SunCore == true && LoveCore == false)
        {
            WinCount = 3;
        }
        if (GrowCore == true && EarthCore == true && SunCore == true && LoveCore == true)
        {
            WinCount = 4;
        }
        if (WinCount == WinNeeds)
        {
            print("I Win");
            WinText.SetActive(true);
            ZoomToMe.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Start()
    {
        LevelName = SceneManager.GetActiveScene().name;
        Time.timeScale = 1.75f;
        TextAsset t1 = (TextAsset)Resources.Load(LevelName, typeof(TextAsset));
        string s = t1.text;
        int i;
        s = s.Replace("\n", "");
        for (i = 0; i < s.Length; i++)
        {
            bool Done= false;
            ObjNumber = 0;
            int column, row;
            column = i % (columncount +1);
            row = i / (rowcount + 1);
            GameObject t;

            for (int d = '0'; d <= '9'; d++)
            {
                if (Done == false)
                {
                    if ((s[i]) == d)
                    {
                        Done = true;
                        t = (GameObject)(Instantiate(Objects[ObjNumber], new Vector3(column, row, 0), Quaternion.identity));
                        break;
                    }
                    ObjNumber++;
                }
            }
            for (char c = 'A'; c <= 'Z'; c++)
            {
                if (Done == false)
                {
                    if ((s[i]) == c)
                    {
                        
                        if (c == 'P' || c == 'S')
                        {
                            t = (GameObject)(Instantiate(Objects[0], new Vector3(column, row, 0), Quaternion.identity));
                        }
                        Done = true;
                        t = (GameObject)(Instantiate(Objects[ObjNumber], new Vector3(column, row, 0), Quaternion.identity));
                        break;
                    }
                }
                    ObjNumber++;
            }
            for (char c = 'a'; c <= 'z'; c++)
            {
                if (Done == false)
                {
                    if ((s[i]) == c)
                    {

                        t = (GameObject)(Instantiate(Objects[0], new Vector3(column, row, 0), Quaternion.identity));
                        Done = true;
                        t = (GameObject)(Instantiate(Objects[ObjNumber], new Vector3(column, row, 0), Quaternion.identity));
                        break;
                    }
                }
                ObjNumber++;
            }

            if (s[i] == '1')
                {                

                }

            
        }

    }
}