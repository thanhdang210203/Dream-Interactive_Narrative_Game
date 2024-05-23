using System;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    // The radius of the item's interaction area
    public float interactionRadius;

    private void Start()
    {
        // Add a sphere collider to represent the item's interaction area
        SphereCollider sphereCollider = gameObject.AddComponent<SphereCollider>();
        sphereCollider.radius = interactionRadius;
        sphereCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is on the player's layer
        if (other.CompareTag("Player"))
        {
            // The player has entered the item's interaction area
            Debug.Log("Player entered the item's interaction area");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}