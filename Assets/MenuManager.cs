using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
	[SerializeField] private GameObject panel;
	[SerializeField] private Button startAloneButton;

	private void Start()
	{
		startAloneButton.onClick.AddListener(
			() =>
			{
				panel.SetActive(false);
			}
			);
	}
}
