using UnityEngine;
using UnityEngine.EventSystems;

namespace FreakySnake.Control
{
    public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        public float dragSpeed = 6f;
    
        private float _screen;
    
        private Vector2 _centerPos;
    
        private float _horizontal;
        private float _vertical;
        
        public Vector2 CenterPos
        {
            set => _centerPos = value;
        }
    
        public float Horizontal =>_horizontal;
        public float Vertical => _vertical;

        private void Start()
        {
            _screen = 1f * Screen.width / 40; 
            _centerPos = GetComponent<RectTransform>().position;
        }
        
        /// <summary>
        /// Tính toán giá trị _horizontal và _vertical
        /// </summary>
        /// <param name="pos"></param>
        private void GetAxis(Vector2 pos)
        { 
            var diff = pos - _centerPos;
            var distance = diff.magnitude;
            
            if (distance > _screen)
            {
                pos = _centerPos + diff / distance * _screen;
            }
            
            GetComponent<RectTransform>().position = pos;
            var move = pos - _centerPos;
            _horizontal = move.x;
            _vertical = move.y;
        }
        
        /// <summary>
        /// Xác định vị trí mới khi kéo joystick,
        /// và gọi GetAxis() để cập nhật giá trị _horizontal và _vertical.
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData)
        {
            var newPos = new Vector2(eventData.position.x - 20f, eventData.position.y - 20f);
            GetAxis(newPos);
        }
    
        /// <summary>
        /// Đưa giá trị của _horizontal và vertical về 0.
        /// Đưa joystick về vị trí ban đầu khi ngừng kéo.
        /// </summary>
        /// <param name="eventData"></param>
        public void OnEndDrag(PointerEventData eventData)
        {
            GetComponent<RectTransform>().position = _centerPos;
            GetAxis(_centerPos);
        }
    }
}
