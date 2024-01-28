using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{

    // ��v�����J�[�hID���X�g
    private List<int> mContainCardIdList = new List<int>();

    // �J�[�h�����}�l�[�W���N���X
    public CardCreateManager CardCreate;

    //���C�t�����}�l�[�W���[�N���X
    public LifeCreateManager CreateLife;

    //���C�t�J�E���g
    int lifeCount = 3;

    void Start()
    {

        // ��v�����J�[�hID���X�g��������
        this.mContainCardIdList.Clear();

        // �J�[�h���X�g�𐶐�����
        this.CardCreate.CreateCard();

        // ���C�t�𐶐�����
        this.CreateLife.CreateLife();

    }

    void Update()
    {
        // �I�������J�[�h���Q���ȏ�ɂȂ�����
        if (GameStateController.Instance.SelectedCardIdList.Count >= 2)
        {
            //���C�t�������
            this.CreateLife.HideLife(lifeCount);

            // �ŏ��ɑI������CardID���擾����
            int selectedId = GameStateController.Instance.SelectedCardIdList[0];
            if (this.mContainCardIdList.Count == 6)
            {
                Debug.Log("�N���A�I");
            }

            // 2���ڂɂ������J�[�h�ƈꏏ��������
            if (selectedId == GameStateController.Instance.SelectedCardIdList[1])
            {
                    // ��v�����J�[�hID��ۑ�����
                    this.mContainCardIdList.Add(selectedId);
            }
            // �J�[�h�̕\���؂�ւ����s��
            this.CardCreate.HideCardList(this.mContainCardIdList);

            // �I�������J�[�h���X�g������������
            GameStateController.Instance.SelectedCardIdList.Clear();
        }
    }
}