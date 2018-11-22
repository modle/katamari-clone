using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}

	// follow cameras, procedural updates, last-known-states; runs every frame, but runs after all items have been processed in Update()
	// so we know absolutely the player has moved for that frame
	void LateUpdate() {
		transform.position = player.transform.position + offset;
	}
}
