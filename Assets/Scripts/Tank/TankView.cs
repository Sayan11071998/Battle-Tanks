using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    public Rigidbody rb;

    private float movement;
    private float rotation;

    private void Update()
    {
        Movement();

        if (movement != 0)
        {
            tankController.Move(movement, 30);
        }

        if (rotation != 0)
        {
            tankController.Rotate(rotation, 20);
        }
    }

    private void Movement()
    {
        movement = Input.GetAxis("Vertical");
        rotation = Input.GetAxis("Horizontal");
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