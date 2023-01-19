using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �������� ũ�� ����
[CreateAssetMenu]

public class StageData : ScriptableObject
{
    [SerializeField]
    private Vector3 limiteMin;

    [SerializeField]
    private Vector3 limiteMax;

    public Vector3 LimitMin => limiteMin;
    public Vector3 LimitMax => limiteMax;
}
