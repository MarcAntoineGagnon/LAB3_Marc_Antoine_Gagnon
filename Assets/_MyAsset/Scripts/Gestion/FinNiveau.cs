using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinNiveau : MonoBehaviour
{
    Player _player;
    GestionJeu _gestionJeu;
    private bool _finish = false; // Boolean si la partie est termin�e
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _gestionJeu = FindObjectOfType<GestionJeu>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !_finish)
        {
            _finish = true;
            
            int noScene = SceneManager.GetActiveScene().buildIndex; // Selection du num�ro de scene
            _gestionJeu.SetTempsNiv(noScene); // Enregistrement du temps du niveau
            _gestionJeu.SetPointageNiv(noScene); // Enregistrement du pointage du niveau

            if (noScene == 3) // V�rification si c'est la derni�re sc�ne du jeu
            {
                _player.FinPartie();
                _gestionJeu.SetTempsFinal(Time.time);
                SceneManager.LoadScene(noScene + 1); // changement de scene
            }
            else
            {
                SceneManager.LoadScene(noScene + 1); // changement de scene
            }
        }
    }
    
    public float Temps_final() // Obtention du temps final du jeu (temps + pointage de tout les niveaux)
    {
        float temps = Time.time;
        temps = temps + _gestionJeu.GetPointage();
        return temps;
    }
}
