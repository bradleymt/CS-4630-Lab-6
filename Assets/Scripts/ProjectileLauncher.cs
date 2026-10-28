using UnityEngine;
using UnityEngine.InputSystem;
public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float launchForce = 18f;
    void Update()
    {
        if (Keyboard.current != null &&
        Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject projectile = Instantiate(
        projectilePrefab,
        firePoint.position,
        firePoint.rotation
        );
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(
        firePoint.forward * launchForce,
        ForceMode.Impulse
        );
        Destroy(projectile, 5f);
    }
}