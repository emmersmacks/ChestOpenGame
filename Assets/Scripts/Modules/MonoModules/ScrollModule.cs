using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollModule : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject contentBar;
    [SerializeField] Button panelButton;

    private Camera _camera;
    private bool _move;
    private Vector3 _startPositionTouch;
    private Vector3 _startPositionContent;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _move = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _move = false;
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _startPositionTouch = _camera.ScreenToWorldPoint(Input.mousePosition);
            _startPositionContent = contentBar.transform.position;
        }

        if (Input.GetMouseButton(0) && _move)
        {
            _move = true;
            var currentTouch = _camera.ScreenToWorldPoint(Input.mousePosition);
            var distance = Vector3.Distance(new Vector3(_startPositionTouch.x, 0, 0), new Vector3(currentTouch.x, 0, 0));
            if (currentTouch.x < _startPositionTouch.x)
            {
                contentBar.transform.position = new Vector3(_startPositionContent.x - distance, _startPositionContent.y, 0);
            }
            else
            {
                contentBar.transform.position = new Vector3(_startPositionContent.x + distance, _startPositionContent.y, 0);
            }
        }

        if(Input.GetMouseButtonUp(1))
        {
            _move = false;
        }
    }
}
