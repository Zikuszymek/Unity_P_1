using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public GameObject ballPrefab;
    public bool autoPlay = false;

    Vector3 vector;
	float min, max;
	private Ball ball;
    private Animator animator;
    private PaddlePart paddlePart;

	void Start () {
        paddlePart = FindObjectOfType<PaddlePart>();
        min = 0.5f;
		max = 15.5f;
		vector = new Vector3 (this.transform.position.y, this.transform.position.y, this.transform.position.x);
		ball = FindObjectOfType<Ball> ();
        animator = GetComponent<Animator>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float offset = transform.position.x - collision.transform.position.x;

        Collider2D paddleColider = paddlePart.GetComponent<Collider2D>();
        float padding = paddleColider.bounds.size.x / 2;
    }

    private void UpdatePaddleSize()
    {
        Collider2D paddleColider = paddlePart.GetComponent<Collider2D>();
        float padding = paddleColider.bounds.size.x / 2;
        min = padding + 0.2f;
        max = 16f - (min);
    }
	
	void Update () {
		if (!autoPlay) {
            UpdatePaddleSize();
            MoveWithMouse ();
		} else {
			AutoPlay();
        }
	}

	void AutoPlay(){
		Vector3 ballPos = ball.transform.position;
		vector.x = Mathf.Clamp (ballPos.x, min, max);
		this.transform.position = vector; 
	}

	void MoveWithMouse(){
		float test = Input.mousePosition.x / Screen.width * 16;
		vector.x = Mathf.Clamp (test, min, max);
		this.transform.position = vector; 
	}


    public void Grow()
    {
        animator.SetTrigger("Grow");
    }

    public void Shrink()
    {
        animator.SetTrigger("Shrink");
    }

    public void SpeedUp()
    {
        Ball[] ballsArray = FindObjectsOfType<Ball>();
        foreach (Ball ballPlay in ballsArray)
        {
            ballPlay.SpeedUp();
        }
    }

    public void SpeedDown()
    {
        Ball[] ballsArray = FindObjectsOfType<Ball>();
        foreach(Ball ballPlay in ballsArray)
        {
            ballPlay.SpeedDown();
        }
    }

    public void AddBall()
    {
        GameObject ballPlay = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        Vector3 ballPosition = ballPlay.transform.position;
        ballPosition.y += 1f;
        ballPlay.transform.position = ballPosition;
        Rigidbody2D ballRigidBody = ballPlay.GetComponent<Rigidbody2D>();
        ballPlay.GetComponent<Ball>().gameStarted = true;
        ballRigidBody.velocity = new Vector2(2f, 10f);
    }
}
