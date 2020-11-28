using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Project Name: OurSmallWorld
* Create Date: 2020/11/3
* Author: Suz
* Update Record: 
* 11/18	明确了RoleController定位，功能精简优化，去掉了多余的事件相关模块
* 11/20	添加了人物朝向常量，便于设置人物朝向，关于根据坐标自动设置朝向的想法待定
*/

public class RoleController : MonoBehaviour {
	//移动速度
	public static float moveSpeed = 5.0f;

	//由导演传来的移动指令信息
	private bool isMoveOrder;

	//人物朝向常量（人物所有图片默认向右）
	public const bool RIGHT = false;
	public const bool LEFT = true;

	//移动目标位置
	private Vector3 goalPosition;

	// Update is called once per frame
	void FixedUpdate() {
		if (isMoveOrder && transform.position != goalPosition) {
			Move();
		}
		else {
			isMoveOrder = false;
			moveSpeed = 5.0f;
		}
	}

	/// <summary>
	/// 角色持续移动方法
	/// </summary>
	private void Move() {
		transform.position = Vector3.Lerp(transform.position, goalPosition, moveSpeed * Time.deltaTime);
	}

	/// <summary>
	/// 角色位置设置
	/// </summary>
	/// <param name="position"></param>
	public void SetRolePosition(Vector3 position) {
		transform.position = position;
	}

	/// <summary>
	/// 角色转身
	/// </summary>
	/// <param name="turnDirection">true为左 false为右 </param>
	public void RoleTurn(bool turnDirection) {
		GetComponent<SpriteRenderer>().flipX = turnDirection;
	}

	/// <summary>
	/// 角色移动
	/// </summary>
	/// <param name="goalPosition"></param>
	public void RoleMove(Vector3 goalPosition, float speed = 5.0f) {
		this.goalPosition = goalPosition;
		isMoveOrder = true;
		moveSpeed = speed;
	}

	/// <summary>
	/// 角色停止移动
	/// </summary>
	public void RoleStop() {
		isMoveOrder = false;
		goalPosition = transform.position;
		PlayerController.instance.rg.velocity = new Vector2(0, 0);
	}
}
	