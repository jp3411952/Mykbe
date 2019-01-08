namespace mmowar
{
    using System.Collections.Generic;
    using UnityEngine;
    /// <summary>
    /// 资源路径管理常量
    /// 为规范各方文件管理特拟定以下规则，再以后的使用过程中在进行优化
    /// -- Assets 子文件 根
    ///     --Resources         |二级
    ///             --AudioClip         
    ///                 --UI
    ///                     --XXWin
    ///                             xxView.audioclip 
    ///                 --GO
    ///                     --xxGO
    ///                       XXgo.audioclip
    ///             --Prefab            
    ///                 --UI                
    ///                     --Img            
    ///                          XXImg.prefab  
    ///                     --Effect
    ///                          xxWinEff.prefab
    ///                     --View          
    ///                 --Go
    ///                     --Img            
    ///                     --Effect
    ///                     --View
    ///              --Anima           
    ///                 --UI 
    ///                     -- 对应具体的UI
    ///                         xxWin.animator
    ///                 --Go
    ///                     xxgo.animator
    ///              --Anim
    ///         
    /// </summary>
    /// 
  
    
    public class PathMgr 
    {

        public  static PathMgr _instanse;

        /// <summary>
        /// 文件目录"/斜杠在前"
        /// </summary>
        /// 
        private static string AssetPath = "";
        public static string ResRealPath            = "/Resources";

        /// <summary>
        /// UI资源路径
        /// </summary>
        public Dictionary<int, string> m_dicPerfab_UI = new Dictionary<int, string>();
        //public Dictionary<Prefab_GO, string> m_dicPerfab_GO = new Dictionary<Prefab_UI, string>();

        /// <summary>
        ///  相对路径
        /// </summary>
        public static string AudioClipRelaPath      = "AudioClip";
        public static string TextFileRelaPath = "ResFile";
        public static string PrefabRealPath         = "Prefab";
        public static string AnimaRealPath          = "Anima";
        public static string SpriteRealPath = "Sprite";
        public static string PublicPath =       "Public";
        public static string PropertyFile = "PropertyFile";
        public const string  PathHua = "/";


        public static string UIRealPath             = "/UI";
        public static string GoRealPath             = "/GO";
     
        public static string Pre_UIorGO_ImgRealPath = "/Img";
        public static string Pre_UIorGO_EffRealPath = "/Effect";
 

        public static string LoginRelaPath = "/Login";
        public static string SelectAvateRealPath = "/SelectAvate";

         static PathMgr()
        {
            _instanse = new PathMgr();
       
        }
        //给对应资源添加
        public void AddResFileName(int res, int key,string name)
        {
            switch (res)
            {
                case (int)ResFilelis.Prefab_UI_EM:
                    m_dicPerfab_UI[key] = name;
                    break;
                default:
                    break;
            }

        }
        public static string getAssetPath()
        {
#if UNITY_EDITOR
            AssetPath = Application.dataPath;
#else
            AssetPath = Application.persistentDataPath;
#endif
            return AssetPath;
        }



        //public bool AddByFileName()
        //{

        //}
        /// <summary>
        /// Lv2
        /// </summary>
        /// <returns></returns>
        public static string get2LvResoureceAbsolPath()
        {
            return getAssetPath() + ResRealPath;
        }
        /// <summary>
        /// 源资分类绝对路径
        /// </summary>
        /// <returns></returns>
        public static string GetAnimaAbsolPath()
        {
            return get2LvResoureceAbsolPath()+ PathHua + AnimaRealPath;
        }
        public static string GetTextFilePath()
        {
            return get2LvResoureceAbsolPath() + PathHua + TextFileRelaPath;
        }
        public static string GetPrefabAbsolPath()
        {
            return get2LvResoureceAbsolPath() + PathHua + PrefabRealPath;
        }
        public static string GetAudioAbsolClip()
        {
            return get2LvResoureceAbsolPath() + PathHua + AudioClipRelaPath;
        }
        public static string GetSpriteAbsolPath()
        {
            return get2LvResoureceAbsolPath() + PathHua + SpriteRealPath;
        }

        public  void  ClearDate()
        {
            m_dicPerfab_UI.Clear();
        }

        public string GetPath(int ResType,int Reskey)
        {
            string path = "";
            switch (ResType)
            {
                case (int)ResFilelis.Prefab_UI_EM:
                    m_dicPerfab_UI.TryGetValue(Reskey, out path);
                    break;
                default:
                    break;
            }

            return path;
        }

        /// <summary>
        ///  相对路径
        /// </summary>
        /// <returns></returns>
        public static string GetPublicPrefabPath()
        {
            return PublicPath + PathHua + PrefabRealPath;
        }

        public static string GetAnimaRealPath()
        {
            return  AnimaRealPath;
        }
        public static string GetPrefabUIRealPath()
        {
            return PrefabRealPath  + UIRealPath;
        }
        //public static string GetAudioAbsolClip()
        //{
        //    return get2LvResoureceAbsolPath() + PathHua + AudioClipRelaPath;
        //}
        //public static string GetSpriteAbsolPath()
        //{
        //    return get2LvResoureceAbsolPath() + PathHua + SpriteRealPath;
        //}
    }

    /// <summary>
    /// 文件后缀名
    /// </summary>
    public class FileSuffix
    {
        protected FileSuffix()
        {
        }
        public static string SpriteSuff = ".sprite";
        public static string PrefabSuff = ".prefab";
        public static string PngSuff = ".png";
        public static string AnimationSuff = ".animation";
        public static string AnimatorSuff = ".animator";
        public static string Map3 = ".mp3";
    }

}