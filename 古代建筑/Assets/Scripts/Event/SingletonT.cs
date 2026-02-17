using UnityEngine;

// 泛型单例模板，可直接复用（替换T为你要做单例的类名）
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // 全局唯一实例（核心），外部通过 类名.Instance 访问
    private static T _instance;

    // 公开的实例访问器，确保全局唯一
    public static T Instance
    {
        get
        {
            // 如果实例为空，自动在场景中查找
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();

                // 如果查找不到，自动创建一个GameObject挂载该单例
                if (_instance == null)
                {
                    GameObject singletonObj = new GameObject(typeof(T).Name);
                    _instance = singletonObj.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    // 初始化单例（确保唯一+场景切换不销毁）
    protected virtual void Awake()
    {
        // 如果已有实例，且不是当前实例 → 销毁重复的
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // 赋值实例 + 标记为场景切换不销毁
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
    }
}
