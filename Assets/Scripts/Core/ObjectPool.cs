using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private T prefab;
    private Queue<T> poolQueue = new Queue<T>();
    private Transform parent;

    //  онструктор: prefab Ч объект, который будем клонировать; initialSize Ч начальное количество; parent Ч родитель дл€ созданных объектов (можно оставить null)
    public ObjectPool(T prefab, int initialSize, Transform parent = null)
    {
        this.prefab = prefab;
        this.parent = parent;
        for (int i = 0; i < initialSize; i++)
        {
            T obj = Object.Instantiate(prefab, parent);
            obj.gameObject.SetActive(false);
            poolQueue.Enqueue(obj);
        }
    }

    // ћетод, который возвращает объект из пула (если пуст Ч создаЄт новый)
    public T GetObject()
    {
        if (poolQueue.Count > 0)
        {
            T obj = poolQueue.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            T obj = Object.Instantiate(prefab, parent);
            return obj;
        }
    }

    // ¬озвращаем объект обратно в пул
    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);
        poolQueue.Enqueue(obj);
    }
}
