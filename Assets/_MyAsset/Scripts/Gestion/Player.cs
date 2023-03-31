using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Attribut
    [SerializeField] private float _speed = 500f;           // Vitesse du joueur
    [SerializeField] private float _rotationSpeed = 500f;   // Vitesse de rotation
    private Rigidbody _rb; // RigidBody du joueur
    GestionJeu _gestionJeu;
    private bool _mobile = true; // Boolean si le joueur peut bouger

    // positionnement de départ du joueur
    void Start()
    {
        transform.position = new Vector3(-45f, 21.7f, -45f);
        _rb = GetComponent<Rigidbody>();
        _gestionJeu = FindObjectOfType<GestionJeu>();
    }

    void FixedUpdate()
    {
        if(_mobile) 
        { 
           MouvementsPlayer();
        }
    }

    // fonction de mouvement du jouuer
    private void MouvementsPlayer()
    {
        // attribut Déplacement normal
        float sprint = _speed * 1.5f;
        float positionX = Input.GetAxis("Horizontal");
        float positionZ = Input.GetAxis("Vertical");
        Vector3 direction = new(positionX, 0f, positionZ);

        // Sprint Lorsque le joueur appui sur shift
        if (Input.GetKey(KeyCode.LeftShift))
            _rb.velocity = direction.normalized * Time.fixedDeltaTime * sprint; // Mouvement sprint
        else
            _rb.velocity = direction.normalized * Time.fixedDeltaTime * _speed; // Mouvement normale

        // Rotation Joueur
        if(direction.magnitude >= 0.1f) // Si le joueur est en mouvement uniquement (garde son angle lorsque immobile)
        {
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, _rotationSpeed * Time.deltaTime); // rotation en fonction de l'angle
        }
        

    }

    // Fonction pour empêcher le joueur de bouger
    public void immobile()
    {
        _mobile = false;
    }

    // Fonction pour redonner la possibilité au joueur de bouger
    public void mobile()
    {
        _mobile= true;
    }

    // Fin de la partie et arret du joueur
    public void FinPartie()
    {
        _gestionJeu.EndGame();
        gameObject.SetActive(false);
    }
}


