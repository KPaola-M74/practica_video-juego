using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class managerjuego : MonoBehaviour
{
    
    public void QuitGames()
    {
        // Este m�todo cierra el juego
        Application.Quit();
        // Esto solo es �til para probar en el Editor de Unity
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void LoadprevScenes()
    {
        // Cargar la siguiente escena en el �ndice del Build Settings
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
