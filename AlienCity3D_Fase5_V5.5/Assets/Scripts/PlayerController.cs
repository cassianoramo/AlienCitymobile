using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterController))]
//[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	public float MoveSpeed;
	public float RotationSpeed;
	CharacterController cc;
	private Animator anim;
	protected Vector3 gravidade = Vector3.zero;
	protected Vector3 move1 = Vector3.zero;
	//private bool jump = false;
	private float h;
	private float v;
	//public Rigidbody player;
	/*public Vector3 direcaopulo = new Vector3(0,1,0);
	[Range(1,20)]
	public float forcadopulo = 5.0f;
	[Range(0.5f,10.0f)]
	public float distanciadochao;
	[Range(0.5f,5.0f)]
	public float tempoporpulo = 1.5f;
	public LayerMask layers = -1;
	private bool estanochao, contar = false;
	private float cronometro = 0;
	private Rigidbody corporigido;*/

	void Start()
	{
		cc = GetComponent<CharacterController> ();
		anim = GetComponent<Animator>();
		//player = GetComponent<Rigidbody> ();
		anim.SetTrigger("Parado");
		//corporigido = GetComponent<Rigidbody> ();
	}

	void Update()
	{
		Move ();
		Anima ();
		if (!cc.isGrounded ) {
			gravidade += Physics.gravity * Time.deltaTime;
		} else {
			gravidade = Vector3.zero;
		}
		/*estanochao = Physics.Linecast (transform.position, transform.position - Vector3.up * distanciadochao, layers);
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
		}*/
	}
	 
	void Anima()
	{
		if (!Input.anyKey)
		{
			anim.SetTrigger("Parado");
		} 
		else 
		{
			if(Input.GetKeyDown("space"))
			{
				anim.SetTrigger("Pula");
				//jump = true;
		
			}
	else
			{
				anim.SetTrigger("Corre");
			}
		}
	/*	if (jump) {
			Jump ();
		} */
	}
	void Move(){
		h = CrossPlatformInputManager.GetAxis ("Horizontall");
		v = CrossPlatformInputManager.GetAxis ("Verticall");
		if(Input.GetKey("right") || Input.GetKey("left") || h > 0){
			transform.Rotate (new Vector3 (0, Input.GetAxis ("Horizontal") * RotationSpeed * Time.deltaTime, 0));
		}
		if (h > 0 || h < 0) {
			transform.Rotate (new Vector3 (0, h * RotationSpeed * Time.deltaTime, 0));
		}
		if (Input.GetKey ("up") || Input.GetKey ("down") || v > 0) {
			Vector3 move = Input.GetAxis ("Vertical") * transform.TransformDirection (Vector3.forward) * MoveSpeed;
			move += gravidade;
			cc.Move (move * Time.deltaTime);
		}
		if (v < 0 || v > 0) {
			Vector3 move = v * transform.TransformDirection (Vector3.forward) * MoveSpeed;
			move += gravidade;
			cc.Move (move * Time.deltaTime);
		}
		move1 += gravidade;
		cc.Move (move1 * Time.deltaTime);
	}
	/*void Jump (){
		if (cc.isGrounded) {
			Debug.Log ("rxetcyo");
			player.AddForce (Vector3.up * 2000 * Time.deltaTime);
			jump = false;
			Debug.Log ("rxe");
		}
	}*/
}


