using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulotouch : MonoBehaviour {
	public float força;
	public float pulo;
	public Rigidbody playerr;
	private bool clique, penochao;

	void FixedUpdate () {
		RaycastHit dpulo;
		if (Physics.Raycast (transform.position, -transform.up, out dpulo, pulo)) {
			if (dpulo.collider) {
				penochao = true;
			} else {
				penochao = false;
			}
			if (penochao == true) {
				if (clique == true) {
					playerr.AddForce (Vector3.up * força * Time.deltaTime);
					clique = false;
				} else {
					clique = false;
				}
			}
		}
	}
	public void Button (bool cliquei){
		clique = cliquei;
	}
}
