using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenuSpawner : MonoBehaviour
{

    /// **************
    /// Attach this to canvas
    /// **************

    public static UpgradeMenuSpawner menu;
    public RadialMenu menuPrefab;

    void Awake()
    {
        menu = this;
    }

    public void SpawnMenu(ClickToUpgrade obj)
    {
        //Instantiate radial menu prefab
        RadialMenu newMenu = Instantiate(menuPrefab) as RadialMenu;
        newMenu.transform.SetParent(transform, false); //set menu as child of canvas, worldPositionStays is false such that local orientation of object is kept instead of global orientationS
        newMenu.transform.position = obj.menuSpawnPosition; //spawn the menu where the cannon is
        newMenu.SpawnButtons(obj); //spawn buttons
    }
}
