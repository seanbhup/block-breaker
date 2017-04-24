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
	
}
