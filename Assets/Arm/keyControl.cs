using UnityEngine;

public class JointKeyboardController : MonoBehaviour
{
    [Header("Assign the Articulation Body you want to control")]
    public ArticulationBody joint;

    [Header("Joint Motion Settings")]
    public float speed = 50f; // degrees per second
    public KeyCode positiveKey = KeyCode.Q;
    public KeyCode negativeKey = KeyCode.E;

    private float target;

    void Start()
    {
        target = joint.xDrive.target;
    }

    void Update()
    {
        float move = 0f;
        if (Input.GetKey(positiveKey))
            move = 1f;
        else if (Input.GetKey(negativeKey))
            move = -1f;

        if (move != 0)
        {
            target += move * speed * Time.deltaTime;

            var drive = joint.xDrive;
            drive.target = target;
            joint.xDrive = drive;
        }
    }
}
