using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Project Name: OurSmallWorld
* Create Date: 2020/11/3
* Author: Suz
* Update Record: 
* 11/4	完成的脚本转移到本类
* 11/12	完成了章节选择，目前将所有脚本的调用暂时用统一方法实现，待改进
* 
*/

/// <summary>
///
/// </summary>
public class ItemScript : PerformanceManagerBase {

	//物品脚本单例
	public static ItemScript instance;

	//	{
	//	//客厅
	//	Letter,//信封
	//	NO_SMOKING_Sign,//“禁止吸烟”标志
	//	Calender,//日历
	//	Gramophone,//留声机
	//	FishTank,//鱼缸

	//	//厨房
	//	Oven,//烤箱
	//	CoffeeMaker,//咖啡机
	//	RadioInKicthen,//收音机
	//	NormalCookbook,//外传版本食谱

	//	//卧室
	//	Photo,//合照
	//	DoubleBed,//双人床
	//	Privity,//约法三章
	//	Violin,//小提琴
	//	Dairy,//日记

	//	//多莉房间
	//	DogPainting_ByDolly,//多莉的狗狗画
	//	DogPainting_ByFriend,//多莉朋友的狗狗画
	//	Paintings_ByDolly,//多莉的其他画作（可以再做细分，展示更多细节）
	//	Easel,//画架（包括画板颜料作为一个整体）
	//	RadioInDollySpace,//收音机
	//	DeckChair,//躺椅
	//	Medal,//奖牌
	//	Bookrack,//书架
	//	PaintingBooks__OnDesk,//书桌上的绘画书籍
	//	SpecialCookbook,//秘藏版食谱

