using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piege_declencheur_Fleche : MonoBehaviour
{
    private bool _isActive = false; // Détection si le piège à déjà été activé
    [SerializeField] private List<GameObject> _listPiege = new List<GameObject>(); // Liste de toute les pieges à activer
    [SerializeField] private float _vitesse = 1f; // Vitesse de translation des pièges

    private void Update()
    {
        if(_isActive)
        {
            foreach (var obj in _listPiege)
            {
                obj.transform.Translate(Vector3.back * Time.deltaTime * _vitesse); // Translation de tout les pièges de la liste
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !_isActive)
        {
            _isActive = true; // Déclenchement du piège au contact avec le joueur
        }
        
    }
}
