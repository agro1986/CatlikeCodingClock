using UnityEngine;
using System.Collections;
using System;

public class ClockAnimator : MonoBehaviour {

	public Transform hours;
	public Transform minutes;
	public Transform seconds;

	public bool analog = true;

	private const float degreesPerHour = 360.0f / 12.0f;
	private const float degreesPerMinute = 360.0f / 60.0f;
	private const float degreesPerSecond = 360.0f / 60.0f;

	// Use this for initialization
	private void Start () {
	
	}
	
	// Update is called once per frame
	private void Update () {
		if (analog) {
			UpdateAnalog ();
		} else {
			UpdateDigital ();
		}
	}

	private void UpdateAnalog() {
		var timeOfDay = DateTime.Now.TimeOfDay;
		hours.localRotation = Quaternion.Euler (0.0f, 0.0f, -(float)timeOfDay.TotalHours * degreesPerHour);
		minutes.localRotation = Quaternion.Euler (0.0f, 0.0f, -(float)timeOfDay.TotalMinutes * degreesPerMinute);
		seconds.localRotation = Quaternion.Euler (0.0f, 0.0f, -(float)timeOfDay.TotalSeconds * degreesPerSecond);
	}

	private void UpdateDigital() {
		var time = DateTime.Now;
		hours.localRotation = Quaternion.Euler (0.0f, 0.0f, -time.Hour * degreesPerHour);
		minutes.localRotation = Quaternion.Euler (0.0f, 0.0f, -time.Minute * degreesPerMinute);
		seconds.localRotation = Quaternion.Euler (0.0f, 0.0f, -time.Second * degreesPerSecond);
	}
}
