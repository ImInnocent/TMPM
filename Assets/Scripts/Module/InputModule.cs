using UnityEngine;
using System.Collections;

public enum Dir{
	Up = 0,
	Left,
	Down,
	Right
}

public class InputModule : MonoBehaviour {
	private MoveModule move = null;

	void Start(){
		if (move == null) {
			move = GetComponent<MoveModule> ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			GetInput (Dir.Up);
		} 
		if (Input.GetKey (KeyCode.A)) {
			GetInput (Dir.Left);
		}
		if (Input.GetKey (KeyCode.S)) {
			GetInput (Dir.Down);
		}
		if (Input.GetKey (KeyCode.D)) {
			GetInput (Dir.Right);
		}
	}

	void GetInput(Dir dir){
		if (move == null) {
			move = GetComponent<MoveModule> ();
		}

		if (move != null) {
			move.Move (dir);
		}
	}
}
