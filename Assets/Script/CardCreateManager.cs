using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardCreateManager : MonoBehaviour
{

    // ��������Card�I�u�W�F�N�g
    public Card CardPrefab;

    // �u�J�[�h�v�𐶐�����e�I�u�W�F�N�g
    public RectTransform CardCreateParent;

    // ���������J�[�h�I�u�W�F�N�g��ۑ�����
    List<Card> CardList = new List<Card>();

    public void CreateCard()
    {
        // �J�[�h��񃊃X�g
        List<CardData> cardDataList = new List<CardData>();

        // �\������J�[�h�摜���̃��X�g
        List<Sprite> imgList = new List<Sprite>();

        // Resources/Image�t�H���_���ɂ���摜���擾����
        imgList.Add(Resources.Load<Sprite>("Image/1"));
        imgList.Add(Resources.Load<Sprite>("Image/2"));
        imgList.Add(Resources.Load<Sprite>("Image/3"));
        imgList.Add(Resources.Load<Sprite>("Image/4"));
        imgList.Add(Resources.Load<Sprite>("Image/5"));
        imgList.Add(Resources.Load<Sprite>("Image/6"));
        imgList.Add(Resources.Load<Sprite>("Image/7"));

        // for���񂷉񐔂��擾����
        int loopCnt = imgList.Count;

        for (int i = 0; i < loopCnt; i++)
        {

            // �J�[�h���𐶐�����
            CardData cardata = new CardData(i, imgList[i]);
            cardDataList.Add(cardata);
        }
        // ���������J�[�h���X�g�Q���̃��X�g�𐶐�����
        List<CardData> SumCardDataList = new List<CardData>();
        SumCardDataList.AddRange(cardDataList);
        SumCardDataList.AddRange(cardDataList);
        // ���X�g�̒��g�������_���ɍĔz�u����
        List<CardData> randomCardDataList = SumCardDataList.OrderBy(a => Guid.NewGuid()).ToList();

        // �J�[�h�I�u�W�F�N�g�𐶐�����
        foreach (var _cardData in randomCardDataList)
        {

            // Instantiate �� Card�I�u�W�F�N�g�𐶐�
            Card card = Instantiate<Card>(this.CardPrefab, this.CardCreateParent);
            // �f�[�^��ݒ肷��
            card.Set(_cardData);
            // ���������J�[�h�I�u�W�F�N�g��ۑ�����
            this.CardList.Add(card);
        }
    }
    /// <summary>
    /// �擾���Ă��Ȃ��J�[�h��w�ʂɂ���
    /// </summary>
    public void HideCardList(List<int> containCardIdList)
    {

        foreach (var _card in this.CardList)
        {

            // ���Ɋl�������J�[�hID�̏ꍇ�A��\���ɂ���
            if (containCardIdList.Contains(_card.Id))
            {

                // �J�[�h���\���ɂ���
                //_card.SetInvisible();
            }
            // �l�����Ă��Ȃ��J�[�h�͗��ʕ\���ɂ���
            else
            {
                // �J�[�h�𗠖ʕ\���ɂ���
                _card.SetHide();
            }
        }
    }
}