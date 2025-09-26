using System;
using UnityEngine;
using UnityEngine.UI;

public class Area : MonoBehaviour
{
    [SerializeField] public float areaWidth = 120f;
    [SerializeField] public float areaHeight = 60f;

    private void Update()
    {
        Debug.DrawLine(transform.position, transform.position + new Vector3(0f, areaHeight, 0f), Color.red);
        Debug.DrawLine(transform.position, transform.position - new Vector3(0f, areaHeight, 0f), Color.red);
        Debug.DrawLine(transform.position, transform.position + new Vector3(areaWidth, 0f, 0f), Color.red);
        Debug.DrawLine(transform.position, transform.position - new Vector3(areaWidth, 0f, 0f), Color.red);
    }
    
    public float areaRadius = 100f;
    public WordOption wordHeld;
    public Sprite associatedSprite;
}
