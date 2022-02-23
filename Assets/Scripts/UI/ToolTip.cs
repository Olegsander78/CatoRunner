using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI View;
    public string TextView;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        View.text = TextView;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        View.text = "";
    }
}
