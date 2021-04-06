using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Patterns
{
    class Editor
    {
        public string Text { get; set; }
    }

    interface ICommand
    {
        void Exucute();
        void Undo();
    }

    abstract class Command : ICommand
    {
        protected Editor _editor;

        protected Command(Editor e)
        {
            _editor = e;
        }

        public abstract void Exucute();
        public abstract void Undo();
    }

    class CopyCommand : Command
    {
        public CopyCommand(Editor e) : base(e)
        { }

        public override void Exucute()
        {
            Console.WriteLine($"запоминаем '{_editor.Text}' в буфер обмена");
        }

        public override void Undo()
        {
        }
    }

    class CutCommand : Command
    {
        protected string _backup;
        public CutCommand(Editor e) : base(e)
        { }

        public override void Exucute()
        {
            _backup = _editor.Text;
            _editor.Text = string.Empty;
        }

        public override void Undo()
        {
            _editor.Text = _backup;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var editor = new Editor();
            var history = new Stack<ICommand>();

            editor.Text = "Hello world";

            var cmd = new CutCommand(editor);
            cmd.Exucute();
            history.Push(cmd);

            Console.WriteLine(editor.Text);

            history.Pop().Undo();
            Console.WriteLine(editor.Text);
        }
    }
}
