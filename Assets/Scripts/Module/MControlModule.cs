using UnityEngine;
using System.Collections;

public class MControlModule : MonoBehaviour {
	float timer = 0;
	bool power = false;
	GameObject enemy = null;
	GameObject maker = null;
	GameObject target = null;

	void Init(float _timer, GameObject _maker, GameObject _target){
		timer = _timer;
		maker = _maker;
		target = _target;
		power = true;

		//maker
		if (maker != null){
			if( maker.GetComponent<InputModule> () != null) 
				Destroy(maker.GetComponent <InputModule> ());
		}

		//target
		if (_target.GetComponent<AutoMoveModule> () != null) {
			Destroy (_target.GetComponent<AutoMoveModule> ());
		}

		if (_target.GetComponent<InputModule> () == null) {
			_target.AddComponent<InputModule> ();
		}

		Character cha = _target.GetComponent<Character> ();
		if (cha != null) {

			cha.charTag = CharTags.Ally == cha.charTag ? CharTags.Enemy : CharTags.Ally;
		}

		if (target.GetComponent<AIModule> () != null) {
			target.GetComponent <AIModule> ().ResetTarget();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Q) && !power) {
			GameObject tgt = FindTarget ();

			Init (30f, gameObject, tgt);
		}

		if (power) {
			timer -= Time.deltaTime;

			if (timer <= 0) {
				power = false;

				//maker
				if (maker != null){
					if( maker.GetComponent<InputModule> () == null) 
						maker.AddComponent <InputModule> ();
				}

				//target
				if (target != null) 
				{
					Character cha = target.GetComponent<Character> ();
					if (cha != null) {

						cha.charTag = CharTags.Ally == cha.charTag ? CharTags.Enemy : CharTags.Ally;
					}

					if (target.GetComponent<AIModule> () != null) {
						target.GetComponent <AIModule> ().ResetTarget();
					}

					if (target.GetComponent<AutoMoveModule> () == null) {
						target.AddComponent <AutoMoveModule> ();
					}

					if (target.GetComponent<InputModule> () != null) {
						Destroy(target.GetComponent<InputModule>());
					}
				}

				timer = 0f;
			}
		}
	}

	GameObject FindTarget(){
		CharTags myTag = GetComponent<Character> ().charTag;

		if (enemy == null) {
			enemy = GameObject.Find ( myTag == CharTags.Ally ? "Enemy" : "Ally");
		}

		if (enemy != null) {
			Character[] children = enemy.GetComponentsInChildren<Character> ();

			for (int i = 0; i < children.Length; i++) {
				float dis = Vector2.Distance (children [i].transform.position, transform.position);

				if (dis < 15f && children[i].charTag != myTag) {
					Debug.Log (name + " -@> " + children [i].name);
					return children [i].gameObject;
				}
			}

		}

		return null;
	}
}
