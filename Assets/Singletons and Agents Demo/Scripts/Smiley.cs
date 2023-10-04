using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Smiley : MonoBehaviour
{
    public float moveSpeed;

    private Vector3 _move;

    private void Update()
    {
        _move = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
            _move.y += 1;
        if (Input.GetKey(KeyCode.S))
            _move.y -= 1;
        if (Input.GetKey(KeyCode.D))
            _move.x += 1;
        if (Input.GetKey(KeyCode.A))
            _move.x -= 1;

        this.transform.position += _move.normalized * moveSpeed * Time.deltaTime;

    }
}
