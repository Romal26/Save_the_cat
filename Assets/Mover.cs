using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Mover : MonoBehaviour
{
	[SerializeField] private float force;
	[SerializeField] private float minValue;

	private Rigidbody rb;
	private int curObj;
	GameObject[] objects;

	Color startColor;
	private float startPos = -1;

	private void Start()
	{
		objects = GameObject.FindGameObjectsWithTag("log");

		startColor = objects[0].transform.GetComponent<MeshRenderer>().material.color;
	}

	// код, исполняемый каждый кадр
	void Update()
	{
		if (rb != null && Math.Abs(rb.position.z) > 2)
		{
			this.rb = null;
			curObj = -1;
			startPos = -1;
		}

		MoveObject();
		ChooseObject();
	}

	private void MoveObject()
	{
		if (rb == null)
			return;

		if (startPos == -1 && (Input.GetMouseButton(0) || Input.touchCount != 0))
		{
			startPos = GetPos();
		}

		if (Input.GetMouseButton(0) || Input.touchCount != 0)
		{
			var delta = startPos - GetPos();

			//if (Math.Abs(delta) > minValue)
			{
				rb.velocity = new Vector3(0, 0, force * -delta);
			}

			startPos = GetPos();
		}
	}

	private float GetPos()
	{
		return Input.touchSupported ? Input.GetTouch(0).position.y : Input.mousePosition.y;
	}

	private void ChooseObject()
	{
		if (Input.GetMouseButtonDown(0) || (Input.touchCount != 0 && Input.GetTouch(0).phase == TouchPhase.Began))
		{
			foreach (var item in objects)
			{
				Material mat = item.transform.GetComponent<MeshRenderer>().material;
				mat.color = startColor;
			}

			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			bool success = Physics.Raycast(ray, out RaycastHit hit);

			if (success)
			{
				if (hit.transform.tag == "cat")
					return;

				Material mat = hit.transform.GetComponent<MeshRenderer>().material;
				mat.color = Color.Lerp(startColor, Color.white, 0.5f);

				if (hit.transform.TryGetComponent(out Rigidbody rb))
				{
					this.rb = rb;
					curObj = hit.transform.GetInstanceID();
				}
				else
				{
					this.rb = null;
					curObj = -1;
					startPos = -1;
				}
			}
		}
	}
}
