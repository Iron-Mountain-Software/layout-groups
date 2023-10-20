using UnityEngine;
using UnityEngine.UI;

namespace IronMountain.LayoutGroups
{
    [ExecuteAlways]
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(GridLayoutGroup))]
    public class ResponsiveGridLayoutCellSizeFit : MonoBehaviour
    {
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
                    int rowCount = transform.childCount / _gridLayoutGroup.constraintCount;
                    if (transform.childCount % _gridLayoutGroup.constraintCount > 0) rowCount++;
                    if (rowCount <= 0) rowCount = 1;
                    float workableWidth = _rectTransform.rect.width
                                          - _gridLayoutGroup.padding.left
                                          - _gridLayoutGroup.padding.right
                                          - _gridLayoutGroup.spacing.x * (_gridLayoutGroup.constraintCount - 1);
                    float workableHeight = _rectTransform.rect.height
                                           - _gridLayoutGroup.padding.top
                                           - _gridLayoutGroup.padding.bottom
                                           - _gridLayoutGroup.spacing.y * (rowCount - 1);
                    _gridLayoutGroup.cellSize = new Vector2(
                        workableWidth / _gridLayoutGroup.constraintCount,
                        workableHeight / rowCount);
                    break;
                }
                case GridLayoutGroup.Constraint.FixedRowCount:
                {
                    int columnCount = transform.childCount / _gridLayoutGroup.constraintCount;
                    if (transform.childCount % _gridLayoutGroup.constraintCount > 0) columnCount++;
                    if (columnCount <= 0) columnCount = 1;
                    float workableWidth = _rectTransform.rect.width
                                          - _gridLayoutGroup.padding.left
                                          - _gridLayoutGroup.padding.right
                                          - _gridLayoutGroup.spacing.x * (columnCount - 1);
                    float workableHeight = _rectTransform.rect.height
                                           - _gridLayoutGroup.padding.top
                                           - _gridLayoutGroup.padding.bottom
                                           - _gridLayoutGroup.spacing.y * (_gridLayoutGroup.constraintCount - 1);
                    _gridLayoutGroup.cellSize = new Vector2(
                        workableWidth / columnCount,
                        workableHeight / _gridLayoutGroup.constraintCount);
                    break;
                }
            }
        }
    }
}
