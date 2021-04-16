using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    float vertical;
    float horizontal;

    float yRotate;
    Transform tr;
    Rigidbody rb;
    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        rb.velocity = tr.forward * vertical * 20f;
        rb.AddForce(tr.right * horizontal * 20f);
        transform.rotation = Quaternion.Euler(0, yRotate, 0);

    }
    public void SomeMethod(float val)
    {
        yRotate = val;
    }
}
