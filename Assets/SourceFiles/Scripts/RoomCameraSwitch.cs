using UnityEngine;

public class RoomCameraSwitch : MonoBehaviour
{
    [Header("Configuration")]
    public Camera cameraDeCettePiece; // Glisse la caméra de la pièce ici
    
    private static Camera[] toutesLesCameras; // Liste partagée par tous les scripts

    void Start()
    {
        // On récupère toutes les caméras du jeu une seule fois
        if (toutesLesCameras == null)
        {
            toutesLesCameras = Camera.allCameras;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // On vérifie que c'est bien le joueur (Tag "Player")
        if (other.CompareTag("Player"))
        {
            ActiverCetteCamera();
        }
    }

    void ActiverCetteCamera()
    {
        // 1. On met toutes les caméras en priorité basse (0)
        foreach (Camera cam in toutesLesCameras)
        {
            cam.depth = 0;
        }

        // 2. On met la caméra de cette pièce en priorité haute (1)
        // Cela l'affiche sur l'écran principal sans éteindre les autres
        cameraDeCettePiece.depth = 1;
    }
}