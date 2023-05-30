using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _bullet;
    [SerializeField] float _movespeed = 0.0f;
    [SerializeField] float _downspeed = 0.0f;
    [SerializeField] float _jumpspeed = 0.0f;
    [SerializeField] float _spacetime = 0.0f;
    float _time = 0.0f;
    bool _jumpflag = false;

    // Start is called before the first frame update
    void Start()
    {
        _time = _spacetime;
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;

        Transform transform = _player.transform;
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= _movespeed;
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += _movespeed;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (pos.y <= -1.22f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _jumpflag = false;
                if (pos.y <= -0.5f)
                {
                    _jumpflag = true;
                    pos.y += _jumpspeed;
                }
            }
        }
        if (pos.y >= -1.22f)
        {
            if (_jumpflag == false)
            {
                pos.y -= _downspeed;
            }
        }

        transform.position = pos;

        if (_time >= _spacetime)
        {
            if (transform.localScale.x == 1)
            {
                if (Input.GetKey(KeyCode.B))
                {
                    Instantiate(_bullet, new Vector3(pos.x, pos.y, pos.z), Quaternion.identity);
                    _time = 0.0f;
                }
            }
            if (transform.localScale.x == -1)
            {
                if (Input.GetKey(KeyCode.B))
                {
                    Instantiate(_bullet, new Vector3(pos.x, pos.y, pos.z), Quaternion.Euler(0, 180, 0));
                    _time = 0.0f;
                }
            }
        }
    }
}
