using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;
using mmowar;
using UnityEngine.EventSystems;
using KBEngine;

/// <summary>
///  获取用户名与交涉
/// </summary>
public class LoginMediator : Mediator
{
    public new static string NAME = "LoginMediator";
    public LoginView loginview;
    public AccountProxy accProxy;

    public LoginMediator(object viewComponent)
       : base(NAME, viewComponent)
    {
        loginview = GameObjectUtility.SafeGetComponent<LoginView>(ViewComponent as GameObject);
        UIEventTriggerListener.Get(loginview.loginBtn.gameObject).onClick += Login;
        UIEventTriggerListener.Get(loginview.registerBtn.gameObject).onClick += Register;
        accProxy = Facade.RetrieveProxy(AccountProxy.NAME) as AccountProxy;
    }

    
    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="eventData"></param>
    public void Login(PointerEventData eventData)
    {
       
       // KBEngine.Event.fireIn(EventInTypes.login, stringAccount, stringPasswd, System.Text.Encoding.UTF8.GetBytes("kbengine_unity3d_demo"));
    }

    /// <summary>
    /// 注册
    /// </summary>
    /// <param name="eventData"></param>
    public void Register(PointerEventData eventData)
    {
        //创建账号
     //  KBEngine.Event.fireIn(EventInTypes.createAccount, stringAccount, stringPasswd, System.Text.Encoding.UTF8.GetBytes("kbengine_unity3d_demo"));
    }

    public override IList<NotifyDefine> ListNotificationInterests()
    {
        
        return base.ListNotificationInterests();
    }

    public override void HandleNotify<SendEntity, Param>(INotification<SendEntity, Param> notification)
    {
        base.HandleNotify(notification);
    }

    ~LoginMediator()
    {
        UIEventTriggerListener.Get(loginview.loginBtn.gameObject).onClick -= Login;
        UIEventTriggerListener.Get(loginview.registerBtn.gameObject).onClick -= Register;
    }
}
