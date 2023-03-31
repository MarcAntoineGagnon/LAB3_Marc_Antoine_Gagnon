using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionJeu : MonoBehaviour
{
    private int _pointage;          // Nombres d'obstacles touchés au total
    public int _pointageNiv1;       // Nombre d'obstacles touchés au niveau 1
    public int _pointageNiv2;       // Nombre d'obstacles touchés au niveau 2
    public int _pointageNiv3;       // Nombre d'obstacles touchés au niveau 3
    public float _tempsNiv1;        // Temps du niveau 1 
    public float _tempsNiv2;        // Temps du niveau 2 
    public float _tempsNiv3;        // Temps du niveau 3 
    private bool _endGame = false;  // Détermine si le jeu est terminer

    // Détection si il existe déjà un gameObject GestionJeu (si oui on efface le nouveau pour conserver le temps)
    private void Awake()
    {
        int nbGestionJeu = FindObjectsOfType<GestionJeu>().Length;
        if (nbGestionJeu > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        InstructionDepart();
        _pointage = 0;
    }

    // Permettre de quitter le jeu en appuyant sur echap lorsque la partie est terminer
    void Update()
    {
        if (_endGame)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
    // Instruction du jeu
    private void InstructionDepart()
    {
        Debug.Log("*** Course à obstacle ***");
        Debug.Log("Le but du jeu est d'atteindre la zone d'arrivée le plus rapidement possible.");
        Debug.Log("Chaque obstacle qui sera touché donnera une pénalité de 1 seconde au joueur");
        Debug.Log("Bonne chance !");
    }

    // Méthode d'augmentation du pointage
    public void AugmenterPointage()
    {
        _pointage++;
        Debug.Log("Nombre d'accrochage : " + _pointage);
    }
    // Méthode pour connaitre le pointage total
    public int GetPointage()
    {
        return _pointage;
    }

    // Methode enregistrer temps de chaque niveau
    public void SetTempsNiv(int noScene)
    {
        if(noScene == 0)
        {
            Debug.Log("Fin Niveau 1");
            _tempsNiv1 = Time.time;
        }
        else if (noScene == 1)
        {
            Debug.Log("Fin Niveau 2");
            _tempsNiv2 = Time.time - _tempsNiv1;
        }
        else if (noScene == 2)
        {
            Debug.Log("Fin Niveau 3");
            _tempsNiv3 = Time.time - _tempsNiv1 - _tempsNiv2;
        }
    }

    // Methode enregistrer pointage de chaque niveau
    public void SetPointageNiv(int noScene)
    {
        if (noScene == 0)
        {
            _pointageNiv1 = GetPointage();
        }
        else if (noScene == 1)
        {
            _pointageNiv2 = GetPointage() - _pointageNiv1; // pointage total - niveau précédent
        }
        else if (noScene == 2)
        {
            _pointageNiv3 = GetPointage() - _pointageNiv1 - _pointageNiv2; // pointage total - niveau précédent
        }
    }

    //Methode retourner temps de chaque niveau
    public float GetTempsNiv1()
    {
        return _tempsNiv1;
    }

    public float GetTempsNiv2()
    {
        return _tempsNiv2;
    }

    public float GetTempsNiv3()
    {
        return _tempsNiv3;
    }

    // Methode retourner pointage de chaque niveau
    public int GetPointageNiv1()
    {
        return _pointageNiv1;
    }

    public int GetPointageNiv2() 
    {
        return _pointageNiv2;
    }
    public int GetPointageNiv3() 
    {
        return _pointageNiv3;
    }

    // Methode retourner temps Final de chaque niveau (temps + pointage)
    public float GetTempsFinalNiv1()
    {
        float temps = GetTempsNiv1();
        temps = temps + GetPointageNiv1();
        return temps;
    }

    public float GetTempsFinalNiv2()
    {
        float temps = GetTempsNiv2();
        temps = temps + GetPointageNiv2();
        return temps;
    }

    public float GetTempsFinalNiv3()
    {
        float temps = GetTempsNiv3();
        temps = temps + GetPointageNiv3();
        return temps;
    }

    // Méthode pour finir la partie
    public void EndGame()
    {
        _endGame = true;
    }
}
