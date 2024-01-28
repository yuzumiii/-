using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    // ライフのID
    public int Id;
    public void Set(LifeData data)
    {
        // IDを設定する
        this.Id = data.Id;
    }
    public class LifeData
    {

        // カードID
        public int Id { get; private set; }

        public LifeData(int _id)
        {
            this.Id = _id;
        }
    }

}
