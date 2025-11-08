using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drive : MonoBehaviour
{
    Rigidbody rb;
    Vector3 translation;
    Vector3 rotation;

    [SerializeField] float driveForce;
    [SerializeField] GameObject tipObject;
    [SerializeField] GameObject farObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = (tipObject.transform.position - farObject.transform.position).normalized;
        if (Input.GetKey(KeyCode.W))
        {
            translation = forward * driveForce;
        }
        if (Input.GetKey(KeyCode.S))
        {
            translation = -forward * driveForce;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotation = Vector3.down * driveForce;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotation = Vector3.up * driveForce;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(translation);
        rb.AddTorque(rotation);

        translation = Vector3.zero;
        rotation = Vector3.zero;
    }
}
