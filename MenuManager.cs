using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

	public GameObject startButton;

	//Volume Button
	public GameObject volumeBtnPlay;
	public GameObject volumeBtnMute;

	private Button startBtn;


	string subject = "COLOR HARMONY";
	string body = "GAME LINK HERE + Amazing arcade game worth time spending";

	void Awake ()
	{
		startBtn = startButton.GetComponent<Button> ();
		startBtn.interactable = false;

		Invoke ("SetStartButton", .9f);
	}

	void SetStartButton ()
	{
		startBtn.interactable = true;
	}

	public void Play ()
	{
		SceneManager.LoadScene (1);
	}

	public void Donate()
	{
		Application.OpenURL ("https://www.paypal.me/quickreflexstudios/5");
	}


	public void ShareText(){
		//execute the below lines if being run on a Android device
		#if UNITY_ANDROID
		//Refernece of AndroidJavaClass class for intent
		AndroidJavaClass intentClass = new AndroidJavaClass ("android.content.Intent");
		//Refernece of AndroidJavaObject class for intent
		AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent");
		//call setAction method of the Intent object created
		intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string>("ACTION_SEND"));
		//set the type of sharing that is happening
		intentObject.Call<AndroidJavaObject>("setType", "text/plain");
		//add data to be passed to the other activity i.e., the data to be sent
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
		intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body);
		//get the current activity
		AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");
		//start the activity by sending the intent data
		currentActivity.Call ("startActivity", intentObject);
		#endif

	}
}
