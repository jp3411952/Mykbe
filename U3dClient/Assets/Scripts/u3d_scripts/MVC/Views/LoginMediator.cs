using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;

public class LoginMediator : Mediator
{
    public new static string NAME = "LoginMediator";
    public LoginMediator()
    {

    }

    public override IList<NotifyDefine> ListNotificationInterests()
    {
        
        return base.ListNotificationInterests();
    }

    public override void HandleNotify<SendEntity, Param>(INotification<SendEntity, Param> notification)
    {
        base.HandleNotify(notification);
    }

}
