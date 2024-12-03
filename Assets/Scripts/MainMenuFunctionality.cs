using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenuFunctionality : MonoBehaviour
{




    [SerializeField] public TextMeshProUGUI QuitButton;
    [SerializeField] public TextMeshProUGUI RestartButton;
    public void Quit()
    {
        Application.Quit();

    }


    public void restart()

    {
        SceneManager.LoadScene("World 1-3");
    }



}
