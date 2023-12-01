using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
   public Animator transition;
   
   public void PlayGame()
   {
        //transition.SetTrigger("Play");
       //loadGameScene();
       
        //lSceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
        
   }

   public void QuitGame()
   {
        Debug.Log("Quit");
        Application.Quit();
   }
/*
   public void loadGameScene()
   {
     StartCoroutine(transitionRoutine());
   }

   IEnumerator transitionRoutine()
   {
     transition.SetTrigger("Play");
 
     yield return new WaitForSeconds(1);

     SceneManager.LoadScene("GameScene");
   }
*/
}
