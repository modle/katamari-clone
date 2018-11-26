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
    private Vector3 moveVector = Vector3.zero;
    private Vector3 defaultPosition = new Vector3(0, 10f, 0);
    private float maxDistance = 1000f;
    private float baseGravity = 1f;

	void Start() {
		count = 0;
		SetCountText();
		winText.text = "";
	}

	// physics code
	void FixedUpdate() {
        moveVector = GetMoveVector();
        moveVector.y = Input.GetAxis("Triggers") * 5;
		GetComponent<Rigidbody>().AddForce(moveVector * speed);
        ResetIfOutside();
	}

    Vector3 GetMoveVector() {
        Vector3 tempVector = Vector3.zero;
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
        tempVector = new Vector3(moveHorizontal, 0.0f, moveVertical);
        tempVector = camera.transform.TransformDirection(tempVector);
        return tempVector;
    }

    void ResetIfOutside() {
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
        print (Input.GetAxis("Triggers"));
        return Input.GetAxis("Triggers") != 0;
    }

    bool IsOutsideBounds() {
        // return false;
        return transform.position.x > maxDistance || transform.position.x < -maxDistance || transform.position.z > maxDistance || transform.position.z < -maxDistance;
    }

	void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag != "pickup") {
            return;
        }
        DoPickup(other);
	}

    void DoPickup(Collision other) {
        other.gameObject.transform.SetParent(transform);
        Destroy(other.gameObject.GetComponent<Rigidbody>());
        other.gameObject.GetComponent<Collider>().isTrigger = false;
    }

	void SetCountText() {
		countText.text = "Count: " + count.ToString();
	}
}
