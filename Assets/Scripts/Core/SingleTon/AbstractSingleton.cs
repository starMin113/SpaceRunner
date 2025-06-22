using UnityEngine;
    public abstract class  AbstractSingleton<T>:MonoBehaviour where T:Component
    {
    protected static T s_Instance;
    public static T Instance
    {
        get
        {
            if(s_Instance == null)
            {
                s_Instance = FindFirstObjectByType<T>();
                if (s_Instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    s_Instance = obj.AddComponent<T>();
                    DebugUtil.Log("SinlgTon " + s_Instance.GetType().Name);
                }
                        
            }
            return s_Instance;
        }
    }
    protected virtual void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

