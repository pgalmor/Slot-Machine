using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    private Row[] rows;

    [SerializeField]
    private TextMeshProUGUI creditsText;

    [SerializeField]
    private TextMeshProUGUI winText;

    [SerializeField]
    private Button spinButton;

    private int prizeValue = 0;
    private bool resultsChecked = true;

    private int credits = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped || !rows[3].rowStopped || !rows[4].rowStopped)
        {
            prizeValue = 0;
        }

        if(rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && rows[3].rowStopped && rows[4].rowStopped && !resultsChecked)
        {
            CheckResults();
            spinButton.interactable = true;
        }
    }

    public void OnClick()
    {
        spinButton.GetComponent<AudioSource>().Play();
        StartCoroutine(StartMachine());
        resultsChecked = false;
        spinButton.interactable = false;
        GetComponent<AudioSource>().Play();
        winText.gameObject.SetActive(false);
    }

    private IEnumerator StartMachine()
    {
        float rotTime = (float)System.Math.Round(Random.Range(2f, 4f), 2);

        for (int i = 0; i < rows.Length; i++)
        {
            rows[i].StartRotating(rotTime);
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void CheckResults()
    {
        Debug.Log("checking!");
        int combination = 0;
        int figure = 0;
        bool win = false;

        //BASIC COMBINATIONS
        for (int i = 0; i < 3; i++)
        {
            if (rows[0].stoppedSlots[i] == rows[1].stoppedSlots[i]
                && rows[0].stoppedSlots[i] == rows[2].stoppedSlots[i]
                && rows[0].stoppedSlots[i] == rows[3].stoppedSlots[i]
                && rows[0].stoppedSlots[i] == rows[4].stoppedSlots[i]
                && win == false)
            {
                combination = 5;
                figure = rows[0].stoppedSlots[i];
                win = true;
            }
            if (rows[0].stoppedSlots[i] == rows[1].stoppedSlots[i]
                && rows[0].stoppedSlots[i] == rows[2].stoppedSlots[i]
                && rows[0].stoppedSlots[i] == rows[3].stoppedSlots[i]
                && win == false)
            {
                combination = 4;
                figure = rows[0].stoppedSlots[i];
                win = true;
            }
            if (rows[0].stoppedSlots[i] == rows[1].stoppedSlots[i] && rows[0].stoppedSlots[i] == rows[2].stoppedSlots[i] && win == false)
            {
                combination = 3;
                figure = rows[0].stoppedSlots[i];
                win = true;
            }
        }

        //EXTRA COMBINATIONS
        if(rows[0].stoppedSlots[2] == rows[1].stoppedSlots[0]
            && rows[0].stoppedSlots[2] == rows[2].stoppedSlots[2]
            && rows[0].stoppedSlots[2] == rows[3].stoppedSlots[0]
            && rows[0].stoppedSlots[2] == rows[4].stoppedSlots[2]
            && win == false)
        {
            combination = 5;
            figure = rows[0].stoppedSlots[2];
            win = true;
        }
        if (rows[0].stoppedSlots[0] == rows[1].stoppedSlots[2]
             && rows[0].stoppedSlots[0] == rows[2].stoppedSlots[0]
             && rows[0].stoppedSlots[0] == rows[3].stoppedSlots[2]
             && rows[0].stoppedSlots[0] == rows[4].stoppedSlots[0]
             && win == false)
        {
            combination = 5;
            figure = rows[0].stoppedSlots[0];
            win = true;
        }
        if (rows[0].stoppedSlots[0] == rows[1].stoppedSlots[1]
             && rows[0].stoppedSlots[0] == rows[2].stoppedSlots[2]
             && rows[0].stoppedSlots[0] == rows[3].stoppedSlots[1]
             && rows[0].stoppedSlots[0] == rows[4].stoppedSlots[0]
             && win == false)
        {
            combination = 5;
            figure = rows[0].stoppedSlots[0];
            win = true;
        }
        if (rows[0].stoppedSlots[2] == rows[1].stoppedSlots[1]
             && rows[0].stoppedSlots[2] == rows[2].stoppedSlots[0]
             && rows[0].stoppedSlots[2] == rows[3].stoppedSlots[1]
             && rows[0].stoppedSlots[2] == rows[4].stoppedSlots[2]
             && win == false)
        {
            combination = 5;
            figure = rows[0].stoppedSlots[2];
            win = true;
        }
        if (rows[0].stoppedSlots[0] == rows[1].stoppedSlots[0]
             && rows[0].stoppedSlots[0] == rows[2].stoppedSlots[1]
             && rows[0].stoppedSlots[0] == rows[3].stoppedSlots[2]
             && rows[0].stoppedSlots[0] == rows[4].stoppedSlots[2]
             && win == false)
        {
            combination = 5;
            figure = rows[0].stoppedSlots[0];
            win = true;
        }
        if (rows[0].stoppedSlots[2] == rows[1].stoppedSlots[2]
             && rows[0].stoppedSlots[2] == rows[2].stoppedSlots[1]
             && rows[0].stoppedSlots[2] == rows[3].stoppedSlots[0]
             && rows[0].stoppedSlots[2] == rows[4].stoppedSlots[0]
             && win == false)
        {
            combination = 5;
            figure = rows[0].stoppedSlots[2];
            win = true;
        }

        if(win == true)
        {
            switch (combination)
            {
                case 3:
                    switch (figure)
                    {
                        case 1:
                            prizeValue = 50;
                            break;
                        case 2:
                            prizeValue = 20;
                            break;
                        case 3:
                        case 4:
                        case 5:
                            prizeValue = 10;
                            break;
                        case 6:
                            prizeValue = 5;
                            break;
                        case 7:
                            prizeValue = 2;
                            break;
                    }
                    break;
                case 4:
                    switch (figure)
                    {
                        case 1:
                            prizeValue = 75;
                            break;
                        case 2:
                            prizeValue = 30;
                            break;
                        case 3:
                        case 4:
                            prizeValue = 20;
                            break;
                        case 5:
                            prizeValue = 15;
                            break;
                        case 6:
                            prizeValue = 10;
                            break;
                        case 7:
                            prizeValue = 5;
                            break;
                    }
                    break;
                case 5:
                    switch (figure)
                    {
                        case 1:
                            prizeValue = 100;
                            break;
                        case 2:
                            prizeValue = 60;
                            break;
                        case 3:
                            prizeValue = 50;
                            break;
                        case 4:
                            prizeValue = 40;
                            break;
                        case 5:
                            prizeValue = 30;
                            break;
                        case 6:
                            prizeValue = 20;
                            break;
                        case 7:
                            prizeValue = 10;
                            break;
                    }
                    break;
            }

            prizeValue = 5;
            credits += prizeValue;
            winText.SetText("WIN!! " + prizeValue + " points");
            creditsText.SetText("CREDITS: " + credits);
            winText.gameObject.SetActive(true);
            winText.GetComponent<AudioSource>().Play();
        }

        resultsChecked = true;
        prizeValue = 0;
        win = false;
    }
}
