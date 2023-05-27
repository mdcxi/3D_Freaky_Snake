using System;
using FreakySnake.Bar.UI;
using UnityEngine;
using UnityEngine.UI;

namespace FreakySnake.Bar
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(CanvasScaler))]
    public class BarCanvas : Empty
    {
        public BarMode BarMode => barRenderMode;

        public Transform AnchorTransform
        {
            get => parentTransform;
            set => parentTransform = value;
        }
        
        [SerializeField] private BarMode barRenderMode;

        [SerializeField] private Transform parentTransform;

        [SerializeField] private Camera camera;
        
        private Canvas _canvas;
        private UI.Bar[] _bars;
        private Canvas Canvas => _canvas == null || !Application.isPlaying ? GetComponent<Canvas>() : _canvas;

        private UI.Bar[] Bars => _bars == null || _bars.Length == 0 || !Application.isPlaying
            ? GetComponentsInChildren<UI.Bar>()
            : _bars;
        
        private void Awake()
        {
            camera = camera == null ? Camera.main : camera;
            _canvas = Canvas;
        }

        private void OnEnable()
        {
            DisableEdit();
        }

        private void LateUpdate()
        {
            if (Application.isPlaying)
            {
                LookAtCamera(true);
            }
        }

        public void UpdateCanvas()
        {
            switch (barRenderMode)
            {
                case BarMode.World:
                    RectTransform.SetParent(parentTransform, false);
                    RectTransform.localScale = Vector3.one / 100f;
                    Canvas.renderMode = RenderMode.WorldSpace;
                    Canvas.worldCamera = camera;
                    SizeDelta = Vector2.zero;
                    LocalPosition = Vector3.zero;
                    break;
            }
            ResetBarScale();
        }

        private void ResetBarScale()
        {
            foreach (var bar in Bars)
            {
                bar.LocalScale = Vector3.one;
            }
        }

        public void LookAtCamera(bool condition)
        {
            Vector3 alignment = !condition || camera == null ? Vector3.forward : camera.transform.forward;
            RectTransform.LookAt(RectTransform.position + alignment);
        }

        private void DisableEdit()
        {
            RectTransform.hideFlags = HideFlags.None;
            Canvas.hideFlags = HideFlags.NotEditable;
            hideFlags = HideFlags.None;
        }

        private void OnTransformChildrenChanged()
        {
            ResetBarScale();
        }
    }
}

