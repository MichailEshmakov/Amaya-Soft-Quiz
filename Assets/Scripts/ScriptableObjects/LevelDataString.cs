using Model;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = nameof(LevelData) + "/New " + nameof(LevelDataString))]
    public class LevelDataString : LevelData
    {
        [SerializeField] private ThemeString _theme;

        public override ITheme Theme => _theme;
    }
}