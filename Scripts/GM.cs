using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
* Project Name: OurSmallWorld
* Create Date: 2020/11/3
* Author: Suz
* Update Record: 
* 11/18	封装了isInteractMode的访问
* 11/19	将ScenesManager类的创建Dolly实例的相关方法转移至本类
*/

public class GM : MonoBehaviour {

	//游戏管理员类单例
	public static GM instance;

	//交互模式
	private bool isInteractMode = true;

	//Dolly的prefab
	public GameObject DollyProfab;
	public const string DollyName = "Dolly(Clone)";

	private void Awake() {
		if (instance == null) {
			instance = this;
		}
		else if (instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);

	}

	/// <summary>
	/// 开始游戏按键按钮事件
	/// </summary>
	private void StartBtnClicked() {
		BGMController.instance.PlayAudio(BGMController.instance.Op_Rainy, 0.5f);
		Debug.Log("GM Change Scene To Opening");
		ScenesManager.instance.ChangeScene(Color.black, ScenesManager.OPENING);
	}

	/// <summary>
	/// 进入交互模式
	/// </summary>
	public void IntoInteractMode() {
		Debug.Log("Is Interact Mode True");
		isInteractMode = true;
		if (MainStoryScript.instance.ArvinRoleController != null) {
			MainStoryScript.instance.ArvinRoleController.RoleStop();
		}
	}

	/// <summary>
	/// 结束交互模式
	/// </summary>
	public void OutFromInteractMode() {
		Debug.Log("Is Interact Mode False");
		isInteractMode = false;
	}

	/// <summary>
	/// 获取GM的InteractMode
	/// </summary>
	/// <returns></returns>
	public bool GetInteractMode() {
		return isInteractMode;
	}


	/// <summary>
	/// 创建Dolly游戏体实例
	/// </summary>
	/// <param name="position"></param>
	public void CreateDollyInstance(Vector3 position) {
		SetDollyRoleController(InstantiateDolly(position));
	}

	/// <summary>
	/// 实例化Dolly预制体
	/// </summary>
	/// <returns></returns>
	private RoleController InstantiateDolly(Vector3 position) {
		return Instantiate(instance.DollyProfab, position, Quaternion.identity).GetComponent<RoleController>();
	}

	/// <summary>
	/// 将RoleController组件交给MainStoryScript
	/// </summary>
	/// <param name="roleController"></param>
	private void SetDollyRoleController(RoleController roleController) {
		MainStoryScript.instance.DollyRoleController = roleController;
	}

}
