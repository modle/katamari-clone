using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject camera;
	public float speed;
	public Text countText;
	public Text winText;
	private int count = 0;

	void Start() {
		count = 0;
		SetCountText();
		winText.text = "";
	}

	// physics code
	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveVector = new Vector3(moveHorizontal, 0.0f, moveVertical);
        moveVector = camera.transform.TransformDirection(moveVector);
        moveVector.y = 0f;
		GetComponent<Rigidbody>().AddForce(moveVector * speed);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag("pickup")) {
			other.gameObject.SetActive(false);
			count += 1;
			SetCountText();
			if (GameObject.FindGameObjectsWithTag("pickup").Length == 0) {
				winText.text = "You Win";
			}
		}
	}

	void SetCountText() {
		countText.text = "Count: " + count.ToString();
	}
}
