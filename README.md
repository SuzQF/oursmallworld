# oursmallworld
这是个基于Unity的文字冒险游戏。

游戏形式类似去除了战斗模式的《十三机兵防卫圈》。

玩家将通过男主人公的视角经历与妻子的田园生活。

不过游戏还未做完。

代码部分，我意在构建一个泛用的游戏演出控制模块，由旁白、台词、角色、动画、音效、场景切换等模块组成。

通过各模块专项负责一部分的功能实现与控制，再由演出脚本实现整体演出流程的控制。

游戏功能

游戏控制模块：负责游戏操作权控制（游戏中玩家会在特殊时刻无法操作角色），与游戏启动、结束相关功能的控制；游戏存读档（未实现）。

主角控制模块：负责接收玩家在游戏主要流程内能对游戏内角色发出的指令，以及对应的指令处理。主要是主角移动和与游戏内NPC、场景等进行交互。

脚本：包括游戏主要剧情、人物交互、场景物体交互等三大部分的演出脚本，直接操控下属模块，负责游戏内的一切演出。

台词、旁白模块：在脚本进行时，控制游戏中所有台词、旁白从显示到隐藏的全过程，包括台词跟随角色、台词更新、及台词、旁白出现和隐藏的渐变视效控制。

角色控制模块：在脚本进行时，对游戏内角色的行为进行控制的脚本，包括初始化角色位置、角色转向、角色移动等功能。

场景转换模块：负责切换场景、不同场景间的切换视效控制和场景预设等功能。在脚本进行时，更换场景背景或切换场景。

摄像机控制模块：负责游戏全流程中的摄像机移动、跟随、放缩等功能，包括脚本进行时。

音效音乐模块：负责游戏全流程中的BGM和音效的播放、暂停、切换等功能，包括脚本进行时。

动画控制模块（未实现）：负责游戏全流程中的角色动画和其他动画的播放和切换等功能，包括脚本进行时。