	//	//艾文房间
	//	BigBookrack,//大书架
	//	BeHusbandAndFatherBook,//关于成为好丈夫和父亲的书
	//	ViolinStand,//小提琴架
	//	BigBed,//大床
	//	Poster_DeadPoemSocity,//死亡诗社海报
	//	Cabinet,//陈列柜
	//	WorkDesk,//书桌
	//	ScreenOnWall,//墙上大型投影屏幕
	//}
	public List<Item> items = new List<Item> {

		//客厅场景——————————————————————————————————————————————————————
		//信
		new Item("Letter",2,new string[][] {
			new string[] {
				"【艾文亲启：】",
				"【见字如晤，安好勿念。】",
				"【在阿尔卑斯山滑雪。】",
				"【附：明信片一张。父字。】",
				"阿尔卑斯山？九月去滑雪？",
				"时间是？今年三月",
				"…………",
				"明信片上是父母的合照",
				"我们与父母分开生活，来往不多",
				"我们家族都信奉【独立人格】",
				"不过我和多莉都……",
				"不太【独立】"
			},
			new string[] {
				"父亲寄来的信，一切安好",
				"半年前了，回信就等下次吧"
			},
		}),

		//“禁止吸烟”标志
		new Item("NO_SMOKING_Sign",2,new string[][]{
			new string[] {
				"以前压力大，经常抽烟",
				"多莉生病后就没再抽了",
				"村里爱吸烟的人不少",
				"为多莉身体考虑，就有了这个"
			},
			new string[] {
				"多莉总能让我平静下来",
				"比烟好多了"
			}
		}),

		//日历
		new Item("Calender",1,new string[][] {
			new string[] {
				"【9月26日，周六】",
				"今天是个特别的日子"
			}
		}),

		//留声机
		new Item("Gramophone",2,new string[][] {
			new string[] {
				"父母都还在使用的留声机",
				"多莉很喜欢",
				"所以会觉得多莉很独特",
				"她不喜欢现代科技",
				"反而喜欢这些复古的东西"
			}
		},true),

		//鱼缸
		new Item("FishTank",2,new string[][] {
			new string[] {
			"每次看到这鱼缸都想吐槽",
			"多莉养的宠物鱼",
			"她明明排斥现代科技的",
			"但为了鱼还是买了这个鱼缸",
			"怎么看都和其他家具格格不入"
			}
		}),

		//厨房场景————————————————————————————————————————————————————
		//收音机
		new Item("RadioInKicthen",2,new string[][] {
			new string[] {
				"收音机，多莉做饭时会听",
				"多莉房间也有一个一模一样的",
				"她熟知喜欢的节目播出时间",
				"也总是能轻松调到想要的频道",
				"我就完全摆弄不来",
				"一碰就只剩下电流杂音了",
				"找机会让多莉教教我"
			}
		}),

		//外传版食谱
		new Item("NormalCookbook",2,new string[][] {
			new string[] {
				"多莉的烹饪能力远近闻名",
				"常有村民来向她讨教",
				"不善言辞的她就制作了这部食谱",
				"很有她的风格",
				"食谱步骤很细致",
				"也有小提示和修改的痕迹",
				"连我这种厨房毁灭者都看得懂",
				"不过也还是经常出错",
				"我果然没救了吧"
			}
		}),

		//冰箱
		new Item("Refrigerator",2,new string[][] {
			new string[] {
				"午餐肉和土豆是冰箱里的常客",
				"因为从小家教的关系，我没吃过快餐",
				"现在就报复性的喜欢上了午餐肉",
				"多莉则是最爱碳烤小土豆",
				"她只要家乡产的小土豆",
				"好在这土豆种植周期短",
				"每隔三四个月，岳父母就会寄过来很多",
				"她也经常烹饪奇怪的土豆料理",
				"可怜试吃的总是我",
				"虽然也有好吃到升天的料理就是了"
			}
		}),

		//卧室场景————————————————————————————————————————————————————
		//合照
		new Item("Photo",2,new string[][] {
			new string[] {
				"和多莉在房子前的合照",
				"多莉不喜欢生人",
				"所以照相者是房子的前主人",
				"她也是多莉的朋友",
			}
		},true),

		//约法三章
		new Item("Privity",2,new string[][] {
			new string[] {
				"【约法三章】，我们夫妻间的默契",
				"每次试吃多莉都会要我说真话",
				"但有时候说了真话又会被打",
				"真是拿她没办法",
				"陌生人来访，多莉大都不会露面",
				"只有熟悉的邻居来访，她才会出来",
			}
		},true),

		//日记
		new Item("Dairy",2,new string[][] {
			new string[] {
				"我的日记",
				"有时心有所感就会写一篇",
				"对多莉也是公开的",
				"她还会批注吐槽",
				"对日记的，对我的",
				"也是我们之间交流的另一种方式",
			}
		},true),

		//小提琴
		new Item("Violin",2,new string[][] {
			new string[] {
				"我从小用到大的小提琴",
				"琴弦也换过几次了",
				"有些磕碰，不过大体保养的很好",
				"多莉也喜欢听我拉小提琴",
				"她常说【心境由艺术外显】",
				"她喜欢也擅长这样来理解我的情绪",
				"通常还蛮准确的",
			}
		}),

		//多莉房间——————————————————————————————————————————————————————
		//多莉的狗狗画
		new Item("DogPainting_ByDolly",2,new string[][] {
			new string[] {
				"多莉画的狗狗，很早之前了 ",
				"虽然技法相当粗浅",
				"不过却能传达出她内心的感受",
				"如她所说的【心境由艺术外显】",
				"我也从画里了解她很多",
			}
		}),

		//朋友的狗狗画
		new Item("DogPainting_ByFriend",2,new string[][] {
			new string[] {
				"这幅画是多莉的画家朋友送给她的",
				"多莉很喜欢狗狗，但是对狗毛过敏",
				"她只能望而却步",
				"她的朋友画了一幅狗狗画送给了她",
				"多莉收到画的时候很惊喜",
				"写了长长的一封信表达感谢",
				"这幅画看得出来很专业",
				"但很克制技法的展现",
				"甚至可以说有一点多莉的味道",
				"也是一副很温暖的画",
			}
		}),

		//多莉的画
		new Item("Paintings_ByDolly",2,new string[][] {
			new string[] {
				"来到这里之后多莉画了很多画",
				"比起都市，她更喜欢乡村的风景",
				"我也很喜欢她的画",
				"简单的线条、随性的构图",
				"以及极具个人色彩的上色风格",
				"单纯而蓬勃的灵魂",
			}
		}),

		//画架
		new Item("Easel",2,new string[][] {
			new string[] {
				"多莉最喜欢在这里画画",
				"视野开阔，光线充足，无人打扰",
				"我曾躺在旁边看着她画画",
				"那种画面……",
				"让人不想挪开眼睛",
				"堪称绝景",
			}
		},true),

		//收音机
		new Item("RadioInDollySpace",2,new string[][] {
			new string[] {
				"收音机，多莉偶尔休息时会听",
				"客厅也有一个一模一样的",
				"她常听一些音乐频道",
				"多是乡村音乐"
			}
		}),

		//躺椅
		new Item("DeckChair",2,new string[][] {
			new string[] {
				"垫得很舒服的躺椅",
				"我偶尔会躺这看多莉画画",
				"不过大多数时候是多莉躺这儿",
				"小憩也好，看书也好",
				"听收音机放松也好",
			}
		}),
		
		//奖杯陈列柜
		new Item("Medal",2,new string[][] {
			new string[] {
				"大学时期的一些奖牌",
				"【校运动会长跑冠军】",
				"【校运动会游泳400米破纪录】",
				"多莉说她大学时是运动健将",
				"单人项目的奖她大都拿了一遍",
				"而且也是应届【优秀毕业生】",
				"但她还是只有一个朋友",
				"【那位朋友照顾她很多】",
				"她这么说",
				"我也很感谢她的那位朋友",
			}
		}),
		
		//书架
		new Item("Bookrack",2,new string[][] {
			new string[] {
				"多莉的书架",
				"一些关于绘画和艺术的书籍",
				"也有一些食谱，料理相关的书",
				"其他大多是文学作品和电影",
				"这两者她看的很多",
			}
		}),
		
		//秘藏食谱
		new Item("SpecialCookbook",2,new string[][] {
			new string[] {
				"待定"
			}
		}),
		
		//艾文房间——————————————————————————————————————————————————————
		//大书架
		new Item("BigBookrack",2,new string[][] {
			new string[] {
				"我的书架，大部分都是工作相关的书",
				"上面这些是曲谱，偶尔会练习一下",
				"新买了几本园艺方面的书",
				"多莉料理要罗勒草做调料",
				"我就换掉了原来种的矢车菊",
				"好在还留有一部分矢车菊",
				"泡茶喝也挺好的",
				"《》……",
				"我和多莉到现在也没有孩子",
				"多莉的身体不太好",
				"我则担心自己没法成为一个好的父亲",
				"这本书能给我一些力量吧",
				"以后等我们都准备好了",
				"打算领养一个孩子",
			}
		}),

		//小提琴架
		new Item("ViolinStand",2,new string[][] {
			new string[] {
				"一般我会把小提琴放在卧室",
				"晚上会拉给多莉听",
				"偶尔也会带到房间里",
				"我最喜欢克莱斯勒的《爱的忧伤》",
				"小时候母亲经常给我拉这曲子",
				"这曲子给予我慰藉",

			}
		}),

		
		//大床
		new Item("BigBed",2,new string[][] {
			new string[] {
				"无论何时床上都是可以放松的地方",
				"没有枕头，可以随意伸展和翻滚",
				"想怎么躺就怎么躺",
				"我享受那种感觉",
				"不受拘束，宽广而自由",

			}
		}),
		
		//《死亡诗社》海报
		new Item("Poster_DeadPoemSocity",2,new string[][] {
			new string[] {
				"O captain! My captain!",
				"我最爱的电影《死亡诗社》",
				"启发我、鼓舞我很多",
				"Carpe diem",
				"享受现在，活在当下",
				"为自己所爱而活",

			}
		}),
		
		//陈列柜
		new Item("Cabinet",2,new string[][] {
			new string[] {
				"部分是个人荣誉，",
				"其他的是公司荣誉",
				"【稀松平常】——父母的评价",
				"我这辈子大概赶不上他们的成就",
				"还好有多莉安慰我，支持我",
			}
		}),
		
		//窗户
		new Item("Windows",2,new string[][] {
			new string[] {
				"我讨厌封闭黑暗的环境",
				"所以窗户开得比较多",
				"头顶也有智能灯具",
				"这整栋房子都相当复古",
				"也只有我的房间会用到现代科技",
				"哦对，还有那个鱼缸",
			}
		}),
		
		//工作书桌
		new Item("WorkDesk",2,new string[][] {
			new string[] {
				"待定"
			}
		}),

		//手机
		new Item("PhoneOnDesk",2,new string[][] {
			new string[] {

			}
		}),
		
		//模板
		new Item("",2,new string[][] {
			new string[] {

			}
		}),

	};

