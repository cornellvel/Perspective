using UnityEngine;
using System.Collections;


public class Turning : MonoBehaviour {

    // Use this for initialization
    void Start () {
       
    }
    void Update()
    {

    }

    void Rotate()
    {
        var player = new GameObject();

        RotateAvatar rotateAvatar = player.GetComponent <RotateAvatar>();
        rotateAvatar.changeRotation();
    }

}
