using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace NullLib.ConsForms.Controls
{
    public class GroupBox : Control
    {
        private int headerHeight = 1;

        public int HeaderHeight { get => headerHeight; set => headerHeight = value; }
        public ConsoleColor HeaderForeColor { get; set; }
        public ConsoleColor HeaderBackColor { get; set; }

        public override Point AbsClientLocation
        {
            get
            {
                return base.AbsClientLocation + new Size(0, HeaderHeight);
            }
        }
        public override Size AbsClientSize
        {
            get
            {
                return base.AbsClientSize - new Size(0, HeaderHeight);
            }
        }
        public override Rectangle AbsClientRectangle
        {
            get
            {
                Rectangle baseAbsClientRectangle = base.AbsClientRectangle;
                return new Rectangle(baseAbsClientRectangle.Location + new Size(0, HeaderHeight), baseAbsClientRectangle.Size - new Size(0, HeaderHeight));
            }
        }

        public override void DrawContent()
        {
            InitializeDrawing(this,
                              out var absLeft,
                              out var absTop,
                              out var absRight,
                              out var absBottom,
                              out var absParentRight,
                              out var absParentBottom,
                              out var bufWidth,
                              out var bufHeight,
                              out var txtIndex,
                              out var writeTxt,
                              out var strBuilder,
                              out var childBounds);
            DrawContentArea(HeaderBackColor,
                            HeaderForeColor,
                            absLeft,
                            absTop,
                            absRight,
                            absTop + HeaderHeight,
                            absParentRight,
                            absParentBottom,
                            bufWidth,
                            bufHeight,
                            ref txtIndex,
                            ref writeTxt,
                            Text,
                            strBuilder,
                            childBounds);
            DrawContentArea(BackColor,
                            ForeColor,
                            absLeft,
                            absTop + HeaderHeight,
                            absRight,
                            absBottom,
                            absParentRight,
                            absParentBottom,
                            bufWidth,
                            bufHeight,
                            ref txtIndex,
                            ref writeTxt,
                            string.Empty,
                            strBuilder,
                            childBounds);
            DrawChildrenContent(Controls);
        }
    }
}
