using UnityEngine;
using System.Collections;

public class RotateAvatar_back_10 : MonoBehaviour {

    // Use this for initialization
    void Start () {

    }
    void Update()
    {

    }

    public void changeRotation_back_10()
    {
        Vector3 _tmp2 = this.transform.eulerAngles;
        _tmp2.x = this.transform.eulerAngles.x;
        _tmp2.y = (this.transform.eulerAngles.y + 10);
        _tmp2.z = this.transform.eulerAngles.z;
        this.transform.eulerAngles = _tmp2;
    }

}
