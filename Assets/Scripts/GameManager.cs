using TMPro;
using UnityEngine;
using static GameManager;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public enum GameState { Playing, Won, Lost }
    public int targetScore = 3;
    public int startingAmmo = 10;
    public TMP_Text scoreText, ammoText, resultText;
    public GameState state = GameState.Playing;
    private int score, ammo, projectilesInFlight;
    void Awake()
    {
        if (Instance != null && Instance != this)
        { Destroy(gameObject); return; }
        Instance = this;
    }
    void Start() { ammo = startingAmmo; UpdateHUD(); }
    public bool CanShoot() => state == GameState.Playing && ammo > 0;
    public void ShotFired()
    {
        if (!CanShoot()) return;
        ammo--;
        projectilesInFlight++;
        UpdateHUD();
     }
    public void AddScore(int points)
    {
        if (state != GameState.Playing) return;
        score += points;
        if (score >= targetScore) state = GameState.Won;
        UpdateHUD();
    }
    public void ProjectileFinished()
    {
        projectilesInFlight = Mathf.Max(0, projectilesInFlight - 1);
        if (state == GameState.Playing && ammo == 0 && projectilesInFlight == 0)
            state = GameState.Lost;
        UpdateHUD();
    }
    void UpdateHUD()
    {
        if (scoreText) scoreText.text = "Score: " + score + "/" + targetScore;
        if (ammoText) ammoText.text = "Ammo: " + ammo;
        if (resultText) resultText.text = state == GameState.Won ? "YOU WIN!" :
        state == GameState.Lost ? "GAME OVER!" : "";
    }
}