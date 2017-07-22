using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemTag
/// </summary>
public class ItemTag
{
    public Item Item { get; set; }
    public string TagName { get; set; }

    public ItemTag()
    {
        
    }

    public ItemTag(Item item, string tagName)
    {
        Item = item;
        TagName = tagName;
    }
}