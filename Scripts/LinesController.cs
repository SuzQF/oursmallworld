using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
*Project Name: OurSmallWorld
*Create Date: 2020/11/3
*Author: Suz
*Update Record: 
*11/16		将主线剧情相关数据移至MainStoryScript类，纯化本类
*11/16		本类将只负责与台词相关的服务提供
*/

public class LinesController : MonoBehaviour {
	//台词控制器单例
	public static LinesController instance;

	//用于台词UI跟随
	public Camera LinesControllerCamera;
	public Canvas LinesControllerCanvas;

	//台词显示所用UI
	[SerializeField]private Text linesTxtBox;
	[SerializeField]private Text linesTxt;

	//台词对应跟随目标
	[SerializeField] private Transform target;

	//台词显示位置Y轴偏移量
	[SerializeField] private float DollyOffSetValue = 732;
	[SerializeField] private float ArvinOffSetValue = 840;

	//物品交互台词
	public string[] itemScripts;
	public int itemCurrentLine = 0;

	/// <summary>
	/// 初始化
	/// </summary>
	void Awake() {
		if (instance == null) {
			instance = this;
		}

		else if (instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
		
	}

	// Update is called once per frame
	void Update() {
		TxtPositionFollow();
	}

	/// <summary>
	/// 角色台词位置跟随
	/// </summary>
	private void TxtPositionFollow() {

		//Text跟随
		if (target==null) {
			return;
		}
		var temp = Camera.main.WorldToScreenPoint(target.transform.position);
		Vector2 pos = new Vector2();
		bool isRect = RectTransformUtility.ScreenPointToLocalPointInRectangle(LinesControllerCanvas.transform as RectTransform, temp, LinesControllerCamera, out pos);
		if (isRect) {

			//根据当前说话角色调整台词UI显示偏移量
			linesTxtBox.rectTransform.anchoredPosition = new Vector2(pos.x, pos.y 
				+ (MainStoryScript.instance.mainStoryScript[MainStoryScript.instance.mainStoryScriptCurrentLine] == 0 ? ArvinOffSetValue : DollyOffSetValue));
		}
	}

	/// <summary>
	/// 角色下一句台词
	/// </summary>
	/// <returns></returns>
	public IEnumerator NextLine() {
		Debug.Log("NextLine Start" + Time.time);
		bool isOver = false;
		while (!isOver) {

			//获取下一句台词信息
			GetNextLine();

			//等待台词淡入协程结束
			yield return StartCoroutine(LinesFadeIn(5f));
			isOver = true;

			//持续显示时间
			yield return new WaitForSeconds(0.5f);
		}

		//等待台词淡出协程结束
		yield return StartCoroutine(LinesFadeOut(4f));
		Debug.Log("HideLines");

		//一句台词显示完毕后，剧本台词指针前移
		if (PerformanceManagerBase.isStoryChapter) {
			MainStoryScript.instance.mainStoryScriptCurrentLine += 1;
		}

		target = null;
		Debug.Log("NextLine End" + Time.time);
	}

	/// <summary>
	/// 确定下一句台词
	/// </summary>
	/// <returns>如果是剧情则返回true，否则为false</returns>
	private void GetNextLine() {

		//如果与场景交互
		if (PerformanceManagerBase.isItemChapter) {
			linesTxt.text = itemScripts[itemCurrentLine];
			target = PlayerController.instance.transform;
			itemCurrentLine += 1;
		}

		////如果与多莉交互
		//else if (PerformanceManager.instance.isDollyChapter) {
		//	linesTxt.text = DollyScript[DollyScriptCurrentLine];
		//}

		//如果是剧情
		//根据剧本的当前台词flag选择跟随目标和确定台词
		else if (PerformanceManagerBase.isStoryChapter) {
			if (MainStoryScript.instance.mainStoryScript[MainStoryScript.instance.mainStoryScriptCurrentLine] == 0) {
				linesTxt.text = MainStoryScript.instance.ArvinLines[MainStoryScript.instance.ArvinCurrentLine];
				target = PlayerController.instance.transform;
				MainStoryScript.instance.ArvinCurrentLine += 1;
			}
			else if (MainStoryScript.instance.mainStoryScript[MainStoryScript.instance.mainStoryScriptCurrentLine] == 1) {
				linesTxt.text = MainStoryScript.instance.DollyLines[MainStoryScript.instance.DollyCurrentLine];
				target = MainStoryScript.instance.DollyRoleController.transform;
				MainStoryScript.instance.DollyCurrentLine += 1;
			}
		}

	}

	/// <summary>
	/// 台词淡入协程
	/// </summary>
	/// <param name="rendSpeed"></param>
	/// <returns></returns>
	private IEnumerator LinesFadeIn(float rendSpeed) {
		instance.ShowLines();
		float alpha = 0;
		while (alpha < 1) {
			alpha += rendSpeed * Time.deltaTime;
			linesTxtBox.transform.GetChild(0).GetComponent<Image>().color = new Vector4(1, 1, 1, alpha);
			linesTxtBox.transform.GetChild(1).GetComponent<Text>().color = new Vector4(0, 0, 0, alpha);
			yield return 0;
		}
		Debug.Log("Line Fade In Over");
	}

	/// <summary>
	/// 显示台词UI
	/// </summary>
	private void ShowLines() {
		linesTxtBox.gameObject.SetActive(true);
	}

	/// <summary>
	/// 台词淡出协程
	/// </summary>
	/// <param name="rendSpeed"></param>
	/// <returns></returns>
	private IEnumerator LinesFadeOut(float rendSpeed) {
		float alpha = 1;
		while (alpha > 0) {
			alpha -= rendSpeed * Time.deltaTime;
			linesTxtBox.transform.GetChild(0).GetComponent<Image>().color = new Vector4(1, 1, 1, alpha);
			linesTxtBox.transform.GetChild(1).GetComponent<Text>().color = new Vector4(0, 0, 0, alpha);
			yield return new WaitForSeconds(0);
		}
		instance.HideLines();
	}

	/// <summary>
	/// 隐藏台词UI
	/// </summary>
	private void HideLines() {
		linesTxtBox.gameObject.SetActive(false);
	}


}