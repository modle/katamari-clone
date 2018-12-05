using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour {

  private float movement;

    // Update is called once per frame
    void Update () {
        // multiplying the framerate value by Time.deltaTime makes the rotation smooth and frame-rate independent
        // transform.Translate (new Vector3 (0.01f * Time.time % 1, 0, 0));
        movement = Mathf.Sin(Time.time) * Time.deltaTime;
        transform.Translate (new Vector3 (movement, 0, movement));
    }
}
