using System.Collections;
using UnityEngine;

public class GearToothCollider : MonoBehaviour {
    public float forceApplied = 50;

    void OnCollisionEnter(Collision col) {
        GetComponent<Rigidbody>().AddForce(0, forceApplied, 0);
    }
}
