using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	private float maxSpeed = 4.0f;
	private Animator anim;
	private int direction = 0; //0 == down, 1 == left, 2 == up, 3 == right

	void Start () {
		anim = (Animator) GetComponent ("Animator");
	}
	
	void FixedUpdate () {
		float hmove = Input.GetAxis("Horizontal");
		GetComponent<Rigidbody2D>().velocity = new Vector2(hmove*maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		
		float vmove = Input.GetAxis("Vertical");
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, vmove*maxSpeed);
		
		if(hmove > 0){
			direction = 3;//right
		}else if(hmove < 0){
			direction = 1;//left
		}
		if(Mathf.Abs(vmove) > Mathf.Abs(hmove)){
			if(vmove > 0){
				direction = 2;//up
			}else if(vmove < 0){
				direction = 0;//down
			}
		}
		
		anim.SetFloat("speed", Mathf.Abs(hmove) + Mathf.Abs(vmove));
		anim.SetInteger("direction", direction);
		
	}
}