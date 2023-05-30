using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] float _speed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform transform = _bullet.transform;
        Vector3 pos = transform.position;

        if (transform.rotation.y == 0)
        {
            pos.x -= _speed;
        }
        if (transform.rotation.y == 1)
        {
            pos.x += _speed;
        }

        transform.position = pos;
    }
}
