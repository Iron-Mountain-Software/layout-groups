using UnityEngine;

namespace IronMountain.LayoutGroups
{
    [ExecuteAlways]
    [RequireComponent(typeof(RectTransform))]
    public class ResponsiveRectTransform : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private bool setWidth = false;
        [SerializeField] private bool setHeight = false;
        [SerializeField] [Range(0, 1)] private float screenWidthPercent;
        [SerializeField] [Range(0, 1)] private float screenHeightPercent;

        public bool SetWidth
        {
            get => setWidth;
            set => setWidth = value;
        }
        
        public bool SetHeight
        {
            get => setHeight;
            set => setHeight = value;
        }
        
        public float ScreenWidthPercent
        {
            get => screenWidthPercent;
            set => screenWidthPercent = value;
        }
        
        public float ScreenHeightPercent
        {
            get => screenHeightPercent;
            set => screenHeightPercent = value;
        }

        private void Awake()
        {
            if (!rectTransform) rectTransform = GetComponent<RectTransform>();
        }

        private void OnValidate()
        {
            if (!rectTransform) rectTransform = GetComponent<RectTransform>();
        }

        private void OnGUI()
        {
            if (!rectTransform) return;
            if (setWidth) rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width * screenWidthPercent);
            if (setHeight) rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height * screenHeightPercent);
        }
    }
}
