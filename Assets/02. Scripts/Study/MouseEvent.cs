using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    private void Update()
    {
        // MouseClickEvent();
    }
    private void MouseClickEvent()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Debug.Log("Mouse Button Down");
        }
        if (Input.GetMouseButton(0)) 
        {
            Debug.Log("Mouse Button");
        }
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse Button Up");
        }
    }
}
