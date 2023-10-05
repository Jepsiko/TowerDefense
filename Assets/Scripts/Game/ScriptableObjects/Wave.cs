using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wave
{

    [Serializable]
    public class Batch
    {
        public GameObject enemy;
        public int size;
        public float interval;
    }

    public List<Batch> batches;
}
