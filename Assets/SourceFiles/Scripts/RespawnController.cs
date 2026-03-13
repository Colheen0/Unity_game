using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets; // Ajouté pour RespawnPlayer

public class InputRespawn : MonoBehaviour
{
    private InputAction respawnAction;
    private RespawnPlayer respawnPlayer; // Changement de type

    private void Start()
    {
        // Récupère RespawnPlayer sur le même GameObject ou dans la scène
        if (!TryGetComponent<RespawnPlayer>(out respawnPlayer))
        {
            respawnPlayer = FindObjectOfType<RespawnPlayer>();
            if (respawnPlayer == null)
                Debug.LogWarning("Aucun StarterAssets.RespawnPlayer trouvé sur l'objet ou dans la scène.");
        }

        // Cherche l'action "Respawn" dans l'InputSystem
        respawnAction = InputSystem.actions.FindAction("Respawn");
        if (respawnAction != null)
        {
            respawnAction.performed += OnRespawnPerformed;
            respawnAction.Enable();
        }
        else
        {
            Debug.LogWarning("Action d'entrée 'Respawn' introuvable. Vérifiez votre InputActionAsset et le nom de l'action.");
        }
    }

    private void OnRespawnPerformed(InputAction.CallbackContext context)
    {
        DoRespawn();
    }

    private void DoRespawn()
    {
        if (respawnPlayer != null)
        {
            respawnPlayer.Respawn();
            Debug.Log("Respawn déclenché via Input System.");
        }
        else
        {
            Debug.LogWarning("Impossible de respawn : RespawnPlayer manquant.");
        }
    }

    private void OnDestroy()
    {
        if (respawnAction != null)
        {
            respawnAction.performed -= OnRespawnPerformed;
            respawnAction.Disable();
        }
    }
}