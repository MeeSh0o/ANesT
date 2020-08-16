using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 类似于物品合成机制
/// </summary>
public class ItemCombin : MonoBehaviour
{
    [System.Serializable]
    public class ItemCombinConfig
    {
        [SerializeField]
        public List<string> NeedItemNames;

        [SerializeField]
        public List<Item> OutputItem;
    }

    [Header("物品合成表")]
    [SerializeField]
    public List<ItemCombinConfig> CombinsTable;

    private void Update()
    {
        foreach (ItemCombinConfig config in CombinsTable)
        {
            if (config.NeedItemNames.TrueForAll((itemName) =>
                Inventory.Instance.GetSelectedItems().Exists(item => item.name == itemName)))
            {
                foreach (string itemName in config.NeedItemNames)
                {
                    Inventory.Instance.RemoveItem(itemName);
                }

                config.OutputItem.ForEach(item => Inventory.Instance.AddItem(item));
            }
        }
    }
}