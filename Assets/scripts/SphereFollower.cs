using UnityEngine;
using System.Collections;

public class SphereFollower : MonoBehaviour {
    public GameObject player;
    
    private Vector3 _offset;
    Quaternion wantedRotation;
    
    void Start() {
        _offset = new Vector3 (0, 22, -10);    //just put the values that you want instead of y and z
        wantedRotation = Quaternion.Euler(0, 0, 0);
    }
    
    void FixedUpdate() {
        Vector3 flatSpeed = player.GetComponent<Rigidbody>().velocity;
        flatSpeed.y = 0;
        //stores the flat velocity of your player so it can put the camera always behind it
    
        if (flatSpeed.x > 0.5f || flatSpeed.z > 0.5f) {
            float targetAngle = Quaternion.LookRotation(flatSpeed).eulerAngles.y;
            wantedRotation = Quaternion.Euler(0, targetAngle, 0);
        }
    
        transform.position = player.transform.position + (wantedRotation * _offset);
        transform.LookAt(player.transform);
    }
}
