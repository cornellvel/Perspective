using UnityEngine;
using System.Collections;

public class MimicSelf : MonoBehaviour {
	public GameObject followedObject;

    // Use this for initialization
    void Start()
    {
        transform.parent = followedObject.transform;
    }

    void followPosition()
    {
        Vector3 _tmp = followedObject.transform.position;
        _tmp.x = followedObject.transform.position.x;
        //might need to put in offset to get height right
        _tmp.y = followedObject.transform.position.y;
        _tmp.z = followedObject.transform.position.z;
        this.transform.position = _tmp;
    }
    // Update is called once per frame

    void Update()
    {
        followPosition();
    }
}
