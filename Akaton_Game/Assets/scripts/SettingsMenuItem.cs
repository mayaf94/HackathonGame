using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuItem : MonoBehaviour
{
    [HideInInspector] public Image img;
    [HideInInspector] public Transform transForm;
    //SettingsMenu settingsMenu;
    //int index;
 
    void Awake()
    {
        img = GetComponent<Image>();
        transForm = transform;
        //settingsMenu = transForm.parent.GetComponent<SettingsMenu>();
        //index = transForm.GetSiblingIndex() - 1;
    }

}
