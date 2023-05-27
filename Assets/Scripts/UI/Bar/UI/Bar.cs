using System;
using System.Collections;
using System.Collections.Generic;
using FreakySnake.Bar;
using UnityEngine;

namespace FreakySnake.Bar.UI
{
    public class Bar : Empty
    {
        private BarCanvas _barCanvas;

        private BarCanvas BarCanvas =>
            _barCanvas == null || Application.isPlaying ? GetComponent<BarCanvas>() : _barCanvas;
        
        private void Awake()
        {
            _barCanvas = BarCanvas;
        }
        
        private void OnEnable()
        {
            InstantiateBarCanvas();
        }

        private void InstantiateBarCanvas()
        {
            GameObject barCanvasObject = new GameObject();
            Transform transform = RectTransform.parent;
            _barCanvas = barCanvasObject.AddComponent<BarCanvas>();
            RectTransform.SetParent(barCanvasObject.transform);
            _barCanvas.transform.SetParent(transform);
            _barCanvas.AnchorTransform = transform;
            _barCanvas.UpdateCanvas();
        }
    }
}

