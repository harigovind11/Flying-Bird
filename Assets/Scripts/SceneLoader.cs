using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

  public  void LoadNextLevel()
    {
   
Debug.Log("ssss");
        SceneManager.LoadScene("Game");
    }
 
}
