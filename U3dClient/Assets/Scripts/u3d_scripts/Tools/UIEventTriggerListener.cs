using UnityEngine;
using UnityEngine.EventSystems;

namespace mmowar
{
    /// <summary>
    /// 模仿NGUI实现的
    /// </summary>
    public class UIEventTriggerListener : EventTrigger
{

    public delegate void VoidDelegate(PointerEventData eventData);
    public delegate void VoidBaseEventDelegate(BaseEventData baseED);
    public event VoidDelegate onClick;
    public VoidDelegate onDown;
    public VoidDelegate onEnter;
    public VoidDelegate onExit;
    public VoidDelegate onUp;
    public VoidBaseEventDelegate onSelect;
    public VoidBaseEventDelegate onUpdateSelect;

    static public UIEventTriggerListener Get(GameObject go)
    {
        UIEventTriggerListener listener = go.GetComponent<UIEventTriggerListener>();
        if (listener == null) listener = go.AddComponent<UIEventTriggerListener>();
        return listener;
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (onClick != null) onClick(eventData);
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        if (onDown != null) onDown(eventData);
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (onEnter != null) onEnter(eventData);
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (onExit != null) onExit(eventData);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        if (onUp != null) onUp(eventData);
    }
    public override void OnSelect(BaseEventData eventData)
    {
        if (onSelect != null) onSelect(eventData);
    }
    public override void OnUpdateSelected(BaseEventData eventData)
    {
        if (onUpdateSelect != null) onUpdateSelect(eventData);
    }
}

}