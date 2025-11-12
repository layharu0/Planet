using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Planet.Manager
{
    public class PlanetOptionManager : MonoBehaviour
    {
        private static PlanetOptionManager _instance;
        public static PlanetOptionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindAnyObjectByType<PlanetOptionManager>();
                    if (_instance == null)
                    {
                        GameObject go = new GameObject("PlanetOptionManager");
                        _instance = go.AddComponent<PlanetOptionManager>();
                    }
                }

                return _instance;
            }
        }

        public static float SpeedMultify => Instance._speedMultifyValue;
        public static float DistanceMultify => Instance._distanceMultifyValue;

        [Header("青己 可记")]
        [Tooltip("青己 傍傈 加档 硅啦")]
        [SerializeField] float _speedMultifyValue = 1;

        [Tooltip("青己 芭府 硅啦")]
        [SerializeField] float _distanceMultifyValue = 1;

        public void Awake()
        {
            if (Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);
        }
    }
}

