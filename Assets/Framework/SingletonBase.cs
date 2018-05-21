using UnityEngine;


namespace Framework
{

    /// <summary>
    /// シングルトン既定クラス
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
    {

        static T instance;

        public static T Instance
        {
            get
            {
                Initialize();
                return instance;
            }
        }

        /// <summary>
        /// インスタンスの名前を設定
        /// </summary>
        /// <returns></returns>
        protected abstract string InstanceName();

        private void Awake()
        {
            name = InstanceName();
            DontDestroyOnLoad(this);
        }

        public static void Initialize()
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<T>();
                if(instance == null)
                {
                    throw new System.Exception("instance is null type : " + typeof(T));
                }
            }
        }
    }


}

