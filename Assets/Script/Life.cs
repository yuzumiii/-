using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    // ���C�t��ID
    public int Id;
    public void Set(LifeData data)
    {
        // ID��ݒ肷��
        this.Id = data.Id;
    }
    public class LifeData
    {

        // �J�[�hID
        public int Id { get; private set; }

        public LifeData(int _id)
        {
            this.Id = _id;
        }
    }

}
