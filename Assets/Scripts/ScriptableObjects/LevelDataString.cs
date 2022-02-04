using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = nameof(LevelData) + "/New " + nameof(LevelDataString))]
public class LevelDataString : LevelData
{
    [SerializeField] private ThemeString _theme;

    public override ITheme Theme => _theme;
}
