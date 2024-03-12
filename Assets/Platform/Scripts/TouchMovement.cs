using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Platformer
{
    public class TouchMovement : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        private Vector2 _delta;
        public Vector2 Delta => _delta;

        [Tooltip("Mobile controller that will be given the input.")]
        public PlayerController Controller;

        private RectTransform _joystickBackground;
        private RectTransform _joystickHandle;

        private bool _isDragging = false;

        private void Start()
        {
            _joystickBackground = GetComponent<RectTransform>();
            _joystickHandle = _joystickBackground.GetChild(0).GetComponent<RectTransform>(); // Assuming the joystick handle is the first child
        }

        public void OnDrag(PointerEventData eventData)
        {
            _isDragging = true;
            ProcessTouch(eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _isDragging = false;
            _delta = Vector2.zero;
            if (Controller != null)
                Controller.HasMovement = false;
        }

        private void ProcessTouch(PointerEventData eventData)
        {
            Vector2 backgroundCenter = _joystickBackground.position;
            Vector2 joystickDirection = (eventData.position - backgroundCenter).normalized;

            float handleRadius = _joystickBackground.rect.width * 0.5f;

            // Limit the handle within the background
            float handleDistance = Vector2.Distance(eventData.position, backgroundCenter);
            float limitedRadius = Mathf.Min(handleDistance, handleRadius);
            Vector2 limitedJoystickDirection = joystickDirection * limitedRadius;

            _joystickHandle.position = backgroundCenter + limitedJoystickDirection;

            _delta = limitedJoystickDirection / handleRadius;

            if (Controller != null)
            {
                Controller.HasMovement = _isDragging;
                Controller.Movement = _delta;
            }
        }
    }
}
