using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plaque_Pression : MonoBehaviour
{
    [SerializeField] GameObject _obstacle; // Obstacle affecter par l'activation

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Lourd") // Uniquement activ� si le GameObject � le tag Lourd (ex : Caisse)
        {
            _obstacle.SetActive(false); // D�sactivation de l'obstacle
        }
        
    }

    private void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.tag == "Lourd")
        {
            _obstacle.SetActive(true); // R�activation de l'obstacle si le GameObject ne touche plus � la plaque
        }
    }
}
