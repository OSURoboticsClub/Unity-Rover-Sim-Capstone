using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json.Linq;
using Unity.VisualScripting;

public class TestReceiver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextAsset driveMessageJson;
    [SerializeField] private UdpController udpController;  // assign in Inspector
    private JObject driveMessage;

    public JointKeyboardController[] wheels;
    void Start()
    {
        StartCoroutine(RunAtInterval());
        udpController.ConfigureSubscription("cmd_vel","geometry_msgs/msg/Twist");
    }
    
    IEnumerator RunAtInterval()
    {
        while (true) // Or some condition
        {
            driveMessage = udpController.GetLatestMessage("cmd_vel");
            if (driveMessage != null)
            {
                Debug.Log(driveMessage["data"]);
                foreach (JointKeyboardController w in wheels)
                {
                    w.SetVals(float.Parse(driveMessage["data"]["linear"]["x"].ToString()), float.Parse(driveMessage["data"]["angular"]["z"].ToString()));

                }
            }

            
            yield return new WaitForSeconds(1f/30f); // Wait 1 second
        }
    }
}
