using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPins : MonoBehaviour
{
    private Transform original;
    private string[] KnockedDown = new string[10];
    private int CurrentFrame = 0;

    public Frame[] Frames = new Frame[10];
    public GameObject Ballprefab;
    private GameObject Ball;
    public GameObject Prefab;


    // Start is called before the first frame update
    void Start()
    {
        GameObject Lane = Instantiate(Prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Ball = Instantiate(Ballprefab);
        Lane.transform.parent = gameObject.transform;
        Lane.transform.Rotate(-90.0f, 0, 0);
        ResetArray();
        for (int i = 1; i < 11; i++) Frames[i - 1] = new Frame(i);
        Debug.Log("Frame: " + CurrentFrame + " Attempt: " + Frames[CurrentFrame].Attempts + " Score: " + Frames[CurrentFrame].Score);
    }

    public void DestroyBall()
    {
        Destroy(Ball);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetPins(true);
        }
    }

    public void BallEnded()
    {
        Frames[CurrentFrame].Attempts++;
        Frames[CurrentFrame].Score += CheckIfKnockedDown();
        Debug.Log("Frame: " + CurrentFrame + " Attempt: " + Frames[CurrentFrame].Attempts + " Score: " + Frames[CurrentFrame].Score);
        if(CurrentFrame < 9)
        {
            if (Frames[CurrentFrame].Attempts == 2)
            {
                CurrentFrame++;
                ResetPins(true);
            }
            else
            {
                ResetPins(false);
            }
        }
        else
        {
            switch (Frames[CurrentFrame].Attempts)
            {
                case 1:
                    if (Frames[CurrentFrame].Score == 10)
                        ResetPins(true);
                    else
                        ResetPins(false);
                    break;
                case 2:
                    if (Frames[CurrentFrame].Score == 10 || Frames[CurrentFrame].Score == 20)
                        ResetPins(true);
                    //else
                        //gameover
                    break;
                case 3:
                    //gameover
                    break;
            }
        }
    }

    public void ResetPins(bool ResetAll)
    {
        Debug.Log(CheckIfKnockedDown());
        Destroy(transform.GetChild(0).gameObject);
        Ball = Instantiate(Ballprefab);
        GameObject Lane = Instantiate(Prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Lane.transform.parent = gameObject.transform;
        Lane.transform.Rotate(-90.0f, 0, 0);
        if(!ResetAll)
        {
            int i = 0;
            foreach (Transform child in Lane.transform)
            {
                for (int i2 = 0; i2 < 10; i2++)
                {
                    if (KnockedDown[i2].Equals(child.name))
                    {
                        Destroy(child.gameObject);
                    }
                }
                i++;
            }
        }
    }

    public int CheckIfKnockedDown()
    {
        int i = 0;
        ResetArray();
        Transform lane = transform.GetChild(0);
        foreach (Transform child in lane)
        {
            if (child.eulerAngles.x < 265 || child.eulerAngles.x > 275)
            {
                KnockedDown[i] = child.name;
                i++;
            }
        }
        return i;
    }

    private void ResetArray()
    {
        for(int i = 0; i < 10; i++)
        {
            KnockedDown[i] = "";
        }
    }

    public class Frame
    {
        public int FrameNumber;
        public int Score = 0;
        public int Attempts = 0;

        public Frame(int i)
        {
            FrameNumber = i;
        }
    }
}
