using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationService.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder builder)
        {
            DropTables(builder);
            var sql = @"create table dbo.SecurityUser(
                        	Id int not null,
                        	UserName nvarchar(500) not null,
                        	Password nvarchar(max) not null,
                            constraint PK_SecurityUser primary key clustered ( Id asc ),
                            constraint UNIQUE_SecurityUser_UserName unique(UserName)
                        )
                        go
                        
                        create table SecurityRole(
                        	Id int not null,
                        	Name nvarchar(500) not null,
                        	constraint PK_SecurityRole primary key clustered ( Id asc )
                        )
                        
                        go
                        
                        create table SecurityUserRole(
                        	SecurityUserId int not null,
                        	SecurityRoleId int not null,
                        	constraint FK_SecurityRole_SecurityUserId foreign key (SecurityUserId) references SecurityUser (Id),
                        	constraint FK_SecurityRole_SecurityRoleId foreign key (SecurityRoleId) references SecurityRole (Id)
                        )
                        go
                        ";

            builder.Sql(sql);
        }

        protected override void Down(MigrationBuilder builder)
        {
            DropTables(builder);
        }

        private void DropTables(MigrationBuilder builder)
        {
            builder.Sql(@"if exists (select 1 from sys.tables where name = 'SecurityUserRole')
                            drop table SecurityUserRole");

            builder.Sql(@"if exists (select 1 from sys.tables where name = 'SecurityUser')
                            drop table SecurityUser");

            builder.Sql(@"if exists (select 1 from sys.tables where name = 'SecurityRole')
                            drop table SecurityRole");
        }
    }
}
