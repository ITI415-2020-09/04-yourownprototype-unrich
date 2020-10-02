using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;
    void Update()
    {
        Vector3 position = this.transform.position;
        float movement = Input.GetAxis("Horizontal");
        position.x = position.x + speed * movement * Time.deltaTime;
        this.transform.position = position;
    }
}
