using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Item
{
    private string itemID;
    private string name;
    private string description;
    private DateTime postedDate;
    private decimal deposit;
    private decimal pricePerDay;
    private decimal pricePerWeek;
    private decimal pricePerMonth;
    private string img1;
    private string img2;
    private string img3;
    private string img4;
    private Member renter;
    private Category categoryName;

    public Item(string itemID, string name, string description, DateTime postedDate, decimal deposit,
        decimal pricePerDay, decimal pricePerWeek, decimal pricePerMonth, string img1, string img2, string img3, string img4, Member renter, Category categoryName)
    {
        this.itemID = itemID;
        this.name = name;
        this.description = description;
        this.postedDate = postedDate;
        this.deposit = deposit;
        this.pricePerDay = pricePerDay;
        this.pricePerWeek = pricePerWeek;
        this.pricePerMonth = pricePerMonth;
        this.img1 = img1;
        this.img2 = img2;
        this.img3 = img3;
        this.img4 = img4;
        this.renter = renter;
        this.categoryName = categoryName;
    }

    public Item() { }

    public string ItemID { get { return itemID; } set { itemID = value; } }
    public string Name { get { return name; } set { name = value; } }
    public string Description { get { return description; } set { description = value; } }
    public DateTime PostedDate { get { return postedDate; } set { postedDate = value; } }
    public decimal Deposit { get { return deposit; } set { deposit = value; } }
    public decimal PricePerDay { get { return pricePerDay; } set { pricePerDay = value; } }
    public decimal PricePerWeek { get { return pricePerWeek; } set { pricePerWeek = value; } }
    public decimal PricePerMonth { get { return pricePerMonth; } set { pricePerMonth = value; } }
    public string Img1 { get { return img1; } set { img1 = value; } }
    public string Img2 { get { return img2; } set { img2 = value; } }
    public string Img3 { get { return img3; } set { img3 = value; } }
    public string Img4 { get { return img4; } set { img4 = value; } }
    public Member Renter { get { return renter; } set { renter = value; } }
    public Category CategoryName { get { return categoryName; } set { categoryName = value; } }

}