using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GetSelectedButton : MonoBehaviour, ISelectHandler
{
    SpotTheMistake spotTheMistake;
    GameObject lastSelected;

    /*public void OnDeselect(BaseEventData eventData)
    {
        spotTheMistake.selectedWord = null;
    }*/

    public void OnSelect(BaseEventData eventData)
    {
        spotTheMistake.selectedWord = this.gameObject.GetComponent<Button>();
        lastSelected = this.gameObject;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spotTheMistake = FindFirstObjectByType<SpotTheMistake>();
    }

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == null && lastSelected != null)
        {
            EventSystem.current.SetSelectedGameObject(lastSelected);
        }
    }

}
