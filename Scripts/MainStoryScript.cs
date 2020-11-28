using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
* Project Name: OurSmallWorld
* Create Date: 2020/11/3
* Author: Suz
* Update Record: 
* 11/4	已完成部分的主线脚本转移至本类，下属模块的事件调用改为调用基类的事件触发方法。
* 11/16	将主线脚本相关数据转移到本类，本类只处理涉及主线脚本的功能 
* 11/18	角色移动相关的功能调用由事件触发改为直接调用对应角色RoleController对象的对应方法
* 11/19	删除所有事件方法的调用，所有功能调用改为方法调用（NextLine无法用方法调用，只能保留StartCoroutine形式）
* 
*/

/// <summary>
///
/// </summary>
public class MainStoryScript : PerformanceManagerBase
{
	//主线脚本单例
	public static MainStoryScript instance;

	//Sprite资源
	public Sprite background_Opening_Sunny;

	public RoleController ArvinRoleController;
	public RoleController DollyRoleController;
	

	//艾文台词
	public string[] ArvinLines = new string[] {
		"已经十点钟了……",
		"多莉？",
		"又去那了吧。",
		"去楼下散散步？",
		"多莉大厨的小弟报道",
		"要不要一起玩游戏？",
		"抱歉……",
		"手机在我的房间",
		"公司那边又有事了？留言了",
		"【很抱歉周末打扰你，艾文】",
		"【文件发你邮箱里了】",
		"工作",
		"多莉？",
		"多莉！你刚才去哪儿了?",
		"快，快吃药",
		"治病的药啊！快……",
		"早安……多莉？",
		"多莉？",
		"可以。"
	};

	//艾文下一句台词
	[SerializeField] public int ArvinCurrentLine = 0;

	//多莉台词
	public string[] DollyLines = new string[] {
		"先吃点东西吧。",
		"想玩什么？",
		"啊！？",
		"艾文？",
		"我在阁楼睡着了……",
		"抱歉，让你担心了。",
		"什么药?",
		"早安",
		"早安，艾文。",
		"艾文，我爱你。",
		"艾文，你不该在这里躺着。",
		"快起来吧。",
		"别感冒了。",
		"邻居要出远门，",
		"拜托寄养在我们家几天，",
		"可以吗？"
	};

	//多莉的下一句台词
	[SerializeField] public int DollyCurrentLine = 0;

	//主线脚本对话顺序
	public int[] mainStoryScript = new int[] { 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 0 };

	//主线脚本当前演出台词序号
	public int mainStoryScriptCurrentLine = 0;

	/// <summary>
	/// 初始化
	/// </summary>
	private void Awake() {
		InstanceInit();
	}

