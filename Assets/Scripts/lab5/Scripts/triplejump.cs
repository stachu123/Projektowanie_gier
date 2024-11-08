using UnityEngine;

public class triplejump: MonoBehaviour
{
    public float jumpforce = 3f;
    private MoveWithCharacterController playerController;
    private bool isOnPlatform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na platforme.");
            playerController = other.gameObject.GetComponent<MoveWithCharacterController>();
            if (playerController != null && !isOnPlatform)
            {
                playerController.jumpHeight *= jumpforce; // Increase jump force
                isOnPlatform = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isOnPlatform)
        {
            if (playerController != null)
            {
                playerController.jumpHeight /= jumpforce; // Reset to the original jump force
            }
            isOnPlatform = false;
        }
    }
}
