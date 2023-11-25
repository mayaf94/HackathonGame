using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class Word : MonoBehaviour
{
     public List<Letter> letters;

     [SerializeField] private string expectedWord;
     
     private int _currLetterIndex = 0;

     private bool wordCompleted;

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
          //todo add decoration to the marked button
          QuestionsManager.Shared().currentWord = this;
          FindNextCell();
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
     }


     public void FillAndStep(char character)
     {
          FillCurrentCell(character);  //todo: the button need to check FindNextCell too to walk over the first letters if filled
          if (!FindNextCell())
          {
               if (WordIsEqualTo())
               {
                    wordCompleted = true;
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
               letter.ChangeLetterColor(Color.green);
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
     }
     
     public bool IsWordFilled()
     {
          foreach (Letter letter in letters)
          {
               if (!letter.isFilled)
                    return false;
          }

          return true;
     }

     public int GetLength()
     {
          return letters.Count;
     }
     
}
