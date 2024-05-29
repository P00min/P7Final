using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public LayerMask targetLayer; // Layer containing the spiders
    public float shootRange = 100f; // Maximum distance to shoot
    public Transform firePoint;

    private bool isPickedUp = false;

    void Update()
    {
        if (isPickedUp && Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, shootRange, targetLayer))
        {
            // Check if the raycast hit a spider
            SpiderAI spider = hit.collider.GetComponent<SpiderAI>();
            if (spider != null)
            {
                // Destroy the spider
                Destroy(spider.gameObject);
            }
        }
    }

    public void PickUp()
    {
        isPickedUp = true;
    }
}