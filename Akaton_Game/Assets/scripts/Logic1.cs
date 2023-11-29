using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic1 : MonoBehaviour
{
    public void OnPlayCross()
    {
        SceneManager.LoadScene("LeeyamCrossword");
    }
    public void OnPlayFaked()
    {
        SceneManager.LoadScene("Game2");
    }
    public void OnPlayBack()
    {
        SceneManager.LoadScene("MainScreen");
    }


}
