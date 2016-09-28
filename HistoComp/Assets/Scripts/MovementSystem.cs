using UnityEngine;
using System.Collections;

public class MovementSystem : MonoBehaviour {
	float VELOCITY = 2.0f;
	public static float speed = 1.5f;
	public static int direction = 1; // 1 == forward, 0 == none, -1 == backward

	public static bool answerIsCorrect = false;
	public static bool viewingArt = false;


	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	// Update is called once per frame
	void Update () {
		if (viewingArt == true && speed == 0 && (GvrViewer.Instance.Triggered || Input.GetKeyDown("space"))) {
			Debug.Log ("PRESS");
			speed = VELOCITY;
		}
		gameObject.transform.Translate (Vector3.right * speed * direction * Time.deltaTime);

	}

	void OnTriggerEnter(Collider other) {
		if (direction == 1 && other.gameObject.tag == "brake") {
			speed = 0;
			direction = 1;
			viewingArt = true;
		} else if (direction == -1 && other.gameObject.tag == "brake-reverse") {
			speed = 0;
			direction = 1;
			viewingArt = true;
		} else if (other.gameObject.tag == "brake-answer") { // brake to answer question
			viewingArt = false;
			speed = 0;
		}
	}
}
