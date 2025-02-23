using System;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private TankSpawner spawner;
    
    private TankType selectedType;

    private void Start()
    {
        selectedType = TankType.GreenTank;
    }

    public void SetTankType(int selected)
    {
        selectedType = (TankType)selected;
    }

    public void StartGame()
    {
        spawner.CreateTank(selectedType);
        mainMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}