	//场景道具——脚本字典
	public Dictionary<string, string[]> Item_ScriptDic = new Dictionary<string, string[]>() {

		//烤箱
		{"Oven",new string[]{""
			}
		},
		//咖啡机
		{"CoffeeMaker",new string[]{""
			}
		},

		//双人床
		{"DoubleBed",new string[]{""
			}
		},

		//工作书桌
		{"WorkDesk",new string[]{""
			}
		},
		//大屏幕
		{"ScreenOnWall",new string[]{""
			}
		}
	};

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
	/// 物品章节入口
	/// </summary>
	/// <param name="itemName"></param>
	public void ChooseItemChapter(string itemName) {
		ChapterStart("Item");

		//确认当前场景，缩小检索范围
		switch (ScenesManager.instance.currentSceneName) {

			//客厅
			case ScenesManager.LIVING_ROOM:

				//检索物品名
				switch (itemName) {

					//信封
					case "Letter":
						StartCoroutine(InteractItem_Letter());
						break;

					//禁烟标志
					case "NO_SMOKING_Sign":
						StartCoroutine(InteractItem_NO_SMOKING_Sign());
						break;

					//日历
					case "Calender":
						StartCoroutine(InteractItem_Calender());
						break;

					//留声机
					case "Gramophone":
						StartCoroutine(InteractItem_Gramophone());
						break;

					//鱼缸
					case "FishTank":
						StartCoroutine(InteractItem_FishTank());
						break;

					default:
						break;
				}
				break;

			//厨房
			case ScenesManager.KICTHEN:
				switch (itemName) {

					//厨房的收音机
					case "RadioInKicthen":
						StartCoroutine(InteractItem_RadioInKicthen());
						break;

					//外传版食谱
					case "NormalCookbook":
						StartCoroutine(InteractItem_NormalCookbook());
						break;

					//冰箱
					case "Refrigerator":
						StartCoroutine(InteractItem_Refrigerator());
						break;
					default:
						break;
				}
				break;

			//卧室
			case ScenesManager.BED_ROOM:
				switch (itemName) {

					//夫妻合照
					case "Photo":
						StartCoroutine(InteractItem_Photo());
						break;

					//约法三章
					case "Privity":
						StartCoroutine(InteractItem_Privity());
						break;

					//日记
					case "Dairy":
						StartCoroutine(InteractItem_Dairy());
						break;

					//小提琴
					case "Violin":
						StartCoroutine(InteractItem_Violin());
						break;
					default:
						break;
				}
				break;
			//多莉房间
			case ScenesManager.DOLLY_SPACE:
				switch (itemName) {

					//多莉的狗狗画
					case "DogPainting_ByDolly":
						StartCoroutine(InteractItem_DogPainting_ByDolly());
						break;

					//朋友的狗狗画
					case "DogPainting_ByFriend":
						StartCoroutine(InteractItem_DogPainting_ByFriend());
						break;

					//多莉的其他作品
					case "Paintings_ByDolly":
						StartCoroutine(InteractItem_Paintings_ByDolly());
						break;

					//画架
					case "Easel":
						StartCoroutine(InteractItem_Easel());
						break;

					//多利房间的收音机
					case "RadioInDollySpace":
						StartCoroutine(InteractItem_RadioInDollySpace());
						break;

					//躺椅
					case "DeckChair":
						StartCoroutine(InteractItem_DeckChair());
						break;

					//奖牌陈列柜
					case "Medal":
						StartCoroutine(InteractItem_Medal());
						break;

					//书架
					case "Bookrack":
						StartCoroutine(InteractItem_Bookrack());
						break;

					//秘藏食谱
					case "SpecialCookbook":
						StartCoroutine(InteractItem_SpecialCookbook());
						break;
					default:
						break;
				}
				break;

			//艾文房间
			case ScenesManager.ARVIN_SPACE:
				switch (itemName) {

					//大书架
					case "BigBookrack":
						StartCoroutine(InteractItem_BigBookrack());
						break;

					//小提琴架
					case "ViolinStand":
						StartCoroutine(InteractItem_ViolinStand());
						break;

					//大床
					case "BigBed":
						StartCoroutine(InteractItem_BigBed());
						break;

					//《死亡诗社》海报
					case "Poster_DeadPoemSocity":
						StartCoroutine(InteractItem_Poster_DeadPoemSocity());
						break;

					//陈列柜
					case "Cabinet":
						StartCoroutine(InteractItem_Cabinet());
						break;

					//窗户
					case "Windows":
						StartCoroutine(InteractItem_Windows());
						break;

					//书桌
					case "WorkDesk":
						StartCoroutine(InteractItem_WorkDesk());
						break;

					//桌上手机
					case "PhoneOnDesk":
						StartCoroutine(InteractItem_PhoneOnDesk());
						break;
					default:
						break;
				}
				break;
			
			default:
				break;
		}

		
	}

