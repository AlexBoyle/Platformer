using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	public float temp = 0;
	public float speed = 0;
	public float jump = 0;
	public float maxSpeed = 100;
	public Transform groundCheckPoint;
	public Transform leftCheckPoint;
	public Transform rightCheckPoint;
	public Vector2 groundCheckRadius;
	public LayerMask groundLayer;
	private bool preJump;
	public bool isGround;
	public bool isLeft;
	public bool isRight;
	public Vector3 respawnPoint;
	private Rigidbody2D r;
	void Start () {
		r = gameObject.GetComponent<Rigidbody2D> ();
		respawnPoint = gameObject.transform.position;
	}

	void FixedUpdate () {
		isGround = Physics2D.OverlapBox(groundCheckPoint.position, new Vector2(.7f,.001f),0, groundLayer)? true:false;
		isLeft = Physics2D.OverlapBox(leftCheckPoint.position, new Vector2(.001f,.7f),0, groundLayer)? true:false;
		isRight = Physics2D.OverlapBox(rightCheckPoint.position, new Vector2(.001f,.7f),0, groundLayer)? true:false;
		if (Input.GetButton ("Left")) {
			r.AddForce (new Vector2 (isGround?-speed:-speed*.5f, 0));
		}
		if (Input.GetButton ("Right")) {
			r.AddForce (new Vector2 (isGround?speed:speed*.5f, 0));
		}
		if (Input.GetButton ("Jump") && preJump == false && isGround) {
			r.AddForce (new Vector2 (0, jump));
		}
		else if (Input.GetButton ("Jump") && preJump == false && (isLeft || isRight)) {
			r.AddForce (new Vector2 ((isLeft?1:-1) *150, jump ));
		}
		temp = r.velocity.x;
		if (r.velocity.x > maxSpeed) {
			r.AddForce (new Vector2 (r.velocity.x, 0) - (r.velocity - new Vector2 (maxSpeed, 0)));


		}
		if (isGround) {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (1, 0, 0);
		} else {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (0, 1, 0);
		}
		if (isLeft || isRight) {
			r.velocity *= .9f;
		}
		if (!isGround) {
			r.AddForce (new Vector2 (0, 0));
		}
		preJump = Input.GetButton ("Jump");
	}
	void OnCollisionEnter2D(Collision2D coll){
		if (LayerMask.LayerToName (coll.gameObject.layer) == "Death") {
			gameObject.transform.position = Vector3.Scale(respawnPoint, new Vector3(1,1,0));
		}
	}

}
