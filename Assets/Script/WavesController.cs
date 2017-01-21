using UnityEngine;
using System.Collections;

public class WavesController : MonoBehaviour
{
    public float alpha, beta, gamma, delta, theta, defaultDamage;

    // Quando ilPlaer collide con un onda, confronta il tag e aumenta il livello dell'onda cerebrale corrispondente
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "alpha":
                alpha += defaultDamage;
                break;

            case "beta":
                beta += defaultDamage;
                break;

            case "gamma":
                gamma += defaultDamage;
                break;

            case "delta":
                delta += defaultDamage;
                break;

            case "theta":
                theta += defaultDamage;
                break;
        }
       
    }


}
