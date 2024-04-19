using UnityEngine;
using UnityEngine.UI;

namespace IronMountain.LayoutGroups
{
    [ExecuteAlways]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(HorizontalLayoutGroup))]
    public class ResponsiveHorizontalLayoutSpacing : MonoBehaviour
    {
        [SerializeField] private HorizontalLayoutGroup horizontalLayoutGroup;
        [SerializeField] [Range(0, 1)] private float screenWidthPercent;
        [SerializeField] private PaddingFlags affectPadding;

        [Header("Cache")] 
        private int _screenPixels;
        private int _spacingPixels;
        
        private void Awake() => OnValidate();

        private void OnValidate()
        {
            if (!horizontalLayoutGroup) horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
            RecalculateSpacing();
        }

        private void Update()
        {
            if (_screenPixels != Screen.width) RecalculateSpacing();
        }

        private void RecalculateSpacing()
        {
            if (!horizontalLayoutGroup) return;
            
            _screenPixels = Screen.width;
            _spacingPixels = Mathf.RoundToInt(screenWidthPercent * Screen.width);

            horizontalLayoutGroup.spacing = _spacingPixels;
            
            if (affectPadding.left) horizontalLayoutGroup.padding.left = _spacingPixels;
            if (affectPadding.right) horizontalLayoutGroup.padding.right = _spacingPixels;
            if (affectPadding.top) horizontalLayoutGroup.padding.top = _spacingPixels;
            if (affectPadding.bottom)  horizontalLayoutGroup.padding.bottom = _spacingPixels;
        }
    }
}