using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimScript : MonoBehaviour
{
    public Camera cam;
    public float range = 100f;

    public void OnShoot(InputAction.CallbackContext context)
    {
        Shoot();
    }

    private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position , cam.transform.forward , out hit , range))
        {
            if(hit.transform.name == "glass_panel_1_with_door")
            {
                Debug.Log("Door Locked");
            }
        } 

    }
    void Update()
    {
        
    }
}
