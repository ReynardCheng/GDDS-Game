using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToUpgrade : MonoBehaviour {

    /// **************
    /// Attach this to all upgradeable cannons to open up an radial menu for player to choose what to do with the cannon
    /// **************
   
    [System.Serializable]
    public class Action
    {
        //What elements each action button will contain
        public Color color;
        public Sprite iconSprite;
        public string actionName;
    }

    /// **************
    /// List in the inspector
    /// What actions can the player take with this object : a list
    /// **************
    public Action[] options;



    void OnMouseDown() //hELP THE MENU DOESNT SPAWN
    {   
        //When clicked, access UpgradeMenuSpawner which will then load radial menu prefab
        UpgradeMenuSpawner.menu.SpawnMenu(this);
        Debug.Log("Clicked for menu");
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown("space"))
    //    {
    //        print("test");
    //        UpgradeMenuSpawner.menu.SpawnMenu(this);
    //    }
    //}
}
