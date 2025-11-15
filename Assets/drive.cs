using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drive : MonoBehaviour
{
    Rigidbody rb;
    Vector3 translation;
    Vector3 rotation;

    [SerializeField] GameObject tipObject;
    [SerializeField] GameObject farObject;
    [SerializeField] GameObject headObject;

    [SerializeField] float rotateForce;
    [SerializeField] float driveForce;
    float archiveRotateForce;
    float archiveDriveForce;

    Vector3 initPosition;
    Quaternion initRotation;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        archiveDriveForce = driveForce;
        archiveRotateForce = rotateForce;
        initPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z) ;
        initRotation = new Quaternion(transform.rotation.x,transform.rotation.y,transform.rotation.z,transform.rotation.w);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = (tipObject.transform.position - farObject.transform.position).normalized;
        Vector3 up = (headObject.transform.position - farObject.transform.position).normalized;
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
            rotation = -up * rotateForce;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotation = up * rotateForce;
        }
        if (Input.GetKey(KeyCode.T))
        {
            transform.position = initPosition;
            transform.rotation = initRotation;
            Debug.Log(initPosition);
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(translation);
        rb.AddTorque(rotation);

        translation = Vector3.zero;
        rotation = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {
            driveForce = archiveDriveForce;
            rotateForce = archiveRotateForce;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {
            driveForce = 0;
            rotateForce = 0;
        }
    }
}
