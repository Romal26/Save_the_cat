using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
	[SerializeField] private float force;
	private Rigidbody rb;

	// код, исполняемый каждый кадр
	void Update()
	{
		ChooseObject();
		if (rb != null)
			MoveObject();
	}

	private void MoveObject()
	{
		float axis = Input.GetAxis("Vertical");
		if (axis > 0) // W
		{
			Vector3 direction = new Vector3(0, 0, axis * force);
			print(direction);
			rb.AddForce(direction);
		}
		else if (axis < 0) // S
		{
			Vector3 direction = new Vector3(0, 0, -axis * force);
			print(direction);
			rb.AddForce(direction);
		}
	}

	private void ChooseObject()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			bool success = Physics.Raycast(ray, out RaycastHit hit);
			if (success)
			{
				Material mat = hit.transform.GetComponent<MeshRenderer>().material;
				Color color = mat.color;
				color = Color.Lerp(color, Color.white, 0.5f);
				mat.color = color;

				if (hit.transform.TryGetComponent<Rigidbody>(out Rigidbody rb))
					this.rb = rb;
			}
		}
	}
}
