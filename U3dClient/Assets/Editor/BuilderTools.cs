using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace mmowar
{

    public class BuilderTools
    {

        static public BuildTarget GetBuildTarget()
        {
            BuildTarget target = BuildTarget.WebGL;
#if UNITY_STANDALONE
            target = BuildTarget.StandaloneWindows;
#elif UNITY_IPHONE
			    target = BuildTarget.iPhone;
#elif UNITY_ANDROID
			    target = BuildTarget.Android;
#endif
            return target;
        }
    }
}