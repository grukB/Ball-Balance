using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public static class GlobalVariables
{
    public static int playerLevel = 1;
    public static int difficulty = 0;
}

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI CounterText;

    private int Count = 0;
    private int currentToUpgrade = 0;
    private int amountToUpgrade = 100;
    private int currentToUpgradeDif = 0;
    private int amountToUpgradeDif = 50;
    private int startDifCount = 15;

    private void Start()
    {
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Count
        if (other.gameObject.CompareTag("Sphere"))
        {
            currentToUpgrade++;
            Count++;
            CounterText.text = "" + Count;

            other.gameObject.layer = 1;
        }



        // Player Upgrade
        if(currentToUpgrade == amountToUpgrade)
        {
            ScalePlayer();;
            GlobalVariables.playerLevel *= 2;
            currentToUpgrade = 0;
            amountToUpgrade *= 2;
        }


        // Difficulty
        if (currentToUpgradeDif == startDifCount)
        {
            GlobalVariables.difficulty = 1;
        }
        if (currentToUpgradeDif == amountToUpgradeDif)
        {
            GlobalVariables.difficulty++;
        }
    }


    void ScalePlayer()
    {
        gameObject.transform.localScale = new Vector3(
            gameObject.transform.localScale.x,
            gameObject.transform.localScale.y,
            gameObject.transform.localScale.z *2);
    }
}
