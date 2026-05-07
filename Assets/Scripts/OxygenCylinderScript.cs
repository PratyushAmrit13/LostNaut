using UnityEngine;

public class OxygenCylinderScript : MonoBehaviour
{
    public float oxygenAmount = 150f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerOxygen playerOxygen =
                other.GetComponent<PlayerOxygen>();

            if (playerOxygen != null)
            {
                playerOxygen.AddOxygen(oxygenAmount);
            }

            Destroy(gameObject);
        }
    }
}