	/// <summary>
	/// 单例初始化
	/// </summary>
	private void InstanceInit() {
		if (instance == null) {
			instance = this;
		}

		else if (instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}

	/// <summary>
	/// 剧情章节入口
	/// </summary>
	/// <param name="ChapterNumber">第几章</param>
	public void ChooseStoryChapter(int chapterNumber) {
		ChapterStart("Story");
		switch (chapterNumber) {
			case 0:
				Debug.Log("Start Coroutine Chapter0");
				StartCoroutine(Chapter0());
				break;
			case 1:
				Debug.Log("Start Coroutine Chapter1");
				StartCoroutine(Chapter1());
				break;
			case 2:
				Debug.Log("Start Coroutine Chapter2");
				StartCoroutine(Chapter2());
				break;
			case 3:
				Debug.Log("Start Coroutine Chapter3");
				StartCoroutine(Chapter3());
				break;
			case 4:
				Debug.Log("Start Coroutine Chapter4");
				StartCoroutine(Chapter4());
				break;
			case 5:
				Debug.Log("Start Coroutine Chapter5");
				StartCoroutine(Chapter5());
				break;
			case 6:
				Debug.Log("Start Coroutine Chapter6");
				StartCoroutine(Chapter6());
				break;
			default:
				Debug.Log("No Chapter " + chapterNumber);
				break;
		}
	}

	/// <summary>
	/// 章节结束整理
	/// </summary>
	protected override void ChapterEnd() {

		Debug.Log("Story Chapter " + currentChapter + " End");

		//章节结束flag，跳出章节演出循环
		isChapterEnd = true;

		//重置演出指针
		currentPerformance = 0;

		//章节+1
		currentChapter += 1;

		//重置章节类型Flag
		isStoryChapter = false;

		//章节结束事件，通知订阅者
		GM.instance.OutFromInteractMode();
	}


	//脚本———————————————————————————————————————————————————————
	/// <summary>
	/// 序章脚本
	/// </summary>
	/// <returns></returns>
	IEnumerator Chapter0() {

		//章节结束flag
		while (!isChapterEnd) {
			switch (currentPerformance) {
				case 0:
					waitSeconds = 2.61f;
					break;
				case 1:
					//旁白“葬礼总是与雨天挂钩”
					Debug.Log("旁白“葬礼总是与雨天挂钩”" + Time.time);
					AsidesController.instance.NextAside(new Vector3(0, 3, 0));

					break;
				case 2:
					//旁白“黑色的长柄雨伞、”
					Debug.Log("“黑色的长柄雨伞、”" + Time.time);
					AsidesController.instance.NextAside(new Vector3(0, 2, 0));

					break;
				case 3:
					//旁白“被雨水打湿的皮鞋、”
					Debug.Log("“被雨水打湿的皮鞋、”" + Time.time);
					AsidesController.instance.NextAside(new Vector3(0, 1, 0));

					break;
				case 4:
					//旁白“捧着乳白色花束流泪的人……”
					Debug.Log("旁白“捧着乳白色花束流泪的人……”" + Time.time);
					AsidesController.instance.NextAside(new Vector3(0, 0, 0));

					break;
				case 5:
					//旁白“然而并不是所有的葬礼都会在阴雨天举办”
					Debug.Log("旁白“然而并不是所有的葬礼都会在阴雨天举办”" + Time.time);
					AsidesController.instance.NextAside(new Vector3(0, -1, 0));

					waitSeconds = 1.5f;
					break;
				case 6:
					//切换背景至“阳光明媚的葬礼”
					Debug.Log("切换背景至“阳光明媚的葬礼”" + Time.time);
					ScenesManager.instance.ChangeBackground(
						Color.white, 
						background_Opening_Sunny, 
						new Vector3(2.80f, 2.80f, 2.80f), 
						new Vector3(0, -0.94f, 0), 
						Color.white);

					//切换BGM
					Debug.Log("切换BGM" + Time.time);
					BGMController.instance.ChangeAudio(BGMController.instance.Op_Sunny, 0.25f, 0.125f);

					waitSeconds = 6.01f;
					break;
				case 7:

					//旁白“阳光倾泻在墓碑表面”
					Debug.Log("旁白“阳光倾泻在墓碑表面”" + Time.time);
					AsidesController.instance.NextAside(new Vector3(0, 3, 0));

					waitSeconds = 2.61f;
					break;
				case 8:
					//旁白“花岗岩被照耀得色彩斑斓”
					Debug.Log("旁白“花岗岩被照耀得色彩斑斓”" + Time.time);
					AsidesController.instance.NextAside(new Vector3(0, 2, 0));

					break;
				case 9:
					//旁白“有撑着黑色长柄雨伞的人”
					Debug.Log("旁白“有撑着黑色长柄雨伞的人”" + Time.time);
					AsidesController.instance.NextAside(new Vector3(0, 1, 0));

					break;
				case 10:
					//旁白“但不至于压抑”
					Debug.Log("旁白“但不至于压抑”" + Time.time);
					AsidesController.instance.NextAside(new Vector3(0, 0, 0));

					break;
				case 11:
					//旁白“墓碑上的名字……”	
					Debug.Log("旁白“墓碑上的名字……”" + Time.time);
					AsidesController.instance.NextAside(new Vector3(0, -1, 0));

					waitSeconds = 3.01f;
					break;
				case 12:
					//旁白“墓碑上的名字，我……”
					Debug.Log("旁白“墓碑上的名字，我……”" + Time.time);
					AsidesController.instance.NextAside(new Vector3(0, -2, 0));

					waitSeconds = 2.5f;
					break;
				case 13:
					//切换场景，跳转至游戏开始
					Debug.Log("切换场景，跳转至游戏开始" + Time.time);
					ScenesManager.instance.ChangeScene(Color.white, ScenesManager.BED_ROOM);

					ChapterEnd();
					yield break;

				default:
					break;
			}
			currentPerformance += 1;
			yield return new WaitForSeconds(waitSeconds);
		}

	}

	/// <summary>
	/// 第一章脚本
	/// </summary>
	/// <returns></returns>
	IEnumerator Chapter1() {

		while (!isChapterEnd) {
			switch (currentPerformance) {
				case 0:
					//艾文初始位置，面朝左边
					Debug.Log("艾文初始位置，面朝左边");
					ArvinRoleController.SetRolePosition(new Vector3(-2, -3.5f, 0));
					ArvinRoleController.RoleTurn(RoleController.LEFT);

					//使角色停下
					ArvinRoleController.RoleStop();
					waitSeconds = 1.5f;
					break;
				case 1:
					//艾文向左移动
					Debug.Log("艾文向左移动");
					ArvinRoleController.RoleMove(new Vector3(-4, -3.5f, 0));

					//艾文台词“已经十点钟了……”
					Debug.Log("艾文台词“已经十点钟了……”");
					yield return StartCoroutine(LinesController.instance.NextLine());

					waitSeconds = 0.5f;
					break;
				case 2:
					//艾文向右转身
					Debug.Log("艾文向右转身");
					ArvinRoleController.RoleTurn(RoleController.RIGHT);

					//艾文台词“多莉？”
					Debug.Log("艾文台词“多莉？”");
					yield return StartCoroutine(LinesController.instance.NextLine());

					waitSeconds = 0.5f;
					break;
				case 3:
					//艾文向右移动
					Debug.Log("艾文向右移动");
					ArvinRoleController.RoleMove(new Vector3(2, -3.5f, 0));

					waitSeconds = 0.5f;
					break;
				case 4:
					//艾文台词“又去那儿了吗？”
					Debug.Log("艾文台词“又去那儿了吗？”");
					yield return StartCoroutine(LinesController.instance.NextLine());

					//艾文结束位置
					Debug.Log("艾文结束位置");
					ArvinRoleController.SetRolePosition(new Vector3(2, -3.5f, 0));

					//章节结束操作
					ChapterEnd();
					yield break;
				default: break;
			}
			currentPerformance += 1;
			yield return new WaitForSeconds(waitSeconds);
		}
	}

	/// <summary>
	/// 第二章脚本
	/// </summary>
	/// <returns></returns>
	IEnumerator Chapter2() {
		while (!isChapterEnd) {
			switch (currentPerformance) {
				case 0:

					//设置多莉初始位置，面朝右边
					Debug.Log("设置多莉初始位置,面朝右边");
					DollyRoleController.SetRolePosition(new Vector3(0, -4.2f, 0));
					DollyRoleController.RoleTurn(RoleController.RIGHT);

					//艾文停下
					ArvinRoleController.RoleStop();

					//艾文台词“去楼下散散步？”
					Debug.Log("艾文台词“去楼下散散步？”");
					yield return StartCoroutine(LinesController.instance.NextLine());

					waitSeconds = 0f;
					break;
				case 1:

					//多莉向左转身
					Debug.Log("多莉向左转身");
					DollyRoleController.RoleTurn(RoleController.LEFT);

					//多莉向左移动
					Debug.Log("多莉向左移动");
					DollyRoleController.RoleMove(new Vector3(-4.5f, -4.2f, 0));

					waitSeconds = 1f;
					break;
				case 2:

					//多莉向右转身
					Debug.Log("多莉向右转身");
					DollyRoleController.RoleTurn(RoleController.RIGHT);

					//多莉台词“先吃点东西吧”
					Debug.Log("多莉台词“先吃点东西吧？”");
					yield return StartCoroutine(LinesController.instance.NextLine());

					waitSeconds = 0.5f;
					break;
				case 3:

					//艾文台词“多莉大厨的小弟报道”
					Debug.Log("艾文台词“多莉大厨的小弟报道”");
					yield return StartCoroutine(LinesController.instance.NextLine());

					waitSeconds = 0.5f;
					break;
				case 4:

					//多莉向右移动到艾文右边
					Debug.Log("多莉向右移动到艾文右边");
					DollyRoleController.RoleMove(new Vector3(10.5f, -4.2f, 0),2.5f);

					waitSeconds = 0.8f;
					break;
				case 5:
					//艾文向右转身
					Debug.Log("艾文向右转身");
					ArvinRoleController.RoleTurn(RoleController.RIGHT);

					ChapterEnd();
					yield break;
			}
			currentPerformance += 1;
			yield return new WaitForSeconds(waitSeconds);
		}

	}

	/// <summary>
	/// 第三章脚本
	/// </summary>
	/// <returns></returns>
	IEnumerator Chapter3() {
		while (!isChapterEnd) {
			switch (currentPerformance) {
				case 0:
					//使角色停下
					ArvinRoleController.RoleStop();

					//切换场景至游戏场景
					ScenesManager.instance.ChangeScene(Color.black,ScenesManager.GAME_SCENE);
					yield return new WaitForSeconds(1f);
					ChapterEnd();
					yield break;

				default:
					break;
			}
			currentPerformance += 1;
			yield return new WaitForSeconds(waitSeconds);
		}

	}

	/// <summary>
	/// 第四章脚本
	/// </summary>
	/// <returns></returns>
	IEnumerator Chapter4() {
		while (!isChapterEnd) {
			switch (currentPerformance) {
				case 0:

					//设置艾文初始位置
					Debug.Log("设置艾文初始位置");
					ArvinRoleController.SetRolePosition(new Vector3(2f, -4f));

					//使角色停下
					ArvinRoleController.RoleStop();

					//设置多莉初始位置
					Debug.Log("设置多莉初始位置");
					DollyRoleController.SetRolePosition(new Vector3(-3.1f, -4.7f));
					waitSeconds = 0.8f;
					break;

				case 1:

					//艾文台词“要不要一起玩游戏？”
					Debug.Log("艾文台词“要不要一起玩游戏？”");
					yield return StartCoroutine(LinesController.instance.NextLine());

					waitSeconds = 0.2f;
					break;
				case 2:
					//多莉台词“想玩什么？”
					Debug.Log("多莉台词“想玩什么？”");
					yield return StartCoroutine(LinesController.instance.NextLine());

					waitSeconds = 0.2f;
					break;
				case 3:
					//切换场景至游戏场景
					ScenesManager.instance.ChangeScene(Color.black,ScenesManager.GAME_SCENE);

					ChapterEnd();
					yield break;

				default:
					break;
			}
			currentPerformance += 1;
			yield return new WaitForSeconds(waitSeconds);
		}

	}

	/// <summary>
	/// 第五章脚本
	/// </summary>
	/// <returns></returns>
	IEnumerator Chapter5() {
		while (!isChapterEnd) {
			switch (currentPerformance) {
				case 0:

					//使角色停下
					ArvinRoleController.RoleStop();

					//设置声道并播放音频
					BGMController.instance.SetAudioStereo(-1f);
					BGMController.instance.PlayAudio(BGMController.instance.PhoneRell, 0.125f);
					
					//画外音“*手机铃声*”
					Debug.Log("画外音“*手机铃声*”");
					AsidesController.instance.NextAside(
						asidePos: new Vector3(6, 4.5f, 0),//旁白坐标
						rendInSpeed: 2.5f, //淡入时间0.4s
						rendOutSpeed: 2.5f,//淡出时间0.4s
						cycleRound: 1,//显示循环次数
						showSeconds: 0.6f,//持续显示时间
						cycleInternal: 3f);//循环间隔

					waitSeconds = 0.5f;
					break;
				case 1:
					//多莉台词“啊！？”
					Debug.Log("多莉台词“啊？”");
					yield return StartCoroutine(LinesController.instance.NextLine());

					waitSeconds = 0.5f;
					break;
				case 2:
					//艾文台词“抱歉……”
					Debug.Log("艾文台词“抱歉……”");
					yield return StartCoroutine(LinesController.instance.NextLine());

					waitSeconds = 0.5f;
					break;
				case 3:
					//艾文向右转身
					Debug.Log("艾文向右转身");
					ArvinRoleController.RoleTurn(RoleController.RIGHT);

					//艾文向右移动走出客厅
					Debug.Log("艾文向右移动走出客厅");
					ArvinRoleController.RoleMove(new Vector3(8.438f, -4, 0));

					waitSeconds = 1.3f;
					break;
				case 4:
					//艾文停止移动
					Debug.Log("艾文停止移动");
					ArvinRoleController.RoleStop();

					waitSeconds = 1.5f;
					break;
				case 5:
					//艾文台词“手机在我的房间”
					Debug.Log("艾文台词“手机在我的房间”");
					yield return StartCoroutine(LinesController.instance.NextLine());

					//暂停BGM
					BGMController.instance.PauseAudio(0.125f);

					ChapterEnd();
					yield break;

				default:
					break;
			}
			currentPerformance += 1;
			yield return new WaitForSeconds(waitSeconds);
		}

	}

	/// <summary>
	/// 第六章脚本
	/// </summary>
	/// <returns></returns>
	IEnumerator Chapter6() {
		while (!isChapterEnd) {
			switch (currentPerformance) {
				case 0:
					//台词“公司那边的事吗？”
					Debug.Log("台词“公司那边又有事了？留言了”");
					yield return StartCoroutine(LinesController.instance.NextLine());

					break;
				case 1:
					//台词““很抱歉在周末打扰你，艾文”
					Debug.Log("台词““【很抱歉在周末打扰你，艾文】”");
					yield return StartCoroutine(LinesController.instance.NextLine());

					break;
				case 2:
					//台词“文件发你邮箱里了””
					Debug.Log("台词“【文件发你邮箱里了】””");
					yield return StartCoroutine(LinesController.instance.NextLine());

					break;
				case 3:
					//台词“工作。”
					Debug.Log("台词“工作”");
					yield return StartCoroutine(LinesController.instance.NextLine());

					ScenesManager.instance.ChangeScene(Color.black, ScenesManager.GAME_SCENE);

					ChapterEnd();
					yield break;

				default:
					break;
			}
			currentPerformance += 1;
			yield return new WaitForSeconds(waitSeconds);
		}
	}

	/// <summary>
	/// 脚本模板
	/// </summary>
	/// <returns></returns>
	IEnumerator Chapter() {
		while (!isChapterEnd) {
			switch (currentPerformance) {
				case 0:
					//yield return StartCoroutine(LinesController.instance.NextLine());
					ChapterEnd();
					yield break;

				default:
					break;
			}
			currentPerformance += 1;
			yield return new WaitForSeconds(waitSeconds);
		}

	}

}
