using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableObject draggableObject = dropped.GetComponent<DraggableObject>();
            draggableObject.parentAfterDrag = transform;
        }
    }
}
