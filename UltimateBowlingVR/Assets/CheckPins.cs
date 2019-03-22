using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPins : MonoBehaviour
{
    private Transform original;

    // Start is called before the first frame update
    void Start()
    {
        CheckIfKnockedDown();
        original = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(CheckIfKnockedDown());
        }
    }

    public void ResetPins()
    {
        foreach(Transform child in transform)
        {
            
        }
    }

    public int CheckIfKnockedDown()
    {
        int i = 0;
        foreach (Transform child in transform)
        {
            if (child.eulerAngles.x < 265 || child.eulerAngles.x > 275)
            {
                i++;
            }
        }
        return i;
    }
}
