using UnityEngine;
using System.Collections;

public class ClipModule : MonoBehaviour {
	public Rect clipRect = new Rect(new Vector2(-8f, -4f), new Vector2(16f, 8f));

	// Update is called once per frame
	void Update () {
		if (!clipRect.Contains (transform.position)) {
			transform.position = -transform.position;
		}
	}
}
