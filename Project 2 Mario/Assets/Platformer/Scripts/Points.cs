using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    public TextMeshProUGUI coincount;

    public TextMeshProUGUI pointscount;
    public static float coins = 0;
    public static float points = 0;

    // Update is called once per frame
    void Update()
    {
        coincount.text = "Coins \n" + coins.ToString();
        pointscount.text = "Score \n" + points.ToString();
        
    }
}
