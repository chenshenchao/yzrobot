using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class RobotBehaviour : MonoBehaviour
{
    public const int StandMode = 0;
    public const int AttackByBeat = 1;
    public const int AttackByFire = 2;
    public const int MoveByWalk = 1;
    public const int MoveByJump = 2;

    public float hp = 100f;     // 当前血量
    public float hpMax = 100f;  // 最大血量

    public float beatPower = 10f; // 打击强度
    public float beatSpeed = 40f; // 打击速度
    public float fireSpeed = 40f; // 开火速度
    public float walkSpeed = 6f; // 行走速度
    public float turnSpeed = 40f; // 转身速度

    public Transform muzzle; // 枪口定位
    public GameObject bullet; // 子弹预制件

    public GameObject playerMark; // 玩家颜色标记件
    public int playerNumber;       // 玩家排号

    private float beatLastAt = 0f; // 上次出拳时间
    private float fireLastAt = 0f; // 上次开火时间

    private Animator animator; // 动画器
    private Rigidbody body;    // 刚体

    public float beatInterval { get { return 100f / (100f + beatSpeed); } }
    public float fireInterval { get { return 100f / (100f + fireSpeed); } }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
    }

    public void Stand()
    {
        animator.SetInteger("AttackMode", StandMode);
        animator.SetInteger("MoveMode", StandMode);
    }

    public void Walk(Vector3 direction)
    {
        animator.SetInteger("MoveMode", MoveByWalk);

        transform.forward = Vector3.Lerp(
            transform.forward,
            direction,
            Time.deltaTime * turnSpeed
        ).normalized;
        body.velocity = transform.forward * walkSpeed;
    }

    public void Jump()
    {
        animator.SetInteger("MoveMode", MoveByJump);
    }

    public void Beat()
    {
        if ((beatLastAt + beatInterval) < Time.time)
        {
            beatLastAt = Time.time;
            animator.SetInteger("AttackMode", AttackByBeat);
        }
    }

    public void Fire()
    {
        if ((fireLastAt + fireInterval) < Time.time)
        {
            fireLastAt = Time.time;
            animator.SetInteger("AttackMode", AttackByFire);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 position = transform.position;
        //position.y += bottom.w;
        Gizmos.color = Color.red;
        //Gizmos.DrawWireCube(position, bottom);
        Gizmos.DrawWireCube(position, Vector3.one);
    }
}
