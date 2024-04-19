using UnityEngine;
using UnityEngine.UI;

namespace IronMountain.LayoutGroups
{
    [ExecuteAlways]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(GridLayoutGroup))]
    public class ResponsiveGridLayoutSpacing : MonoBehaviour
    {
        private enum RelationType
        {
            Separate,
            UseMinimum,
            UseMaximum
        }

        [SerializeField] private GridLayoutGroup gridLayoutGroup;
        [SerializeField] private RelationType relationType;
        [SerializeField] [Range(0, 1)] private float screenWidthPercent;
        [SerializeField] [Range(0, 1)] private float screenHeightPercent;
        [SerializeField] private PaddingFlags affectPadding;

        [Header("Cache")] 
        private Vector2Int _screenPixels = Vector2Int.zero;
        private Vector2Int _spacingPixels = Vector2Int.zero;
        
        private void Awake() => OnValidate();

        private void OnValidate()
        {
            if (!gridLayoutGroup) gridLayoutGroup = GetComponent<GridLayoutGroup>();
            RecalculateSpacing();
        }


        private void Update()
        {
            if (_screenPixels.x != Screen.width || _screenPixels.y != Screen.height) RecalculateSpacing();
        }

        private void RecalculateSpacing()
        {
            if (!gridLayoutGroup) return;
            
            _screenPixels.x = Screen.width;
            _screenPixels.y = Screen.height;
            
            _spacingPixels.x = Mathf.RoundToInt(screenWidthPercent * Screen.width);
            _spacingPixels.y = Mathf.RoundToInt(screenHeightPercent * Screen.height);
            
            switch (relationType)
            {
                case RelationType.Separate:
                    break;
                case RelationType.UseMinimum:
                    int minimum = Mathf.Min(_spacingPixels.x, _spacingPixels.y);
                    _spacingPixels.x = minimum;
                    _spacingPixels.y = minimum;
                    break;
                case RelationType.UseMaximum:
                    int maximum = Mathf.Max(_spacingPixels.x, _spacingPixels.y);
                    _spacingPixels.x = maximum;
                    _spacingPixels.y = maximum;
                    break;
            }
            
            gridLayoutGroup.spacing = _spacingPixels;

            if (affectPadding.left) gridLayoutGroup.padding.left = _spacingPixels.x;
            if (affectPadding.right) gridLayoutGroup.padding.right = _spacingPixels.x;
            if (affectPadding.top) gridLayoutGroup.padding.top = _spacingPixels.y;
            if (affectPadding.bottom)  gridLayoutGroup.padding.bottom = _spacingPixels.y;
        }
    }
}