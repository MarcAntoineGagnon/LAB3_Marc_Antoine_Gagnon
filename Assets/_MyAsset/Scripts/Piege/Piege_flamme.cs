using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piege_flamme : MonoBehaviour
{
    GestionJeu _gestionJeu;
    [SerializeField] private float _vitesse = 10f;  // vitesse de sortie des lance
    [SerializeField] private float _temps = 0.5f;   // temps de la translation verticale
    [SerializeField] private float _delais = 1f;    // temps avant le début de la translation (avant de sortir et avant de rentrer)
    private float _timer;           // Chronomètre pour le temps de la translation
    private float _timerDelais;     // Chronomètre pour le temps du délais
    private bool _retour = false;   // Boolean pour connaitre le sens de la translation

    private void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
    }
    void Update()
    {
        _timer += Time.deltaTime; // Augmentation du timer Translation

        if (_timer < _temps) // Détection si la translation n'est pas terminer
        {
            if (!_retour) // Si les lances sorte du sol
            {
                transform.Translate(Vector3.up * Time.deltaTime * _vitesse); // Translation Verticale vers le haut
            }
            else // Si les lances rentre dans le sol
            {
                transform.Translate(Vector3.down * Time.deltaTime * _vitesse); // Translation Verticale vers le bas
            }
        }
        else
        {
            _timerDelais += Time.deltaTime; // Augmentation du timer Delais

            if (_timerDelais >= _delais && _retour == false) // Détection si le delais est terminer et si la lance sort ou rentre
            {
                _timerDelais = 0f;
                _timer = 0f;
                _retour = true;
            }
            else if (_timerDelais >= _delais && _retour == true)
            {
                _timerDelais = 0f;
                _timer = 0f;
                _retour = false;
            }
        }

    }

    // Si le joueur touche au flamme il se fait bruller (+1 pointage mais ne l'immobilise pas)
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _gestionJeu.AugmenterPointage();
        }
    }
}
