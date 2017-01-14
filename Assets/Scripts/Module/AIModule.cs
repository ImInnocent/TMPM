using UnityEngine;
using System.Collections;

public class AIModule : MonoBehaviour {
	private GameObject target;
	private float timer = 0f;
	private const float maxTimer = 3f;

	void Update () {
		if (timer > 0) {
			timer -= Time.deltaTime;
		}

		if (target == null) {
			Character cha = GetComponent<Character> ();

			CharTags tag = cha != null ? cha.charTag : CharTags.None;

			if (tag != CharTags.None) {
				target = GameObject.Find (tag == CharTags.Ally ? "Enemy" : "Ally");
			}
		}

		if (target != null && timer <= 0f) {
			Transform[] children = target.GetComponentsInChildren<Transform> ();

			for (int i = 0; i < children.Length; i++) {
				float dis = Vector2.Distance (children [i].position, transform.position);
				Character cha = children [i].GetComponent<Character> ();

				if (dis < 5f && cha != null) {
					Debug.Log (name + " -> " + children [i].name);
					CreateArrow (children[i].gameObject);
					timer = maxTimer;
				}
			}
		}
	}

	void CreateArrow(GameObject _target ){
		//
		Character cha = GetComponent<Character>();
		float damage = cha != null ? cha.stat.atk : 0f;

		//
		GameObject proj = new GameObject ("Arrow");

		proj.transform.SetParent (target.transform);

		//attach component
		ProjectileModule projM = proj.AddComponent<ProjectileModule>();
		SpriteRenderer spr = proj.AddComponent<SpriteRenderer>();

		//set <SpriteRenderer>
		Sprite image = Resources.Load<Sprite>("Sprites/arrow");
		spr.sprite = image != null ? image : null;

		//set <ProjectileModule>
		projM.SetTarget(_target, damage, 1.5f);

		//set <Transform>
		proj.transform.position = transform.position;

	}
}
