using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cannon : MonoBehaviour
{
    private InputAction shoot;
    public GameObject bullet;
    public GameObject explosion;  
    public PlayerInput myPlayerInput;
    public Transform firePoint;
    public float fireRate = 0.5f; 
    public float explosionDuration = 2f; 
    private bool isFiring = false;

    // Start is called before the first frame update
    void Start()
    {
        myPlayerInput.currentActionMap.Enable();
        shoot = myPlayerInput.currentActionMap.FindAction("Shoot");

        shoot.performed += Shoot_performed;
        shoot.canceled += Shoot_canceled; 
    }

    private void Shoot_performed(InputAction.CallbackContext obj)
    {
        if (!isFiring)
        {
            isFiring = true;
            StartCoroutine(FireContinuously());
        }
    }

    private void Shoot_canceled(InputAction.CallbackContext obj)
    {
        isFiring = false;
    }

    private IEnumerator FireContinuously()
    {
        while (isFiring)
        {
            FireBullet();
            yield return new WaitForSeconds(fireRate); 
        }
    }

    private void FireBullet()
    {
        // Instantiate the bullet
        Instantiate(bullet, firePoint.position, firePoint.rotation);

        // Instantiate the explosion effect at the fire point
        GameObject Explosion = Instantiate(explosion, firePoint.position, firePoint.rotation);

        // Destroy the explosion object after the explosionDuration
        Destroy(Explosion, explosionDuration);
    }

  
}
