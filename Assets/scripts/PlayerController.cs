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
    private Vector3 jumpVector = Vector3.zero;
    private Vector3 moveVector = Vector3.zero;
    private Vector3 defaultPosition = new Vector3(0, 10f, 0);
    private float maxDistance = 1000f;

	void Start() {
		count = 0;
		SetCountText();
		winText.text = "";
	}

	// physics code
	void FixedUpdate() {
        moveVector.y = 0f;

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

        jumpVector = Vector3.zero;
        jumpVector = ButtonsArePushed() ? Vector3.up * 5 : Vector3.zero;
        if (transform.position.y > 30f && !ButtonsArePushed()) {
            jumpVector = Vector3.down * 4;
        }
        moveVector = new Vector3(moveHorizontal, 0.0f, moveVertical);
        moveVector += jumpVector;
        moveVector = camera.transform.TransformDirection(moveVector);
		GetComponent<Rigidbody>().AddForce(moveVector * speed);
        if (IsBelow()) {
            transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);
            return;
        }
        if (IsOutsideBounds()) {
            transform.position = defaultPosition;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
	}

    bool IsBelow() {
        return transform.position.y < -25f;
    }

    bool ButtonsArePushed() {
        return Input.GetAxis("Fire1") != 0 || Input.GetAxis("Fire2") != 0 || Input.GetAxis("Fire3") != 0 || Input.GetAxis("Jump") != 0;
    }

    bool IsOutsideBounds() {
        // return false;
        return transform.position.x > maxDistance || transform.position.x < -maxDistance || transform.position.z > maxDistance || transform.position.z < -maxDistance;
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
