using UnityEngine;

public abstract class BulletController : MonoBehaviour
{
    protected BulletModel model;
    protected BulletView view;

    public virtual void Initialize(BulletModel bulletModel, BulletView bulletView)
    {
        model = bulletModel;
        view = bulletView;

        view.Initialize(model);
    }

    protected virtual void Update()
    {
        if (model == null)
            return;

        if (model.ShouldDestroy())
        {
            Destroy(gameObject);
            return;
        }

        MoveBullet();
        CheckCollision();
    }

    protected abstract void MoveBullet();

    protected virtual void CheckCollision()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, model.speed * Time.deltaTime, model.hitLayers))
        {
            HandleCollision(hit);
        }
    }

    protected virtual void HandleCollision(RaycastHit hit)
    {
        TankController tankController = hit.collider.GetComponent<TankController>();
        if (tankController != null)
        {
            tankController.TakeDamage(model.damage);
        }

        view.PlayImpactEffect(hit.point);
        Destroy(gameObject);
    }
}