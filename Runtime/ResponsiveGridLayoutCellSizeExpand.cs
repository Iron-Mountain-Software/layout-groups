using UnityEngine;
using UnityEngine.UI;

namespace IronMountain.LayoutGroups
{
    [ExecuteAlways]
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(GridLayoutGroup))]
    public class ResponsiveGridLayoutCellSizeExpand : MonoBehaviour
    {
        [SerializeField] private float aspectRatio = 1;
        [SerializeField] private bool forceFitWidth = true;
        [SerializeField] private bool forceFitHeight = true;
        [SerializeField] private LayoutGroup parentLayoutGroup;

        [Header("Cache")]
        private RectTransform _rectTransform;
        private GridLayoutGroup _gridLayoutGroup;
        private RectTransform _parentLayoutGroupRectTransform;

        private RectTransform ParentLayoutGroupRectTransform
        {
            get
            {
                if (!parentLayoutGroup)
                {
                    _parentLayoutGroupRectTransform = null;
                    return null;
                }
                if (!_parentLayoutGroupRectTransform)
                {
                    _parentLayoutGroupRectTransform = parentLayoutGroup.GetComponent<RectTransform>();
                }
                return _parentLayoutGroupRectTransform;
            }
        }

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _gridLayoutGroup = GetComponent<GridLayoutGroup>();
        }

        private void OnEnable()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
        }

        private void OnDisable()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
        }

        private float GetWorkableWidth()
        {
            if (parentLayoutGroup is VerticalLayoutGroup verticalLayoutGroup)
            {
                return ParentLayoutGroupRectTransform.rect.width
                       - verticalLayoutGroup.padding.left
                       - verticalLayoutGroup.padding.right
                       - _gridLayoutGroup.padding.left
                       - _gridLayoutGroup.padding.right
                       - _gridLayoutGroup.spacing.x * (_gridLayoutGroup.constraintCount - 1);
            }
            return _rectTransform.rect.width
                   - _gridLayoutGroup.padding.left
                   - _gridLayoutGroup.padding.right
                   - _gridLayoutGroup.spacing.x * (_gridLayoutGroup.constraintCount - 1);
        }
        
        private float GetWorkableHeight()
        {
            if (parentLayoutGroup is HorizontalLayoutGroup horizontalLayoutGroup)
            {
                return ParentLayoutGroupRectTransform.rect.height
                       - horizontalLayoutGroup.padding.top
                       - horizontalLayoutGroup.padding.bottom
                       - _gridLayoutGroup.padding.top
                       - _gridLayoutGroup.padding.bottom
                       - _gridLayoutGroup.spacing.y * (_gridLayoutGroup.constraintCount - 1);
            }
            return _rectTransform.rect.height
                   - _gridLayoutGroup.padding.top
                   - _gridLayoutGroup.padding.bottom
                   - _gridLayoutGroup.spacing.y * (_gridLayoutGroup.constraintCount - 1);
        }

        private void LateUpdate()
        {
            if (forceFitWidth)
            {
                _rectTransform.offsetMin = new Vector2(0, _rectTransform.offsetMin.y);
                _rectTransform.offsetMax = new Vector2(0, _rectTransform.offsetMax.y);
            }
            if (forceFitHeight)
            {
                _rectTransform.offsetMin = new Vector2(_rectTransform.offsetMin.x, 0);
                _rectTransform.offsetMax = new Vector2(_rectTransform.offsetMax.x, 0);
            }
            switch (_gridLayoutGroup.constraint)
            {
                case GridLayoutGroup.Constraint.FixedColumnCount:
                {
                    float workableWidth = GetWorkableWidth();
                    float elementWidth = workableWidth / _gridLayoutGroup.constraintCount;
                    float elementHeight = elementWidth / aspectRatio;
                    _gridLayoutGroup.cellSize = new Vector2(elementWidth, elementHeight);
                    int rows = transform.childCount / _gridLayoutGroup.constraintCount;
                    if (transform.childCount % _gridLayoutGroup.constraintCount > 0) rows++;
                    _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,
                        elementHeight * rows
                        + _gridLayoutGroup.padding.top
                        + _gridLayoutGroup.padding.bottom
                        + _gridLayoutGroup.spacing.y * Mathf.Max(0, rows - 1));
                    break;
                }
                case GridLayoutGroup.Constraint.FixedRowCount:
                {
                    float workableHeight = GetWorkableHeight();
                    float elementHeight = workableHeight / _gridLayoutGroup.constraintCount;
                    float elementWidth = elementHeight * aspectRatio;
                    _gridLayoutGroup.cellSize = new Vector2(elementWidth, elementHeight);
                    int cols = transform.childCount / _gridLayoutGroup.constraintCount;
                    if (transform.childCount % _gridLayoutGroup.constraintCount > 0) cols++;
                    _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,
                        elementWidth * cols
                        + _gridLayoutGroup.padding.left
                        + _gridLayoutGroup.padding.right
                        + _gridLayoutGroup.spacing.x * Mathf.Max(0, cols - 1));
                    break;
                }
            }
        }
    }
}
