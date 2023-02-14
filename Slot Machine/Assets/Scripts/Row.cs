using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private float turningPoint;
    private float rotSpeed;

    public bool rowStopped;
    public int[] stoppedSlots;

    public int[] slots;

    // Start is called before the first frame update
    void Start()
    {
        rowStopped = true;
        turningPoint = transform.position.y + (2.1f * (slots.Length - 3));
        rotSpeed = 0.2625f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRotating(float time)
    {
        StartCoroutine(Rotate(time * 1000));
    }

    private IEnumerator Rotate(float time)
    {
        rowStopped = false;

        switch (time % 8)
        {
            case 1:
                time += 7;
                break;
            case 2:
                time += 6;
                break;
            case 3:
                time += 5;
                break;
            case 4:
                time += 4;
                break;
            case 5:
                time += 3;
                break;
            case 6:
                time += 2;
                break;
            case 7:
                time += 1;
                break;
        }

        for (int i = 0; i < time; i++)
        {
            if (transform.position.y >= turningPoint)
                transform.position = new Vector2(transform.position.x, 2.8f);

            transform.position = new Vector2(transform.position.x, transform.position.y + rotSpeed);

            yield return null;
        }

        float roundedPos = (float)System.Math.Round(transform.position.y * 10.0f) * 0.1f;
        float stoppedPos = roundedPos - 2.8f;
        for (int i = 0; i < 3; i++)
        {
            stoppedSlots[i] = slots[(int)(stoppedPos / 2.1) + i];
        }
        rowStopped = true;
    }
}
