using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public float Timeleft;

    public bool TimerOn = false;
    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            if (Timeleft > 0)
            {
                Timeleft -= Time.deltaTime;
                updateTimer(Timeleft);
            }
            else
            {
                Debug.Log("Time is up!");
                Timeleft = 0;
                TimerOn = false;
            }
        }
    }

    void updateTimer(float currentTime)
    {
        int wholeSecond = Mathf.FloorToInt(currentTime);
        timerText.text = $"Time \n{wholeSecond.ToString()}";
    }
}

