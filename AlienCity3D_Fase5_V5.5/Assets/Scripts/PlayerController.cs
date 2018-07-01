using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

	public float MoveSpeed;
	public float RotationSpeed;
	CharacterController cc;
	private Animator anim;
	protected Vector3 gravidade = Vector3.zero;
	protected Vector3 move1 = Vector3.zero;
	private bool jump = false;
	private float h;
	private float v;

	void Start()
	{
		cc = GetComponent<CharacterController> ();
		anim = GetComponent<Animator>();
		anim.SetTrigger("Parado");
	}

	void Update()
	{
		Move ();
		//Vector3 move = Input.GetAxis ("Vertical") * transform.TransformDirection (Vector3.forward) * MoveSpeed;
		//transform.Rotate (new Vector3 (0, Input.GetAxis ("Horizontal") * RotationSpeed * Time.deltaTime, 0));
		if (!cc.isGrounded) {
			gravidade += Physics.gravity * Time.deltaTime;
		} 
		else 
		{
			gravidade = Vector3.zero;
			if(jump)
			{
				gravidade.y = 6f;
				jump = false;
			}
		}
		//move += gravidade;
		//cc.Move (move* Time.deltaTime);
		Anima ();
	
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
				jump = true;
			}
	else
			{
				anim.SetTrigger("Corre");
			}
		}
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
}


