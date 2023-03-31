using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piege_Teleportation : MonoBehaviour
{
    [SerializeField] private float _positionX = 0f; // position en X de la téléportation
    [SerializeField] private float _positionY = 0f; // position en Y de la téléportation
    [SerializeField] private float _positionZ = 0f; // position en Z de la téléportation

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = new Vector3(_positionX, _positionY, _positionZ); // Téléportation du GameObject à la position indiquée
    }
}
