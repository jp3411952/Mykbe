namespace MVC
{
    using PureMVC.Interfaces;
    using PureMVC.Patterns;
    public class StartCommand : SimpleCommand
    {
        public override void Execute<SendEntity, Param>(INotification<SendEntity, Param> note)
        {
            //加载配置文件
            //对游戏世界进行设置
        }
    }

}

