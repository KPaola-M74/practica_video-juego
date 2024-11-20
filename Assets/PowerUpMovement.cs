using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    // Start is called before the first frame update

   public void Update()
{
    transform.Translate(Vector2.left * spikeGenerator.currentSpeed * Time.deltaTime);
}
public SpikeGenerator spikeGenerator;

private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("nextline"))
    {
        spikeGenerator.generateNextSpikeWithGap();

    }
  if (collision.gameObject.CompareTag("finish"))
    {
        Destroy(this.gameObject);
    } 
}
}

