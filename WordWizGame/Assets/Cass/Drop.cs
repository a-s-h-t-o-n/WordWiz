using UnityEngine;
using UnityEngine.EventSystems;

public class Drop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        //DraggableObject draggable = eventData.pointerDrag.GetComponent<DraggableObject>();
        /*if (draggable != null)
        {
            draggable.startPosition = transform.position;
        }*/

        GameObject dropped = eventData.pointerDrag;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
