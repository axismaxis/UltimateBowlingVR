using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLane : MonoBehaviour
{
    public GameObject Pins;
    private CheckPins PinController;

    private bool timeron = false;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        PinController = Pins.GetComponent<CheckPins>();
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
            }
        }
    }

    void timerEnded()
    {
        Debug.Log(PinController.CheckIfKnockedDown());
        //TODO reset
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Ball"))
        {
            timeron = true;
        }
    }
}
