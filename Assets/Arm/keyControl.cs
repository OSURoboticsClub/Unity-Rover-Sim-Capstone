using UnityEngine;

public class JointKeyboardController : MonoBehaviour
{

    public enum Side
    {
        Left,
        Right
    }
    [Header("Assign the Articulation Body you want to control")]
    public ArticulationBody joint;

    [Header("Joint Motion Settings")]
    public float speed = 500f; // degrees per second
    public KeyCode positiveKey = KeyCode.Q;
    public KeyCode negativeKey = KeyCode.E;

    public Side side = Side.Left;

    private float target;
    public float linearX;
    private float rotationZ;

    void Start()
    {
        target = joint.xDrive.target;
    }

    public void SetVals(float linearX, float rotationZ)
    {
        this.linearX = linearX;
        this.rotationZ = rotationZ;
    }

    void FixedUpdate()
    {
        // float move = 0f;
        // if (Input.GetKey(positiveKey))
        //     move = 1f;
        // else if (Input.GetKey(negativeKey))
        //     move = -1f;

        // if (move != 0)
        // {
        //     target += move * speed * Time.deltaTime;

        //     var drive = joint.xDrive;
        //     drive.target = target;
        //     joint.xDrive = drive;
        // }
        if(Time.frameCount < 50)
        {
            return;
        }


        if(side == Side.Left)
        {
            target = linearX - (rotationZ / 2.0f);
        }
        else
        {
            target = linearX + (rotationZ / 2.0f);
        }

        target *= speed / 10.0f;

        var drive = joint.xDrive;
        drive.target = target;
        joint.xDrive = drive;


    }
}
