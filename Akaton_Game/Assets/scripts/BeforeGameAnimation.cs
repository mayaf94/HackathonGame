using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeGameAnimation : MonoBehaviour
{
    public Transform box;
    public GameObject Object;

    public void Start()
    {
        Object.SetActive(false);
    }

    public void OnEnable()
    {
        Object.SetActive(true);
        box.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;
    }

    public void CloseDialoge()
    {
        box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnClose);
    }

    public void OnClose()
    {
        Object.SetActive(false);
    }
}
