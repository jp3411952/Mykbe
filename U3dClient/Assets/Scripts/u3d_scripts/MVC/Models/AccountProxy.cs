using PureMVC.Patterns;

public class AccountProxy : Proxy
{
    public new static string NAME  = "AccountProxy";
    public AccountModel _accoutModel;
    public AccountProxy()
        : base(NAME,null)
    {
        _accoutModel = new AccountModel();
    }
}
