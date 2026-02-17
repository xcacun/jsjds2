using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    menuName = "DialogSO", // 右键菜单路径（GameConfig目录下的PlayerData选项）
    fileName = "DialogSO"         // 创建SO资源时的默认文件名
)]
public class DialogNodeSO : ScriptableObject
{
    public Sprite speakerSprite;
    public bool isReading;
    [TextArea]
    public string Content;
    public bool canOption;
    public bool willEnd;
    public DialogNodeSO Next;
    public EStartWhat eWillStart;
}
