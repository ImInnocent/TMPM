using UnityEngine;
using System.Collections;

public enum CharTags{
	Ally = 0,
	Enemy,
	None
}

public class CharStat{
	public float hp = 0f;
	public float atk = 0f;

	public CharStat(float _hp, float _atk){
		hp = _hp;
		atk = _atk;
	}
}

public class Character : MonoBehaviour {
	public CharTags charTag = CharTags.None;
	public CharStat stat = null;

	public void SetStat(CharTags _tag, CharStat _stat){
		charTag = _tag;
		stat = _stat;
	}

	public void GetDamage(float _damage){
		if (stat != null) {
			stat.hp -= _damage;
		}

		//~~
	}
}
