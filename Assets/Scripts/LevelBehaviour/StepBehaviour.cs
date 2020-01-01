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
        
        [Reorderable(null, "Action", null)]
        public StepActionList stepAction;
    }
}
