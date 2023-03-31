using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listObstacle = new List<GameObject>(); // Liste de tout les obstacles
    [SerializeField] private Light _lumiere; // Lumière à changer
    private bool _actif = false; // Boolean si il à déjà été activé

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !_actif)
        {
            foreach (var obj in _listObstacle)
            {
                obj.SetActive(false); // Désactivé tout les obstacles de la liste
            }

            _lumiere.color = Color.green; // Changement de la couleur de la lumière
            transform.Rotate(90f, 0f, 0f); // Rotation du levier (haut vers le bas)
            _actif = true;
        }

    }
}
