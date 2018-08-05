using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Rigidbody MyBody;

    float InitWalkPower = 30.0f;
    float maxWalkSpeed = 2.0f;

    float JumpPower = 200.0f;

    // Use this for initialization
    void Start () {
        this.MyBody = GetComponent<Rigidbody>();
        gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {

        if(IsSpaceKeyDown())
        {
            this.MyBody.AddForce(transform.up * this.JumpPower);
        }

        float DownKey = KeyDown();

        float speedx = Mathf.Abs(this.MyBody.velocity.x);

        if (speedx < this.maxWalkSpeed)
        {
            this.MyBody.AddForce(transform.right * DownKey * this.InitWalkPower);
        }
        if (DownKey != 0)
        {
            transform.localScale = new Vector3(DownKey, 0.5f, 0.5f);
        }

    }

    private bool IsSpaceKeyDown()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }

    private float KeyDown()
    {
        float result = 0;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            result = 0.5f;
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            result = -0.5f;
        }
        return result;
    }
}
