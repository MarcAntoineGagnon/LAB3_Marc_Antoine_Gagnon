using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piege_declencheur_Fleche : MonoBehaviour
{
    private bool _isActive = false; // D�tection si le pi�ge � d�j� �t� activ�
    [SerializeField] private List<GameObject> _listPiege = new List<GameObject>(); // Liste de toute les pieges � activer
    [SerializeField] private float _vitesse = 1f; // Vitesse de translation des pi�ges

    private void Update()
    {
        if(_isActive)
        {
            foreach (var obj in _listPiege)
            {
                obj.transform.Translate(Vector3.back * Time.deltaTime * _vitesse); // Translation de tout les pi�ges de la liste
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !_isActive)
        {
            _isActive = true; // D�clenchement du pi�ge au contact avec le joueur
        }
        
    }
}
