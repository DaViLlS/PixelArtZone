using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewArtefact", menuName = "Items/Artefact", order = 51)]
public class ArtefactSO : ItemSO
{
    [SerializeField] public string artefactType;
}
