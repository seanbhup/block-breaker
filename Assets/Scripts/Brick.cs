using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip brickPop;

	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		//Keep track of breakable bricks
		if(isBreakable){
			breakableCount++;
//			print (breakableCount);
		}
		
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		AudioSource.PlayClipAtPoint (brickPop, transform.position, 0.8f);
		if(isBreakable){
			HandleHits();
		}
	}
	
	void HandleHits() {
		timesHit++;
		
		int maxHits = hitSprites.Length + 1;
		
		if (timesHit >= maxHits){
			breakableCount--;
			levelManager.BrickDestroyed ();
			
			PuffSmoke ();
			
			Destroy(gameObject);
		}
		else{
			//			changes sprite to reflect how many times its been hit
			LoadSprites();
		}
	}
	
	void PuffSmoke(){
		GameObject smokePuff = Instantiate (smoke, transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex] != null){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else{
			Debug.LogError("Brick sprite missing");
		}
	}
	
//	TODO Remove this method once We actually win

	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
	
}
