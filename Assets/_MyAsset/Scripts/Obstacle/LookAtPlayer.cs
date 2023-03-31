using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player"); // Trouver le gameObject joueur
    }


    void Update()
    {
        this.transform.LookAt(player.transform); // Transformer la rotation pour qu'il regarde le joueur
    }
}
