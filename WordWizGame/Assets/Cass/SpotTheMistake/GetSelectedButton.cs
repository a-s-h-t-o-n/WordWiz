using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GetSelectedButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    SpotTheMistake spotTheMistake;

    public void OnDeselect(BaseEventData eventData)
    {
        spotTheMistake.selectedWord = null;
    }

    public void OnSelect(BaseEventData eventData)
    {
        spotTheMistake.selectedWord = this.gameObject.GetComponent<Button>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spotTheMistake = FindFirstObjectByType<SpotTheMistake>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
