using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePanel : MonoBehaviour
{
    public Transform openSidePanelBtn,closeSidePanelBtn;

    public List<IChartToggle> chartToggle = new List<IChartToggle>();

    public void PlayAnimation(string triggerToSet)
    {
        //openSidePanelBtn.gameObject.SetActive(!openSidePanelBtn.gameObject.activeInHierarchy);
        //closeSidePanelBtn.gameObject.SetActive(!closeSidePanelBtn.gameObject.activeInHierarchy);
        var anim = GetComponent<Animator>();
        anim.SetTrigger(triggerToSet);
    }
}
