using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 paddleVector3;
	public bool gameStarted = false;
    private Rigidbody2D rigidBody2D;

    private int currentSpeed = 1;
    private float bonusTime;

	void Start () {
		paddle = FindObjectOfType<Paddle>();
		paddleVector3 = this.transform.position - paddle.transform.position;
        rigidBody2D = GetComponent<Rigidbody2D>();

    }
	
	void Update () {
		if (!gameStarted) {
			this.transform.position = paddle.transform.position + paddleVector3;
		
			if (Input.GetMouseButtonDown (0)) {
				gameStarted = true;
                rigidBody2D.velocity = new Vector2 (2f, 10f);
			}
		}

        checkBallBonus();

	}

	void OnCollisionEnter2D (Collision2D collision){

		if(gameStarted){
			GetComponent<AudioSource>().Play ();
            if(rigidBody2D.velocity.x < 0.1f && rigidBody2D.velocity.x > -0.1)
            {
                Debug.Log("X Velocity x: " + rigidBody2D.velocity.x + " y " + rigidBody2D.velocity.y);
                rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x + 1f, rigidBody2D.velocity.y);
            }

            if (rigidBody2D.velocity.y < 0.1f && rigidBody2D.velocity.y > -0.1)
            {
                Debug.Log("Y Velocity x: " + rigidBody2D.velocity.x + " y " + rigidBody2D.velocity.y);
                rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, rigidBody2D.velocity.y + 1f);
            }
        }
	}

    private void checkBallBonus()
    {
        if(Time.time - bonusTime > 10f)
        {
            SetNormalSpeed();
        }
    }

    private void SetNormalSpeed()
    {
        if(currentSpeed == 0)
        {
            SpeedUp();
        } else if (currentSpeed == 2)
        {
            SpeedDown();
        }
    }

    public void SpeedUp()
    {
        bonusTime = Time.time;
        if (currentSpeed < 2)
        {
            currentSpeed++;
            rigidBody2D.velocity *= 1.5f;
        }
    }

    public void SpeedDown()
    {
        bonusTime = Time.time;
        if (currentSpeed > 0)
        {
            currentSpeed--;
            rigidBody2D.velocity *= 0.666f;
        }
    }
}
