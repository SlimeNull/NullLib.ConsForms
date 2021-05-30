using System;
using System.Collections.Generic;
using System.Text;

namespace NullLib.ConsForms
{
    //
    // 摘要:
    //     指示某个元素相对于父元素的已分配的布局槽水平轴上的显示位置。
    public enum HorizontalAlignment
    {
        //
        // 摘要:
        //     元素的父元素的布局槽左对齐方式。
        Left = 0,
        //
        // 摘要:
        //     元素的父元素的布局槽的中心对齐。
        Center = 1,
        //
        // 摘要:
        //     元素与父元素的布局槽的右侧对齐。
        Right = 2,
        //
        // 摘要:
        //     拉伸以填充整个布局槽的父元素。
        Stretch = 3
    }
}
