using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Infated.Tools
{


    [System.Serializable]
    public class StepBehaviourList : ReorderableArray<StepBehaviour>
    {
    }


    public class LevelBehaviour : MonoBehaviour
    {
        public GameObject[] levelFruitPrefabs;
        public GameObject[] bossFruitPrefabs;

        private IEnumerator swordCoroutine;
        private IEnumerator fruitCoroutine;

        [Reorderable(null, "Step", null)]
        public StepBehaviourList stepList;


        public FruitArea InitFruit(int step)
        {
            int randomInt = Random.Range(0, levelFruitPrefabs.Length);
            GameObject fruitObj = Instantiate(levelFruitPrefabs[randomInt], Vector3.zero, Quaternion.identity);
            fruitObj.GetComponent<GameobjectMover>().MoveOn();
            return fruitObj.GetComponent<FruitArea>();
        }

        public void StartCoroutines(int step,Sword sword,FruitArea fruit)
        {
            if(swordCoroutine != null)
            StopCoroutine(swordCoroutine);
            if(swordCoroutine != null)
            StopCoroutine(fruitCoroutine);
            swordCoroutine = StartSwordCoroutine(step,sword);
            fruitCoroutine = StartFruitCoroutine(step,fruit);
            StartCoroutine(swordCoroutine);
            StartCoroutine(fruitCoroutine);

        }

        IEnumerator StartFruitCoroutine(int step,FruitArea fruit)
        {
            StepActionList sal = stepList[step].stepActionForFruit;

            while (true)
            {
                foreach (StepAction stepAction in sal)
                {
                    fruit.rotateSpeed = stepAction.rotationSpeed;
                    fruit.isClockWise = stepAction.isClockWise;
                    yield return new WaitForSeconds(stepAction.stepTime);
                }
                yield return null;
            }
            
            yield return null;
        }

        IEnumerator StartSwordCoroutine(int step,Sword sword)
        {
            
            StepActionList sal = stepList[step].stepActionForSword;

            while (true)
            {
                foreach (StepAction stepAction in sal)
                {
                    sword.rotateSpeed = stepAction.rotationSpeed;
                    sword.isClockWise = stepAction.isClockWise;
                    yield return new WaitForSeconds(stepAction.stepTime);
                }
                yield return null;
            }
            yield return null;
        }
        
    }
}