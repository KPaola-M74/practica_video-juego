using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce;
    float score;
    bool isAlive = true;
    public Text ScoreTxt;
     public Text ScoreTxt2;

    [SerializeField] private GameObject loseCanvas; // Referencia al Canvas de perder
     [SerializeField] private GameObject PausaCanvas; // Referencia al Canvas de perder

    [SerializeField]
    bool isGrounded = false;
  [SerializeField] private GameObject instru; // Referencia al Canvas de perder
    Rigidbody2D RB;

    private float scoreMultiplier = 1f; // Multiplicador inicial de puntaje

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;

        if (loseCanvas != null)
        {
            loseCanvas.SetActive(false); // Asegúrate de que el Canvas esté desactivado al inicio
            PausaCanvas.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
                 instru.SetActive(false);
            }
        }

        if (isAlive)
        {
            // Incrementa el puntaje usando el multiplicador
            score += Time.deltaTime * 4 * scoreMultiplier;
            ScoreTxt.text = "SCORE: " + Mathf.FloorToInt(score).ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.CompareTag("power"))
        {
            Debug.Log("Power-up recogido, multiplicador activado.");
            StartCoroutine(ActivateScoreMultiplier());
            Destroy(collision.gameObject); // Elimina el power-up
        }

        if (collision.gameObject.CompareTag("kiil")) // Si el jugador muere
        {
            Debug.LogError("kill");
            isAlive = false;
            Time.timeScale = 0; // Pausa el tiempo del juego

            if (loseCanvas != null)
            {
                loseCanvas.SetActive(true); // Activa el Canvas de "Perder"
            }
        }
    }

    private IEnumerator ActivateScoreMultiplier()
    {
        scoreMultiplier = 20f; // Activa el multiplicador de x20
        yield return new WaitForSeconds(10f); // Espera 10 segundos
        scoreMultiplier = 1f; // Restaura el multiplicador a su valor inicial
        Debug.Log("El efecto del multiplicador ha terminado.");
    }

     

}