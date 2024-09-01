using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public GameController gameController;

	public int speed = 10;
	//Movement Bool
	bool isRight = false;
	bool isLeft = false;
	bool isUp = false;
	bool isDown = false;

	public bool moveUp = false;
	public bool moveDown = false;
	public bool moveLeft = false;
	public bool moveRight = false;

	//Touch Control
	private float fingerStartTime = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;
	private bool isSwipe = false;
	private float minSwipeDist = 50.0f;
	private float maxSwipeTime = 0.5f;

	void Update ()
	{
		if (Input.touchCount > 0) {

			foreach (Touch touch in Input.touches) {
				switch (touch.phase) {
				case TouchPhase.Began:
					/* this is a new touch */
					isSwipe = true;
					fingerStartTime = Time.time;
					fingerStartPos = touch.position;
					break;

				case TouchPhase.Canceled:
					/* The touch is being canceled */
					isSwipe = false;
					break;

				case TouchPhase.Ended:

					float gestureTime = Time.time - fingerStartTime;
					float gestureDist = (touch.position - fingerStartPos).magnitude;

					if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist) {
						Vector2 direction = touch.position - fingerStartPos;
						Vector2 swipeType = Vector2.zero;

						if (Mathf.Abs (direction.x) > Mathf.Abs (direction.y)) {
							// the swipe is horizontal:
							swipeType = Vector2.right * Mathf.Sign (direction.x);
						} else {
							// the swipe is vertical:
							swipeType = Vector2.up * Mathf.Sign (direction.y);
						}

						if (swipeType.x != 0.0f) {
							if (swipeType.x > 0.0f) {
								
								// MOVE RIGHT
								if (isLeft || isUp || isUp) {
									isRight = false;
								} else {
									isRight = true;
								}

							} else {
								
								// MOVE LEFT
								if (isRight || isUp || isDown) {
									isLeft = false;
								} else {
									isLeft = true;
								}

							}
						}

						if (swipeType.y != 0.0f) {
							if (swipeType.y > 0.0f) {
								
								// MOVE UP
								if (isRight || isLeft || isDown) {
									isUp = false;
								} else {
									isUp = true;
								}


							} else {
								
								// MOVE DOWN
								if (isRight || isLeft || isUp) {
									isDown = false;
								} else {
									isDown = true;
								}

							}
						}

					}

					break;
				}
			}
		}

		//Move Right
		if (Input.GetKeyDown (KeyCode.D)) {
			if (isLeft || isUp || isDown) {
				isRight = false;
			} else {
				isRight = true;
			}
		}
		if (transform.position.x <= 4.5 && isRight) {
			transform.position += transform.right * Time.deltaTime * speed;

			/*------UPDATED CODE FOR RIGHTMOVEMENT------------------*/

//			isRightCheck = true;
//			CheckTheDirection ();
		}
		if (transform.position.x >= 4.5) {
			isRight = false;
		}


		//Move Left
		if (Input.GetKeyDown (KeyCode.A)) {
			if (isRight || isUp || isDown) {
				isLeft = false;
			} else {
				isLeft = true;
			}
		}
		if (transform.position.x >= -4.5 && isLeft) {
			transform.position += -transform.right * Time.deltaTime * speed;
		}
		if (transform.position.x <= -4.5) {
			isLeft = false;
		}


		//Move Up
		if (Input.GetKeyDown (KeyCode.W)) {
			if (isRight || isLeft || isDown) {
				isUp = false;
			} else {
				isUp = true;
			}
		}
		if (transform.position.y <= 6.5 && isUp) {
			transform.position += transform.up * Time.deltaTime * speed;
		}
		if (transform.position.y >= 6.5) {
			isUp = false;
		}

		//Move Down
		if (Input.GetKeyDown (KeyCode.S)) {
			if (isRight || isLeft || isUp) {
				isDown = false;
			} else {
				isDown = true;
			}
		}
		if (transform.position.y >= -6.5 && isDown) {
			transform.position += -transform.up * Time.deltaTime * speed;
		}
		if (transform.position.y <= -6.5) {
			isDown = false;
		}
	}

//	public bool CheckForCondition()
//	{
//		if (GameController.instance.moveUpLine && moveUp) {
//			return true;
//		}
//		return true;
//	}

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.gameObject.name == "UpArrow") {
			moveUp = true;
//			print (moveUp);
		}else if (target.gameObject.name == "DownArrow") {
			moveDown = true;
//			print (moveDown);
		}else if (target.gameObject.name == "LeftArrow") {
			moveLeft = true;
//			print (moveLeft);
		}else if (target.gameObject.name == "RightArrow") {
			moveRight = true;
//			print (moveRight);
		}
			
//		if (moveRight != GameController.instance.moveRightLine) {
//			GameController.instance.GameOver ();
//		}

//		if (target.gameObject.tag == "Orange" || target.gameObject.tag == "Blue" || target.gameObject.tag == "Green" || target.gameObject.tag == "Grey" || target.gameObject.tag == "Pink" || target.gameObject.tag == "Yellow") {
//
//			GameObject gameManager = GameObject.FindGameObjectWithTag ("GameController");
//			GameController gameController = gameManager.GetComponent<GameController> ();

//			gameController.GameOver();

//			Destroy (gameObject);
//		}
	}

}
