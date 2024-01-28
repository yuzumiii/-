using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{

    // 一致したカードIDリスト
    private List<int> mContainCardIdList = new List<int>();

    // カード生成マネージャクラス
    public CardCreateManager CardCreate;

    //ライフ生成マネージャークラス
    public LifeCreateManager CreateLife;

    //ライフカウント
    int lifeCount = 3;

    void Start()
    {

        // 一致したカードIDリストを初期化
        this.mContainCardIdList.Clear();

        // カードリストを生成する
        this.CardCreate.CreateCard();

        // ライフを生成する
        this.CreateLife.CreateLife();

    }

    void Update()
    {
        // 選択したカードが２枚以上になったら
        if (GameStateController.Instance.SelectedCardIdList.Count >= 2)
        {
            //ライフを一つ失う
            this.CreateLife.HideLife(lifeCount);

            // 最初に選択したCardIDを取得する
            int selectedId = GameStateController.Instance.SelectedCardIdList[0];
            if (this.mContainCardIdList.Count == 6)
            {
                Debug.Log("クリア！");
            }

            // 2枚目にあったカードと一緒だったら
            if (selectedId == GameStateController.Instance.SelectedCardIdList[1])
            {
                    // 一致したカードIDを保存する
                    this.mContainCardIdList.Add(selectedId);
            }
            // カードの表示切り替えを行う
            this.CardCreate.HideCardList(this.mContainCardIdList);

            // 選択したカードリストを初期化する
            GameStateController.Instance.SelectedCardIdList.Clear();
        }
    }
}