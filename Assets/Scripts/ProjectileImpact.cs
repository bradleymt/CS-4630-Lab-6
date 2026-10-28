using UnityEngine;
public class ProjectileImpact : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Target target =
        collision.gameObject.GetComponent<Target>();
        if (target != null)
        {
            target.Hit();
            Destroy(gameObject);
        }
    }
}