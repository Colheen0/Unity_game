using UnityEngine;
using UnityEngine.InputSystem;

public class DoorController : MonoBehaviour
{
    public float yOpen = -2.5f;
    public float yClosed = 2.5f;
    public float speed = 5f;

    private bool closed = false;

    public void ToggleDoor()
    {
        closed = !closed;
        Debug.Log("Porte activée ! État fermé : " + closed);
    }

    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            ToggleDoor();
        }

        float cibleY = closed ? yClosed : yOpen;
        Vector3 pos = transform.localPosition;
        pos.y = Mathf.MoveTowards(pos.y, cibleY, speed * Time.deltaTime);
        transform.localPosition = pos;
    }
}