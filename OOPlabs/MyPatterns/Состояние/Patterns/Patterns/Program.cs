using System;

namespace Patterns
{
    interface IState
    {
        void PressUp();
        void PressDown();
        void PressBlock();

    }

    class Phone
    {
        private IState _state;

        public Phone(IState s)
        {
            ChangeState(s);
        }

        public void ChangeState(IState s)
        {
            _state = s;
        }

        public void PressUp() => _state.PressUp();
        public void PressDown() => _state.PressDown();
        public void PressBlock() => _state.PressBlock();
    }

    abstract class PhoneState : IState
    {
        protected Phone _phone;

        protected PhoneState(Phone p)
        {
            SetPhone(p);
        }

        public void SetPhone(Phone p)
        {
            _phone = p;
        }

        public abstract void PressUp();

        public abstract void PressDown();

        public abstract void PressBlock();

    }

    class BlockedState : PhoneState
    {
        public BlockedState(Phone p) : base(p)
        {
        }
        public override void PressUp()
        {
            Console.WriteLine("Operation not");
        }

        public override void PressDown()
        {
            Console.WriteLine("Operation not");
        }

        public override void PressBlock()
        {
            _phone.ChangeState(new UnblockedState(_phone));
        }
    }

    class UnblockedState : PhoneState
    {
        public UnblockedState(Phone p) : base(p)
        {
        }
        public override void PressUp()
        {
            Console.WriteLine("Volume up");
        }

        public override void PressDown()
        {
            Console.WriteLine("Volume down");
        }

        public override void PressBlock()
        {
            _phone.ChangeState(new BlockedState(_phone));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var initialState = new BlockedState(null);
            var phone = new Phone(initialState);
            initialState.SetPhone(phone);

            phone.PressDown();
            phone.PressBlock();
            phone.PressDown();
        }
    }
}
