namespace EntityFrameworkBasedService.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            // use resources (sql commands in file) for migration
            // it usefull when database already exists with some structure
            SqlResource("EntityFrameworkBasedService.Context.Migrations.InitialCreate.sql");

            /* 
             * alternative way
             * 
            CreateTable(
                "payments.Commissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaymentServiceId = c.Int(),
                        PointId = c.Int(),
                        Level = c.Int(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        MinCommission = c.Decimal(storeType: "money"),
                        Formula = c.String(maxLength: 4096, unicode: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            */
            
        }
        
        public override void Down()
        {
            DropTable("payments.Commissions");
        }
    }
}
