using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public event Action PressInput;
    public event Action UnPressInput;    
    public event Action<RotationDirection> SwipeInput;

    private float _timeTouchEnded;
    private float _displayTime = 0.45f;
    private Touch _touch;
    private TouchPhase _touchPhase;
    public static InputManager instance;
    
    private void Awake()
    {
        instance ??= this;
    }

    private void Update()
    {
        if(Input.touchCount == 1)
        {
            _touch = Input.GetTouch(0);
            
            switch(_touch.phase)
            {
                case TouchPhase.Stationary:
                    if(_touchPhase != TouchPhase.Stationary && Time.time - _timeTouchEnded > _displayTime)
                    {
                        _touchPhase = _touch.phase;
                        PressInput?.Invoke();
                    }
                    break;
                case TouchPhase.Ended:
                    _touchPhase = _touch.phase;
                    _timeTouchEnded = Time.time;
                    UnPressInput?.Invoke();
                    break;
                case TouchPhase.Began:
                    _touchPhase = _touch.phase;
                    _timeTouchEnded = Time.time;
                    break;
                case TouchPhase.Moved:
                    if(_touchPhase != TouchPhase.Moved && Time.time - _timeTouchEnded > _displayTime)
                    {
                        _touchPhase = _touch.phase;
                        PressInput?.Invoke();
                    }
                    break;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        int minimumSwipePosition = Screen.width / 4;
        if(Vector2.Distance(eventData.pressPosition, eventData.position) < minimumSwipePosition)
        {
            return;
        }
        
        Vector3 dragVectorDirection = (eventData.position - eventData.pressPosition).normalized;

        SwipeInput?.Invoke(GetDragDirection(dragVectorDirection));
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    private RotationDirection GetDragDirection(Vector3 dragVector)
    {
        float positiveX = Mathf.Abs(dragVector.x);
        float positiveY = Mathf.Abs(dragVector.y);
        RotationDirection draggedDir = RotationDirection.None;
        if (positiveX > positiveY)
        {
            draggedDir = (dragVector.x > 0) ? RotationDirection.Right : RotationDirection.Left;
        }

        return draggedDir;
    }
}

public enum RotationDirection
{
    Left,
    Right, 
    None
}
