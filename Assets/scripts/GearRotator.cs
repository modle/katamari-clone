using System.Collections;
using UnityEngine;

public class GearRotator : MonoBehaviour {

    public Vector3 rotation;
	// Update is called once per frame
	void Update () {
		// multiplying the framerate value by Time.deltaTime makes the rotation smooth and frame-rate independent
		transform.Rotate(rotation * Time.deltaTime);
	}
}
