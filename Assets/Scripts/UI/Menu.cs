using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Planet.UI
{
    public class Menu : MonoBehaviour
    {
        private bool _isOpened = false;
        private bool _isMoving = false;

        private RectTransform _rectTransform;
        private float _startY = 0;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _startY = _rectTransform.anchoredPosition.y;
        }

        public void OnClickMenuButton()
        {
            if (!_isMoving)
            {
                StartCoroutine(MenuMoveTween());
            }
        }

        private IEnumerator MenuMoveTween()
        {
            _isMoving = true;
            if (_isOpened)
            {
                yield return _rectTransform.DOAnchorPosY(_startY, 1).WaitForCompletion();

            }

            else
            {
                yield return _rectTransform.DOAnchorPosY(0, 1).WaitForCompletion();
            }

            _isOpened = !_isOpened;
            _isMoving = false;
        }
    }

}