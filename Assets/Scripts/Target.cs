using UnityEngine;
public class Target : MonoBehaviour
{
    public static int score = 0;
    public void Hit()
    {
        score++;
        Debug.Log("Target hit! Score: " + score);
        Destroy(gameObject);
    }
}