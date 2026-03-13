using UnityEngine;

using StarterAssets; 

public class ObstacleTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {

            RespawnPlayer playerRespawn = other.GetComponentInParent<RespawnPlayer>();

            if (playerRespawn != null)
            {
                playerRespawn.Respawn();
            }
            else
            {
                Debug.LogError("Le joueur (Tag 'Player') n'a pas le script 'RespawnPlayer' ou le script est mal placé!");
            }
        }
    }
}