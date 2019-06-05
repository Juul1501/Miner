using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzleController : MonoBehaviour
{
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    void Start()
    {
        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
    }

    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();

            m_Raycaster.Raycast(m_PointerEventData, results);
            if (results[0].gameObject.CompareTag("piece"))
            {
                MovePiece(results[0].gameObject, Input.mousePosition);
            }
        }
        foreach (var touch in Input.touches)
        {
            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = touch.position;
            List<RaycastResult> results = new List<RaycastResult>();

            m_Raycaster.Raycast(m_PointerEventData, results);
            if (results[0].gameObject.CompareTag("piece"))
            {
                MovePiece(results[0].gameObject, touch.position);
            }
        }
    }

    void MovePiece(GameObject piece, Vector3 position)
    {
        piece.transform.position = position;
    }
}
