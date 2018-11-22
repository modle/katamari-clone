using UnityEngine;
using System.Collections;

public class TransformFollower : MonoBehaviour {
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private Vector3 offsetPosition;

    private void Update() {
        Refresh();
    }

    public void Refresh() {
        // compute position
        Vector3 newPosition = new Vector3(target.transform.position.x, 10f, target.transform.position.z);
        transform.position = newPosition - offsetPosition;

        // compute rotation
        Vector3 rotation = new Vector3(target.transform.rotation.x, 0.0f, target.transform.rotation.z);
        transform.rotation = Quaternion.LookRotation(rotation);
        // transform.LookAt(target.transform);
    }
}
