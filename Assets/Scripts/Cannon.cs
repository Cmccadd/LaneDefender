using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cannon : MonoBehaviour
{   
    private InputAction shoot;
    public GameObject bullet;
    public PlayerInput myPlayerInput;
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        myPlayerInput.currentActionMap.Enable();
        shoot = myPlayerInput.currentActionMap.FindAction("Shoot");

        shoot.performed += Shoot_performed;


    }


    private void Shoot_performed(InputAction.CallbackContext obj)
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
