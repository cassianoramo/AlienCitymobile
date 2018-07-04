using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Pulo : MonoBehaviour {
	public Vector3 direcaopulo = new Vector3(0,1,0);
	[Range(1f,20f)]
	public float forcadopulo = 5.0f;
	[Range(0.5f,10.0f)]
	public float distanciadochao;
	[Range(0.5f,5.0f)]
	public float tempoporpulo = 1.5f;
	public LayerMask layers = -1;
	private bool estanochao, contar = false;
	private float cronometro = 0;
	private Rigidbody corporigido;
	// Use this for initialization
	void Start () {
		corporigido = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		estanochao = Physics.Linecast (transform.position, transform.position - Vector3.up * distanciadochao, layers);
		if (Input.GetKeyDown (KeyCode.Space) && estanochao == true && contar == false) {
			corporigido.AddForce (direcaopulo * forcadopulo, ForceMode.Impulse);
			estanochao = false;
			contar = true;
		}
		if (contar == true) {
			cronometro += Time.deltaTime;
		}
		if (cronometro >= tempoporpulo) {
			contar = false;
			cronometro = 0;
		}
	}
}
