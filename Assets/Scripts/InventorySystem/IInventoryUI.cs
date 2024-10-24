

using System;
using System.Collections.Generic;

public interface IInventoryUI<T,Y>
{
    event Func<List<ItemScrObj>> onSetNewItem;
    void SetNewItemByInventoryCell( T item,Y slot = default);
    void ResetItemByInventoryCell( T item = default, Y slot = default);
    void UpdateInventorySlots();
}