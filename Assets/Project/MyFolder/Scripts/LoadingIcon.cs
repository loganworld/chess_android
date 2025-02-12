﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingIcon : MonoBehaviour
{
	private int angle = 0;
	private bool isLoading = false;

	public string[] strText;

	public GameObject loading;
	public Text guideText;
	public int speed = 3;
	public enum Direction
	{
		LEFT,
		RIGHT
	}
	public Direction direction = Direction.LEFT;
	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
	}

	void OnEnable()
	{
		isLoading = true;
		StartCoroutine("StartAni");
	}

	void OnDisable()
	{
		isLoading = false;
	}

	void FixedUpdate()
	{
		if (isLoading)
		{
			if (direction == Direction.LEFT)
				angle += speed;
			else
				angle -= speed;
			if (angle >= 360)
			{
				angle = 0;
			}
			loading.transform.localRotation = Quaternion.Euler(0, 0, -angle);
		}
		else
		{
			angle = 0;
		}
	}

	IEnumerator StartAni()
	{
		int index = 0;
		while (true)
		{
			if (guideText != null)
			{
				guideText.text = strText[index % 3];
				index++;
			}
			yield return new WaitForSeconds(1.0f);
		}
	}
}
