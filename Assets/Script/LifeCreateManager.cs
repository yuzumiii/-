using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class LifeCreateManager : MonoBehaviour
{
    // 生成するCardオブジェクト
    public Life lifePrefab;
    // 「カード」を生成する親オブジェクト
    public RectTransform lifeParent;

    // 生成したカードオブジェクトを保存する
    List<Life> LifeList = new List<Life>();
    public void CreateLife()
    {
        for (int i=0; i< 5; i++) {
            Life life = Instantiate<Life>(this.lifePrefab, this.lifeParent);
            LifeList.Add(life);
        }
    }

    //星を非表示にする
    public void HideLife(int lifeCount)
    {
        // 星を隠す
        LifeList[lifeCount].gameObject.SetActive(false);
    }
}
