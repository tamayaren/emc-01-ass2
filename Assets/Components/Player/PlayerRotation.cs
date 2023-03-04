using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
// ReSharper disable All

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float angleOffset = -90f;
    public bool isMouseLooking = true;

    // Update is called once per frame
    void Update()
    {
        if (!isMouseLooking) return;
        if (Camera.current == null) return;
        Vector3 mousePosition = Input.mousePosition;
        Vector3 objectPosition = Camera.current.WorldToScreenPoint(this.transform.position);
        
        mousePosition.z = Camera.current.transform.position.z;
        mousePosition.x = mousePosition.x - objectPosition.x;
        mousePosition.y = mousePosition.y - objectPosition.y;

        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + angleOffset));
    }
}
