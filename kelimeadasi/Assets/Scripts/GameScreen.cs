using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreen : MonoBehaviour
{

    public void PlayGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame()
    {
        Debug.Log("Oyundan Çýktýk");
        Application.Quit();


    }

    public void AYARLAR()
    {

        SceneManager.LoadScene("AYARLAR");

    }


    public void ReturnToMainMenu()
    {

        SceneManager.LoadScene("anamennnu");

    }

    public void ReturnToGameScreen()
    {

        SceneManager.LoadScene("GameScreen");

    }

    public void ReturnToSkorTablosu()
    {

        SceneManager.LoadScene("SkorTablosu");

    }

    public void ReturnToOyna()
    {

        SceneManager.LoadScene("oyna");

    }

    public void ReturnTobolum2()
    {

        SceneManager.LoadScene("bolum2");

    }

    public void ReturnTobolum3()
    {

        SceneManager.LoadScene("bolum3");

    }

}