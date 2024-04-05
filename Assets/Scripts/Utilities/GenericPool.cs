using System.Collections.Generic;
using System;

public class GenericObjectPool<T> where T : class
{
    public List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();

    protected T GetItem()
    {
        if (pooledItems.Count > 0)
        {
            PooledItem<T> item = pooledItems.Find(item => !item.isUsed);
            if (item != null)
            {
                item.isUsed = true;
                return item.Item;
            }
        }
        return CreateNewPooledItem();
    }

    private T CreateNewPooledItem()
    {
        PooledItem<T> newItem = new PooledItem<T>();
        newItem.Item = CreateItem();
        newItem.isUsed = true;
        pooledItems.Add(newItem);
        return newItem.Item;
    }

    protected virtual T CreateItem()
    {
        throw new NotImplementedException("CreateItem() method not implemented in derived class");
    }

    public void ReturnItem(T item)
    {
        PooledItem<T> pooledItem = pooledItems.Find(i => i.Item.Equals(item));
        pooledItem.isUsed = false;
    }
}

public class PooledItem<T>
{
    public T Item;
    public bool isUsed;
}