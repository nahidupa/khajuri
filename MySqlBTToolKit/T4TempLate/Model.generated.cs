﻿

 
//---------------------------------------------------------------------------------------------------
//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by BLToolkit template for T4.
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------
using System;

using BLToolkit.Data;
using BLToolkit.Data.Linq;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace Templates
{
	public partial class DataModel : DbManager
	{
		public Table<categories>           categories           { get { return this.GetTable<categories>();           } }
		public Table<customercustomerdemo> customercustomerdemo { get { return this.GetTable<customercustomerdemo>(); } }
		public Table<customerdemographics> customerdemographics { get { return this.GetTable<customerdemographics>(); } }
		public Table<customers>            customers            { get { return this.GetTable<customers>();            } }
		public Table<employees>            employees            { get { return this.GetTable<employees>();            } }
		public Table<employeeterritories>  employeeterritories  { get { return this.GetTable<employeeterritories>();  } }
		public Table<order_details>        order_details        { get { return this.GetTable<order_details>();        } }
		public Table<orders>               orders               { get { return this.GetTable<orders>();               } }
		public Table<products>             products             { get { return this.GetTable<products>();             } }
		public Table<region>               region               { get { return this.GetTable<region>();               } }
		public Table<shippers>             shippers             { get { return this.GetTable<shippers>();             } }
		public Table<shippers_tmp>         shippers_tmp         { get { return this.GetTable<shippers_tmp>();         } }
		public Table<suppliers>            suppliers            { get { return this.GetTable<suppliers>();            } }
		public Table<territories>          territories          { get { return this.GetTable<territories>();          } }
		public Table<usstates>             usstates             { get { return this.GetTable<usstates>();             } }
	}

	[TableName(Name="categories")]
	public partial class categories
	{
		[Identity, PrimaryKey(1)] public int    CategoryID   { get; set; } // int(10)
		                          public string CategoryName { get; set; } // varchar(15)
		[Nullable               ] public string Description  { get; set; } // longtext(4294967295)
		[Nullable               ] public byte[] Picture      { get; set; } // longblob(4294967295)
	}

	[TableName(Name="customercustomerdemo")]
	public partial class customercustomerdemo
	{
		[PrimaryKey(1)] public string CustomerID     { get; set; } // char(5)
		[PrimaryKey(2)] public string CustomerTypeID { get; set; } // char(10)
	}

	[TableName(Name="customerdemographics")]
	public partial class customerdemographics
	{
		[          PrimaryKey(1)] public string CustomerTypeID { get; set; } // char(10)
		[Nullable               ] public string CustomerDesc   { get; set; } // longtext(4294967295)
	}

	[TableName(Name="customers")]
	public partial class customers
	{
		[          PrimaryKey(1)] public string CustomerID   { get; set; } // char(5)
		                          public string CompanyName  { get; set; } // varchar(40)
		[Nullable               ] public string ContactName  { get; set; } // varchar(30)
		[Nullable               ] public string ContactTitle { get; set; } // varchar(30)
		[Nullable               ] public string Address      { get; set; } // varchar(60)
		[Nullable               ] public string City         { get; set; } // varchar(15)
		[Nullable               ] public string Region       { get; set; } // varchar(15)
		[Nullable               ] public string PostalCode   { get; set; } // varchar(10)
		[Nullable               ] public string Country      { get; set; } // varchar(15)
		[Nullable               ] public string Phone        { get; set; } // varchar(24)
		[Nullable               ] public string Fax          { get; set; } // varchar(24)
	}

	[TableName(Name="employees")]
	public partial class employees
	{
		[Identity, PrimaryKey(1)] public int       EmployeeID      { get; set; } // int(10)
		                          public string    LastName        { get; set; } // varchar(20)
		                          public string    FirstName       { get; set; } // varchar(10)
		[Nullable               ] public string    Title           { get; set; } // varchar(30)
		[Nullable               ] public string    TitleOfCourtesy { get; set; } // varchar(25)
		[Nullable               ] public DateTime? BirthDate       { get; set; } // datetime
		[Nullable               ] public DateTime? HireDate        { get; set; } // datetime
		[Nullable               ] public string    Address         { get; set; } // varchar(60)
		[Nullable               ] public string    City            { get; set; } // varchar(15)
		[Nullable               ] public string    Region          { get; set; } // varchar(15)
		[Nullable               ] public string    PostalCode      { get; set; } // varchar(10)
		[Nullable               ] public string    Country         { get; set; } // varchar(15)
		[Nullable               ] public string    HomePhone       { get; set; } // varchar(24)
		[Nullable               ] public string    Extension       { get; set; } // varchar(4)
		[Nullable               ] public byte[]    Photo           { get; set; } // longblob(4294967295)
		[Nullable               ] public string    Notes           { get; set; } // longtext(4294967295)
		[Nullable               ] public int?      ReportsTo       { get; set; } // int(10)
		[Nullable               ] public string    PhotoPath       { get; set; } // varchar(255)
	}

	[TableName(Name="employeeterritories")]
	public partial class employeeterritories
	{
		[PrimaryKey(1)] public int    EmployeeID  { get; set; } // int(10)
		[PrimaryKey(2)] public string TerritoryID { get; set; } // varchar(20)
	}

	[TableName(Name="order_details")]
	public partial class order_details
	{
		[PrimaryKey(1)] public int     OrderID   { get; set; } // int(10)
		[PrimaryKey(2)] public int     ProductID { get; set; } // int(10)
		                public decimal UnitPrice { get; set; } // decimal(19,4)
		                public short   Quantity  { get; set; } // smallint(5)
		                public float   Discount  { get; set; } // float(12)
	}

	[TableName(Name="orders")]
	public partial class orders
	{
		[Identity, PrimaryKey(1)] public int       OrderID        { get; set; } // int(10)
		[Nullable               ] public string    CustomerID     { get; set; } // char(5)
		[Nullable               ] public int?      EmployeeID     { get; set; } // int(10)
		[Nullable               ] public DateTime? OrderDate      { get; set; } // datetime
		[Nullable               ] public DateTime? RequiredDate   { get; set; } // datetime
		[Nullable               ] public DateTime? ShippedDate    { get; set; } // datetime
		[Nullable               ] public int?      ShipVia        { get; set; } // int(10)
		[Nullable               ] public decimal?  Freight        { get; set; } // decimal(19,4)
		[Nullable               ] public string    ShipName       { get; set; } // varchar(40)
		[Nullable               ] public string    ShipAddress    { get; set; } // varchar(60)
		[Nullable               ] public string    ShipCity       { get; set; } // varchar(15)
		[Nullable               ] public string    ShipRegion     { get; set; } // varchar(15)
		[Nullable               ] public string    ShipPostalCode { get; set; } // varchar(10)
		[Nullable               ] public string    ShipCountry    { get; set; } // varchar(15)
	}

	[TableName(Name="products")]
	public partial class products
	{
		[Identity, PrimaryKey(1)] public int      ProductID       { get; set; } // int(10)
		                          public string   ProductName     { get; set; } // varchar(40)
		[Nullable               ] public int?     SupplierID      { get; set; } // int(10)
		[Nullable               ] public int?     CategoryID      { get; set; } // int(10)
		[Nullable               ] public string   QuantityPerUnit { get; set; } // varchar(20)
		[Nullable               ] public decimal? UnitPrice       { get; set; } // decimal(19,4)
		[Nullable               ] public short?   UnitsInStock    { get; set; } // smallint(5)
		[Nullable               ] public short?   UnitsOnOrder    { get; set; } // smallint(5)
		[Nullable               ] public short?   ReorderLevel    { get; set; } // smallint(5)
		                          public sbyte    Discontinued    { get; set; } // tinyint(3)
	}

	[TableName(Name="region")]
	public partial class region
	{
		[PrimaryKey(1)] public int    RegionID          { get; set; } // int(10)
		                public string RegionDescription { get; set; } // char(50)
	}

	[TableName(Name="shippers")]
	public partial class shippers
	{
		[Identity, PrimaryKey(1)] public int    ShipperID   { get; set; } // int(10)
		                          public string CompanyName { get; set; } // varchar(40)
		[Nullable               ] public string Phone       { get; set; } // varchar(24)
	}

	[TableName(Name="shippers_tmp")]
	public partial class shippers_tmp
	{
		[Identity, PrimaryKey(1)] public int    ShipperID   { get; set; } // int(10)
		                          public string CompanyName { get; set; } // varchar(40)
		[Nullable               ] public string Phone       { get; set; } // varchar(24)
	}

	[TableName(Name="suppliers")]
	public partial class suppliers
	{
		[Identity, PrimaryKey(1)] public int    SupplierID   { get; set; } // int(10)
		                          public string CompanyName  { get; set; } // varchar(40)
		[Nullable               ] public string ContactName  { get; set; } // varchar(30)
		[Nullable               ] public string ContactTitle { get; set; } // varchar(30)
		[Nullable               ] public string Address      { get; set; } // varchar(60)
		[Nullable               ] public string City         { get; set; } // varchar(15)
		[Nullable               ] public string Region       { get; set; } // varchar(15)
		[Nullable               ] public string PostalCode   { get; set; } // varchar(10)
		[Nullable               ] public string Country      { get; set; } // varchar(15)
		[Nullable               ] public string Phone        { get; set; } // varchar(24)
		[Nullable               ] public string Fax          { get; set; } // varchar(24)
		[Nullable               ] public string HomePage     { get; set; } // longtext(4294967295)
	}

	[TableName(Name="territories")]
	public partial class territories
	{
		[PrimaryKey(1)] public string TerritoryID          { get; set; } // varchar(20)
		                public string TerritoryDescription { get; set; } // char(50)
		                public int    RegionID             { get; set; } // int(10)
	}

	[TableName(Name="usstates")]
	public partial class usstates
	{
		           public int    StateID     { get; set; } // int(10)
		[Nullable] public string StateName   { get; set; } // varchar(100)
		[Nullable] public string StateAbbr   { get; set; } // varchar(2)
		[Nullable] public string StateRegion { get; set; } // varchar(50)
	}
}
