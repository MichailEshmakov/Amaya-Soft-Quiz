using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

[CreateAssetMenu(menuName = nameof(LevelData) + "/New " + nameof(LevelDataInt))]
public class LevelDataInt : LevelData
{
    [SerializeField] private ThemeInt _theme;

    protected override Theme<object> GetTheme()
    {
        return _theme.ToObject();
    }
}
