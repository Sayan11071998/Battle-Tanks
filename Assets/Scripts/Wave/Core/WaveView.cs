using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WaveView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private TextMeshProUGUI enemyCountText;
    [SerializeField] private GameObject waveStartPanel;
    [SerializeField] private TextMeshProUGUI waveStartMessage;
    [SerializeField] private Image waveProgressBar;
    [SerializeField] private AudioSource waveStartSound;
    [SerializeField] private AudioSource waveCompleteSound;
    [SerializeField] private AudioSource allWavesCompleteSound;

    public void UpdateWaveText(int waveNumber)
    {
        if (waveText != null)
            waveText.text = $"Wave: {waveNumber}";
    }

    public void UpdateEnemyCount(int remaining, int total)
    {
        if (enemyCountText != null)
            enemyCountText.text = $"Enemies: {remaining}/{total}";

        if (waveProgressBar != null)
            waveProgressBar.fillAmount = 1f - (float)remaining / total;
    }

    public void ShowWaveStartMessage(string message, AudioClip sound = null)
    {
        if (waveStartPanel != null)
        {
            waveStartPanel.SetActive(true);

            if (waveStartMessage != null)
                waveStartMessage.text = message;

            if (waveStartSound != null && sound != null)
                waveStartSound.PlayOneShot(sound);

            Invoke(nameof(HideWaveStartMessage), 3f);
        }
    }

    private void HideWaveStartMessage()
    {
        if (waveStartPanel != null)
            waveStartPanel.SetActive(false);
    }

    public void PlayWaveCompleteSound()
    {
        if (waveCompleteSound != null)
            waveCompleteSound.Play();
    }

    public void PlayAllWavesCompleteSound()
    {
        if (allWavesCompleteSound != null)
            allWavesCompleteSound.Play();
    }
}