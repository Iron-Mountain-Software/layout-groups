using UnityEngine;
using UnityEngine.UI;

namespace IronMountain.LayoutGroups
{
    [ExecuteAlways]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(VerticalLayoutGroup))]
    public class ResponsiveVerticalLayoutSpacing : MonoBehaviour
    {
        [SerializeField] private VerticalLayoutGroup verticalLayoutGroup;
        [SerializeField] [Range(0, 1)] private float screenHeightPercent;
        [SerializeField] private PaddingFlags affectPadding;

        [Header("Cache")] 
        private int _screenPixels;
        private int _spacingPixels;
        
        private void Awake() => OnValidate();

        private void OnValidate()
        {
            if (!verticalLayoutGroup) verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
            RecalculateSpacing();
        }

        private void Update()
        {
            if (_screenPixels != Screen.height) RecalculateSpacing();
        }

        private void RecalculateSpacing()
        {
            if (!verticalLayoutGroup) return;
            
            _screenPixels = Screen.height;
            _spacingPixels = Mathf.RoundToInt(screenHeightPercent * Screen.height);

            verticalLayoutGroup.spacing = _spacingPixels;
            
            if (affectPadding.left) verticalLayoutGroup.padding.left = _spacingPixels;
            if (affectPadding.right) verticalLayoutGroup.padding.right = _spacingPixels;
            if (affectPadding.top) verticalLayoutGroup.padding.top = _spacingPixels;
            if (affectPadding.bottom)  verticalLayoutGroup.padding.bottom = _spacingPixels;
        }
    }
}