using UnityEngine;
using System.Collections;

public class MovementSystem : MonoBehaviour {
	float speed = 1.5f;

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	// Update is called once per frame
	void Update () {
		if (GvrViewer.Instance.Triggered || Input.GetKeyDown("space")) {
			Debug.Log ("PRESS");
		}
		gameObject.transform.Translate (Vector3.right * speed * Time.deltaTime);

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "brake") {
			Debug.Log ("Brake Triggered");
			speed = 0;
			Destroy (other.gameObject);
		}
	}
}
