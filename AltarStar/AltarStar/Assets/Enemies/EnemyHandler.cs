using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    public FloatData healthBase;
    private FloatData health;

    // Start is called before the first frame update
    void Start()
    {
        health = Instantiate(healthBase);

        print(health.value);
    }

    private void OnTriggerEnter(Collider other)
    {
        health.UpdateValue(amount: 0.1f);
    }

}
