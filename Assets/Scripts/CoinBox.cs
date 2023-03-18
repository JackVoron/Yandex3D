using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CoinBox : MonoBehaviour
{
    [SerializeField] private HitEffect _hitEffectPrefab;
    [SerializeField] private Resources _resources;
    public Resources Resources {get => _resources; set => _resources = value;}

    private int _coinsPerClick = 1;

    // Метод вызывается из Interaction при клике на объект
    public void Hit()
    {
        HitEffect hitEffect = Instantiate(_hitEffectPrefab, transform.position, Quaternion.identity);
        hitEffect.Init(_coinsPerClick);
        _resources.CollectCoins(1, transform.position);
        Destroy(gameObject);
    }
    // Этот метод увеличивает количество монет, получаемой при клике
    public void AddCoinsPerClick(int value)
    {
        _coinsPerClick += value;
    }

}
