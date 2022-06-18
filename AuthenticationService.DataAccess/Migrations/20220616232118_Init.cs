using Microsoft.EntityFrameworkCore.Migrations;

namespace AuthenticationService.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder builder)
        {
            DropTables(builder);
            var sql = @"
                        create table SecurityUser(
                        Id int not null,
                        UserName nvarchar(500) not null,
                        Password nvarchar(max) not null,
                        constraint PK_User primary key clustered ( Id asc ),
                        )
                        go
                        
                        create table SecurityRole(
                        	Id int not null,
                        	Name nvarchar(500) not null,
                        	constraint PK_Role primary key clustered ( Id asc )
                        )
                        go
                        
                        create table SecurityUserRole(
                        	SecurityUserId int not null,
                        	SecurityRoleId int not null,
                            constraint PK_UserRole primary key clustered ( SecurityUserId,  SecurityRoleId ),
                        	constraint FK_UserRole_UserId foreign key (SecurityUserId) references [SecurityUser] (Id),
                        	constraint FK_UserRole_RoleId foreign key (SecurityRoleId) references [SecurityRole] (Id)
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
