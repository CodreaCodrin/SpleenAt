using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonLogic : MonoBehaviour
{
    private TMP_Text myText;
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void OptionsPress()
    {
        myText = GetComponentInChildren<TMP_Text>();
        myText.text = "OPTIONS";
       
    }
}
