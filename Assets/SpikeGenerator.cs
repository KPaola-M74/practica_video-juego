using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject spike;
    public GameObject power; // Referencia al prefab del power-up
    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;
    public float SpeedMultiplier;

    public float minX, maxX; // Rango de posición aleatoria en el eje X
    public float minY, maxY; // Rango de posición aleatoria en el eje Y

    void Awake()
    { Time.timeScale = 1f; 
        currentSpeed = MinSpeed;
        generateSpike();
        generatePowerWithGap(); // Inicia la generación de power-ups
    }

    public void generateNextSpikeWithGap()
    {
        float randomWait = Random.Range(0.1f, 1.2f);
        Invoke("generateSpike", randomWait);
    }

    void generateSpike()
    {
        GameObject SpikeIns = Instantiate(spike, transform.position, transform.rotation);
        SpikeIns.GetComponent<SpikeScript>().spikeGenerator = this;
    }

    public void generatePowerWithGap()

    {
        
        float randomWait = Random.Range(2f, 30f); // Intervalo aleatorio entre 2 y 5 segundos
        Invoke("generatePower", randomWait);
    }

    void generatePower()
    {
        // Generar posición aleatoria dentro del rango definido
        //float randomX = Random.Range(minX, maxX);
        //float randomY = Random.Range(minY, maxY);
        //Vector2 randomPosition = new Vector2(randomX, randomY);
       //GameObject PowerIns = Instantiate(power, randomPosition, Quaternion.identity);
        //PowerIns.GetComponent<SpikeScript>().spikeGenerator = this;
        // Instanciar el power-up en la posición aleatoria
        // GameObject PowerIns = Instantiate(power, randomPosition, Quaternion.identity);
         GameObject PowerIns = Instantiate(power, transform.position, transform.rotation);
        PowerIns.GetComponent<PowerUpMovement>().spikeGenerator = this;
        // Llama nuevamente para seguir generando power-ups
        generatePowerWithGap();
    }

    void Update()
    {
        if (currentSpeed < MaxSpeed)
        {
            currentSpeed += SpeedMultiplier * Time.deltaTime;
        }
    }
}