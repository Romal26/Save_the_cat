using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_meow : MonoBehaviour
{
	[SerializeField] AudioSource catMeow;
	[SerializeField] Rigidbody catRb;

	bool stop = false;

	void Update()
	{
		if (stop)
			return;

		if (catRb.velocity.y < -10f)
		{
			stop = true;
			catMeow.Play();
		}

	}
}
