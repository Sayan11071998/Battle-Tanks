using UnityEngine;
using UnityEngine.AI;

public class EnemyTankController : TankController
{
    private NavMeshAgent navAgent;
    private Transform playerTransform;
    private EnemyTankModel enemyModel;
    private GameManager gameManager;
    private WaveManagerController waveManager;

    [SerializeField] private BulletModel armorPiercingBulletPrefab;
    [SerializeField] private BulletModel highExplosiveBulletPrefab;
    [SerializeField] private BulletModel guidedMissileBulletPrefab;

    private enum State
    {
        Idle,
        Chasing,
        Attacking
    }

    private State currentState = State.Idle;

    public override void Initialize(TankModel tankModel, TankView tankView)
    {
        base.Initialize(tankModel, tankView);

        enemyModel = tankModel as EnemyTankModel;

        navAgent = GetComponent<NavMeshAgent>();
        if (navAgent != null)
        {
            navAgent.speed = model.moveSpeed;
            navAgent.angularSpeed = model.rotationSpeed;
            navAgent.stoppingDistance = model.attackRange * 0.8f;
        }

        gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            playerTransform = gameManager.GetPlayerTransform();
        }

        waveManager = FindObjectOfType<WaveManagerController>();

        model.OnDestroyed += HandleDestroyed;
    }

    private void HandleDestroyed()
    {
        // Add score
        if (gameManager != null)
        {
            gameManager.AddScore(enemyModel.scoreValue);
        }

        // Notify wave manager
        if (waveManager != null)
        {
            waveManager.EnemyDestroyed();
        }

        // Destroy after delay to allow effects to play
        Destroy(gameObject, 3f);

        // Disable components
        GetComponent<Collider>().enabled = false;
        if (navAgent != null)
            navAgent.enabled = false;

        enabled = false;
    }

    protected override BulletModel GetBulletPrefab()
    {
        switch (enemyModel.bulletType)
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

    private void Update()
    {
        if (model == null || playerTransform == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // State transitions
        switch (currentState)
        {
            case State.Idle:
                if (distanceToPlayer <= model.detectionRange)
                {
                    currentState = State.Chasing;
                }
                break;

            case State.Chasing:
                if (distanceToPlayer <= model.attackRange)
                {
                    currentState = State.Attacking;
                }
                else if (distanceToPlayer > model.detectionRange)
                {
                    currentState = State.Idle;
                }
                break;

            case State.Attacking:
                if (distanceToPlayer > model.attackRange)
                {
                    currentState = State.Chasing;
                }
                break;
        }

        // State behaviors
        switch (currentState)
        {
            case State.Idle:
                // Just stay in place
                break;

            case State.Chasing:
                ChasePlayer();
                break;

            case State.Attacking:
                AttackPlayer();
                break;
        }
    }

    private void ChasePlayer()
    {
        if (navAgent != null && navAgent.enabled)
        {
            navAgent.SetDestination(playerTransform.position);
        }
    }

    private void AttackPlayer()
    {
        // Stop moving
        if (navAgent != null && navAgent.enabled)
        {
            navAgent.SetDestination(transform.position);
        }

        // Rotate to face player
        Vector3 direction = playerTransform.position - transform.position;
        direction.y = 0;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, model.rotationSpeed * Time.deltaTime);

        // Fire if facing player
        float angle = Vector3.Angle(transform.forward, direction);
        if (angle < 10f)
        {
            Fire();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (model == null) return;

        // Detection range
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, model.detectionRange);

        // Attack range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, model.attackRange);
    }
}