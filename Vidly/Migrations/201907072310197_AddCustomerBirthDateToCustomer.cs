namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerBirthDateToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CustomerBirthGate", c => c.DateTime(nullable:true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "CustomerBirthGate");
        }
    }
}
