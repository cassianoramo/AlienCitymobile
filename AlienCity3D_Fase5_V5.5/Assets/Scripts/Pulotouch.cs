using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pulotouch : MonoBehaviour {
	public float força;
	public float pulo;
	public Rigidbody playerr;
	private bool clique, penochao;
	Button bo;
	void Start () {
		bo = GetComponent<Button> ();
	}

	void FixedUpdate () {
		RaycastHit dpulo;
		if (Physics.Raycast (transform.position, -transform.up, out dpulo, pulo)) {
			if (dpulo.collider) {
				penochao = true;	
				bo.interactable = true;
			}
		}
		else {
			penochao = false;
			bo.interactable = false;
		}
		if (penochao) {
			if (clique == true) {
				playerr.AddForce (Vector3.up * força * Time.deltaTime);
				clique = false;
			} else {
				clique = false;
			}
		}
	}
	public void Pular(bool cliquei){
		clique = true;
	}
}
