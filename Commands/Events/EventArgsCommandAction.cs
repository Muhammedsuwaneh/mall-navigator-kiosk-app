using Microsoft.Xaml.Behaviors;
using System.Windows.Input;
using System.Windows;

namespace MallMapKiosk.Commands.Events
{
    public sealed class EventArgsCommandAction : TriggerAction<DependencyObject>
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            "Command", typeof(ICommand), typeof(EventArgsCommandAction), new PropertyMetadata(null));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void Invoke(object parameter)
        {
            if (Command != null && Command.CanExecute(parameter))
            {
                Command.Execute(parameter);
            }
        }
    }
}
