using UnityEngine;
using Model;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = nameof(LevelData) + "/New " + nameof(LevelDataInt))]
    public class LevelDataInt : LevelData
    {
        [SerializeField] private ThemeInt _theme;

        public override ITheme Theme => _theme;
    }
}
