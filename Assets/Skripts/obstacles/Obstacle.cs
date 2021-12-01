using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private int _damage;
    [SerializeField] private Text _uiHp;

    private void Update()
    {
        _uiHp.text = _hp.ToString();
    }

    public void AplyDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
        {
            _hp = 0;
            Destroy(gameObject);
        }
    }
}
