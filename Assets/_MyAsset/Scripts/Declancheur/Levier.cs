using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier : MonoBehaviour
{
    [SerializeField] private List<GameObject> _listObstacle = new List<GameObject>(); // Liste de tout les obstacles
    [SerializeField] private Light _lumiere; // Lumi�re � changer
    private bool _actif = false; // Boolean si il � d�j� �t� activ�

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !_actif)
        {
            foreach (var obj in _listObstacle)
            {
                obj.SetActive(false); // D�sactiv� tout les obstacles de la liste
            }

            _lumiere.color = Color.green; // Changement de la couleur de la lumi�re
            transform.Rotate(90f, 0f, 0f); // Rotation du levier (haut vers le bas)
            _actif = true;
        }

    }
}
