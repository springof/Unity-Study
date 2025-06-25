using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private GameObject backgroundUI;
    [SerializeField] private GameObject handlerUI;

    [SerializeField] private KnightController_Joystick knightController;

    private Vector2 startPos, currPos;

    void Start()
    {
        backgroundUI.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        backgroundUI.SetActive(true);
        backgroundUI.transform.position = eventData.position;
        startPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        currPos = eventData.position;
        Vector2 dragDir = currPos - startPos;

        float maxDist = Mathf.Min(dragDir.magnitude, 60f);
        handlerUI.transform.position = startPos + dragDir.normalized * maxDist;

        knightController.InputJoystick(dragDir.x, dragDir.y);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        knightController.InputJoystick(0, 0);
        handlerUI.transform.localPosition = Vector2.zero;
        backgroundUI.SetActive(false);
    }
}
