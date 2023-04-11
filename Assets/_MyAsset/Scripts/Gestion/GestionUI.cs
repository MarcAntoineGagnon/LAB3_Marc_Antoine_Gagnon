using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mono.Reflection;

public class GestionUI : MonoBehaviour
{
    private GestionJeu _gestionJeu;
    private GestionScene _gestionScene;
    private Player _player;

    [SerializeField] private TMP_Text _txtAccrochage = default;
    [SerializeField] private TMP_Text _txtTemps = default;
    [SerializeField] private GameObject _menuPause = default;
    private bool _pause;

    void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _gestionScene = FindObjectOfType<GestionScene>();
        _player = FindObjectOfType<Player>();
        _pause = false;

        _txtAccrochage.text = "Accrocharges : " + _gestionJeu.GetPointage().ToString(); // affichage pointage
        Time.timeScale = 1; // vitesse du jeu
    }

    
    void Update()
    {
        float temps = Time.time - _gestionJeu.GetTempsDepart();
        _txtTemps.text = "Temps : " + temps.ToString("f2");
        GestionPause();
    }

    private void GestionPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_pause)
        {
            _menuPause.SetActive(true);
            Time.timeScale = 0;
            _pause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _pause)
        {
            EnleverPause();
            _gestionScene.FermerInstruction();
        }
    }

    public void EnleverPause()
    {
        _menuPause.SetActive(false);
        Time.timeScale = 1;
        _pause = false;
    }

    public void AugmentePointage(int pointage)
    {
        _txtAccrochage.text = "Accrocharges : " + pointage.ToString();
    }
}
