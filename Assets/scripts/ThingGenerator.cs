using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingGenerator : MonoBehaviour {

    public List<Object> things = new List<Object>();
    int numThings = 200;
    int maxDist = 400;
    int thingScaleMax = 5;

    void Awake () {
        LoadPrefabs();
    }

    void LoadPrefabs() {
        things.Add(Resources.Load("prefabs/asphere", typeof(GameObject)));
        things.Add(Resources.Load("prefabs/acube", typeof(GameObject)));
        things.Add(Resources.Load("prefabs/acylinder", typeof(GameObject)));
        print (things[0]);
        foreach (Object thing in things) {
            SpawnThings(thing);
        }
    }

    void SpawnThings(Object thing) {
        int thingCount = 0;
        while (thingCount < numThings) {
            thingCount++;
            InstantiateResource(thing);
        }
    }

    public void InstantiateResource(Object theObject) {
        Vector3 scaleVector = GetScaleVector(theObject.name);
        Vector3 positionVector = GetValidPosition();
        positionVector.y = scaleVector.y / 2;
        GameObject instance = Instantiate(theObject, positionVector, Quaternion.identity) as GameObject;
        instance.transform.localScale = scaleVector;
        instance.transform.position = positionVector;
        instance.name = theObject.name;
        instance.transform.SetParent(transform);
    }

    Vector3 GetScaleVector(string name) {
        if (name == "asphere") {
            int scaleVal = Random.Range(1, thingScaleMax);
            return new Vector3(
                scaleVal,
                scaleVal,
                scaleVal
            );
        } else {
            return new Vector3(
                Random.Range(1, thingScaleMax),
                Random.Range(1, thingScaleMax),
                Random.Range(1, thingScaleMax)
            );
        }
    }

    Vector3 GetValidPosition() {
        return new Vector3(
            Random.Range(-maxDist, maxDist),
            1,
            Random.Range(-maxDist, maxDist)
        );
    }


}
