using UnityEngine;
using System.Collections;

public class Thrower : MonoBehaviour {

	public GameObject theball;
	public BallScript ballscript;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    void ThrowBall()
	{
        ballscript = GameObject.FindObjectOfType(typeof(BallScript)) as BallScript;
		ballscript.ReleaseMe();
	}

    void PickBall()
    {
        ballscript = GameObject.FindObjectOfType(typeof(BallScript)) as BallScript;
        ballscript.pickUpBall();
    }
}
