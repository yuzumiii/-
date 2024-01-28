using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class LifeCreateManager : MonoBehaviour
{
    // ��������Card�I�u�W�F�N�g
    public Life lifePrefab;
    // �u�J�[�h�v�𐶐�����e�I�u�W�F�N�g
    public RectTransform lifeParent;

    // ���������J�[�h�I�u�W�F�N�g��ۑ�����
    List<Life> LifeList = new List<Life>();
    public void CreateLife()
    {
        for (int i=0; i< 5; i++) {
            Life life = Instantiate<Life>(this.lifePrefab, this.lifeParent);
            LifeList.Add(life);
        }
    }

    //�����\���ɂ���
    public void HideLife(int lifeCount)
    {
        // �����B��
        LifeList[lifeCount].gameObject.SetActive(false);
    }
}
