using UnityEngine;
using System.Collections;

public class ballScript_agency : MonoBehaviour {

    public GameObject player1_hold_RH; //starting guy
    public GameObject player2_hold_RH; //second guy's right hand
    public GameObject player2_hold_LH; //second guy's left hand
    public GameObject self_hold_RH; //third guy
    public GameObject player1_ground; //ground next to first
    public GameObject player2_ground; //ground next to second
    public GameObject self_ground; //ground next to third
    public GameObject animator1; //first guy's animation
    public GameObject animator2; //second guy's animation
    public Rigidbody rigid;
    public Vector3 currBallPosition;

    // connection to hand controller
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device device;

    // check for collision enter, if ball collides with ground then ballOnGround is true
    bool ballOnGround = false;
    // if ball collides with hand, set this to true in collision enter
    bool ballInHand = false;

    // variable to track whether or not it is the first time self is throwing the ball
    bool firstSelf = true;

    // Use this for initialization
    void Start () {
        transform.parent = player1_hold_RH.transform;
        transform.position = player1_hold_RH.transform.position;
        rigid.useGravity = false;
        Vector3 currBallPosition = player1_hold_RH.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collisionInfo)
    {
        // set ballOnGround to true if the ball is on the ground next to self
        // target = GameObject.Find("target") // 'target' = name of gameobject that has animation attached to it
        if (collisionInfo.gameObject.name == "Ground_Self_Male_Rigged")
        {
            ballOnGround = true;
            Debug.Log("collision of ball with SELF GROUND");
            // TO DO: CREATE AND PLAY IDLE ANIMATION FOR AVATARS
            //animator1.play();
            //animator2.play();
        }
        // set ballInHand to true if ball has collided with the player's hand
        if (collisionInfo.gameObject.name == "Empty_Self_Male_Rigged")
        {
            ballInHand = true;
            Debug.Log("collision of ball with SELF HAND");
            // TO DO: CREATE AND PLAY IDLE ANIMATION FOR AVATARS
            //animator1.Play()
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        // if ball is on the ground next to self, call PickUpBall with isSelf = true
        if (collisionInfo.gameObject.name == "Ground_Self_Male_Rigged")
        {
            Debug.Log("PickUpBall on SELF is being called");
            PickUpBall(true);
        }
        // if ball is colliding with self's hand, call ThrowBallTo
        if (collisionInfo.gameObject.name == "Empty_Self_Male_Rigged" && ballInHand)
        {
            if (firstSelf)
            {
                Debug.Log("ThrowBallTo on SELF is being called, the throw will SUCCEED");
                ThrowBallTo(1, false, true);
                firstSelf = false;
            }
            else
            {
                Debug.Log("ThrowBallTo on SELF is being called, the throw will FAIL");
                ThrowBallTo(1, true, true);
            }
        }
    }

    public void PickUpBall(bool isSelf)
    {
        StopAllCoroutines();
        if (isSelf)
        {
            trackedObject = GameObject.FindWithTag("Right Controller").GetComponent<SteamVR_TrackedObject>();
            device = SteamVR_Controller.Input((int)trackedObject.index);
            if (device.GetPress(triggerButton) && ballOnGround)
            {
                Debug.Log("trigger pressed in PickUpBall on SELF");
                transform.parent = self_hold_RH.transform;
                transform.position = self_hold_RH.transform.position;
                ballOnGround = false;
            }
        }
        else
        {
            transform.parent = player1_hold_RH.transform;
            transform.position = player1_hold_RH.transform.position;
            Debug.Log("PickUpBall is called for COMPUTER AVATAR");
        }
    }

    // PlayerThrowingTo: male player is 1, female player is 2, self is 3
    // ground: true if ball is supposed to hit the ground when thrown
    // hand: true if the target is the right hand of PlayerThrowingTo (this only matters for throwing to player 2)
    public void ThrowBallTo(int playerThrowingTo, bool ground, bool hand)
    {
        StopAllCoroutines();
        if (playerThrowingTo == 1)
        {
            // if self is throwing the ball
            trackedObject = GameObject.FindWithTag("Right Controller").GetComponent<SteamVR_TrackedObject>();
            device = SteamVR_Controller.Input((int)trackedObject.index);
            if (device.GetPress(triggerButton))
            {
                Debug.Log("trigger is pressed for ThrowBallTo for SELF");
                ballInHand = false;
                StartCoroutine(MoveToOther(playerThrowingTo, ground, hand));
                // TO DO: RESUME NORMAL ANIMATION FOR AVATARS
            }
        }
        else
        {
            Debug.Log("ThrowBallTo is called for COMPUTER AVATAR");
            StartCoroutine(MoveToOther(playerThrowingTo, ground, hand));
            // TO DO: RESUME NORMAL ANIMATION FOR AVATARS
        }
    }

    IEnumerator MoveToOther(int playerThrowingTo, bool ground, bool hand)
    {
        yield return new WaitForSeconds(0f);
        while (true)
        {
            if (playerThrowingTo == 2)
            {
                if (ground)
                {
                    // time 4
                    transform.position = Vector3.MoveTowards(transform.position, player2_ground.transform.position, .06f);
                    currBallPosition = player2_ground.transform.position;
                    Debug.Log("pass number 4");
                }
                else
                {
                    if (hand)
                    {
                        // time 1
                        transform.position = Vector3.MoveTowards(transform.position, player2_hold_RH.transform.position, .06f);
                        currBallPosition = player2_hold_RH.transform.position;
                        Debug.Log("pass number 1");
                    }
                    else
                    {
                        // time 7
                        transform.position = Vector3.MoveTowards(transform.position, player2_hold_LH.transform.position, .06f);
                        currBallPosition = player2_hold_LH.transform.position;
                        Debug.Log("pass number 7");
                    }

                }
            }
            if (playerThrowingTo == 3)
            {
                if (ground)
                {
                    // time 5
                    transform.position = Vector3.MoveTowards(transform.position, self_ground.transform.position, .06f);
                    currBallPosition = self_ground.transform.position;
                    Debug.Log("pass number 5");
                }
                else
                {
                    // time 2
                    transform.position = Vector3.MoveTowards(transform.position, self_hold_RH.transform.position, .06f);
                    currBallPosition = self_hold_RH.transform.position;
                    Debug.Log("pass number 2");
                }
            }
            else
            {
                if (ground)
                {
                    // time 6
                    transform.position = Vector3.MoveTowards(transform.position, player1_ground.transform.position, .06f);
                    currBallPosition = player1_ground.transform.position;
                    Debug.Log("pass number 6");
                }
                else
                {
                    // time 3
                    transform.position = Vector3.MoveTowards(transform.position, player1_hold_RH.transform.position, .06f);
                    currBallPosition = player1_hold_RH.transform.position;
                    Debug.Log("pass number 3");
                }
            }
            yield return new WaitForSeconds(.005f);
        }
    }
}
