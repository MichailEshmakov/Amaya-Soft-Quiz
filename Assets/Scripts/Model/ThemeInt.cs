using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    [CreateAssetMenu(menuName = "Theme" + "/New " + nameof(ThemeInt))]
    public class ThemeInt : Theme<int>
    {
        public ThemeInt(string name, IReadOnlyList<int> answers) : base(name, answers) { }
    }
}
