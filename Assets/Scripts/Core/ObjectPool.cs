using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private T prefab;
    private Queue<T> poolQueue = new Queue<T>();
    private Transform parent;

    // �����������: prefab � ������, ������� ����� �����������; initialSize � ��������� ����������; parent � �������� ��� ��������� �������� (����� �������� null)
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

    // �����, ������� ���������� ������ �� ���� (���� ���� � ������ �����)
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

    // ���������� ������ ������� � ���
    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);
        poolQueue.Enqueue(obj);
    }
}
