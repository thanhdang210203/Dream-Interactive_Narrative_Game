using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    // The radius of the item's interaction area
    [SerializeField] private float interactionRadius = 1f;
    // The player's layer
    [SerializeField] private LayerMask playerLayer;

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
        if (playerLayer == (playerLayer | (1 << other.gameObject.layer)))
        {
            // The player has entered the item's interaction area
            Debug.Log("Player entered the item's interaction area");
        }
    }
}