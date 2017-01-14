using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject ally;
	public GameObject enemy;

	// Use this for initialization
	void Start () {
		CreatePlayer ();
		CreateEnemy ();
	}

	void CreatePlayer(){
		GameObject player = new GameObject ("Player");

		player.transform.SetParent (ally.transform);

		//attach component
		player.AddComponent<MoveModule>();
		player.AddComponent<InputModule>();
		player.AddComponent<ClipModule>();
		Rigidbody2D body = player.AddComponent<Rigidbody2D>();
		SpriteRenderer spr = player.AddComponent<SpriteRenderer>();
		Character cha = player.AddComponent<Character> ();

		//set <Rigidbody2D>
		body.gravityScale = 0f;
		body.drag = 1f;

		//set <SpriteRenderer>
		Sprite image = Resources.Load<Sprite>("Sprites/player");
		spr.sprite = image != null ? image : null;

		//set <Character>
		cha.SetStat(CharTags.Ally, new CharStat(10f, 3f));
	}

	void CreateEnemy(){
		GameObject monster = new GameObject ("Monster");

		monster.transform.SetParent (enemy.transform);

		//attach component
		monster.AddComponent<MoveModule>();
		monster.AddComponent<AIModule>();
		monster.AddComponent<ClipModule>();
		monster.AddComponent<AutoMoveModule> ();
		Rigidbody2D body = monster.AddComponent<Rigidbody2D>();
		SpriteRenderer spr = monster.AddComponent<SpriteRenderer>();
		Character cha = monster.AddComponent<Character> ();

		//set <Rigidbody2D>
		body.gravityScale = 0f;
		body.drag = 1f;

		//set <SpriteRenderer>
		Sprite image = Resources.Load<Sprite>("Sprites/monster");
		spr.sprite = image != null ? image : null;

		//set <Character>
		cha.SetStat(CharTags.Enemy, new CharStat(10f, 3f));
	}
}
