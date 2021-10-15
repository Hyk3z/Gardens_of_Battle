using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class alarmscript : MonoBehaviour {
	public OgreScript[] ogresToWake;
	public KrawScript[] krawwsToWake;
	public PrincessScript[] PrincessesToWake;
	public bool alarm;
	public UnityEvent alarmEvent;
	public float DelayTime;
	public UnityEvent DelayedEvent;
	bool used;
	// Use this for initialization
	public void RingAlarm()
	{
		alarmEvent.Invoke();
	}

	public void TurnReusable()
	{
		used = false;
	}

    public void OnTriggerEnter(Collider other)
    {
		if (used)
		{
			return;
		}
		if (other.CompareTag("Player") || other.CompareTag("Griffin"))
		{
			foreach (var item in ogresToWake)
			{
				if (item.gameObject.activeInHierarchy)
				{
					item.Detect();
				}
				
			}
			foreach (var item in krawwsToWake)
			{
				if (item.gameObject.activeInHierarchy)
				{
					item.detectou = true;
				}
			}
			foreach (var item in PrincessesToWake)
			{
				if (item && item.gameObject.activeInHierarchy)
				{
					item.detectou = true;
				}
			}
			used = true;
			alarmEvent.Invoke();
			if (DelayTime > 0)
			{
				StartCoroutine(DelayEventInvoke());
			}

		}
		
	}

	IEnumerator DelayEventInvoke()
	{
		yield return new WaitForSeconds(DelayTime);
		DelayedEvent.Invoke();
		yield return null;
	}

}
