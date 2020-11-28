using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*Project Name: OurSmallWorld
*Create Date: 2020/11/3
*Author: Suz
*Update Record: 
*
*/

/// <summary>
/// 玩家控制类
/// </summary>
public class PlayerController : MonoBehaviour {

	//玩家控制类单例
	public static PlayerController instance;

	//角色刚体，控制移动
	public Rigidbody2D rg;

	//场景通行口令
	public string sceneChangePassword;

	//交互对象
	public GameObject interactTarget;

	public bool isInteractWithDolly = false;
	public bool isInteractWithItems = false;

	//[SerializeField] private float Y_Length;

	/// <summary>
	/// 初始化
	/// </summary>
	private void Awake() {

		if (instance == null) {
			instance = this;
		}

		else if (instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
		rg = GetComponent<Rigidbody2D>();
	}

	private void Update() {
		//SpriteRotateControl();
		
		try {
			if (GM.instance.GetInteractMode()==false) {
				SpriteTurnControl();
				MoveControl();
				InteractControl();
			}
		}
		catch (Exception) {

		}

	}

	/// <summary>
	/// 交互操作
	/// </summary>
	private void InteractControl() {
		if (Input.GetKeyUp(KeyCode.Space)) {
			if (interactTarget != null) {
				if (interactTarget.name == GM.DollyName) {
					isInteractWithDolly = true;
					if (MainStoryScript.instance.currentChapter == 2) {
						MainStoryScript.instance.ChooseStoryChapter(2);
					}
					if (MainStoryScript.instance.currentChapter == 3 &&
						FindObjectOfType<ScenesManager>().currentSceneName == ScenesManager.KICTHEN) {
						Debug.Log("Kicthen Make brunch");
						MainStoryScript.instance.ChooseStoryChapter(3);
					}
				}
				if (interactTarget.tag=="Item") {
					isInteractWithItems = true;
					Debug.Log("Item Space");
					ItemScript.instance.InitItemInteract(interactTarget.gameObject.name);
				}
			}

		}

	}

	/// <summary>
	/// 角色sprite放缩控制
	/// </summary>
	/// 
	//public void SpriteRotateControl() {
	//	float scaleValue =0.9f+(maxY-transform.position.y) / Y_Length/10.0f;
	//	transform.localScale = new Vector3(scaleValue,scaleValue,scaleValue);
	//}

	/// <summary>
	/// 角色转身sprite控制
	/// </summary>
	private void SpriteTurnControl() {
		if (Input.GetKeyDown(KeyCode.A) && GetComponent<SpriteRenderer>().flipX == true) {
			GetComponent<SpriteRenderer>().flipX = false;
		}
		if (Input.GetKeyDown(KeyCode.D) && GetComponent<SpriteRenderer>().flipX == false) {
			GetComponent<SpriteRenderer>().flipX = true;
		}
	}

	/// <summary>
	/// 移动指令
	/// </summary>
	private void MoveControl() {
		float moveH = Input.GetAxis("Horizontal") * RoleController.moveSpeed;
		float moveV = Input.GetAxis("Vertical") * RoleController.moveSpeed;
		rg.velocity = new Vector2(moveH, moveV);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.name == GM.DollyName) {
			Debug.Log("Dolly Space to talk");

			/*todo 多莉高亮显示*/

		}
		if (collision.gameObject.tag == "Item") {
			Debug.Log("Item Space to Interact");

			/*todo 物品高亮显示*/

		}
		interactTarget = collision.gameObject;
	}

	private void OnTriggerExit2D(Collider2D collision) {
		if (collision.gameObject.name == GM.DollyName) {
			Debug.Log("Leave Dolly");
			interactTarget = null;
			isInteractWithDolly = false;
		}
		if (collision.gameObject.tag=="Item") {
			Debug.Log("Leave Item");
			interactTarget = null;
			isInteractWithItems = false;
		}
	}

}
