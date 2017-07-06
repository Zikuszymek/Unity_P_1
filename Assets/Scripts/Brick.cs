using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public static int totalBricks = 0;

	public AudioClip crack;
	public Sprite[] hitSprites;
	private int timesHits;
	private LevelManager levelManager;

	void Start () {
		if (this.tag == "Breakable") {
			totalBricks++;
		}
		timesHits = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
        colorCurrentSprite();
    }

	void OnCollisionEnter2D (Collision2D collision){
		AudioSource.PlayClipAtPoint (crack, transform.position);
		bool isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits(){
		timesHits++;
		int maxHits = hitSprites.Length + 1;
		if (timesHits >= maxHits) {
			Destroy (gameObject);
            RandomizeBonus();
			totalBricks--;
			levelManager.BrickDestroyed();
		} else {
			LoadSprites();
		}
	}

	void LoadSprites(){
		int spriteIndex = timesHits - 1;
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
            colorCurrentSprite();
        }
	}


    void RandomizeBonus()
    {
        int randomizeBonus = Random.Range(0, 11);
        if (randomizeBonus % 5 == 0)
        {
            GameObject bonus = Instantiate(levelManager.getRandomBonus(), transform.position, Quaternion.identity) as GameObject;
            bonus.transform.parent = GameObject.FindGameObjectWithTag("Bonus").transform;
        }
    }

	void SimulateWin(){
		levelManager.LoadNextLevel ();
	}

    void colorCurrentSprite()
    {
        SpriteRenderer currentSprite = GetComponent<SpriteRenderer>();
        currentSprite.color = levelManager.getThemeColor();
    }
}
