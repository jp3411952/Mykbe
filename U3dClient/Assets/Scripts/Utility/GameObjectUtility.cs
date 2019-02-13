using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mmowar
{

public class GameObjectUtility
{

        private static GameObjectUtility _instance;

        public static GameObjectUtility Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObjectUtility();
                }
                return _instance;
            }
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="name"></param>
        public GameObject CreateGameObject(string name, Transform parent = null)
        {
            GameObject obj = Object.Instantiate(Resources.Load(name)) as GameObject;
            obj.transform.position = Vector3.zero;
            obj.transform.localScale = Vector3.one;
            if (parent != null)
            {
                obj.transform.parent = parent;
            }
            obj.SetActive(false);
            return obj;
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="name"></param>
        public GameObject CreateGameObject(GameObject target, Transform parent = null)
        {
            GameObject obj = Object.Instantiate(target) as GameObject;
            obj.transform.position = Vector3.zero;
            obj.transform.localScale = Vector3.one;
            if (parent != null)
            {
                obj.transform.SetParent(parent);
            }
            obj.SetActive(false);
            return obj;
        }

        public static T SafeGetComponent<T>(GameObject target) where T : Component
        {
            T t = null;
            if (target == null)
                return t;
            t = target.GetComponent<T>();
            if (t == null)
            {
                t = target.AddComponent<T>();
            }
            return t;
        }

    }

}