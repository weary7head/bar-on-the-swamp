using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManager;


public class MenuButtons : MonoBehaviour
{
   public void PlayGame(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   public void Exit(){
    Application.Quit();
   }
}
