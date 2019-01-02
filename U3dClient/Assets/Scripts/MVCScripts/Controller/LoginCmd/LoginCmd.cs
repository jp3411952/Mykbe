using PureMVC.Interfaces;
using PureMVC.Patterns;

public class LoginCmd : SimpleCommand
{
	public override void Execute(INotification notification)
	{
		base.Execute(notification);
	}
}
