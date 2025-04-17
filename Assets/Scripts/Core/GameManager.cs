using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerTankPrefab;
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverPanel;

    private PlayerTankController playerController;
    private int currentScore = 0;

    private void Start()
    {
        SpawnPlayer();
        UpdateScoreUI();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    private void SpawnPlayer()
    {
        GameObject playerObj = Instantiate(playerTankPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);

        PlayerTankModel playerModel = playerObj.GetComponent<PlayerTankModel>();
        PlayerTankView playerView = playerObj.GetComponent<PlayerTankView>();
        playerController = playerObj.GetComponent<PlayerTankController>();

        if (playerController != null && playerModel != null && playerView != null)
        {
            playerController.Initialize(playerModel, playerView);

            // Subscribe to player destroyed event
            playerModel.OnDestroyed += HandlePlayerDestroyed;
        }
    }

    private void HandlePlayerDestroyed()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        // Give player a moment to see what happened before pausing
        Invoke(nameof(PauseGame), 2f);
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"Score: {currentScore}";
    }

    public Transform GetPlayerTransform()
    {
        if (playerController != null)
            return playerController.transform;

        return null;
    }
}