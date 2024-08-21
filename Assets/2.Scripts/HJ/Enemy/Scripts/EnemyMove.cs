using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class EnemyMove : MonoBehaviour
{
    [SerializeField] private GameObject _moveChannel;
    private Rigidbody2D _rigid;
    private Transform[] _wayPoints;

    private int way = 1; // 현재 가고있는 way번호
    public bool end = false; // 동작 정지 유무 

    public float _moveDistance = 0f; // 움직인 거리

    [SerializeField] private float _speed = 5f;

    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _wayPoints = _moveChannel.GetComponentsInChildren<Transform>();
    }

    private void FixedUpdate()
    {
        _rigid.velocity = new Vector3(0, 0, 0);
        if (end) return;
        _moveDistance += 0.01f * _speed;
        Move();
    }

    private void Move()
    {
        if (way > _moveChannel.transform.childCount)
        {
            end = true;
            _rigid.velocity = new Vector3(0,0,0);
            Pass();
            return;
        }
        _rigid.velocity = (_wayPoints[way].position - transform.position).normalized * _speed;


        if (0.1 > Vector3.Distance(_wayPoints[way].position, transform.position))
        {
            transform.position = _wayPoints[way].position;
            way++;
        }
    }


    private void Pass()
    {
        print("적이 통과했습니다");
    }
}
