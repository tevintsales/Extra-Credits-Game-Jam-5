using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
This is a Top Down Character Control Template


*/
public class CharacterControl : MonoBehaviour {

	private Rigidbody2D rb2d;

	public int dodgeSpeed = 40;
	public int moveSpeed = 10;

	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = 0.05f;
	[Range(0, .3f)] [SerializeField] private float d_MovementSmoothing = 0.05f;

	private Vector3 m_Velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
		//c_Stat = GetComponent<CharacterStatManager>();
	}

	//Accessible Move function
	public void Move (float xmove, float ymove) {
		//Determine Vector
    	Vector3 movement = new Vector3 (xmove, ymove);
    	//Add Velocity and Smoothing--
    	rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, movement * moveSpeed, ref m_Velocity, m_MovementSmoothing);
    	//Debug.Log(rb2d.velocity);
		}
	//Walk Function Half Movement
	public void Walk (float xmove, float ymove) {
		//Determine Vector
    	Vector3 movement = new Vector3 (xmove, ymove);
    	//Add Velocity and Smoothing
    	rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, movement/2 * moveSpeed, ref m_Velocity, m_MovementSmoothing);
		}
	//Sneak Function
	public void Sneak (float xmove, float ymove) {
		//Determine Vector
    	Vector3 movement = new Vector3 (xmove, ymove);
    	//Add Velocity and Smoothing
    	rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, movement/3 * moveSpeed, ref m_Velocity, m_MovementSmoothing);
		}
	//Dodge Function 
	public void Dodge (float xmove, float ymove) {
		//Determine Vector
    	Vector3 movement = new Vector3 (xmove, ymove);
    	//Add Velocity and Smoothing
    	rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, movement * dodgeSpeed, ref m_Velocity, d_MovementSmoothing);
    	//Animation Control
	}
    //Stop Player Movement
    public void StopMove()
    {
        rb2d.velocity = Vector3.zero;
    }
}