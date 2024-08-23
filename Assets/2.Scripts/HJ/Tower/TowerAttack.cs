using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float damage = 30f;
    [SerializeField] private float coolTime = 0.5f;

    private bool cool = false; // ���� ��Ÿ�� �������� ���� true�� ��Ÿ�� ���� (���ݺҰ���)

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Transform target = FindTarget();
        if (target)
        {
            AttackTarget(target);
        }
    }

    private void AttackTarget(Transform target)
    {
        if (cool) return;
        cool = true;
        StartCoroutine(CoolTime());
        target.GetComponent<EnemyHealth>().HealthSet(damage);
    }


    private Transform FindTarget() // Ÿ���� ���� �ȿ� �����鼭 ���� ���� �� ���� ã�� �Լ�
    {
        float dest = 0; // ���� �ָ� �� ���� ã������ �Ÿ� ����
        Transform target = null;

        Collider2D[] allEnemy = Physics2D.OverlapCircleAll(transform.position, 4, enemyLayer);
        
        for (int i = 0; i<allEnemy.Length; i++)
        {
            float enemyDest = allEnemy[i].GetComponent<EnemyMove>()._moveDistance; // ���� �󸶳� �ָ� ������
            if (enemyDest > dest)
            {
                target = allEnemy[i].transform;
                dest = enemyDest;
            }
        }
        return target;
    }

    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(coolTime);
        cool = false;
    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 4);
    }

}
