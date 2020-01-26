using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizePanel : MonoBehaviour
{
    public SelectStickButton[] selectStickButtonList;
    
    public void UnSelectAllButtons()
    {
        foreach (SelectStickButton selectStickButton in selectStickButtonList)
        {
            selectStickButton.isSelectedObj.SetActive(false);
        }
    }

    public void UnlockRandom()
    {
        List<SelectStickButton> unboughtSticks = new List<SelectStickButton>();
        foreach (SelectStickButton selectStickButton in selectStickButtonList)
        {
            if (!selectStickButton.interactable)
            {
                unboughtSticks.Add(selectStickButton);
            }
        }

        int randomInt = Random.Range(0, unboughtSticks.Count);
        
        unboughtSticks[randomInt].UnlockStick();

    }
    
}
