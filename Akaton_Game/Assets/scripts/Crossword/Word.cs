using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class Word : MonoBehaviour
{
     public List<Letter> letters;

     private int _currLetterIndex = 0;

     public void WriteNextLetter(char character)
     {
          while (_currLetterIndex < letters.Count && letters[_currLetterIndex].isFilled)
               _currLetterIndex++; // Continue to next available letter. 
          
          if (_currLetterIndex < letters.Count)
          {
               letters[_currLetterIndex].SetLetter(character);
          }
     }
     
     public bool WordIsEqualTo(string expectedWord)
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
          }
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
