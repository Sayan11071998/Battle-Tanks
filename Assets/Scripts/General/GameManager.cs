using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isGamesStart;

    private void Start()
    {
        isGamesStart = false;
    }

    public void StartGame()
    {
        isGamesStart = true;
    }
}