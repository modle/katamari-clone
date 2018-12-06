using System.Collections;
using UnityEngine;

public class ThingCondenser : MonoBehaviour {

    GameObject player;
    SphereCollider playerCollider;
    private float movementDamping = 150f;
    float delay;
    float moveRecheck = 0.5f;
    float lastMoveCheck = 0f;

    void Start() {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerCollider = player.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update () {
        if (Time.time - lastMoveCheck < moveRecheck) {
            return;
        }
        lastMoveCheck = Time.time;
        if (!GetComponent<ThingToggler>().attached) {
            return;
        }
        Vector3 myPoint = Physics.ClosestPoint(transform.position, playerCollider, player.transform.position, Quaternion.identity);
        // transform.position = Vector3.Slerp(transform.position, player.transform.position, Time.deltaTime * movementDamping);
        transform.position = Vector3.Slerp(transform.position, myPoint, Time.deltaTime * movementDamping);
    }
}
