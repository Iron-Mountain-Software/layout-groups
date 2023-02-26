using UnityEngine;
using UnityEngine.UI;

namespace SpellBoundAR.LayoutGroups
{
    [ExecuteAlways]
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(GridLayoutGroup))]
    public class ResponsiveGridLayoutCellSizeExpand : MonoBehaviour
    {
        [SerializeField] private float aspectRatio = 1;
    
        [Header("Cache")]
        private RectTransform _rectTransform;
        private GridLayoutGroup _gridLayoutGroup;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _gridLayoutGroup = GetComponent<GridLayoutGroup>();
        }

        private void LateUpdate()
        {
            switch (_gridLayoutGroup.constraint)
            {
                case GridLayoutGroup.Constraint.FixedColumnCount:
                {
                    _rectTransform.offsetMin = new Vector2(0, _rectTransform.offsetMin.y);
                    _rectTransform.offsetMax = new Vector2(0, _rectTransform.offsetMax.y);
                    float workableWidth = _rectTransform.rect.width
                                          - _gridLayoutGroup.padding.left
                                          - _gridLayoutGroup.padding.right
                                          - _gridLayoutGroup.spacing.x * (_gridLayoutGroup.constraintCount - 1);
                    float elementWidth = workableWidth / _gridLayoutGroup.constraintCount;
                    float elementHeight = elementWidth / aspectRatio;
                    _gridLayoutGroup.cellSize = new Vector2(elementWidth, elementHeight);
                    break;
                }
                case GridLayoutGroup.Constraint.FixedRowCount:
                {
                    _rectTransform.offsetMin = new Vector2(_rectTransform.offsetMin.x, 0);
                    _rectTransform.offsetMax = new Vector2(_rectTransform.offsetMax.x, 0);
                    float workableHeight = _rectTransform.rect.height
                                           - _gridLayoutGroup.padding.top
                                           - _gridLayoutGroup.padding.bottom
                                           - _gridLayoutGroup.spacing.y * (_gridLayoutGroup.constraintCount - 1);
                    float elementHeight = workableHeight / _gridLayoutGroup.constraintCount;
                    float elementWidth = elementHeight * aspectRatio;
                    _gridLayoutGroup.cellSize = new Vector2(elementWidth, elementHeight);
                    break;
                }
            }
        }
    }
}
