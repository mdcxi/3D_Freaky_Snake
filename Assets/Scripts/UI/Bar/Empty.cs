using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FreakySnake.Bar
{
    [RequireComponent(typeof(RectTransform))]
    public class Empty : MonoBehaviour
    {
        private GameObject _gameObject;
        private RectTransform _rectTransform;

        protected GameObject GameObject => _gameObject == null || !Application.isPlaying ? gameObject : _gameObject;

        protected RectTransform RectTransform =>
            _rectTransform == null || !Application.isPlaying ? GetComponent<RectTransform>() : _rectTransform;
        
        public bool isActive
        {
            get { return GameObject.activeInHierarchy;  }
            set {GameObject.SetActive(value);}
        }

        public Vector3 Position
        {
            get { return RectTransform.position; }
            set { RectTransform.position = value; }
        }

        public Vector3 LocalPosition
        {
            get
            {
                return RectTransform.localPosition;
            }

            set
            {
                RectTransform.localPosition = value;
            }
        }

        public Vector3 LocalScale
        {
            get
            {
                return RectTransform.localScale;
            }

            set
            {
                RectTransform.localScale = value;
            }
        }

        public Vector2 SizeDelta
        {
            get
            {
                return RectTransform.sizeDelta;
            }

            set
            {
                RectTransform.sizeDelta = value;
            }
        }

        public Vector2 AnchorMin
        {
            get
            {
                return RectTransform.anchorMin;
            }
        }
        
        public Vector2 AnchorMax
        {
            get
            {
                return RectTransform.anchorMax;
            }
        }

        public float Width
        {
            get
            {
                return RectTransform.rect.width;
            }
        }

        public float Height
        {
            get
            {
                return RectTransform.rect.height;
            }
        }

        private void Awake()
        {
            _gameObject = GameObject;
            _rectTransform = RectTransform;
        }
    }
}

