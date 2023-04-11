using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionJeu : MonoBehaviour
{
    FinNiveau _finNiveau;
    GestionFin _gestionFin;

    private int _pointage;          // Nombres d'obstacles touchés au total
    public int _pointageNiv1;       // Nombre d'obstacles touchés au niveau 1
    public int _pointageNiv2;       // Nombre d'obstacles touchés au niveau 2
    public int _pointageNiv3;       // Nombre d'obstacles touchés au niveau 3
    public int _pointageFinal;
    public float _tempsDepart;      // Temps au depart du jeu
    public float _tempsNiv1;        // Temps du niveau 1 
    public float _tempsNiv2;        // Temps du niveau 2 
    public float _tempsNiv3;        // Temps du niveau 3 
    public float _tempsFinal;      // Temps a la fin du jeu
    public float _tempsPointage;

    bool _depart; // Verification si le joueur a bouger

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
        _pointage = 0;
        _tempsDepart = Time.time;
    }

    // Permettre de quitter le jeu en appuyant sur echap lorsque la partie est terminer
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 0) // si la premiere ou derniere scene effacer gestionJeu (reset score)
        {
            Destroy(gameObject);
        }
    }

    // Méthode d'augmentation du pointage
    public void AugmenterPointage()
    {
        _pointage++;
        GestionUI gestionUI = FindObjectOfType<GestionUI>();
        gestionUI.AugmentePointage(_pointage);
    }
    // Méthode pour connaitre le pointage total
    public int GetPointage()
    {
        return _pointage;
    }

    // Méthode pour connaitre le pointage total
    public float GetTempsDepart()
    {
        return _tempsDepart;
    }

    // Methode enregistrer temps de chaque niveau
    public void SetTempsNiv(int noScene)
    {
        if(noScene == 0)
        {
            _tempsNiv1 = Time.time;
        }
        else if (noScene == 1)
        {
            _tempsNiv2 = Time.time - _tempsNiv1;
        }
        else if (noScene == 2)
        {
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

    // set du temps final (temps final - temps depart)
    public void SetTempsFinal(float tempsFinal)
    {
        _tempsFinal = tempsFinal - _tempsDepart;
    }

    // Retourner temps final
    public float GetTempsFinal()
    {
        return _tempsFinal;
    }

    // Retourner le temps final + pointage
    public float GetTempsPointage()
    {
        return _tempsFinal + GetPointage();
    }

    public void Fin()
    {
        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            SetTempsFinal(_finNiveau.Temps_final());
            _pointageFinal = GetPointage();
            _tempsPointage = GetTempsFinal() + _pointageFinal;
        }
    }
}
