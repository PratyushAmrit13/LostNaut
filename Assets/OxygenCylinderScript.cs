using UnityEngine;
using TMPro;

public class OxygenCylinderScript : MonoBehaviour
{
    private float OxygenCount;
    public TextMeshProUGUI CountText;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
