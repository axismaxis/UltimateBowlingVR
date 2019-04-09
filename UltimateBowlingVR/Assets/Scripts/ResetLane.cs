using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLane : MonoBehaviour
{
    private CheckPins PinController;

    private bool timeron = false;
    public float time;
    private float resettime;

    // Start is called before the first frame update
    void Start()
    {
        PinController = GetComponentInChildren<CheckPins>();
        resettime = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeron)
        {
            time -= Time.deltaTime;

            if (time <= 0.0f)
            {
                timerEnded();
                time = resettime;
            }
        }
    }

    void timerEnded()
    {
        timeron = false;
        PinController.BallEnded();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Ball"))
        {
            timeron = true;
            PinController.DestroyBall();
        }
    }
}
