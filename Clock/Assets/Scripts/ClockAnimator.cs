using UnityEngine;
using System.Collections;
using System;

public class ClockAnimator : MonoBehaviour {

	public Transform FHours, FMinutes, FSeconds;
	public bool FAnalog = false;

	private const float
		HoursToDegrees = 360f / 12f,
		MinutesToDegrees = 360f / 60f,
		SecondsToDegrees = 360f / 60f;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (FAnalog) {
			TimeSpan timespan = DateTime.Now.TimeOfDay;
			FHours.localRotation =
				Quaternion.Euler(0f,0f,(float)timespan.TotalHours * -HoursToDegrees);
			FMinutes.localRotation =
				Quaternion.Euler(0f,0f,(float)timespan.TotalMinutes * -MinutesToDegrees);
			FSeconds.localRotation =
				Quaternion.Euler(0f,0f,(float)timespan.TotalSeconds * -SecondsToDegrees);
		} else {
			DateTime time = DateTime.Now;
			FHours.localRotation = Quaternion.Euler (0.0f, 0.0f, time.Hour * -HoursToDegrees);
			FMinutes.localRotation = Quaternion.Euler (0.0f, 0.0f, time.Minute * -MinutesToDegrees);
			FSeconds.localRotation = Quaternion.Euler (0.0f, 0.0f, time.Second * -SecondsToDegrees);
		}
	}
}
