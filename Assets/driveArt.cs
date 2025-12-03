using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driveArt : MonoBehaviour
{
    ArticulationBody ab;
    Vector3 translation;
    Vector3 rotation;

    [SerializeField] float rotateForce;
    [SerializeField] float driveForce;
    float archiveRotateForce;
    float archiveDriveForce;

    Vector3 initPosition;
    Quaternion initRotation;

    // Start is called before the first frame update
    void Start()
    {
        ab = GetComponent<ArticulationBody>();
        archiveDriveForce = driveForce;
        archiveRotateForce = rotateForce;
        initPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z) ;
        initRotation = new Quaternion(transform.rotation.x,transform.rotation.y,transform.rotation.z,transform.rotation.w);


    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.right;
        Vector3 up = transform.up;
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
        ab.AddForce(translation);
        ab.AddTorque(rotation);

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
            // driveForce = 0;
            // rotateForce = 0;
        }
    }
}
