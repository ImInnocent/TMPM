﻿using UnityEngine;
using System.Collections;

public class AutoMoveModule : MonoBehaviour {
	private float angle = 0f;
	private const float speed = 1f;
	private const float rotSpd = 60f;
	private Rigidbody2D body = null;

	// Update is called once per frame
	void Update () {
		if (body == null) {
			body = GetComponent<Rigidbody2D> ();
		}

		if (body != null) {
			angle += Time.deltaTime * rotSpd;
			body.AddForce (GetVec (angle) * speed);
		}

	}

	Vector3 GetVec(float angle){
		Vector3 rot = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;

		Vector3 ret = rot.normalized;

		Debug.Log (ret.x + ", " + ret.y);

		return ret;
	}
}
