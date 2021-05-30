using System;
using System.Collections.Generic;
using System.Text;

namespace NullLib.ConsForms.Controls
{
    public class Panel : Control
    {
        public override string Text { get => string.Empty; set => throw new InvalidOperationException(); }
    }
}
