using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image fillBar;

    private void Awake()
    {
        tag = "progressBar";
    }
    // private static ProgressBar self;

    // private void Awake()
    // {
    //     if (self == null)
    //         self = this;
    // }
    
    // public static ProgressBar Shared()
    // {
    //     return self;
    // }
    
    public void FillBar(float fillAmount)
    {
        print("filling by: " + fillAmount);
        fillBar.fillAmount = fillAmount;
    }
}
