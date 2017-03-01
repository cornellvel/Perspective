using UnityEngine;
using System.Collections;

public class Thrower : MonoBehaviour {

	public GameObject theball;
	public BallScript ballscript;
    // added for agency
    public ballScript_agency ballScript_agency;
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

    // new functions for agency
    void ThrowBallTo(int playerThrowingTo, bool ground, bool hand)
    {
        ballScript_agency = GameObject.FindObjectOfType(typeof(ballScript_agency)) as ballScript_agency;
        ballScript_agency.ThrowBallTo(playerThrowingTo, ground, hand);
    }
    void PickUpBall()
    {
        ballScript_agency = GameObject.FindObjectOfType(typeof(ballScript_agency)) as ballScript_agency;
        ballScript_agency.PickUpBall(false);
    }
}
