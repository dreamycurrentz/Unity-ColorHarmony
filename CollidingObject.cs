using UnityEngine;
using System.Collections;

public class CollidingObject : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.tag == "Green" || target.tag == "Blue" || target.tag == "Grey" || target.tag == "Orange" || target.tag == "Pink" || target.tag == "Yellow") {
//			GameController.instance.GameOver ();
//			Destroy (target.gameObject);
		}
	}


}
