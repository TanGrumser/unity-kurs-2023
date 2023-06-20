using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public static GameManager instance;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private PlayerMovement player;

    private int score = 0;

    void Start() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void IncrementScore() {
        score++;
        scoreText.text = $"score: {score.ToString()}";
    }

    public void GameOver() {
        gameOverText.SetActive(true);
        player.enabled = false;
    }
}
