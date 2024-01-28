using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class Card : MonoBehaviour
{

    // �J�[�h��ID
    public int Id;

    // �\������J�[�h�̉摜
    public Image CardImage;

    // �I������Ă��邩����
    private bool mIsSelected = false;

    // �J�[�h���
    private CardData mData;

    // ���W���A��]�A�j���[�V�����Ɏg��
    private RectTransform mRt;

    // �J�[�h�̐ݒ�
    public void Set(CardData data)
    {
        // �J�[�h����ݒ�
        this.mData = data;

        // ID��ݒ肷��
        this.Id = data.Id;

        // �I�𔻒�t���O������������
        this.mIsSelected = false;

        //�S���\�ʂɂ�����
        //this.CardImage.sprite = this.mData.ImgSprite;

        // ���W�����擾���Ă���
        this.mRt = this.GetComponent<RectTransform>();

    }

    /// <summary>
    /// �I�����ꂽ���̏���
    /// </summary>
    public void OnClick()
    {

        // �J�[�h���\�ʂɂȂ��Ă����ꍇ�͖���
        if (this.mIsSelected)
        {
            return;
        }

        // Dotween�ŉ�]�������s��
        this.mRt.DORotate(new Vector3(0f, 90f, 0f), 0.2f)
            // ��]������������
            .OnComplete(() => {

                // �I�𔻒�t���O��L���ɂ���
                this.mIsSelected = true;

                // �J�[�h��\�ʂɂ���
                this.CardImage.sprite = this.mData.ImgSprite;

                // Y���W�����ɖ߂�
                this.onReturnRotate(() => {
                    // �I������CardId��ۑ����悤�I
                    GameStateController.Instance.SelectedCardIdList.Add(this.mData.Id);
                });
            });
    }

    /// <summary>
    /// �J�[�h�̉�]�������ɖ߂�
    /// </summary>
    private void onReturnRotate()
    {

        this.mRt.DORotate(new Vector3(0f, 0f, 0f), 0.2f)
            // ��]���I�������
            .OnComplete(() => {
                // �I������CardId��ۑ����悤�I
                GameStateController.Instance.SelectedCardIdList.Add(this.mData.Id);
            });
    }

    ///  <summary>
    /// �J�[�h��w�ʕ\�L�ɂ���
    /// </summary>
    public void SetHide()
    {
        // 90�x��]����
        this.onRotate(() => {
            // �I�𔻒�t���O������������
            this.mIsSelected = false;

            // �J�[�h��w�ʕ\���ɂ���
            this.CardImage.sprite = Resources.Load<Sprite>("Image/card_back");


            // �p�x�����ɂ��ǂ�
            this.onReturnRotate(() => {
            });
        });
    }

    /// <summary>
    /// �J�[�h��90�x�ɉ�]����
    /// </summary>
    private void onRotate(Action onComp)
    {

        // 90�x��]����
        this.mRt.DORotate(new Vector3(0f, 90f, 0f), 0.2f)
            // ��]���I��������
            .OnComplete(() => {

                if (onComp != null)
                {
                    onComp();
                }
            });
    }

    /// <summary>
    /// �J�[�h�̉�]�������ɖ߂�
    /// </summary>
    private void onReturnRotate(Action onComp)
    {

        this.mRt.DORotate(new Vector3(0f, 0f, 0f), 0.2f)
            // ��]���I�������
            .OnComplete(() => {

                if (onComp != null)
                {
                    onComp();
                }
            });
    }
}


public class CardData
{

    // �J�[�hID
    public int Id { get; private set; }

    // �摜
    public Sprite ImgSprite { get; private set; }

    public CardData(int _id, Sprite _sprite)
    {
        this.Id = _id;
        this.ImgSprite = _sprite;
    }
}

