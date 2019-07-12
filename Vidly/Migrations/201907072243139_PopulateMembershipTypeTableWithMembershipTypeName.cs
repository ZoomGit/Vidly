namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypeTableWithMembershipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET MembershipTypeName='Pay As You Go'WHERE MembershipTypeId=1");
            Sql("UPDATE MembershipTypes SET MembershipTypeName='Monthly'WHERE MembershipTypeId=2");
            Sql("UPDATE MembershipTypes SET MembershipTypeName='Quartly'WHERE MembershipTypeId=3");
            Sql("UPDATE MembershipTypes SET MembershipTypeName='Annual'WHERE MembershipTypeId=4");
        }
        
        public override void Down()
        {
        }
    }
}
