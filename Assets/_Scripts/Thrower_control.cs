using UnityEngine;
using System.Collections;

public class Thrower_control : MonoBehaviour {

	public GameObject theball;
	public BallScript_control ballscript_control;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    void ThrowBall_control()
	{
        ballscript_control = GameObject.FindObjectOfType(typeof(BallScript_control)) as BallScript_control;
		ballscript_control.ReleaseMe();
	}

    void PickBall()
    {
        ballscript_control = GameObject.FindObjectOfType(typeof(BallScript_control)) as BallScript_control;
        ballscript_control.pickUpBall();
    }
}
