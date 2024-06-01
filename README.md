# Layout Groups
*Version: 1.1.2*
## Description: 
Utility scripts for making responsive layout groups.
## Use Cases: 
* Dynamically resizing items in a grid layout to fit the size of their area.
* Dynamically resizing items in a grid layout to keep an aspect ratio and expand with row or column constraints.
* Dynamic padding and spacing as a function of screen size.
## Package Mirrors: 
[<img src='https://img.itch.zone/aW1nLzEzNzQ2ODg3LnBuZw==/original/npRUfq.png'>](https://github.com/Iron-Mountain-Software/layout-groups)[<img src='https://img.itch.zone/aW1nLzEzNzQ2ODkyLnBuZw==/original/Fq0ORM.png'>](https://www.npmjs.com/package/com.iron-mountain.layout-groups)[<img src='https://img.itch.zone/aW1nLzEzNzQ2ODk4LnBuZw==/original/Rv4m96.png'>](https://iron-mountain.itch.io/layout-groups)
---
## Key Scripts & Components: 
1. public struct **PaddingFlags**
1. public class **ResponsiveGridLayoutCellSizeExpand** : MonoBehaviour
1. public class **ResponsiveGridLayoutCellSizeFit** : MonoBehaviour
1. public class **ResponsiveGridLayoutSpacing** : MonoBehaviour
1. public class **ResponsiveHorizontalLayoutSpacing** : MonoBehaviour
1. public class **ResponsiveRectTransform** : MonoBehaviour
   * Properties: 
      * public Boolean ***SetWidth***  { get; set; }
      * public Boolean ***SetHeight***  { get; set; }
      * public float ***ScreenWidthPercent***  { get; set; }
      * public float ***ScreenHeightPercent***  { get; set; }
1. public class **ResponsiveVerticalLayoutSpacing** : MonoBehaviour
