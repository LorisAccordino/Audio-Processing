namespace AudioProcessing.Events
{
    public class ActionWithInvoke<T>
    {
        private readonly Action<T> action;
        private readonly Control targetControl;

        public ActionWithInvoke(Action<T> action, Control targetControl)
        {
            this.action = action;
            this.targetControl = targetControl;
        }

        public void Execute(T arg)
        {
            if (targetControl.InvokeRequired)
            {
                targetControl.Invoke(new MethodInvoker(() => action(arg)));
            }
            else
            {
                action(arg);
            }
        }
    }

    public class ActionWithInvoke
    {
        private readonly Action action;
        private readonly Control targetControl;

        public ActionWithInvoke(Action action, Control targetControl)
        {
            this.action = action;
            this.targetControl = targetControl;
        }

        public void Execute()
        {
            if (targetControl.InvokeRequired)
            {
                targetControl.Invoke(new MethodInvoker(() => action()));
            }
            else
            {
                action();
            }
        }
    }
}
