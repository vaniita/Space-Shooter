using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnboardingCode : MonoBehaviour
{
    public void BeginGame(){
        SceneManager.LoadScene("Onboarding");
    }

    public void EndGame(){
        SceneManager.LoadScene("StartScreen");
    }
}
