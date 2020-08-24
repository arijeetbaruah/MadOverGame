using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace MadeOverGame.Question1
{
    public class SumPairZero : MonoBehaviour
    {
        public int[] sampleArray;

        public bool IsSumTwoZero(int[] list)
        {
            foreach (int item in list)
            {
                int search = Array.Find(list, (i) => i == -item);

                if (search + item == 0)
                    return true;
            }

            return false;
        }

        public bool IsSumThreeZero(int[] list)
        {
            for (int i = 0; i < list.Length - 2; i++)
            {
                for (int j = 0; j < list.Length - 1; j++)
                {
                    for (int k = 0; k < list.Length; k++)
                    {
                        if (list[i] + list[j] + list[k] == 0)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
