

namespace mmowar
{
    /// <summary>
    /// 工厂
    /// </summary>
    public class BaseFactory
    {
        protected static BaseFactory _instanse ;

        static BaseFactory()
        {
            if (_instanse == null)
            {
                _instanse = new BaseFactory();
            }
        }

        protected BaseFactory()
        {
           
        }
        
        public static BaseFactory GetInstanse()
        {
            return _instanse;
        }

        public static T CreateObj<T>() where T : new()
        {
            return new T();
        }

    }

}
