using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Planet.Data
{
    [Serializable]
    public class PlanetData
    {
        [Header("기본 설정")]
        [Tooltip("모델")]
        public GameObject Model;

        [Tooltip("이름")]
        public string Name;

        [Tooltip("근일점(AU)")]
        public float Perihelion;

        [Tooltip("원일점(AU)")]
        public float Aphelion;

        [Tooltip("근일점 경도")]
        public float PerihelionAngle;

        [Tooltip("공전 주기(년)")]
        public float SiderealPeriod;
    }

    [CreateAssetMenu(fileName = "PlanetInfo.asset", menuName = "Planet/PlanetInfo")]
    public class PlanetInfo : ScriptableObject
    {
        public PlanetData[] planetDatas;
    }

}
