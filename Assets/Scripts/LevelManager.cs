using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log("Level start requested for: " + name);
		Application.LoadLevel(name);
	}
	
	public void QuitRequest(){
		Debug.Log("Level quit requested for: " + name);
		Application.Quit();
	}
	
	public void LoadNextLevel(){
//	int index from build settings
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0) {
			LoadNextLevel ();
		}
	}
	
}
