using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Colisor : MonoBehaviour {

	void  OnTriggerEnter (Collider other){
		if  (other.gameObject.CompareTag ( "Obstaculo")) {
			string currentScene = SceneManager.GetActiveScene ().name;
			SceneManager.LoadScene (currentScene);
			Handheld.Vibrate ();
			Debug.Log ("Vibra");
		}
	}
}
