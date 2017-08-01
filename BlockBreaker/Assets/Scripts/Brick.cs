using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public Sprite[] hitSprites;
	private LevelManager levelManager;
	private int timesHit;

	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		bool isBreakable = (this.tag == "breakable");
		if (isBreakable) {
			HandleHits();
		}
	}	
	
	
	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits){
			Destroy (gameObject);
		} else {
			LoadSprites();
		}
	}
	
	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]) {this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];}
	}
	// TODO remove this method once we can actually win
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}	
}
