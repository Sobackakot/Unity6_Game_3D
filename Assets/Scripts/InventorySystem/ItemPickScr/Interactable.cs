 
using UnityEngine;

// Class representing an interactable object. 
public class Interactable : MonoBehaviour
{
    public readonly float radius = 3f; // Interaction radius.
    [SerializeField]private Transform player; // Reference to the player.
    private Transform interact; // Reference to the interactable object's transform. 

    // Draw the interaction radius in the editor.
    private void OnDrawGizmosSelected()
    {
        if (interact == null)
            interact = transform;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius); 
    }
     
    private void Awake()
    {
        interact = GetComponent<Transform>(); 
    }
     
    private void OnMouseDown()
    {
        float distance = Vector3.Distance(player.position, interact.position); // Calculate the distance to the player.
        if (distance < radius)
        {
            Interaction(); // Perform the interaction.
        }
    }

    // Method to perform the interaction.
    public virtual void Interaction()
    {
        Debug.Log("Interactable");
    }
     
}
