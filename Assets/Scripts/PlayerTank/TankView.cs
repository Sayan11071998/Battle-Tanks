using System;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    public Rigidbody rb;
    public MeshRenderer[] childs;

    private float movementInput;
    private float rotationInput;

    private void Start()
    {
    }

    private void Update()
    {
        GetInput();

        if (movementInput != 0)
        {
            tankController.Move(movementInput);
        }

        if (rotationInput != 0)
        {
            tankController.Rotate(rotationInput);
        }
    }

    private void GetInput()
    {
        movementInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");
    }

    public void ChangeColor(Material color)
    {
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].material = color;
        }
    }

    public void SetTankController(TankController _tankController)
    {
        tankController = _tankController;
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }
}