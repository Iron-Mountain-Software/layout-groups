using UnityEngine;

namespace IronMountain.LayoutGroups
{
    [ExecuteAlways]
    [RequireComponent(typeof(RectTransform))]
    public class ResponsiveRectTransform : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private bool setWidth;
        [SerializeField] private bool setHeight;
        [SerializeField] [Range(0, 1)] private float screenWidthPercent;
        [SerializeField] [Range(0, 1)] private float screenHeightPercent;

        [Header("Cache")] 
        private Vector2Int _screenPixels = Vector2Int.zero;
        
        public bool SetWidth
        {
            get => setWidth;
            set
            {
                setWidth = value;
                Resize();
            }
        }

        public bool SetHeight
        {
            get => setHeight;
            set
            {
                setHeight = value;
                Resize();
            }
        }

        public float ScreenWidthPercent
        {
            get => screenWidthPercent;
            set
            {
                screenWidthPercent = value;
                Resize();
            }
        }

        public float ScreenHeightPercent
        {
            get => screenHeightPercent;
            set
            {
                screenHeightPercent = value;
                Resize();
            }
        }
        
        private void OnValidate()
        {
            if (!rectTransform) rectTransform = GetComponent<RectTransform>();
            Resize();
        }

        private void Awake() => OnValidate();
        private void OnEnable() => OnValidate();
        private void Start() => OnValidate();

        private void Update()
        {
            if (_screenPixels.x != Screen.width || _screenPixels.y != Screen.height) Resize();
        }
        
        private void Resize()
        {
            if (!rectTransform) return;
            _screenPixels.x = Screen.width;
            _screenPixels.y = Screen.height;
            if (setWidth) rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width * screenWidthPercent);
            if (setHeight) rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height * screenHeightPercent);
        }
    }
}
