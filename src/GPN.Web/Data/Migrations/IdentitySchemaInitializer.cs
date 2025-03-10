﻿using System.Data.SQLite;

namespace GPN.Web.Data.Migrations
{
    public class IdentitySchemaInitializer
    {
        private readonly string _connectionString;

        public IdentitySchemaInitializer(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Initialize()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                var createRolesTable = @"
                CREATE TABLE IF NOT EXISTS AspNetRoles (
                    Id TEXT PRIMARY KEY,
                    Name TEXT,
                    NormalizedName TEXT,
                    ConcurrencyStamp TEXT
                );";

                var createUsersTable = @"
                CREATE TABLE IF NOT EXISTS AspNetUsers (
                    Id TEXT PRIMARY KEY,
                    UserName TEXT,
                    NormalizedUserName TEXT,
                    Email TEXT,
                    NormalizedEmail TEXT,
                    EmailConfirmed BOOLEAN,
                    PasswordHash TEXT,
                    SecurityStamp TEXT,
                    ConcurrencyStamp TEXT,
                    PhoneNumber TEXT,
                    PhoneNumberConfirmed BOOLEAN,
                    TwoFactorEnabled BOOLEAN,
                    LockoutEnd DATETIME,
                    LockoutEnabled BOOLEAN,
                    AccessFailedCount INTEGER
                );";

                var createRoleClaimsTable = @"
                CREATE TABLE IF NOT EXISTS AspNetRoleClaims (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    RoleId TEXT NOT NULL,
                    ClaimType TEXT,
                    ClaimValue TEXT,
                    FOREIGN KEY (RoleId) REFERENCES AspNetRoles(Id) ON DELETE CASCADE
                );";

                var createUserClaimsTable = @"
                CREATE TABLE IF NOT EXISTS AspNetUserClaims (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    UserId TEXT NOT NULL,
                    ClaimType TEXT,
                    ClaimValue TEXT,
                    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE
                );";

                var createUserLoginsTable = @"
                CREATE TABLE IF NOT EXISTS AspNetUserLogins (
                    LoginProvider TEXT NOT NULL,
                    ProviderKey TEXT NOT NULL,
                    ProviderDisplayName TEXT,
                    UserId TEXT NOT NULL,
                    PRIMARY KEY (LoginProvider, ProviderKey),
                    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE
                );";

                var createUserRolesTable = @"
                CREATE TABLE IF NOT EXISTS AspNetUserRoles (
                    UserId TEXT NOT NULL,
                    RoleId TEXT NOT NULL,
                    PRIMARY KEY (UserId, RoleId),
                    FOREIGN KEY (RoleId) REFERENCES AspNetRoles(Id) ON DELETE CASCADE,
                    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE
                );";

                var createUserTokensTable = @"
                CREATE TABLE IF NOT EXISTS AspNetUserTokens (
                    UserId TEXT NOT NULL,
                    LoginProvider TEXT NOT NULL,
                    Name TEXT NOT NULL,
                    Value TEXT,
                    PRIMARY KEY (UserId, LoginProvider, Name),
                    FOREIGN KEY (UserId) REFERENCES AspNetUsers(Id) ON DELETE CASCADE
                );"
                ;

                using (var command = new SQLiteCommand(createRolesTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SQLiteCommand(createUsersTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SQLiteCommand(createRoleClaimsTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SQLiteCommand(createUserClaimsTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SQLiteCommand(createUserLoginsTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SQLiteCommand(createUserRolesTable, connection))
                {
                    command.ExecuteNonQuery();
                }
                using (var command = new SQLiteCommand(createUserTokensTable, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