	/// <summary>
	/// 初始化场景交互
	/// </summary>
	/// <param name="itemName"></param>
	public void InitItemInteract(string itemName) {
		Debug.Log(itemName);
		Item target = GetItemByName(itemName);
		if (target != null) {
			LinesController.instance.itemScripts = target.GetItemLines();
			instance.ChooseItemChapter(itemName);
		}

	}

	/// <summary>
	/// 通过名字搜索物品
	/// </summary>
	/// <param name="itemName"></param>
	/// <returns></returns>
	private Item GetItemByName(string itemName) {
		foreach (Item item in items) {
			if (item.itemName == itemName) {
				return item;
			}
		}
		return null;
	}

	/// <summary>
	/// 通用方法-显示台词
	/// </summary>
	/// <returns></returns>
	private IEnumerator NormalScript_TempMethod() {
		waitSeconds = 0.5f;
		for (; currentPerformance < LinesController.instance.itemScripts.Length; currentPerformance++) {
			yield return StartCoroutine(LinesController.instance.NextLine());
			yield return new WaitForSeconds(waitSeconds);
		}
		ChapterEnd();
	}

	/// <summary>
	/// 章节结束整理
	/// </summary>
	protected override void ChapterEnd() {
		Debug.Log("Item Interact " + PlayerController.instance.interactTarget.name + " End");

		//章节结束flag，跳出章节演出循环
		isChapterEnd = true;

		//重置演出指针
		currentPerformance = 0;
		LinesController.instance.itemCurrentLine = 0;

		//重置章节类型Flag
		isItemChapter = false;

		//章节结束
		GM.instance.OutFromInteractMode();
	}


