using UnityEngine;

public class TankSelectionUI : MonoBehaviour
{
    public TankSpawner tankSpawner;

    public void GreenTankSelected()
    {
        tankSpawner.CreateTank(TankTypes.GreenTank);
        this.gameObject.SetActive(false);
    }

    public void BlueTankSelected()
    {
        tankSpawner.CreateTank(TankTypes.BlueTank);
        this.gameObject.SetActive(false);
    }

    public void RedTankSelected()
    {
        tankSpawner.CreateTank(TankTypes.RedTank);
        this.gameObject.SetActive(false);
    }
}