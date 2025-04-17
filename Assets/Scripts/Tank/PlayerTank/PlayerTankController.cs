using UnityEngine;

public class PlayerTankController : TankController
{
    private PlayerTankModel playerModel;
    private PlayerTankView playerView;

    [SerializeField] private BulletModel armorPiercingBulletPrefab;
    [SerializeField] private BulletModel highExplosiveBulletPrefab;
    [SerializeField] private BulletModel guidedMissileBulletPrefab;

    public override void Initialize(TankModel tankModel, TankView tankView)
    {
        base.Initialize(tankModel, tankView);

        playerModel = tankModel as PlayerTankModel;
        playerView = tankView as PlayerTankView;
    }

    private void Update()
    {
        if (model == null)
            return;

        HandleMovement();
        HandleRotation();
        HandleFiring();

        if (playerModel != null && playerView != null)
        {
            playerView.UpdateFuelVisuals(playerModel.currentFuel, playerModel.maxFuel);
        }
    }

    private void HandleMovement()
    {
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(vertical) > 0.1f && playerModel.currentFuel > 0)
        {
            Vector3 movement = transform.forward * vertical * model.moveSpeed * Time.deltaTime;
            transform.position += movement;

            // Consume fuel
            playerModel.ConsumeFuel(vertical * playerModel.fuelConsumptionRate * Time.deltaTime);
        }
    }

    private void HandleRotation()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontal) > 0.1f && playerModel.currentFuel > 0)
        {
            float rotation = horizontal * model.rotationSpeed * Time.deltaTime;
            transform.Rotate(0, rotation, 0);

            // Consume fuel
            playerModel.ConsumeFuel(Mathf.Abs(horizontal) * playerModel.fuelConsumptionRate * 0.5f * Time.deltaTime);
        }
    }

    private void HandleFiring()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    protected override BulletModel GetBulletPrefab()
    {
        switch (model.bulletType)
        {
            case BulletType.ArmorPiercing:
                return armorPiercingBulletPrefab;
            case BulletType.HighExplosive:
                return highExplosiveBulletPrefab;
            case BulletType.GuidedMissile:
                return guidedMissileBulletPrefab;
            default:
                return armorPiercingBulletPrefab;
        }
    }
}