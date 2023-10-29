using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SleepRigidbody : MonoBehaviour
{
	private Rigidbody _rb;

	void Start()
	{
		_rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		_rb.sleepThreshold = -1;
		_rb.WakeUp();
	}
}
