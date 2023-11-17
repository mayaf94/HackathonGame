using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic1 : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    public void OnPlayCross()
    {
        SceneManager.LoadScene("Game1");
    }
    public void OnPlayFaked()
    {
        SceneManager.LoadScene("Game2");
    }
    public void OnPlayBack()
    {
        P1.SetActive(false);
        P2.SetActive(false);
        SceneManager.LoadScene("MainScreen");
    }

}
