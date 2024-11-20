using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement; // Para reiniciar la escena
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    public GameObject resultWindow; // La ventana de resultados (Canvas)
    public Text totalScoreText;    // Texto para mostrar el puntaje total
    private float finalScore;      // Variable para almacenar el puntaje final

    // Método para mostrar la ventana de resultados
    public void ShowResult(float score)
    {
        finalScore = score; // Almacena el puntaje final
        resultWindow.SetActive(true); // Muestra la ventana de resultados
        totalScoreText.text = "Puntaje Total: " + Mathf.FloorToInt(finalScore).ToString(); // Actualiza el texto con el puntaje
        Time.timeScale = 0f; // Pausa el juego
    }

    // Método para reiniciar el juego
    public void RestartGame()
    {
        Time.timeScale = 1f; // Restaura el tiempo del juego
         SceneManager.LoadScene(0);
    }
    
}
