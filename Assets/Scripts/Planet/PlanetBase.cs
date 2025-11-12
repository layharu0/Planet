using Planet.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Planet.Base
{
    public class PlanetBase : MonoBehaviour
    {
        [Header("기본 설정")]
        [Tooltip("공전 축")]
        [SerializeField] Transform _center;

        [Tooltip("근일점(AU)")]
        [SerializeField] float _perihelion;

        [Tooltip("원일점(AU)")]
        [SerializeField] float _aphelion;

        [Tooltip("근일점 경도")]
        [SerializeField] float _perihelionAngle;

        [Tooltip("공전 주기(년)")]
        [SerializeField] float _siderealPeriod;

        float _nowAngle = 0;

        public void Awake()
        {
            //초기값 설정
            _nowAngle = _perihelionAngle;
            transform.position = GetPosition(_nowAngle * Mathf.Deg2Rad);
        }

        public void Update()
        {
            //다음 경도 계산
            float nextAngle = _nowAngle + 360 / _siderealPeriod * Time.deltaTime * PlanetOptionManager.SpeedMultify;

            while (nextAngle > 360)
            {
                nextAngle -= 360;
            }

            float rad = Mathf.Deg2Rad * nextAngle;
            transform.position = GetPosition(rad);
            _nowAngle = nextAngle;
        }

        private Vector3 GetPosition(float angle)
        {
            //경도 보정
            angle -= _perihelionAngle;

            //위치 계산
            float x = _center.position.x + _perihelion * Mathf.Cos(angle) * PlanetOptionManager.DistanceMultify;
            float y = _center.position.z + _aphelion * Mathf.Sin(angle) * PlanetOptionManager.DistanceMultify;

            return new Vector3(x, 0, y);
        }
    }
}