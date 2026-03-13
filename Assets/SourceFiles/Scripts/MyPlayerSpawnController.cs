using UnityEngine;

public class MyPlayerSpawnController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Prefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject newObject = Instantiate(m_Prefab, transform.position, Quaternion.identity);
        newObject.transform.SetParent(transform);
    }
}
