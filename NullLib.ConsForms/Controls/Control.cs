using NullLib.ConsoleEx;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NullLib.ConsForms.Controls
{
    public class Control
    {
        public Control() :
            this(null, string.Empty)
        { }
        public Control(string text) :
            this(null, text)
        { }
        public Control(Control parent, string text)
        {
            this.parent = parent;
            this.text = text;

            this.foreColor = Console.ForegroundColor;
            this.backColor = Console.BackgroundColor;

            controls = new ControlCollection(this);
        }

        protected Control parent;
        protected string text;
        protected int width;
        protected int height;
        protected ConsoleColor foreColor;
        protected ConsoleColor backColor;
        private Thickness margin;
        private Thickness padding;
        private HorizontalAlignment horizontalAlignment;
        private VerticalAlignment verticalAlignment;
        private readonly ControlCollection controls;

        protected int AbsParentRight => parent != null ? parent.AbsLeft + parent.Width : Console.BufferWidth;
        protected int AbsParentBottom => parent != null ? parent.AbsTop + parent.Height : Console.BufferHeight;

        protected void MeasureVertical(out Rectangle parentAbsClient, out int abstop, out int absheight)
        {
            if (parent == null)
            {
                parentAbsClient = new Rectangle(0, 0, Console.WindowWidth, Console.WindowHeight);
                switch (VerticalAlignment)
                {
                    case VerticalAlignment.Top:
                        abstop = Margin.Top;
                        absheight = Height;
                        break;
                    case VerticalAlignment.Center:
                        abstop = (Console.WindowHeight - Margin.VerticalLength - Height) / 2 + Margin.Top;
                        absheight = Height;
                        break;
                    case VerticalAlignment.Bottom:
                        abstop = Console.WindowHeight - Height - Margin.Bottom;
                        absheight = Height;
                        break;
                    case VerticalAlignment.Stretch:
                        abstop = Margin.Top;
                        absheight = Console.WindowHeight - Margin.VerticalLength;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            else
            {
                parentAbsClient = parent.AbsClientRectangle;
                switch (VerticalAlignment)
                {
                    case VerticalAlignment.Top:
                        abstop = parentAbsClient.Y + Margin.Top;
                        absheight = Height;
                        break;
                    case VerticalAlignment.Center:
                        abstop = parentAbsClient.Y + (parentAbsClient.Height - Margin.VerticalLength - Height) / 2 + Margin.Top;
                        absheight = Height;
                        break;
                    case VerticalAlignment.Bottom:
                        abstop = parentAbsClient.Y + parentAbsClient.Height - Height - Margin.Bottom;
                        absheight = Height;
                        break;
                    case VerticalAlignment.Stretch:
                        abstop = parentAbsClient.Y + Margin.Top;
                        absheight = parentAbsClient.Height - Margin.VerticalLength;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }
        protected void MeasureHorizontal(out Rectangle parentAbsClient, out int absleft, out int abswidth)
        {
            if (parent == null)
            {
                parentAbsClient = new Rectangle(0, 0, Console.WindowWidth, Console.WindowHeight);
                switch (HorizontalAlignment)
                {
                    case HorizontalAlignment.Left:
                        absleft = Margin.Left;
                        abswidth = Width;
                        break;
                    case HorizontalAlignment.Center:
                        absleft = (Console.WindowWidth - Margin.HorizontalLength - Width) / 2 + Margin.Left;
                        abswidth = Width;
                        break;
                    case HorizontalAlignment.Right:
                        absleft = Console.WindowWidth - Width - Margin.Right;
                        abswidth = Width;
                        break;
                    case HorizontalAlignment.Stretch:
                        absleft = Margin.Left;
                        abswidth = Console.WindowWidth - Margin.HorizontalLength;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            else
            {
                parentAbsClient = parent.AbsClientRectangle;
                switch (HorizontalAlignment)
                {
                    case HorizontalAlignment.Left:
                        absleft = parentAbsClient.X + Margin.Left;
                        abswidth = Width;
                        break;
                    case HorizontalAlignment.Center:
                        absleft = parentAbsClient.X + (parentAbsClient.Width - Margin.HorizontalLength - Width) / 2 + Margin.Left;
                        abswidth = Width;
                        break;
                    case HorizontalAlignment.Right:
                        absleft = parentAbsClient.X + parentAbsClient.Width - Width - Margin.Right;
                        abswidth = Width;
                        break;
                    case HorizontalAlignment.Stretch:
                        absleft = parentAbsClient.X + Margin.Left;
                        abswidth = parentAbsClient.Width - Margin.HorizontalLength;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }
        protected void MeasureAbsBounds(out Rectangle parentAbsClient, out int absleft, out int abstop, out int abswidth, out int absheight)
        {
            if (parent == null)
            {
                parentAbsClient = new Rectangle(0, 0, Console.WindowWidth, Console.WindowHeight);
                switch (HorizontalAlignment)
                {
                    case HorizontalAlignment.Left:
                        absleft = Margin.Left;
                        abswidth = Width;
                        break;
                    case HorizontalAlignment.Center:
                        absleft = (Console.WindowWidth - Margin.HorizontalLength - Width) / 2 + Margin.Left;
                        abswidth = Width;
                        break;
                    case HorizontalAlignment.Right:
                        absleft = Console.WindowWidth - Width - Margin.Right;
                        abswidth = Width;
                        break;
                    case HorizontalAlignment.Stretch:
                        absleft = Margin.Left;
                        abswidth = Console.WindowWidth - Margin.HorizontalLength;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
                switch (VerticalAlignment)
                {
                    case VerticalAlignment.Top:
                        abstop = Margin.Top;
                        absheight = Height;
                        break;
                    case VerticalAlignment.Center:
                        abstop = (Console.WindowHeight - Margin.VerticalLength - Height) / 2 + Margin.Top;
                        absheight = Height;
                        break;
                    case VerticalAlignment.Bottom:
                        abstop = Console.WindowHeight - Height - Margin.Bottom;
                        absheight = Height;
                        break;
                    case VerticalAlignment.Stretch:
                        abstop = Margin.Top;
                        absheight = Console.WindowHeight - Margin.VerticalLength;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
            else
            {
                parentAbsClient = parent.AbsClientRectangle;
                switch (HorizontalAlignment)
                {
                    case HorizontalAlignment.Left:
                        absleft = parentAbsClient.X + Margin.Left;
                        abswidth = Width;
                        break;
                    case HorizontalAlignment.Center:
                        absleft = parentAbsClient.X + (parentAbsClient.Width - Margin.HorizontalLength - Width) / 2 + Margin.Left;
                        abswidth = Width;
                        break;
                    case HorizontalAlignment.Right:
                        absleft = parentAbsClient.X + parentAbsClient.Width - Width - Margin.Right;
                        abswidth = Width;
                        break;
                    case HorizontalAlignment.Stretch:
                        absleft = parentAbsClient.X + Margin.Left;
                        abswidth = parentAbsClient.Width - Margin.HorizontalLength;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
                switch (VerticalAlignment)
                {
                    case VerticalAlignment.Top:
                        abstop = parentAbsClient.Y + Margin.Top;
                        absheight = Height;
                        break;
                    case VerticalAlignment.Center:
                        abstop = parentAbsClient.Y + (parentAbsClient.Height - Margin.VerticalLength - Height) / 2 + Margin.Top;
                        absheight = Height;
                        break;
                    case VerticalAlignment.Bottom:
                        abstop = parentAbsClient.Y + parentAbsClient.Height - Height - Margin.Bottom;
                        absheight = Height;
                        break;
                    case VerticalAlignment.Stretch:
                        abstop = parentAbsClient.Y + Margin.Top;
                        absheight = parentAbsClient.Height - Margin.VerticalLength;
                        break;
                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        public virtual int AbsLeft
        {
            get
            {
                MeasureHorizontal(out _, out int absleft, out _);
                return absleft;
            }
        }
        public virtual int AbsTop
        {
            get
            {
                MeasureVertical(out _, out int abstop, out _);
                return abstop;
            }
        }
        public virtual Thickness Margin { get => margin; set => margin = value; }
        public virtual Thickness Padding { get => padding; set => padding = value; }
        public virtual VerticalAlignment VerticalAlignment { get => verticalAlignment; set => verticalAlignment = value; }
        public virtual HorizontalAlignment HorizontalAlignment { get => horizontalAlignment; set => horizontalAlignment = value; }
        public virtual string Text { get => text; set => text = value; }
        public virtual Point AbsLocation { get => new Point(AbsLeft, AbsTop); }
        public virtual int Width { get => width; set => width = value; }
        public virtual int Height { get => height; set => height = value; }
        public virtual Size Size { get => new Size(Width, Height); set => (Width, Height) = (value.Width, value.Height); }
        public virtual Rectangle Bounds
        { 
            get
            {
                Thickness margin = Margin;
                return new Rectangle(new Point(margin.Left, margin.Top), Size);
            } 
        }
        public virtual Rectangle AbsBounds
        {
            get
            {
                MeasureAbsBounds(out _, out int absleft, out int abstop, out int abswidth, out int absheight);
                return new Rectangle(absleft, abstop, abswidth, absheight);
            }
        }
        public virtual Point ClientLocation
        {
            get
            {
                Thickness padding = Padding;
                return new Point(padding.Left, padding.Top);
            }
        }
        public virtual Point AbsClientLocation
        {
            get
            {
                Point absLocation = AbsLocation;
                return new Point(absLocation.X + padding.Left, absLocation.Y + padding.Top);
            }
        }
        public virtual Size ClientSize
        {
            get
            {
                Thickness padding = Padding;
                return new Size(Width - padding.HorizontalLength, Height - padding.VerticalLength);
            }
        }
        public virtual Size AbsClientSize
        {
            get
            {
                Rectangle absBounds = AbsBounds;
                Thickness padding = Padding;
                return new Size(absBounds.Width - padding.HorizontalLength, absBounds.Height - padding.VerticalLength);
            }
        }
        public virtual Rectangle ClientRectangle
        {
            get
            {
                Rectangle bounds = Bounds;
                Thickness padding = Padding;
                return new Rectangle(bounds.X + padding.Left, bounds.Y + padding.Top, bounds.Width - padding.HorizontalLength, bounds.Height - padding.VerticalLength);
            }
        }
        public virtual Rectangle AbsClientRectangle
        {
            get
            {
                Rectangle absBounds = AbsBounds;
                Thickness padding = Padding;
                return new Rectangle(absBounds.X + padding.Left, absBounds.Y + padding.Top, absBounds.Width - padding.HorizontalLength, absBounds.Height - padding.VerticalLength);
            }
        }

        public ConsoleColor ForeColor { get => foreColor; set => foreColor = value; }
        public ConsoleColor BackColor { get => backColor; set => backColor = value; }

        public ControlCollection Controls => controls;
        protected static bool CheckTextContinue(string str, int index, int left, out int charLen, params int[] rights)
        {
            charLen = 0;
            return index < str.Length && (charLen = ConsoleText.CalcCharLength(str[index])) + left < rights.Min();
        }
        protected static bool CheckPointInRects(IEnumerable<Rectangle> rects, int x, int y)
        {
            bool result = false;
            foreach (Rectangle rect in rects)
                result |= rect.Contains(x, y);
            return result;
        }
        protected static void DrawContentArea(ConsoleColor backColor, ConsoleColor foreColor, int absLeft, int absTop, int absRight, int absBottom, int absParentRight, int absParentBottom, int bufWidth, int bufHeight, ref int txtIndex, ref bool writeTxt, string text, StringBuilder strBuilder, Rectangle[] childBounds)
        {
            Console.BackgroundColor = backColor;
            Console.ForegroundColor = foreColor;
            for (int top = absTop; top < absBottom && top < absParentBottom && top < bufHeight; top++)
            {
                writeTxt = true;
                Console.CursorTop = top;
                for (int left = absLeft; left < absRight && left < absParentRight && left < bufWidth; left++)
                {
                    Console.CursorLeft = left;

                    if (writeTxt)
                        DrawLineText(ref left, top, absLeft, absRight, absParentRight, bufWidth, ref writeTxt, ref txtIndex, text, strBuilder, childBounds);
                    else
                        DrawLineSpace(ref left, top, absRight, absParentRight, bufWidth, strBuilder, childBounds);
                }
            }
        }
        protected static void InitializeDrawing(Control self, out int absLeft, out int absTop, out int absRight, out int absBottom, out int absParentRight, out int absParentBottom, out int bufWidth, out int bufHeight, out int txtIndex, out bool writeTxt, out StringBuilder strBuilder, out Rectangle[] childBounds)
        {
            self.MeasureAbsBounds(out Rectangle parentAbsClient, out absLeft, out absTop, out int abswidth, out int absheight);
            absRight = absLeft + abswidth;
            absBottom = absTop + absheight;
            absParentRight = parentAbsClient.X + parentAbsClient.Width;
            absParentBottom = parentAbsClient.Y + parentAbsClient.Height;
            bufWidth = Console.WindowWidth;
            bufHeight = Console.WindowHeight;
            txtIndex = 0;
            writeTxt = true;

            strBuilder = new StringBuilder();
            childBounds = self.Controls.Select(v => v.AbsBounds).ToArray();
        }
        protected static void DrawChildrenContent(ControlCollection controls)
        {
            foreach (Control i in controls)
                i.DrawContent();
        }
        protected static void DrawLineSpace(ref int left, int top, int absRight, int absParentRight, int bufWidth, StringBuilder strBuilder, Rectangle[] childBounds)
        {
            strBuilder.Clear();
            for (; left < absRight && left < absParentRight && left < bufWidth; left++)
            {
                if (CheckPointInRects(childBounds, left, top))
                    break;

                strBuilder.Append(' ');
            }
            Console.Write(strBuilder.ToString());
        }
        protected static void DrawLineText(ref int left, int top, int absLeft, int absRight, int absParentRight, int bufWidth, ref bool writeTxt, ref int txtIndex, string text, StringBuilder strBuilder, Rectangle[] childBounds)
        {
            strBuilder.Clear();
            for (; left < absRight && left < absParentRight && left < bufWidth; left++)
            {
                writeTxt = CheckTextContinue(text, txtIndex, absLeft, out int charLen, absRight, absParentRight, bufWidth);
                if (!writeTxt)
                {
                    left--;
                    break;
                }

                char curChar = text[txtIndex++];
                if (CheckPointInRects(childBounds, left, top))
                {
                    break;
                }
                else if (curChar.Equals('\r'))
                {
                    Console.Write(strBuilder.ToString());
                    Console.CursorTop = top;
                    Console.CursorLeft = left = absLeft;
                    strBuilder.Clear();
                    continue;
                }
                else if (curChar.Equals('\n'))
                {
                    writeTxt = false;
                    left--;
                    break;
                }

                strBuilder.Append(curChar);
                left += charLen - 1;
            }
            Console.Write(strBuilder.ToString());
        }
        
        public virtual void DrawContent()
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
            DrawContentArea(BackColor,
                            ForeColor,
                            absLeft,
                            absTop,
                            absRight,
                            absBottom,
                            absParentRight,
                            absParentBottom,
                            bufWidth,
                            bufHeight,
                            ref txtIndex,
                            ref writeTxt,
                            Text,
                            strBuilder,
                            childBounds);
            DrawChildrenContent(Controls);
        }

        public class ControlCollection : IList<Control>, ICollection<Control>
        {
            private Control owner;
            private List<Control> controls;

            public Control Owner => owner;
            public ControlCollection(Control owner)
            {
                this.owner = owner;
                this.controls = new List<Control>();
            }

            public Control this[int index] { get => controls[index]; set => controls[index] = value; }

            public int Count => controls.Count;

            public bool IsReadOnly => false;

            public void Add(Control item)
            {
                controls.Add(item);
                item.parent = owner;
            }

            public void AddRange(IEnumerable<Control> items)
            {
                controls.AddRange(items);
                foreach (var item in items)
                    item.parent = owner;
            }

            public void Clear()
            {
                controls.Clear();
            }

            public bool Contains(Control item) => controls.Contains(item);
            public IEnumerator<Control> GetEnumerator() => controls.GetEnumerator();
            public int IndexOf(Control item) => controls.IndexOf(item);
            public void Insert(int index, Control item) => controls.Insert(index, item);
            public bool Remove(Control item)
            {
                return controls.Remove(item);
            }

            public void RemoveAt(int index)
            {
                controls.RemoveAt(index);
            }

            void ICollection<Control>.CopyTo(Control[] array, int arrayIndex) => controls.CopyTo(array, arrayIndex);
            IEnumerator IEnumerable.GetEnumerator() => controls.GetEnumerator();
        }
    }
}
