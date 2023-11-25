using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyOnKeyboard : MonoBehaviour
{

    public void InsertKey(string key)
    {
        char realKey = key[0]; //to make it work in the OnClick of the button
        QuestionsManager.Shared().InsertLCharacter(realKey);
    }
}
