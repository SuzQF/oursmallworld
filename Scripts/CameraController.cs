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

public class CameraController : MonoBehaviour
{

	public Transform target;

	[SerializeField] private float lerpSpeed = 2.0f;

	[SerializeField] private float minX;
	[SerializeField] private float maxX;
	[SerializeField] private float minY;
	[SerializeField] private float maxY;

	private void Awake() {
		//target = PlayerController.instance.transform;
		
	}

    // Update is called once per frame
    void LateUpdate()
    {
		//transform.position = Vector3.Lerp(transform.position, new Vector3(
		//	Mathf.Clamp(target.position.x, minX, maxX),
		//	Mathf.Clamp(target.position.y, minY, maxY),
		//	transform.position.z),
		//	lerpSpeed * Time.deltaTime);
    }
}
