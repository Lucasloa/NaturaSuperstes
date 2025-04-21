using UnityEngine;
using UnityEngine.Events;

public class ExpPickup : MonoBehaviour
{
    [SerializeField] private int expAmount; // Amount of experience points to give
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Assuming the player has a script that handles experience points
            Exp playerExp = collision.GetComponent<Exp>();
            if (playerExp != null)
            {
                playerExp.AddExp(expAmount); // Add experience to the player
                Debug.Log("Player picked up experience: " + expAmount);
                gameObject.SetActive(false); // Destroy the pickup object
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is create
}
