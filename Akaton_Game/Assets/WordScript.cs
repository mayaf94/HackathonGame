using UnityEngine;
//using System.Collection;
//using System.Collection.Generic;
using TMPro;
using UnityEngine.UI;

public class WordScript : MonoBehaviour
{
    public string wordToGuess;
    public TextMeshProUGUI[] wordButtonsTexts;
    public GameObject[] wordButtons;
    public Color rightColor;
    public Color wrongColor;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void checkWord()
    {
        bool isOk = true;
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            Debug.Log(wordButtonsTexts[i].text.Length +" ,"+ wordButtons[i].name+ " ,"+ wordButtonsTexts[i].text);
            Debug.Log(wordButtons[i].name + " ," + wordToGuess[i]);
            if (wordButtonsTexts[i].text.Length == 1) return;
            Debug.Log(!(wordButtonsTexts[i].text.ToUpper()[0] == wordToGuess.ToUpper()[i]));
            //Debug.Log(wordButtonsTexts[i].text.ToUpper()[0]);
            if (!(wordButtonsTexts[i].text.ToUpper()[0] == wordToGuess.ToUpper()[i])) isOk = false;
        }
        if (isOk)
        {
            Debug.Log("OK");
            ColorButtons(rightColor, true);
            return;
        }
        Debug.Log("BAD");
        ColorButtons(wrongColor, false);
    }

    public void ColorButtons(Color color,bool disableButton)
    {
        for (int i = 0; i < wordToGuess.Length; i++)
        {
            if (wordButtons[i].GetComponent<Image>().color == rightColor) continue;
            wordButtons[i].GetComponent<Image>().color = color;
            wordButtons[i].GetComponent<TMP_InputField>().enabled = !disableButton;
        }
    }
}
