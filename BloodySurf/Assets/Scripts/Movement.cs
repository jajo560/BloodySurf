using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private float horizontal;
    private float vertical;
    public float speed;
    private Rigidbody rb;
    private Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        movement = new Vector3(horizontal, vertical, 0);

        rb.velocity += movement * speed * Time.deltaTime;

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, -8f, 8f), Mathf.Clamp(rb.position.y, -1.4f, 6.7f), 0);

    }
}
