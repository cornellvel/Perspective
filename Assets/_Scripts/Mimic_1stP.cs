using UnityEngine;
using System.Collections;

public class Mimic_1stP : MonoBehaviour {
	public GameObject followedObject;
    public GameObject setCameraHeight;

    // Use this for initialization
    void Start()
    {
        transform.parent = followedObject.transform;
        //float theHeight = holdHeight.transform.position.y;
        //float percentage = (theHeight / 1.56f);
        //float headSize = (percentage / 1000);
        //Vector3 _tmp = this.transform.localScale;
        //percentage of the avatar height
        // Debug.Log("In start");
        // _tmp.x = (this.transform.localScale.x * percentage * .088f);
        //_tmp.y = (this.transform.localScale.y * percentage * .088f);
        // _tmp.z = (this.transform.localScale.z * percentage * .088f);
        //this.transform.localScale = _tmp;
    }

    void followPosition()
    {
        //Debug.Log("In Mimic IstP Follow Position");
        Vector3 _tmp = followedObject.transform.position;
        _tmp.x = followedObject.transform.position.x;
        //_tmp.y = followedObject.transform.position.y;
        //_tmp.y = setCameraHeight.transform.position.y;
        _tmp.y = 0.19f;
        //_tmp.y = -53.5f;
        _tmp.z = followedObject.transform.position.z;
        this.transform.position = _tmp;
        Debug.Log(_tmp.y);
    }

    //void followRotation() {
    //    Vector3 _tmp2 = followedObject.transform.eulerAngles;
    //    _tmp2.x = followedObject.transform.eulerAngles.x;
    //    _tmp2.y = followedObject.transform.eulerAngles.y;
    //    _tmp2.z = followedObject.transform.eulerAngles.z;
    //    this.transform.eulerAngles = _tmp2;
    //}

    // Update is called once per frame
    void Update()
    {
        followPosition();
        //followRotation (); 
    }
}
