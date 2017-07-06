using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public Color themeColor;

    public GameObject[] bonusList;

	public void loadLevel(string levelName){
		Application.LoadLevel (levelName);
	}

	public void quitGame(){
		Application.Quit ();
	}

	public void LoadNextLevel(){
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	public void BrickDestroyed(){
        Debug.Log("Bricks: " + Brick.totalBricks);
		if(Brick.totalBricks <= 0){
			LoadNextLevel();
		}
	}

    public Color getThemeColor()
    {
        return themeColor;
    }

    public GameObject getRandomBonus()
    {
        int randomInt = Random.Range(0, bonusList.Length);
        return bonusList[randomInt];
    }
}
