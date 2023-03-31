using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piege_Propulsion : MonoBehaviour
{
    private bool _isActive = false;
    [SerializeField] private List<GameObject> _listPiege = new List<GameObject>();
    private List<Rigidbody> _listRb = new List<Rigidbody>();
    [SerializeField] private float _vitesse = 1f;


    private void Awake()
    {
        foreach (var piege in _listPiege) 
        {
            _listRb.Add(piege.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !_isActive)
        {
            foreach(var rb in _listRb)
            {
                rb.useGravity = true;
                Vector3 direction = new Vector3(1f, 0f, 0f);
                rb.AddForce(direction * _vitesse);
            }
            _isActive = true;
        }
        
    }
}
