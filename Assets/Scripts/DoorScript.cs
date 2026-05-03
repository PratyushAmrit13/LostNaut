using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private string playerTag = "Player";


    void Awake()
{
    if (doorAnimator == null)
        doorAnimator = GetComponentInParent<Animator>();
}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            doorAnimator.SetBool("character_nearby", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            doorAnimator.SetBool("character_nearby", false);
        }
    }
}