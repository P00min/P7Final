using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public Gun gun;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Pick up the gun
            gun.PickUp();
            // Hide the gun GameObject
            gameObject.SetActive(false);
        }
    }
}