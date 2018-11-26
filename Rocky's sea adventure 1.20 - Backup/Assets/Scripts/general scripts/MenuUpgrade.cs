using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUpgrade : MonoBehaviour {


	public void TurnOffMenu(GameObject menu)
	{
		// turn the menu off
		Destroy(menu);
		RaycastToWorld.menuSpawned = false;
	}
}
