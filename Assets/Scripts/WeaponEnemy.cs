using UnityEngine;
using System.Collections;

public class WeaponEnemy : BulletPoolEnemy
{
    private Vector3 _position = new(-1, 0, 0);
    private int _delay;

    public IEnumerator Shoot()
    {
        WaitForSeconds _waitForSeconds;

        while (enabled)
        {
            _delay = Random.Range(3, 5);
            BulletEnemy bulletEnemy = OnGet();
            bulletEnemy.gameObject.SetActive(true);
            bulletEnemy.transform.position = transform.position + _position;

            yield return _waitForSeconds = new(_delay);
        }
    }
}
