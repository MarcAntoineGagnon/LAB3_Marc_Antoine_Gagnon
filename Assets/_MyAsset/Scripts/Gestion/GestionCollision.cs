using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCollision : MonoBehaviour
{
    private bool _touche = false;       // Boolean pour savoir si l'obstacle à déjà été touché
    private GestionJeu _gestionJeu;

    void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _touche = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" && _touche == false)
        {
            _touche = true;
            if(gameObject.GetComponent<MeshRenderer>() != null) // Détection si gameObject avec le script contient un MeshRenderer
            {
                gameObject.GetComponent<MeshRenderer>().material.color = Color.red; // Changement de couleur au contact du joueur
            }
            _gestionJeu.AugmenterPointage();
        }
    }
}
