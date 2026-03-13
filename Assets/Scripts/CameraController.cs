using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    // On utilise maintenant le type "Camera" standard
    [SerializeField] private Camera m_CameraA;
    [SerializeField] private Camera m_CameraB;

    private InputAction m_SwitchAction;
    private const string SWITCH_ACTION_NAME = "Switch";

    private void Awake()
    {
        // Au début, on active la première et on éteint la seconde
        if (m_CameraA != null) m_CameraA.enabled = true;
        if (m_CameraB != null) m_CameraB.enabled = false;
    }

    private void Start()
    {
        // On récupère l'action "Switch" dans ton Input Action Asset
        m_SwitchAction = InputSystem.actions.FindAction(SWITCH_ACTION_NAME);
        
        if (m_SwitchAction != null)
        {
            m_SwitchAction.performed += OnSwitchActionPerformed;
        }
        else
        {
            Debug.LogError($"L'action {SWITCH_ACTION_NAME} est introuvable !");
        }
    }

    private void OnSwitchActionPerformed(InputAction.CallbackContext obj)
    {
        // On inverse simplement l'état d'activation des caméras
        m_CameraA.enabled = !m_CameraA.enabled;
        m_CameraB.enabled = !m_CameraA.enabled;
    }
}