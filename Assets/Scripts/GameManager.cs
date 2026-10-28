using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public int targetScore = 3;
    void Awake()
    {
        Instance = this;
    }
    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
        if (score >= targetScore)
        {
            Debug.Log("You Win!");
        }
    }
}