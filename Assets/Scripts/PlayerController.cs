using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;
	private Rigidbody2D rb;
	private int count;
	private int timeCount;
	public Text CountText;
	public Text winText;
	public Slider score;
	public Slider time;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		count = 0;
		winText.text = "";
		score.value = 0;
		timeCount = 3000;
		time.value = timeCount;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

		rb.AddForce (movement * speed);
		timeCount = timeCount - Time.frameCount;
		time.value = timeCount;
		//Debug.Log (Time.frameCount);
	}

	void OnTriggerEnter2D(Collider2D other){
	//	Debug.Log ("yes");
		if(other.gameObject.CompareTag("PickUp")){
			other.gameObject.SetActive (false);
			count++;

			SetCountText ();
			score.value=score.value+1;
		}
	}
	void SetCountText(){
		CountText.text = "count: " + count.ToString ();
		if (count >= 12) {
			winText.text="you win!";
		}
	}
}
