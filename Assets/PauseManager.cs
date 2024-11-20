using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{
    private bool isPaused = false; // Indica si el juego está pausado

    public GameObject pauseMenu; // Referencia al menú de pausa
    public Text buttonText; // Referencia al texto del botón de pausa/reanudar

    // Método para pausar el juego y mostrar el menú
    public void PauseGame()
    {
        Time.timeScale = 0f; // Pausa el tiempo del juego
        isPaused = true;

        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true); // Muestra el menú de pausa
        }

        if (buttonText != null)
        {
            buttonText.text = "Reanudar"; // Cambia el texto del botón
        }
    }

    // Método para reanudar el juego y ocultar el menú
    public void ResumeGame()
    {
        Time.timeScale = 1f; // Restaura el tiempo del juego
        isPaused = false;

        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false); // Oculta el menú de pausa
        }

        if (buttonText != null)
        {
            buttonText.text = "Pausar"; // Cambia el texto del botón
        }
    }

    // Método para alternar entre pausa y reanudar
    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void LoadSceneZero()
    {
        SceneManager.LoadScene(1); // Carga la escena en el índice 0
    }
     public void ExitGame()
     {
    
        // Este m�todo cierra el juego
        Application.Quit();
        // Esto solo es �til para probar en el Editor de Unity
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
