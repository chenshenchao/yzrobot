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

    public float hp = 100f;     // ��ǰѪ��
    public float hpMax = 100f;  // ���Ѫ��

    public float beatPower = 10f; // ���ǿ��
    public float beatSpeed = 40f; // ����ٶ�
    public float fireSpeed = 40f; // �����ٶ�
    public float walkSpeed = 6f; // �����ٶ�
    public float turnSpeed = 40f; // ת���ٶ�

    public Transform muzzle; // ǹ�ڶ�λ
    public GameObject bullet; // �ӵ�Ԥ�Ƽ�

    public GameObject playerMark; // �����ɫ��Ǽ�
    public int playerNumber;       // ����ź�

    private float beatLastAt = 0f; // �ϴγ�ȭʱ��
    private float fireLastAt = 0f; // �ϴο���ʱ��

    private Animator animator; // ������
    private Rigidbody body;    // ����

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
