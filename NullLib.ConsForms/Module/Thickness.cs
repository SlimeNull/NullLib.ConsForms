using System;
using System.Collections.Generic;
using System.Text;

namespace NullLib.ConsForms
{
    public struct Thickness
    {
        private int bottom;
        private int right;
        private int top;
        private int left;

        public Thickness(int uniformLength)
            : this(uniformLength, uniformLength, uniformLength, uniformLength) { }
        public Thickness(int horizontalLength, int verticalLength)
            : this(horizontalLength, verticalLength, horizontalLength, verticalLength) { }
        public Thickness(int left, int verticalLength, int right)
            : this(left, verticalLength, right, verticalLength) { }
        public Thickness(int left, int top, int right, int bottom)
        {
            (this.left, this.top, this.right, this.bottom) = (left, top, right, bottom);
        }

        public int Left { get => left; set => left = value; }
        public int Top { get => top; set => top = value; }
        public int Right { get => right; set => right = value; }
        public int Bottom { get => bottom; set => bottom = value; }
        public int VerticalLength { get => top + bottom; }
        public int HorizontalLength { get => left + right; }
    }
}
