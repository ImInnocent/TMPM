using UnityEngine;
using System.Collections;

public class MoveModule : MonoBehaviour {
	private Rigidbody2D rigid = null;
	private const float speed = 2.0f;

	// Use this for initialization
	void Start () {
		if (rigid == null) {
			rigid = GetComponent<Rigidbody2D> ();
		}
	}

	public void Move(Dir dir){
		if (rigid == null) {
			rigid = GetComponent<Rigidbody2D> ();
		}

		if (rigid != null) {
			Vector2 vec = Vector2.zero;

			switch (dir) {
			case Dir.Down:
				vec = new Vector2 (0f, -1f);
				break;
			case Dir.Left:
				vec = new Vector2 (-1f, 0f);
				break;
			case Dir.Right:
				vec = new Vector2 (1f, 0f);
				break;
			case Dir.Up:
				vec = new Vector2 (0f, 1f);
				break;
			}

			rigid.AddForce (vec * speed);
		}
	}

	public void Move(Vector2 dir){
		if (rigid == null) {
			rigid = GetComponent<Rigidbody2D> ();
		}

		if (rigid != null) {

			rigid.AddForce (dir * speed);
		}
	}
}
