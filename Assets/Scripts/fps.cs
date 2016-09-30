using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class fps : MonoBehaviour
{
	float deltaTime = 0.0f;
	float msec = 0.0f;
	float framePerSecond = 0.0f;
	string fpsText = "";
	DateTime lastUpdate = DateTime.Now;

	void Update()
	{
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
		float newMsec = deltaTime * 1000.0f;
		msec += (newMsec - msec) * 0.1f;
		float newFPS = 1.0f / deltaTime;
		framePerSecond += (newFPS - framePerSecond) * 0.1f;
	}

	void OnGUI()
	{
		DateTime newNow = DateTime.Now;
		var interval = newNow - lastUpdate;
		if (interval.TotalSeconds >= 0.3) {
			lastUpdate = newNow;
			fpsText = string.Format("{0:0.0} ms ({1:0.} fps)", msec, framePerSecond);
		}

		int w = Screen.width, h = Screen.height;
		GUIStyle style = new GUIStyle();
		Rect rect = new Rect(0, 0, w, h * 2 / 100);
		style.alignment = TextAnchor.UpperLeft;
		style.fontSize = h * 3 / 100;
		style.normal.textColor = new Color (1.0f, 0.0f, 0.5f, 1.0f);
		GUI.Label(rect, fpsText, style);
	}
}
