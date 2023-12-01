using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image fillBar;

    public void FillBar(float fillAmount)
    {
        print("filling by: " + fillAmount);
        fillBar.fillAmount = fillAmount;
    }
}
