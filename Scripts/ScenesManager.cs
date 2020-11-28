using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
* Project Name: OurSmallWorld
* Create Date: 2020/11/3
* Author: Suz
* Update Record: 
* 11/17	删除冗余代码，优化代码结构
* 11/19	删除事件相关，简化调用
*/


public class ScenesManager : MonoBehaviour {

	//场景管理员类单例
	public static ScenesManager instance;

	//标准场景名
	public const string KICTHEN = "Kicthen";
	public const string LIVING_ROOM = "LivingRoom";
	public const string BED_ROOM = "BedRoom";
	public const string ARVIN_SPACE = "ArvinSpace";
	public const string DOLLY_SPACE = "DollySpace";
	public const string GAME_SCENE = "GameScene";
	public const string OPENING = "Opening";
	public const string MAIN_MENU = "MainMenu";

	//透明度
	[SerializeField] private float alpha;

	//渐变速度
	[SerializeField] private float rendSpeed = 2f;

	private bool isRenderOut = false;

	//当前场景名字
	public string currentSceneName;

	private void Awake() {
		if (instance == null) {
			instance = this;
		}

		else if (instance != this) {
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}

	void FixedUpdate() {
		if (currentSceneName != SceneManager.GetActiveScene().name) {
			EnterNewSceneSet(currentSceneName, SceneManager.GetActiveScene().name);
			currentSceneName = SceneManager.GetActiveScene().name;
		}
	}

	/// <summary>
	/// 切换场景
	/// </summary>
	/// <param name="sceneName">场景名</param>
	public void ChangeScene(Color renderColor, string sceneName) {
		Debug.Log("FadeIn");
		GM.instance.IntoInteractMode();
		StartCoroutine(FadeTo(renderColor, sceneName));
	}

	/// <summary>
	/// 进入新场景事件处理
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public void EnterNewSceneSet(string lastSceneName, string currentSceneName) {

		//淡入视效设置
		instance.SetFadeIn(lastSceneName,currentSceneName);

		//场景初始化
		instance.SceneInit();

		GM.instance.OutFromInteractMode();
	}

	/// <summary>
	/// 设置淡入视效
	/// </summary>
	/// <param name="e"></param>
	private void SetFadeIn(string lastSceneName, string currentSceneName) {

		//根据上一场景选择淡入颜色
		if (lastSceneName == OPENING) {
			instance.StartCoroutine(instance.FadeIn(Color.white));
		}
		else {
			instance.StartCoroutine(instance.FadeIn(Color.black));
		}

		//更新当前场景名
		instance.currentSceneName = currentSceneName;
		Debug.Log("Current Scene: " + instance.currentSceneName);

		//根据当前场景选择淡入速度
		if (instance.currentSceneName == OPENING) {
			instance.rendSpeed = 0.25f;
		}
		else {
			instance.rendSpeed = 2f;
		}
	}

	/// <summary>
	/// 新场景设置
	/// </summary>
	private void SceneInit() {

		//绑定当前场景摄像机
		LinesController.instance.GetComponent<Canvas>().worldCamera = FindObjectOfType<Camera>();

		//场景初始化
		if (currentSceneName == OPENING) {
			if (MainStoryScript.instance.currentChapter == 0) {
				MainStoryScript.instance.ChooseStoryChapter(0);
			}
		}
		else if (currentSceneName == BED_ROOM) {
			if (MainStoryScript.instance.currentChapter == 1) {
				MainStoryScript.instance.ArvinRoleController = PlayerController.instance.gameObject.GetComponent<RoleController>();
				MainStoryScript.instance.ChooseStoryChapter(1);
			}
		}
		else if (currentSceneName == DOLLY_SPACE) {
			if (MainStoryScript.instance.currentChapter == 2) {

				//新建Dolly游戏体
				GM.instance.CreateDollyInstance(new Vector3(0, -4.2f, 0));
			}
		}
		else if (currentSceneName == KICTHEN) {
			if (MainStoryScript.instance.currentChapter == 3) {
				GM.instance.CreateDollyInstance(new Vector3(-2.68f, -4.2f, 0));
			}
		}
		else if (currentSceneName == LIVING_ROOM) {
			if (MainStoryScript.instance.currentChapter == 4) {
				GM.instance.CreateDollyInstance(new Vector3(-3f, -4.7f, 0));
				MainStoryScript.instance.ChooseStoryChapter(4);
			}
			else if (MainStoryScript.instance.currentChapter == 5) {
				GM.instance.CreateDollyInstance(new Vector3(-3f, -4.7f, 0));
				MainStoryScript.instance.ChooseStoryChapter(5);
			}
		}
		else if (currentSceneName == ARVIN_SPACE) {
			if (MainStoryScript.instance.currentChapter == 6) {
				MainStoryScript.instance.ChooseStoryChapter(6);
			}
		}
	}

	//IEnumerator 枚举器笔记 
	//姑且先当作是一个简单需要迭代的的异步吧

	//协程，微线程，在一个线程间完成并发异步的程序结构
	//原理与多线程类似，不过协程始终在一个线程内，比多线程高效，也不存在跨线程通信之类的问题

	/// <summary>
	/// 淡入协程
	/// </summary>
	/// <param name="renderColor">淡入颜色</param>
	/// <returns></returns>
	IEnumerator FadeIn(Color renderColor) {
		while (isRenderOut) {
			yield return new WaitForSeconds(0);
		}
		alpha = 1;
		while (alpha > 0) {

			alpha -= Time.deltaTime * rendSpeed;
			transform.GetChild(0).GetComponent<Image>().color = new Color(renderColor.r, renderColor.g, renderColor.b, alpha);
			//yield return 必须返回 IEnumberable<T>、IEnumberable、IEnumberator<T>和IEnumberator中的一个
			//yield return是一次迭代的结束，如果要中途退出迭代，则使用yield break
			//WaitForSeconds是符合yield return返回值类型的函数，表示等待一定时间（单位：ms）后进行下一次迭代

			yield return new WaitForSeconds(0);
		}
	}

	/// <summary>
	/// 淡出到场景协程
	/// </summary>
	/// <param name="renderColor">淡出颜色</param>
	/// <param name="sceneName">目标场景名</param>
	/// <returns></returns>
	IEnumerator FadeTo(Color renderColor, string sceneName) {
		alpha = 0;
		while (alpha < 1) {
			alpha += Time.deltaTime * rendSpeed;
			transform.GetChild(0).GetComponent<Image>().color = new Vector4(renderColor.r, renderColor.g, renderColor.b, alpha);
			yield return new WaitForSeconds(0);
		}
		Debug.Log("Fade To Scene:" + sceneName);
		SceneManager.LoadScene(sceneName);
		yield break;
	}

	/// <summary>
	/// 淡出协程
	/// </summary>
	/// <param name="renderColor">淡出颜色</param>
	/// <returns></returns>
	IEnumerator FadeOut(Color renderColor) {
		isRenderOut = true;
		Debug.Log("Render Out");
		alpha = 0;
		while (alpha < 1) {
			alpha += Time.deltaTime * rendSpeed;
			transform.GetChild(0).GetComponent<Image>().color = new Vector4(renderColor.r, renderColor.g, renderColor.b, alpha);
			yield return new WaitForSeconds(0);
		}
		Debug.Log("Render Out End");
		isRenderOut = false;
	}

	/// <summary>
	/// 修改背景图协程
	/// </summary>
	/// <param name="e"></param>
	public void ChangeBackground(Color outColor, Sprite imageSource, Vector3 imageScale, Vector3 imagePosition, Color inColor) {
		StartCoroutine(ChangeBackgroundCoroutine(outColor, imageSource, imageScale, imagePosition, inColor));
	}

	/// <summary>
	/// 修改背景图协程
	/// </summary>
	/// <param name="outColor">当前背景图淡出速度</param>
	/// <param name="imageSource">目标背景图Image</param>
	/// <param name="imageScale">目标背景图缩放</param>
	/// <param name="imagePosition">目标背景图位置</param>
	/// <param name="inColor">目标背景图淡入速度</param>
	/// <returns></returns>
	IEnumerator ChangeBackgroundCoroutine(Color outColor, Sprite imageSource, Vector3 imageScale, Vector3 imagePosition, Color inColor) {
		yield return StartCoroutine(FadeOut(inColor));

		FindObjectOfType<SpriteRenderer>().sprite = imageSource;
		FindObjectOfType<SpriteRenderer>().transform.localScale = imageScale;
		FindObjectOfType<SpriteRenderer>().transform.position = imagePosition;

		Debug.Log("Change Background Over");
		yield return StartCoroutine(FadeIn(outColor));
		yield break;
	}
}
