using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement_Translation_horizontale : MonoBehaviour
{
    [SerializeField] private float _vitesse = 1f; // Vitesse de la translation 
    [SerializeField] private float _temps = 1f; // temps de la translation avant de revenir
    private float _timer; // Chronomètre pour le temps de la translation

    private void Update()
    {
        _timer += Time.deltaTime; // Augmentation du chronomètre translation
        if(_timer < _temps)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _vitesse); // Translation horizontale
        }
        else
        {
            _timer = 0f;
            transform.Rotate(0f, 180f, 0f); // Rotation de 180 sur l'axe Y pour faire revenir l'obstacle quand le timer = temps
        }
       
    }
}
