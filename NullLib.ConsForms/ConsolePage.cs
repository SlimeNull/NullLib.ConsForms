using NullLib.ConsForms.Controls;
using System;

namespace NullLib.ConsForms
{
    public class ConsolePage : Control
    {
        public ConsolePage() :
            base(null, string.Empty)
        { }
        public ConsolePage(string text) :
            base(null, text)
        { }

        public override int AbsLeft => 0;
        public override int AbsTop => 0;
        public override int Height { get => Console.WindowHeight; set => Console.WindowHeight = value; }
        public override int Width { get => Console.WindowWidth; set => Console.WindowWidth = value; }
    }
}
