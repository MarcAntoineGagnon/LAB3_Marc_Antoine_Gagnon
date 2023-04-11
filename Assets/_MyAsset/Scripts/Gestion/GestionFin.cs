using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GestionFin : MonoBehaviour
{
    GestionJeu _gestionJeu;

    [SerializeField] private TMP_Text _txtAccrochage = default;
    [SerializeField] private TMP_Text _txtTemps = default;
    [SerializeField] private TMP_Text _txtTempsFinal = default;

    private void Awake()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();

        _txtAccrochage.text = "Accrocharges Totals :    " + _gestionJeu.GetPointage(); // Affichage pointage
        _txtTemps.text = "Temps sans accrochage :   " + _gestionJeu.GetTempsFinal().ToString("f2"); // Affichage temps sans pointage
        _txtTempsFinal.text = "Temps Total Final :  " + _gestionJeu.GetTempsPointage().ToString("f2"); // Affichage temps + pointage
    }
}
