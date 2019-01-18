namespace RemoteAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        addressID = c.Int(nullable: false, identity: true),
                        compName = c.String(nullable: false, maxLength: 100),
                        compAdress = c.String(nullable: false, maxLength: 100),
                        description = c.String(maxLength: 200),
                        image = c.String(),
                    })
                .PrimaryKey(t => t.addressID);
            
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        adName = c.String(nullable: false, maxLength: 50),
                        adPass = c.String(nullable: false, maxLength: 50),
                        adRole = c.Boolean(nullable: false),
                        adImage = c.String(),
                    })
                .PrimaryKey(t => t.adName);
            
            CreateTable(
                "dbo.Bill",
                c => new
                    {
                        billID = c.Int(nullable: false, identity: true),
                        billPhone = c.String(nullable: false, maxLength: 11),
                        billCusName = c.String(nullable: false, maxLength: 50),
                        billDes = c.String(nullable: false, maxLength: 100),
                        billDate = c.DateTime(nullable: false),
                        billTotal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.billID);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        fbID = c.Int(nullable: false, identity: true),
                        fbCusname = c.String(nullable: false, maxLength: 50),
                        memPhone = c.String(nullable: false, maxLength: 11),
                        memEmail = c.String(nullable: false),
                        fbObject = c.Boolean(nullable: false),
                        fbContent = c.String(nullable: false, maxLength: 1000),
                        fbStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.fbID);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        memPhone = c.String(nullable: false, maxLength: 11),
                        memName = c.String(nullable: false, maxLength: 50),
                        memEmail = c.String(nullable: false),
                        memPass = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.memPhone);
            
            CreateTable(
                "dbo.Payment",
                c => new
                    {
                        payID = c.Int(nullable: false, identity: true),
                        memPhone = c.String(nullable: false, maxLength: 11),
                        payCardNum = c.String(nullable: false, maxLength: 20),
                        payType = c.String(nullable: false, maxLength: 20),
                        payExDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.payID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        pID = c.Int(nullable: false, identity: true),
                        pName = c.String(nullable: false, maxLength: 50),
                        pType = c.Boolean(nullable: false),
                        pDes = c.String(nullable: false, maxLength: 100),
                        pPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.pID);
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        sID = c.Int(nullable: false, identity: true),
                        sName = c.String(nullable: false, maxLength: 50),
                        sDes = c.String(nullable: false, maxLength: 100),
                        sPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.sID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Service");
            DropTable("dbo.Product");
            DropTable("dbo.Payment");
            DropTable("dbo.Member");
            DropTable("dbo.Feedback");
            DropTable("dbo.Bill");
            DropTable("dbo.Admin");
            DropTable("dbo.Address");
        }
    }
}