	//脚本———————————————————————————————————————————————————————
	/// <summary>
	/// 信封-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_Letter() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 禁烟标志-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_NO_SMOKING_Sign() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 日历-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_Calender() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 留声机-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_Gramophone() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 鱼缸-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_FishTank() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 厨房的收音机-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_RadioInKicthen() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 外传版食谱-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_NormalCookbook() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 冰箱-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_Refrigerator() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 夫妻合照-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_Photo() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 约法三章-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_Privity() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 日记-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_Dairy() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 小提琴-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_Violin() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 多莉的狗狗画-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_DogPainting_ByDolly() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 朋友的狗狗画-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_DogPainting_ByFriend() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 多莉的其他作品-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_Paintings_ByDolly() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 画架-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_Easel() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 多莉房间的收音机-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_RadioInDollySpace() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 躺椅-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_DeckChair() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 奖牌陈列架-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_Medal() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 书架-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_Bookrack() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 秘藏版食谱-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_SpecialCookbook() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 大书架-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_BigBookrack() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 小提琴架-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_ViolinStand() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 大床-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_BigBed() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 《死亡诗社》海报-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_Poster_DeadPoemSocity() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 陈列柜-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_Cabinet() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 窗户-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_Windows() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 书桌-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_WorkDesk() {
		yield return StartCoroutine(NormalScript_TempMethod());
	}

	/// <summary>
	/// 桌上手机-交互脚本
	/// </summary>
	/// <returns></returns>
	private IEnumerator InteractItem_PhoneOnDesk() {
		MainStoryScript.instance.ChooseStoryChapter(6);
		ChapterEnd();
		yield return 0;
		
	}

}
