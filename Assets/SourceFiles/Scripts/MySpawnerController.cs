using UnityEngine;

public class MySpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Prefab;

    // Update is called once per frame
    void Update()
    {
        GameObject newObject = Instantiate(m_Prefab, transform.position, Quaternion.identity);
        newObject.transform.SetParent(transform);
    }
}
