using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButtons : MonoBehaviour
{
   public void PlayGame()
   {
        SceneManager.LoadScene("BarEnviromen�");
   }

   public void Exit()
   {
        Application.Quit();
   }
}
