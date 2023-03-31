using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Rotatifs : MonoBehaviour
{
    [SerializeField] private float _vitesseR = 1f; //Vitesse de rotation
 
    void FixedUpdate()
    {
        transform.Rotate(0f, _vitesseR, 0f); // Effectue une rotation sur l'axe des Y avec une vitesse _vitesseR
    }
}
