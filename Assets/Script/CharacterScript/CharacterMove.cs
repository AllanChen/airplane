using UnityEngine;
using System.Collections;
public class CharacterMove : MonoBehaviour {

	Animator anitor;
	float hor;
	float ver;

	int warkingHash = Animator.StringToHash("Base Layer.Walk");
	int runHash 	= Animator.StringToHash("Base Layer.Run");
	
	//public AudioClip 	audioClip;

	void Start () {
		anitor = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		hor = Input.GetAxis("Horizontal");
		ver = Input.GetAxis("Vertical");


	}

	void FixedUpdate()
	{
		anitor.SetFloat("walking",ver);
		
		AnimatorStateInfo  animationStateInfo = anitor.GetCurrentAnimatorStateInfo(0);
		
		if(Input.GetKeyDown(KeyCode.LeftShift) && animationStateInfo.nameHash == warkingHash)
		{
			anitor.SetBool("run",true);
		}
		
		if(animationStateInfo.nameHash == runHash && Input.GetKeyUp(KeyCode.LeftShift) )
		{
			anitor.SetBool("run",false);
		}
		
		if(animationStateInfo.nameHash == runHash && Input.GetKeyDown(KeyCode.Space))
		{
			anitor.SetBool("runToJump",true);
		}
		
		if(animationStateInfo.nameHash == runHash && Input.GetKeyUp(KeyCode.Space))
		{
			anitor.SetBool("runToJump",false);
		}
		
		if(animationStateInfo.nameHash == warkingHash && Input.GetKeyDown(KeyCode.Space))
		{
			anitor.SetBool("walkToJump",true);
		}
		
		if(animationStateInfo.nameHash == warkingHash && Input.GetKeyUp(KeyCode.Space))
		{
			anitor.SetBool("walkToJump",false);
		}

	}
}
