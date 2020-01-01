using System.Collections;
using System.Collections.Generic;
using Infated.Tools;
using UnityEngine;

namespace Infated.Tools
{
    [System.Serializable]
    public class StepActionList : ReorderableArray<StepAction>
    {
    }

    [System.Serializable]
    public class StepBehaviour
    {
        public string StepName;
        
        [Reorderable(null, "Fruit Action", null)]
        public StepActionList stepActionForFruit;
        [Reorderable(null, "Sword Action", null)]
        public StepActionList stepActionForSword;
    }
}
