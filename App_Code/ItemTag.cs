using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ItemTag
{
    // properties of ItemTag
    public Item Item { get; set; }
    public string TagName { get; set; }

    // empty ItemTag constructor
    public ItemTag()
    {
        
    }

    // constructor of ItemTag
    public ItemTag(Item item, string tagName)
    {
        Item = item;
        TagName = tagName;
    }
}