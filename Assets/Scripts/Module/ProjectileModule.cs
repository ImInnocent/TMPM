using UnityEngine;
using System.Collections;

public class ProjectileModule : MonoBehaviour {
	private GameObject target = null;
	private float speed = 1f;
	private float damage = 0f;
	private bool power = false;

	public void SetTarget(GameObject _target, float _damage, float _speed = 1f){
		damage = _damage;
		target = _target;
		speed = _speed;
		power = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null && power) {
			//move
			Vector3 tgtPos = target.transform.position;
			Vector3 uVec = tgtPos - transform.position;

			uVec.Normalize ();
			uVec *= speed * Time.deltaTime;

			transform.position += uVec;

			//rotate
			float angle = Vector2.Angle(Vector2.up, uVec);
			if (transform.position.x < tgtPos.x)
				angle = -angle;
			
			transform.rotation = Quaternion.Euler (0, 0, angle);

			//check in around
			float dis = Vector2.Distance (tgtPos, transform.position);

			if (dis < 1f) {
				Character cha = target.GetComponent<Character> ();

				if (cha != null) {
					cha.GetDamage (damage);
				}

				Destroy (this.gameObject);
			}
		}
	}
}
