using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Clickable : MonoBehaviour
{

    [SerializeField] private AnimationCurve _scaleCurve;
    [SerializeField] private float _scaleTime = 0.25f;
    [SerializeField] private CoinBox _coinBoxPrefab;
    [SerializeField] private Resources _resources;

    private int _coinsPerClick = 1;

    // Метод вызывается из Interaction при клике на объект
    public void Hit()
    {
        CoinBox coinBox = Instantiate(_coinBoxPrefab, transform.position + Vector3.up , Random.rotation);
        coinBox.GetComponent<Rigidbody>().AddForce(
            new Vector3(
                Random.Range(1, 3) == 1 ? Random.Range(-100, -30) : Random.Range(30, 100),
                100,
                Random.Range(1, 3) == 1 ? Random.Range(-100, -30) : Random.Range(30, 100)
            ));
        coinBox.Resources = _resources;
        Destroy(coinBox.gameObject, 3);
        StartCoroutine(HitAnimation());
    }

    // Анимация колебания куба
    private IEnumerator HitAnimation()
    {
        for (float t = 0; t < 1f; t += Time.deltaTime / _scaleTime)
        {
            float scale = _scaleCurve.Evaluate(t);
            transform.localScale = Vector3.one * scale;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }
}
