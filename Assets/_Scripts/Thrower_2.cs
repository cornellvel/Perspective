using UnityEngine;
using System.Collections;

public class Thrower_2 : MonoBehaviour {

	public GameObject theball;
	public BallScript_2 ballscript;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    void ThrowBall()
	{
        ballscript = GameObject.FindObjectOfType(typeof(BallScript_2)) as BallScript_2;
		ballscript.ReleaseMe();
	}

    void PickBall()
    {
        ballscript = GameObject.FindObjectOfType(typeof(BallScript_2)) as BallScript_2;
        ballscript.pickUpBall();
    }
}
