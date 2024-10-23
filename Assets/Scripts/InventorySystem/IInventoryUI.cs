

using System;
using System.Collections.Generic;

public interface IInventoryUI<T,Y>
{
    event Func<List<ItemScrObj>> onSetNewItem;
    void SetNewItemByInventoryCell(T slot, Y item);
    void ResetItemByInventoryCell(T slot, Y item);
    void UpdateInventorySlots();
}