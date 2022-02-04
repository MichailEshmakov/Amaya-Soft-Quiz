using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    [CreateAssetMenu(menuName = "Theme" + "/New " + nameof(ThemeString))]
    public class ThemeString : Theme<string>
    {
        public ThemeString(string name, IReadOnlyList<string> answers) : base(name, answers) { }
    }
}

