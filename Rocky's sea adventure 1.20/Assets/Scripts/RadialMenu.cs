using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialMenu : MonoBehaviour {
	public RadialButton buttonPrefab; //reference to button prefab
	public RadialButton selected; //Tells you which button is currently selected
	public int radius; //set radius of radial menu (not button, just so you're not confused)

    /// **************
    /// Zis is ze button-spawning method
    /// **************
    public void SpawnButtons(ClickToUpgrade obj) {

        //ClickToUpgrade is the reference (ie obj refers to ClickToUpgrade)

		for(int i = 0; i < obj.options.Length; i++) {
			RadialButton newButton = Instantiate(buttonPrefab) as RadialButton;
			newButton.transform.SetParent(transform, false);

            //Calculation of angle of rotation (360 degrees / no of buttons) for each button placement
            float theta = (2 * Mathf.PI / obj.options.Length) * i; 
			float xPos = Mathf.Sin(theta); //oh look jolly more math
			float yPos = Mathf.Cos(theta);
			newButton.transform.localPosition = new Vector3(xPos, yPos, 0f) * radius; //set position based on calculations made

            //Setting button elements as listed in ClickToUpgrade's options
			newButton.circle.color = obj.options[i].color; 
			newButton.icon.sprite = obj.options[i].iconSprite;
			newButton.actionName = obj.options[i].actionName;
			newButton.menu = this; //reference to where and what is ze menu
		}
	}

	void Update() {
		if(Input.GetMouseButtonUp(0)) {
			if(selected)
				Debug.Log(selected.actionName + " was chosen");
            Destroy(gameObject);

           //This is probably where we insert method reference of spawning of new cannon prefab, or whatever action is to be taken
           // Need to check which action is selected (compare actionName) and thus what is to be done
		}
	}
}