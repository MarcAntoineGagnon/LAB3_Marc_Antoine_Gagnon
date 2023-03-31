using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinNiveau : MonoBehaviour
{
    Player _player;
    GestionJeu _gestionJeu;
    private bool _finish = false; // Boolean si la partie est terminée
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
            
            int noScene = SceneManager.GetActiveScene().buildIndex; // Selection du numéro de scene
            _gestionJeu.SetTempsNiv(noScene); // Enregistrement du temps du niveau
            _gestionJeu.SetPointageNiv(noScene); // Enregistrement du pointage du niveau

            if (noScene == 2) // Vérification si c'est la dernière scène du jeu
            {
                _player.FinPartie();
                Debug.Log("Partie Terminer !! \n");

                Debug.Log("Temps niveau 1 sans pointage : " + _gestionJeu.GetTempsNiv1());
                Debug.Log("Nombre de collisions Niveau 1 : " + _gestionJeu.GetPointageNiv1());
                Debug.Log("Temps avec collisions Niveau 1 : " + _gestionJeu.GetTempsFinalNiv1() + "\n");

                Debug.Log("Temps niveau 2 sans pointage : " + _gestionJeu.GetTempsNiv2());
                Debug.Log("Nombre de collisions Niveau 2 : " + _gestionJeu.GetPointageNiv2());
                Debug.Log("Temps avec collisions Niveau 2 : " + _gestionJeu.GetTempsFinalNiv2() + "\n");

                Debug.Log("Temps niveau 3 sans pointage : " + _gestionJeu.GetTempsNiv3());
                Debug.Log("Nombre de collisions Niveau 3 : " + _gestionJeu.GetPointageNiv3());
                Debug.Log("Temps avec collisions Niveau 3 : " + _gestionJeu.GetTempsFinalNiv3() + "\n");

                Debug.Log("Votre temps final sans pénalité est de : " + Time.time);
                Debug.Log("Vous avez touché au total : " + _gestionJeu.GetPointage() + " Obstacle(s)");
                Debug.Log("Votre temps final est de : " + Temps_final());
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
