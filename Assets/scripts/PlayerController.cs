using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public static PlayerController controller;

    public GameObject camera;
    public float speed;
    private Vector3 moveVector = Vector3.zero;
    private Vector3 defaultPosition = new Vector3(0, 10f, 0);
    private float maxDistance = 1000f;
    private float baseGravity = 1f;
    public int massScore = 1;

    void Awake() {
        // singleton pattern
        if (controller == null) {
            controller = this;
        } else if (controller != this) {
            Destroy(gameObject);
        }
    }

    // physics code
    void FixedUpdate() {
        moveVector = GetMoveVector();
        moveVector.y = (Input.GetAxis("Triggers") - 0.5f) * 2;
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
        other.gameObject.GetComponent<ThingToggler>().attached = true;
        // if (other.gameObject.name == "acube") {
        Destroy(other.gameObject.GetComponent<Rigidbody>());
        // }
        massScore++;
    }
}
