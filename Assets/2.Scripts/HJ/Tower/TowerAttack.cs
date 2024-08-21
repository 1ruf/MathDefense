using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float damage = 30f;
    [SerializeField] private float coolTime = 0.5f;

    private bool cool = false; // 현재 쿨타임 상태인지 여부 true면 쿨타임 상태 (공격불가능)

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


    private Transform FindTarget() // 타워의 범위 안에 있으면서 가장 많이 간 적을 찾는 함수
    {
        float dest = 0; // 가장 멀리 간 적을 찾기위한 거리 변수
        Transform target = null;

        Collider2D[] allEnemy = Physics2D.OverlapCircleAll(transform.position, 4, enemyLayer);
        
        for (int i = 0; i<allEnemy.Length; i++)
        {
            float enemyDest = allEnemy[i].GetComponent<EnemyMove>()._moveDistance; // 적이 얼마나 멀리 갔는지
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
