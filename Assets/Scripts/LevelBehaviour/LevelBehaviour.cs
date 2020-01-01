using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Infated.Tools
{


    [System.Serializable]
    public class StepBehaviourList : ReorderableArray<StepBehaviour>
    {
    }


    public class LevelBehaviour : MonoBehaviour
    {
        public GameObject[] levelFruitPrefabs;

        [Reorderable(null, "Step", null)]
        public StepBehaviourList stepList;

    }
}