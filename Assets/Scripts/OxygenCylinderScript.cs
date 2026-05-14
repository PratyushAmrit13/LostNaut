using UnityEngine;

public class OxygenCylinderScript : MonoBehaviour
{
    public float oxygenAmount = 150f;
    public float rotateSpeed = 150f;

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

    private void Update()
    {
        transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
    }
}