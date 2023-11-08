using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    //Il faut passer le knockback en un scripts supplementaire a rajouter.

    public static EnemyProjectile Create(Vector3 position, Vector3 moveDir, Quaternion rotation)
    {
        Transform pfProjectile = Resources.Load<Transform>("pfProjectileTest1");
        Transform projectileTransform = Instantiate(pfProjectile, position, rotation);

        EnemyProjectile enemyProjectile = projectileTransform.GetComponent<EnemyProjectile>();

        enemyProjectile.Setup(moveDir);

        return enemyProjectile;
    }



    [SerializeField] private float KnockbackStr;
    [SerializeField] private float KnockbackTimer;
    [SerializeField] private float timerStop;

    private HealthSystem healthSystemPlayer;
    private PlayerMvmnt playerMvmnt;

    private Vector3 moveDir;
    private float moveSpeed;

    private void Start()
    {
        moveSpeed = 10f;
        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        healthSystemPlayer = collision.gameObject.GetComponent<HealthSystem>();
        playerMvmnt = collision.gameObject.GetComponent<PlayerMvmnt>();

        if (playerMvmnt != null)
        {
            CameraShaker.Instance.ShakeCamera(4f, 0.1f);

            playerMvmnt.SetKnockback(transform.position, KnockbackTimer, timerStop, KnockbackStr);

            healthSystemPlayer.Damage(1);

        }

        Destroy(gameObject);
    
    }

    private void Setup(Vector3 moveDir)
    {
        this.moveDir = moveDir;
    }
}
