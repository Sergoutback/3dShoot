using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit() 
    {
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {  // Проверяем, присоединен ли к персонажу сценарий WanderingAI; он может и отсутствовать.
            behavior.SetAlive(false);
        }

        StartCoroutine(Die()); //Метод, вызванный сценарием стрельбы.
    }
    private IEnumerator Die() 
    {
        // Опрокидываем врага, ждем 1,5 секунды и уничтожаем его.
        this.transform.Rotate(75, 0, 0);
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
