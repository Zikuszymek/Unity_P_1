using UnityEngine;
using System.Collections;

public class LooseColider : MonoBehaviour {

	private LevelManager levelManager;

	void Start(){
		levelManager = FindObjectOfType<LevelManager> ();
	}

	void OnCollisionEnter2D (Collision2D collision){

        Destroy(collision.gameObject);
        Invoke("CheckBalls", 0.5f);
    }

    private void CheckBalls()
    {
        Ball[] ballsInGame = GameObject.FindObjectsOfType<Ball>();
        Debug.Log("TEST " + ballsInGame.Length);
        if (ballsInGame.Length < 1)
        {
            Brick.totalBricks = 0;
            levelManager.loadLevel("Lose");
        }
    }
}
