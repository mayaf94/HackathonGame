using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable] public class Word : MonoBehaviour
{
     public List<Letter> letters;

     [SerializeField] private string expectedWord;

     [SerializeField] private Color successColor;
     
     private int _currLetterIndex = 0;

     private bool wordCompleted;

     private TextMeshProUGUI _buttonText;


     private void Awake()
     {
          _buttonText = GetComponentInChildren<TextMeshProUGUI>();
     }

     private void Start()
     {
          wordCompleted = false;
          expectedWord = expectedWord.ToUpper();
          if(expectedWord.Length != letters.Count) 
               Debug.Log("ERROR: The length of expectedWord != letters. Word: " + expectedWord);
     }


     public void OnClickOnButton()
     {
          if(wordCompleted)
               return;
          if (QuestionsManager.Shared().currentWord != null && QuestionsManager.Shared().currentWord != this)
          {
               QuestionsManager.Shared().currentWord.ClearWord();
               QuestionsManager.Shared().currentWord.ResetButtonText();
          }
          _buttonText.fontStyle = FontStyles.Bold;
          QuestionsManager.Shared().currentWord = this;
          FindNextCell();
     }

     public void ResetButtonText()
     {
          _buttonText.fontStyle = FontStyles.Normal;
     }

     /**
      * Set _currLetterIndex to the next available cell
      * Return: false if the index got out of range (after end of the word), true otherwise
      */
     private bool FindNextCell()
     {
          while (_currLetterIndex < letters.Count && letters[_currLetterIndex].isFilled)
               _currLetterIndex++; // Continue to next available letter. 

          return _currLetterIndex < letters.Count;
     }

     private void FillCurrentCell(char character)
     {
          letters[_currLetterIndex].SetLetter(character);
          _currLetterIndex++;
     }


     public void FillAndStep(char character)
     {
          FillCurrentCell(character);  //todo: the button need to check FindNextCell too to walk over the first letters if filled
          if (!FindNextCell())
          {
               if (WordIsEqualTo())
               {
                    wordCompleted = true;
                    _buttonText.fontStyle = FontStyles.Strikethrough;
                    QuestionsManager.Shared().currentWord = null;
                    FillWord();
               }
               else
               {
                    ClearWord();
               }
          }
     }
     
     
     public bool WordIsEqualTo()
     {
          string userAttemptString = "";
          foreach (Letter letter in letters)
          {
               userAttemptString += letter.GetLetter();
          }

          return userAttemptString.Equals(expectedWord);
     }
     
     public void FillWord()
     {
          foreach (Letter letter in letters)
          {
               letter.isFilled = true;
               letter.ChangeLetterColor(successColor);
          }
     }
     
     public void ActivateWord()
     {
          foreach (Letter letter in letters)
          {
               letter.gameObject.SetActive(true);
          }
     }

     public void ClearWord()
     {
          foreach (var letter in letters)
          {
               if(!letter.isFilled)
                    letter.SetLetter('\0');
          }
          _currLetterIndex = 0;
          FindNextCell();
     }
     
     public bool IsWordFilled()
     {
          return wordCompleted;
     }

     public int GetLength()
     {
          return letters.Count;
     }
     
}
