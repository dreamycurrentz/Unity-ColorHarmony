using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleAnim : MonoBehaviour
{

	Animator anim;

	void Start ()
	{
		anim = GetComponent<Animator> ();

		Invoke ("ColoringText", 1f);
	}

	void ColoringText()
	{
		anim.SetTrigger ("titleAnimComplete");
	}
}
