using UnityEngine;

public class ObjectMouseEvent : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Mouse Button Down on Object: " + gameObject.name);
    }
    private void OnMouseUp()
    {
        Debug.Log("Mouse Button Up on Object: " + gameObject.name);
    }
    private void OnMouseEnter()
    {
        Debug.Log("Mouse Entered Object: " + gameObject.name);
    }
    private void OnMouseExit()
    {
        Debug.Log("Mouse Exited Object: " + gameObject.name);
    }
    private void OnMouseOver()
    {
        Debug.Log("Mouse Over Object: " + gameObject.name);
    }
    private void OnMouseDrag()
    {
        Debug.Log("Mouse Dragging Object: " + gameObject.name);
    }
    private void OnMouseUpAsButton()
    {
        Debug.Log("Mouse Up as Button on Object: " + gameObject.name);
    }
}
