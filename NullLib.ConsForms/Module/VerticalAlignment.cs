using System;
using System.Collections.Generic;
using System.Text;

namespace NullLib.ConsForms
{
    //
    // 摘要:
    //     介绍如何子元素是垂直定位或在父级的布局槽内拉伸。
    public enum VerticalAlignment
    {
        //
        // 摘要:
        //     子元素的父元素的布局槽顶部对齐。
        Top = 0,
        //
        // 摘要:
        //     子元素的父布局槽的中心对齐。
        Center = 1,
        //
        // 摘要:
        //     子元素的父元素的布局槽底部对齐。
        Bottom = 2,
        //
        // 摘要:
        //     子元素将拉伸以填充父元素的布局槽。
        Stretch = 3
    }
}
