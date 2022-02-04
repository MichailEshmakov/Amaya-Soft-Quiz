using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartMenuShower : MonoBehaviour
{
    [SerializeField] private RestartMenu _restartMenu;
    [SerializeField] private LevelChanger _levelChanger;

    private void OnValidate()
    {
        if (_restartMenu == null)
            _restartMenu = FindObjectOfType<RestartMenu>();

        if (_levelChanger == null)
            _levelChanger = FindObjectOfType<LevelChanger>();
    }

    private void OnEnable()
    {
        _levelChanger.AllLevelsCompleted += OnAllLevelsCompleted;
    }

    private void OnDisable()
    {
        _levelChanger.AllLevelsCompleted -= OnAllLevelsCompleted;
    }

    private void OnAllLevelsCompleted()
    {
        _restartMenu.gameObject.SetActive(true);
    }
}
