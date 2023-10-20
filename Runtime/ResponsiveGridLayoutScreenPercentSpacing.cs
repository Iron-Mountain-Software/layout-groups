using UnityEngine;
using UnityEngine.UI;

namespace IronMountain.LayoutGroups
{
    [ExecuteAlways]
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(GridLayoutGroup))]
    public class ResponsiveGridLayoutScreenPercentSpacing : MonoBehaviour
    {
        private enum RelationType
        {
            Separate,
            UseMinimum,
            UseMaximum
        }

        [SerializeField] private RelationType relationType;
        [SerializeField] [Range(0, 1)] private float screenWidthPercent;
        [SerializeField] [Range(0, 1)] private float screenHeightPercent;
        [SerializeField] private bool affectPadding;

        [Header("Cache")]
        private GridLayoutGroup _gridLayoutGroup;

        private void Awake()
        {
            _gridLayoutGroup = GetComponent<GridLayoutGroup>();
        }

        private void Update()
        {
            if (!_gridLayoutGroup) return;
            float width = screenWidthPercent * Screen.width;
            float height = screenHeightPercent * Screen.height;
            switch (relationType)
            {
                case RelationType.Separate:
                    _gridLayoutGroup.spacing = new Vector2(width, height);
                    if (affectPadding) _gridLayoutGroup.padding = new RectOffset((int) width, (int) width, (int) height, (int) height);
                    break;
                case RelationType.UseMinimum:
                    float minimum = Mathf.Min(width, height);
                    _gridLayoutGroup.spacing = new Vector2(minimum, minimum);
                    if (affectPadding) _gridLayoutGroup.padding = new RectOffset((int) minimum, (int) minimum, (int) minimum, (int) minimum);
                    break;
                case RelationType.UseMaximum:
                    float maximum = Mathf.Max(width, height);
                    _gridLayoutGroup.spacing = new Vector2(maximum, maximum);
                    if (affectPadding) _gridLayoutGroup.padding = new RectOffset((int) maximum, (int) maximum, (int) maximum, (int) maximum);
                    break;
            }
        }
    }
}