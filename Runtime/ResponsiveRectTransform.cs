using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpellBoundAR.LayoutGroups
{
    [ExecuteAlways]
    [RequireComponent(typeof(RectTransform))]
    public class ResponsiveRectTransform : MonoBehaviour
    {
        [SerializeField] private bool setWidth = false;
        [SerializeField] private bool setHeight = false;
        [SerializeField] [Range(0, 1)] private float screenWidthPercent;
        [SerializeField] [Range(0, 1)] private float screenHeightPercent;

        [Header("Cache")]
        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        private void Update()
        {
            if (!_rectTransform) return;
            if (setWidth) _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width * screenWidthPercent);
            if (setHeight) _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height * screenHeightPercent);
        }
    }
}
