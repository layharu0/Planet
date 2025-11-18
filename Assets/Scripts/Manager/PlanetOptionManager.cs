using UnityEngine;
using UnityEngine.Assertions;
using Planet.Data;
using Planet.Base;
using System.Linq;

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

        public static string[] PlanetList => Instance._planetList;

        [Header("青己 单捞磐")]
        [Tooltip("青己 单捞磐 格废")]
        [SerializeField] PlanetInfo _planetInfo;

        [Tooltip("怕剧 Trasnform")]
        [SerializeField] Transform _sunTransform;

        [Tooltip("青己 坷宏璃飘 何葛 Trasnform")]
        [SerializeField] Transform _planetParent;

        [Header("青己 可记")]
        [Tooltip("青己 傍傈 加档 硅啦")]
        [SerializeField] float _speedMultifyValue = 1;

        [Tooltip("青己 芭府 硅啦")]
        [SerializeField] float _distanceMultifyValue = 1;

        private string[] _planetList;

        public void Awake()
        {
            if (Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            //鞘荐 亲格 眉农
            Assert.IsNotNull(_sunTransform, "SunTransform is Null");
            Assert.IsNotNull(_planetInfo, "PlanetInfo is Null");

            //青己 积己
            CreatePlanets();

            //青己 府胶飘 累己
            _planetList = _planetInfo.planetDatas.Select(p => p.Name).ToArray();
        }

        private void CreatePlanets()
        {
            PlanetData[] datas = _planetInfo.planetDatas;
            foreach (var data in datas)
            {
                GameObject planetObj = Instantiate(data.Model, _planetParent);
                PlanetBase planetBase = planetObj.AddComponent<PlanetBase>();
                planetBase.Initialize(data, _sunTransform);
            }
        }
    }
}

