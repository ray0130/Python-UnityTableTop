using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCard : MonoBehaviour {

	[SerializeField] private GameObject Card_Back;

	void OnMouseDown()
	{
		if(Card_Back.activeSelf)
			{
			Card_Back.SetActive (true);
			}
	}
}
