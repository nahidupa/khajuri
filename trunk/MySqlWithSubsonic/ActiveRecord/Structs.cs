


using System;
using SubSonic.Schema;
using System.Collections.Generic;
using SubSonic.DataProviders;
using System.Data;

namespace Northwind.Data {
	
        /// <summary>
        /// Table: categories
        /// Primary Key: CategoryID
        /// </summary>

        public class categoriesTable: DatabaseTable {
            
            public categoriesTable(IDataProvider provider):base("categories",provider){
                ClassName = "category";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("CategoryID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CategoryName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 15
                });

                Columns.Add(new DatabaseColumn("Description", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Picture", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Object,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn CategoryID{
                get{
                    return this.GetColumn("CategoryID");
                }
            }
				
   			public static string CategoryIDColumn{
			      get{
        			return "CategoryID";
      			}
		    }
            
            public IColumn CategoryName{
                get{
                    return this.GetColumn("CategoryName");
                }
            }
				
   			public static string CategoryNameColumn{
			      get{
        			return "CategoryName";
      			}
		    }
            
            public IColumn Description{
                get{
                    return this.GetColumn("Description");
                }
            }
				
   			public static string DescriptionColumn{
			      get{
        			return "Description";
      			}
		    }
            
            public IColumn Picture{
                get{
                    return this.GetColumn("Picture");
                }
            }
				
   			public static string PictureColumn{
			      get{
        			return "Picture";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: customercustomerdemo
        /// Primary Key: CustomerTypeID
        /// </summary>

        public class customercustomerdemoTable: DatabaseTable {
            
            public customercustomerdemoTable(IDataProvider provider):base("customercustomerdemo",provider){
                ClassName = "customercustomerdemo";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("CustomerID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 5
                });

                Columns.Add(new DatabaseColumn("CustomerTypeID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10
                });
                    
                
                
            }

            public IColumn CustomerID{
                get{
                    return this.GetColumn("CustomerID");
                }
            }
				
   			public static string CustomerIDColumn{
			      get{
        			return "CustomerID";
      			}
		    }
            
            public IColumn CustomerTypeID{
                get{
                    return this.GetColumn("CustomerTypeID");
                }
            }
				
   			public static string CustomerTypeIDColumn{
			      get{
        			return "CustomerTypeID";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: customerdemographics
        /// Primary Key: CustomerTypeID
        /// </summary>

        public class customerdemographicsTable: DatabaseTable {
            
            public customerdemographicsTable(IDataProvider provider):base("customerdemographics",provider){
                ClassName = "customerdemographic";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("CustomerTypeID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10
                });

                Columns.Add(new DatabaseColumn("CustomerDesc", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn CustomerTypeID{
                get{
                    return this.GetColumn("CustomerTypeID");
                }
            }
				
   			public static string CustomerTypeIDColumn{
			      get{
        			return "CustomerTypeID";
      			}
		    }
            
            public IColumn CustomerDesc{
                get{
                    return this.GetColumn("CustomerDesc");
                }
            }
				
   			public static string CustomerDescColumn{
			      get{
        			return "CustomerDesc";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: customers
        /// Primary Key: CustomerID
        /// </summary>

        public class customersTable: DatabaseTable {
            
            public customersTable(IDataProvider provider):base("customers",provider){
                ClassName = "customer";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("CustomerID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 5
                });

                Columns.Add(new DatabaseColumn("CompanyName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40
                });

                Columns.Add(new DatabaseColumn("ContactName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30
                });

                Columns.Add(new DatabaseColumn("ContactTitle", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30
                });

                Columns.Add(new DatabaseColumn("Address", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 60
                });

                Columns.Add(new DatabaseColumn("City", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 15
                });

                Columns.Add(new DatabaseColumn("Region", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 15
                });

                Columns.Add(new DatabaseColumn("PostalCode", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10
                });

                Columns.Add(new DatabaseColumn("Country", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 15
                });

                Columns.Add(new DatabaseColumn("Phone", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 24
                });

                Columns.Add(new DatabaseColumn("Fax", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 24
                });
                    
                
                
            }

            public IColumn CustomerID{
                get{
                    return this.GetColumn("CustomerID");
                }
            }
				
   			public static string CustomerIDColumn{
			      get{
        			return "CustomerID";
      			}
		    }
            
            public IColumn CompanyName{
                get{
                    return this.GetColumn("CompanyName");
                }
            }
				
   			public static string CompanyNameColumn{
			      get{
        			return "CompanyName";
      			}
		    }
            
            public IColumn ContactName{
                get{
                    return this.GetColumn("ContactName");
                }
            }
				
   			public static string ContactNameColumn{
			      get{
        			return "ContactName";
      			}
		    }
            
            public IColumn ContactTitle{
                get{
                    return this.GetColumn("ContactTitle");
                }
            }
				
   			public static string ContactTitleColumn{
			      get{
        			return "ContactTitle";
      			}
		    }
            
            public IColumn Address{
                get{
                    return this.GetColumn("Address");
                }
            }
				
   			public static string AddressColumn{
			      get{
        			return "Address";
      			}
		    }
            
            public IColumn City{
                get{
                    return this.GetColumn("City");
                }
            }
				
   			public static string CityColumn{
			      get{
        			return "City";
      			}
		    }
            
            public IColumn Region{
                get{
                    return this.GetColumn("Region");
                }
            }
				
   			public static string RegionColumn{
			      get{
        			return "Region";
      			}
		    }
            
            public IColumn PostalCode{
                get{
                    return this.GetColumn("PostalCode");
                }
            }
				
   			public static string PostalCodeColumn{
			      get{
        			return "PostalCode";
      			}
		    }
            
            public IColumn Country{
                get{
                    return this.GetColumn("Country");
                }
            }
				
   			public static string CountryColumn{
			      get{
        			return "Country";
      			}
		    }
            
            public IColumn Phone{
                get{
                    return this.GetColumn("Phone");
                }
            }
				
   			public static string PhoneColumn{
			      get{
        			return "Phone";
      			}
		    }
            
            public IColumn Fax{
                get{
                    return this.GetColumn("Fax");
                }
            }
				
   			public static string FaxColumn{
			      get{
        			return "Fax";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: employees
        /// Primary Key: EmployeeID
        /// </summary>

        public class employeesTable: DatabaseTable {
            
            public employeesTable(IDataProvider provider):base("employees",provider){
                ClassName = "employee";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("EmployeeID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("LastName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("FirstName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10
                });

                Columns.Add(new DatabaseColumn("Title", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30
                });

                Columns.Add(new DatabaseColumn("TitleOfCourtesy", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 25
                });

                Columns.Add(new DatabaseColumn("BirthDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("HireDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Address", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 60
                });

                Columns.Add(new DatabaseColumn("City", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 15
                });

                Columns.Add(new DatabaseColumn("Region", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 15
                });

                Columns.Add(new DatabaseColumn("PostalCode", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10
                });

                Columns.Add(new DatabaseColumn("Country", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 15
                });

                Columns.Add(new DatabaseColumn("HomePhone", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 24
                });

                Columns.Add(new DatabaseColumn("Extension", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 4
                });

                Columns.Add(new DatabaseColumn("Photo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Object,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Notes", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ReportsTo", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("PhotoPath", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 255
                });
                    
                
                
            }

            public IColumn EmployeeID{
                get{
                    return this.GetColumn("EmployeeID");
                }
            }
				
   			public static string EmployeeIDColumn{
			      get{
        			return "EmployeeID";
      			}
		    }
            
            public IColumn LastName{
                get{
                    return this.GetColumn("LastName");
                }
            }
				
   			public static string LastNameColumn{
			      get{
        			return "LastName";
      			}
		    }
            
            public IColumn FirstName{
                get{
                    return this.GetColumn("FirstName");
                }
            }
				
   			public static string FirstNameColumn{
			      get{
        			return "FirstName";
      			}
		    }
            
            public IColumn Title{
                get{
                    return this.GetColumn("Title");
                }
            }
				
   			public static string TitleColumn{
			      get{
        			return "Title";
      			}
		    }
            
            public IColumn TitleOfCourtesy{
                get{
                    return this.GetColumn("TitleOfCourtesy");
                }
            }
				
   			public static string TitleOfCourtesyColumn{
			      get{
        			return "TitleOfCourtesy";
      			}
		    }
            
            public IColumn BirthDate{
                get{
                    return this.GetColumn("BirthDate");
                }
            }
				
   			public static string BirthDateColumn{
			      get{
        			return "BirthDate";
      			}
		    }
            
            public IColumn HireDate{
                get{
                    return this.GetColumn("HireDate");
                }
            }
				
   			public static string HireDateColumn{
			      get{
        			return "HireDate";
      			}
		    }
            
            public IColumn Address{
                get{
                    return this.GetColumn("Address");
                }
            }
				
   			public static string AddressColumn{
			      get{
        			return "Address";
      			}
		    }
            
            public IColumn City{
                get{
                    return this.GetColumn("City");
                }
            }
				
   			public static string CityColumn{
			      get{
        			return "City";
      			}
		    }
            
            public IColumn Region{
                get{
                    return this.GetColumn("Region");
                }
            }
				
   			public static string RegionColumn{
			      get{
        			return "Region";
      			}
		    }
            
            public IColumn PostalCode{
                get{
                    return this.GetColumn("PostalCode");
                }
            }
				
   			public static string PostalCodeColumn{
			      get{
        			return "PostalCode";
      			}
		    }
            
            public IColumn Country{
                get{
                    return this.GetColumn("Country");
                }
            }
				
   			public static string CountryColumn{
			      get{
        			return "Country";
      			}
		    }
            
            public IColumn HomePhone{
                get{
                    return this.GetColumn("HomePhone");
                }
            }
				
   			public static string HomePhoneColumn{
			      get{
        			return "HomePhone";
      			}
		    }
            
            public IColumn Extension{
                get{
                    return this.GetColumn("Extension");
                }
            }
				
   			public static string ExtensionColumn{
			      get{
        			return "Extension";
      			}
		    }
            
            public IColumn Photo{
                get{
                    return this.GetColumn("Photo");
                }
            }
				
   			public static string PhotoColumn{
			      get{
        			return "Photo";
      			}
		    }
            
            public IColumn Notes{
                get{
                    return this.GetColumn("Notes");
                }
            }
				
   			public static string NotesColumn{
			      get{
        			return "Notes";
      			}
		    }
            
            public IColumn ReportsTo{
                get{
                    return this.GetColumn("ReportsTo");
                }
            }
				
   			public static string ReportsToColumn{
			      get{
        			return "ReportsTo";
      			}
		    }
            
            public IColumn PhotoPath{
                get{
                    return this.GetColumn("PhotoPath");
                }
            }
				
   			public static string PhotoPathColumn{
			      get{
        			return "PhotoPath";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: employeeterritories
        /// Primary Key: TerritoryID
        /// </summary>

        public class employeeterritoriesTable: DatabaseTable {
            
            public employeeterritoriesTable(IDataProvider provider):base("employeeterritories",provider){
                ClassName = "employeeterritory";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("EmployeeID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("TerritoryID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });
                    
                
                
            }

            public IColumn EmployeeID{
                get{
                    return this.GetColumn("EmployeeID");
                }
            }
				
   			public static string EmployeeIDColumn{
			      get{
        			return "EmployeeID";
      			}
		    }
            
            public IColumn TerritoryID{
                get{
                    return this.GetColumn("TerritoryID");
                }
            }
				
   			public static string TerritoryIDColumn{
			      get{
        			return "TerritoryID";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: order_details
        /// Primary Key: ProductID
        /// </summary>

        public class order_detailsTable: DatabaseTable {
            
            public order_detailsTable(IDataProvider provider):base("order_details",provider){
                ClassName = "order_detail";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("OrderID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ProductID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("UnitPrice", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Quantity", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Discount", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn OrderID{
                get{
                    return this.GetColumn("OrderID");
                }
            }
				
   			public static string OrderIDColumn{
			      get{
        			return "OrderID";
      			}
		    }
            
            public IColumn ProductID{
                get{
                    return this.GetColumn("ProductID");
                }
            }
				
   			public static string ProductIDColumn{
			      get{
        			return "ProductID";
      			}
		    }
            
            public IColumn UnitPrice{
                get{
                    return this.GetColumn("UnitPrice");
                }
            }
				
   			public static string UnitPriceColumn{
			      get{
        			return "UnitPrice";
      			}
		    }
            
            public IColumn Quantity{
                get{
                    return this.GetColumn("Quantity");
                }
            }
				
   			public static string QuantityColumn{
			      get{
        			return "Quantity";
      			}
		    }
            
            public IColumn Discount{
                get{
                    return this.GetColumn("Discount");
                }
            }
				
   			public static string DiscountColumn{
			      get{
        			return "Discount";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: orders
        /// Primary Key: OrderID
        /// </summary>

        public class ordersTable: DatabaseTable {
            
            public ordersTable(IDataProvider provider):base("orders",provider){
                ClassName = "order";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("OrderID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CustomerID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 5
                });

                Columns.Add(new DatabaseColumn("EmployeeID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("OrderDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("RequiredDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ShippedDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ShipVia", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Freight", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ShipName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40
                });

                Columns.Add(new DatabaseColumn("ShipAddress", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 60
                });

                Columns.Add(new DatabaseColumn("ShipCity", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 15
                });

                Columns.Add(new DatabaseColumn("ShipRegion", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 15
                });

                Columns.Add(new DatabaseColumn("ShipPostalCode", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10
                });

                Columns.Add(new DatabaseColumn("ShipCountry", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 15
                });
                    
                
                
            }

            public IColumn OrderID{
                get{
                    return this.GetColumn("OrderID");
                }
            }
				
   			public static string OrderIDColumn{
			      get{
        			return "OrderID";
      			}
		    }
            
            public IColumn CustomerID{
                get{
                    return this.GetColumn("CustomerID");
                }
            }
				
   			public static string CustomerIDColumn{
			      get{
        			return "CustomerID";
      			}
		    }
            
            public IColumn EmployeeID{
                get{
                    return this.GetColumn("EmployeeID");
                }
            }
				
   			public static string EmployeeIDColumn{
			      get{
        			return "EmployeeID";
      			}
		    }
            
            public IColumn OrderDate{
                get{
                    return this.GetColumn("OrderDate");
                }
            }
				
   			public static string OrderDateColumn{
			      get{
        			return "OrderDate";
      			}
		    }
            
            public IColumn RequiredDate{
                get{
                    return this.GetColumn("RequiredDate");
                }
            }
				
   			public static string RequiredDateColumn{
			      get{
        			return "RequiredDate";
      			}
		    }
            
            public IColumn ShippedDate{
                get{
                    return this.GetColumn("ShippedDate");
                }
            }
				
   			public static string ShippedDateColumn{
			      get{
        			return "ShippedDate";
      			}
		    }
            
            public IColumn ShipVia{
                get{
                    return this.GetColumn("ShipVia");
                }
            }
				
   			public static string ShipViaColumn{
			      get{
        			return "ShipVia";
      			}
		    }
            
            public IColumn Freight{
                get{
                    return this.GetColumn("Freight");
                }
            }
				
   			public static string FreightColumn{
			      get{
        			return "Freight";
      			}
		    }
            
            public IColumn ShipName{
                get{
                    return this.GetColumn("ShipName");
                }
            }
				
   			public static string ShipNameColumn{
			      get{
        			return "ShipName";
      			}
		    }
            
            public IColumn ShipAddress{
                get{
                    return this.GetColumn("ShipAddress");
                }
            }
				
   			public static string ShipAddressColumn{
			      get{
        			return "ShipAddress";
      			}
		    }
            
            public IColumn ShipCity{
                get{
                    return this.GetColumn("ShipCity");
                }
            }
				
   			public static string ShipCityColumn{
			      get{
        			return "ShipCity";
      			}
		    }
            
            public IColumn ShipRegion{
                get{
                    return this.GetColumn("ShipRegion");
                }
            }
				
   			public static string ShipRegionColumn{
			      get{
        			return "ShipRegion";
      			}
		    }
            
            public IColumn ShipPostalCode{
                get{
                    return this.GetColumn("ShipPostalCode");
                }
            }
				
   			public static string ShipPostalCodeColumn{
			      get{
        			return "ShipPostalCode";
      			}
		    }
            
            public IColumn ShipCountry{
                get{
                    return this.GetColumn("ShipCountry");
                }
            }
				
   			public static string ShipCountryColumn{
			      get{
        			return "ShipCountry";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: products
        /// Primary Key: ProductID
        /// </summary>

        public class productsTable: DatabaseTable {
            
            public productsTable(IDataProvider provider):base("products",provider){
                ClassName = "product";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("ProductID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ProductName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40
                });

                Columns.Add(new DatabaseColumn("SupplierID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CategoryID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("QuantityPerUnit", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("UnitPrice", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Decimal,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("UnitsInStock", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("UnitsOnOrder", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ReorderLevel", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int16,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Discontinued", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.SByte,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn ProductID{
                get{
                    return this.GetColumn("ProductID");
                }
            }
				
   			public static string ProductIDColumn{
			      get{
        			return "ProductID";
      			}
		    }
            
            public IColumn ProductName{
                get{
                    return this.GetColumn("ProductName");
                }
            }
				
   			public static string ProductNameColumn{
			      get{
        			return "ProductName";
      			}
		    }
            
            public IColumn SupplierID{
                get{
                    return this.GetColumn("SupplierID");
                }
            }
				
   			public static string SupplierIDColumn{
			      get{
        			return "SupplierID";
      			}
		    }
            
            public IColumn CategoryID{
                get{
                    return this.GetColumn("CategoryID");
                }
            }
				
   			public static string CategoryIDColumn{
			      get{
        			return "CategoryID";
      			}
		    }
            
            public IColumn QuantityPerUnit{
                get{
                    return this.GetColumn("QuantityPerUnit");
                }
            }
				
   			public static string QuantityPerUnitColumn{
			      get{
        			return "QuantityPerUnit";
      			}
		    }
            
            public IColumn UnitPrice{
                get{
                    return this.GetColumn("UnitPrice");
                }
            }
				
   			public static string UnitPriceColumn{
			      get{
        			return "UnitPrice";
      			}
		    }
            
            public IColumn UnitsInStock{
                get{
                    return this.GetColumn("UnitsInStock");
                }
            }
				
   			public static string UnitsInStockColumn{
			      get{
        			return "UnitsInStock";
      			}
		    }
            
            public IColumn UnitsOnOrder{
                get{
                    return this.GetColumn("UnitsOnOrder");
                }
            }
				
   			public static string UnitsOnOrderColumn{
			      get{
        			return "UnitsOnOrder";
      			}
		    }
            
            public IColumn ReorderLevel{
                get{
                    return this.GetColumn("ReorderLevel");
                }
            }
				
   			public static string ReorderLevelColumn{
			      get{
        			return "ReorderLevel";
      			}
		    }
            
            public IColumn Discontinued{
                get{
                    return this.GetColumn("Discontinued");
                }
            }
				
   			public static string DiscontinuedColumn{
			      get{
        			return "Discontinued";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: region
        /// Primary Key: RegionID
        /// </summary>

        public class regionTable: DatabaseTable {
            
            public regionTable(IDataProvider provider):base("region",provider){
                ClassName = "region";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("RegionID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("RegionDescription", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });
                    
                
                
            }

            public IColumn RegionID{
                get{
                    return this.GetColumn("RegionID");
                }
            }
				
   			public static string RegionIDColumn{
			      get{
        			return "RegionID";
      			}
		    }
            
            public IColumn RegionDescription{
                get{
                    return this.GetColumn("RegionDescription");
                }
            }
				
   			public static string RegionDescriptionColumn{
			      get{
        			return "RegionDescription";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: shippers
        /// Primary Key: ShipperID
        /// </summary>

        public class shippersTable: DatabaseTable {
            
            public shippersTable(IDataProvider provider):base("shippers",provider){
                ClassName = "shipper";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("ShipperID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CompanyName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40
                });

                Columns.Add(new DatabaseColumn("Phone", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 24
                });
                    
                
                
            }

            public IColumn ShipperID{
                get{
                    return this.GetColumn("ShipperID");
                }
            }
				
   			public static string ShipperIDColumn{
			      get{
        			return "ShipperID";
      			}
		    }
            
            public IColumn CompanyName{
                get{
                    return this.GetColumn("CompanyName");
                }
            }
				
   			public static string CompanyNameColumn{
			      get{
        			return "CompanyName";
      			}
		    }
            
            public IColumn Phone{
                get{
                    return this.GetColumn("Phone");
                }
            }
				
   			public static string PhoneColumn{
			      get{
        			return "Phone";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: shippers_tmp
        /// Primary Key: ShipperID
        /// </summary>

        public class shippers_tmpTable: DatabaseTable {
            
            public shippers_tmpTable(IDataProvider provider):base("shippers_tmp",provider){
                ClassName = "shippers_tmp";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("ShipperID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CompanyName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40
                });

                Columns.Add(new DatabaseColumn("Phone", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 24
                });
                    
                
                
            }

            public IColumn ShipperID{
                get{
                    return this.GetColumn("ShipperID");
                }
            }
				
   			public static string ShipperIDColumn{
			      get{
        			return "ShipperID";
      			}
		    }
            
            public IColumn CompanyName{
                get{
                    return this.GetColumn("CompanyName");
                }
            }
				
   			public static string CompanyNameColumn{
			      get{
        			return "CompanyName";
      			}
		    }
            
            public IColumn Phone{
                get{
                    return this.GetColumn("Phone");
                }
            }
				
   			public static string PhoneColumn{
			      get{
        			return "Phone";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: suppliers
        /// Primary Key: SupplierID
        /// </summary>

        public class suppliersTable: DatabaseTable {
            
            public suppliersTable(IDataProvider provider):base("suppliers",provider){
                ClassName = "supplier";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("SupplierID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("CompanyName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 40
                });

                Columns.Add(new DatabaseColumn("ContactName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30
                });

                Columns.Add(new DatabaseColumn("ContactTitle", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 30
                });

                Columns.Add(new DatabaseColumn("Address", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 60
                });

                Columns.Add(new DatabaseColumn("City", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 15
                });

                Columns.Add(new DatabaseColumn("Region", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 15
                });

                Columns.Add(new DatabaseColumn("PostalCode", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10
                });

                Columns.Add(new DatabaseColumn("Country", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 15
                });

                Columns.Add(new DatabaseColumn("Phone", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 24
                });

                Columns.Add(new DatabaseColumn("Fax", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 24
                });

                Columns.Add(new DatabaseColumn("HomePage", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.String,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn SupplierID{
                get{
                    return this.GetColumn("SupplierID");
                }
            }
				
   			public static string SupplierIDColumn{
			      get{
        			return "SupplierID";
      			}
		    }
            
            public IColumn CompanyName{
                get{
                    return this.GetColumn("CompanyName");
                }
            }
				
   			public static string CompanyNameColumn{
			      get{
        			return "CompanyName";
      			}
		    }
            
            public IColumn ContactName{
                get{
                    return this.GetColumn("ContactName");
                }
            }
				
   			public static string ContactNameColumn{
			      get{
        			return "ContactName";
      			}
		    }
            
            public IColumn ContactTitle{
                get{
                    return this.GetColumn("ContactTitle");
                }
            }
				
   			public static string ContactTitleColumn{
			      get{
        			return "ContactTitle";
      			}
		    }
            
            public IColumn Address{
                get{
                    return this.GetColumn("Address");
                }
            }
				
   			public static string AddressColumn{
			      get{
        			return "Address";
      			}
		    }
            
            public IColumn City{
                get{
                    return this.GetColumn("City");
                }
            }
				
   			public static string CityColumn{
			      get{
        			return "City";
      			}
		    }
            
            public IColumn Region{
                get{
                    return this.GetColumn("Region");
                }
            }
				
   			public static string RegionColumn{
			      get{
        			return "Region";
      			}
		    }
            
            public IColumn PostalCode{
                get{
                    return this.GetColumn("PostalCode");
                }
            }
				
   			public static string PostalCodeColumn{
			      get{
        			return "PostalCode";
      			}
		    }
            
            public IColumn Country{
                get{
                    return this.GetColumn("Country");
                }
            }
				
   			public static string CountryColumn{
			      get{
        			return "Country";
      			}
		    }
            
            public IColumn Phone{
                get{
                    return this.GetColumn("Phone");
                }
            }
				
   			public static string PhoneColumn{
			      get{
        			return "Phone";
      			}
		    }
            
            public IColumn Fax{
                get{
                    return this.GetColumn("Fax");
                }
            }
				
   			public static string FaxColumn{
			      get{
        			return "Fax";
      			}
		    }
            
            public IColumn HomePage{
                get{
                    return this.GetColumn("HomePage");
                }
            }
				
   			public static string HomePageColumn{
			      get{
        			return "HomePage";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: territories
        /// Primary Key: TerritoryID
        /// </summary>

        public class territoriesTable: DatabaseTable {
            
            public territoriesTable(IDataProvider provider):base("territories",provider){
                ClassName = "territory";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("TerritoryID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.AnsiString,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 20
                });

                Columns.Add(new DatabaseColumn("TerritoryDescription", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiStringFixedLength,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("RegionID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn TerritoryID{
                get{
                    return this.GetColumn("TerritoryID");
                }
            }
				
   			public static string TerritoryIDColumn{
			      get{
        			return "TerritoryID";
      			}
		    }
            
            public IColumn TerritoryDescription{
                get{
                    return this.GetColumn("TerritoryDescription");
                }
            }
				
   			public static string TerritoryDescriptionColumn{
			      get{
        			return "TerritoryDescription";
      			}
		    }
            
            public IColumn RegionID{
                get{
                    return this.GetColumn("RegionID");
                }
            }
				
   			public static string RegionIDColumn{
			      get{
        			return "RegionID";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: usstates
        /// Primary Key: 
        /// </summary>

        public class usstatesTable: DatabaseTable {
            
            public usstatesTable(IDataProvider provider):base("usstates",provider){
                ClassName = "usstate";
                SchemaName = "";
                

                Columns.Add(new DatabaseColumn("StateID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("StateName", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("StateAbbr", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 2
                });

                Columns.Add(new DatabaseColumn("StateRegion", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });
                    
                
                
            }

            public IColumn StateID{
                get{
                    return this.GetColumn("StateID");
                }
            }
				
   			public static string StateIDColumn{
			      get{
        			return "StateID";
      			}
		    }
            
            public IColumn StateName{
                get{
                    return this.GetColumn("StateName");
                }
            }
				
   			public static string StateNameColumn{
			      get{
        			return "StateName";
      			}
		    }
            
            public IColumn StateAbbr{
                get{
                    return this.GetColumn("StateAbbr");
                }
            }
				
   			public static string StateAbbrColumn{
			      get{
        			return "StateAbbr";
      			}
		    }
            
            public IColumn StateRegion{
                get{
                    return this.GetColumn("StateRegion");
                }
            }
				
   			public static string StateRegionColumn{
			      get{
        			return "StateRegion";
      			}
		    }
            
                    
        }
        
}