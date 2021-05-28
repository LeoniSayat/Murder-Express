using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipTrigger : MonoBehaviour
{
    public string header;
    public string content;

    private void OnMouseEnter()
    {
        Tooltip.current.SetAndShowToolTip(header, content);
    }

    private void OnMouseExit()
    {
        Tooltip.current.HideToolTip();
    }
}
