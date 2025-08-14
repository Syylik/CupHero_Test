using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    [SerializeField] private MoneyItem _money;
    private Bank _bank;

    [Zenject.Inject]
    public void Construct(Bank bank) => _bank = bank;

    public void Spawn(Vector2 pos)
    {
        Instantiate(_money, transform.position, Quaternion.identity);
    }
}
