using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    public string levelName = "Level1";
    
   public void nextScene()
   {
        SceneManager.LoadScene(levelName);
   }
}