using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
* Project Name: OurSmallWorld
* Create Date: 2020/11/3
* Author: Suz
* Update Record: 
*
*/

public class Temp : MonoBehaviour
{

    void Update()
    {
		if (Input.GetKey(KeyCode.Space)) {
			if (MainStoryScript.instance.currentChapter ==4) {
				SceneManager.LoadScene("LivingRoom");
			}
			if (MainStoryScript.instance.currentChapter == 5) {
				SceneManager.LoadScene("LivingRoom");
			}
			if (MainStoryScript.instance.currentChapter == 6) {
				SceneManager.LoadScene("LivingRoom");
			}
		}
    }
}
