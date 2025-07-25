using System;
using ImTipsyDude.InstantECS;
using UnityEngine;

public class EntityFactory : MonoBehaviour
{
    [SerializeField] private GameObject _slider;

    public T ProductEntity<T>
    (EFactoryProduct product,
        Transform parent,
        Vector3 position = default,
        Quaternion rotation = default)
        where T : IECSEntity
    {
        T result;

        switch (product)
        {
            case EFactoryProduct.Slider:
                result = Instantiate(_slider, position, rotation, parent).GetComponent<T>();
                break;
            default:
                result = null;
                break;
        }

        return result;
    }
}