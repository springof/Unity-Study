﻿using System.Collections;
using UnityEngine;

public class InterationEvent : MonoBehaviour
{
    public enum InteractionType { SIGN, DOOR, NPC, MENU }
    public InteractionType type;

    public GameObject popUp;

    public FadeRoutine fade;

    public GameObject map;
    public GameObject house;

    private bool isHouse;

    public Vector3 inDoorPos;
    public Vector3 outDoorPos;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Interaction(other.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popUp.SetActive(false);
        }
    }

    void Interaction(Transform player)
    {
        switch (type)
        {
            case InteractionType.SIGN:
                popUp.SetActive(true);
                break;
            case InteractionType.DOOR:
                StartCoroutine(DoorRoutine(player));
                break;
            case InteractionType.NPC:
                popUp.SetActive(true);
                break;
        }
    }

    IEnumerator DoorRoutine(Transform player)
    {
        yield return StartCoroutine(fade.Fade(1f, Color.black, true));

        map.SetActive(isHouse);
        house.SetActive(!isHouse);

        var pos = isHouse ? outDoorPos : inDoorPos;
        player.transform.position = pos;

        isHouse = !isHouse;

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(fade.Fade(1f, Color.black, false));
    }
}
