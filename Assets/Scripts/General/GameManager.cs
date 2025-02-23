using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool isGamesStart;

    private void Start()
    {
        isGamesStart = false;
    }

    public void StartGame()
    {
        isGamesStart = true;
    }
}