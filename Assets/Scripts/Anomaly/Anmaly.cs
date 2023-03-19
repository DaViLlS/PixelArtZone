using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Anomaly")]
public class Anmaly : ScriptableObject
{
    [SerializeField] public string anomalyName;
    [SerializeField] public string anomalyType;
    [SerializeField] public int damage;
    [SerializeField] public ArtefactSO[] artefacts;
}
