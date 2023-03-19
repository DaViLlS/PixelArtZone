using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ActiveQuestsObjectives : MonoBehaviour
{
    [SerializeField] private Transform layout;
    [SerializeField] private GameObject objectiveTextPref;
    private List<GameObject> _objectivesGameObjects;
    private List<TextMeshProUGUI> _objectives;

    private void Awake()
    {
        _objectives = new List<TextMeshProUGUI>();
        _objectivesGameObjects = new List<GameObject>();
    }

    public void SetObjectives(Objective[] objectives)
    {
        foreach (GameObject objective in _objectivesGameObjects)
        {
            Destroy(objective.gameObject);
        }

        _objectivesGameObjects.Clear();

        foreach (Objective objective in objectives)
        {
            GameObject objectivePref = Instantiate(objectiveTextPref, Vector2.zero, Quaternion.identity);
                
            TextMeshProUGUI _objectiveText = objectivePref.GetComponentInChildren<TextMeshProUGUI>();
            objectivePref.transform.SetParent(layout);
            _objectiveText.text = objective.objectiveName;

            _objectives.Add(_objectiveText);
            _objectivesGameObjects.Add(objectivePref);
        }
    }

    public void ChangeObjetctiveView(Objective objective)
    {
        foreach (TextMeshProUGUI objectiveToFind in _objectives)
        {
            if (objectiveToFind.text == objective.objectiveName)
            {
                objectiveToFind.fontStyle = FontStyles.Strikethrough;
            }
        }
    }
}
