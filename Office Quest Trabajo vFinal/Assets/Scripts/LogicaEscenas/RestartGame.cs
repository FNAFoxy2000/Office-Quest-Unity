using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void RestartGameScene()
    {
        SceneManager.LoadScene("Introduccion");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("EscenaInicial");
    }
}
