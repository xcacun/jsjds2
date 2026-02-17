using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 [CreateAssetMenu(
        menuName = "IntroduceContentSO", // 右键菜单路径（GameConfig目录下的PlayerData选项）
        fileName = "IntroduceContentSO"         // 创建SO资源时的默认文件名
    )]
public class IntroduceContentSO : ScriptableObject
{
    public Sprite introduceImage;
    [TextArea]
    public string introduceText;
    public EIntroduceWhat introduceWhat;
}
