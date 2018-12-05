using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour {

    // Update is called once per frame
    void Update () {
        // multiplying the framerate value by Time.deltaTime makes the rotation smooth and frame-rate independent
        transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
    }
}
