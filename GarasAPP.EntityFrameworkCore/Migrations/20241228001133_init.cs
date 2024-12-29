using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarasAPP.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    OldID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Extras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Languagees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shortvalue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languagees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    num_code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    alpha_2_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alpha_3_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    en_short_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nationality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.num_code);
                });

            migrationBuilder.CreateTable(
                name: "RoomServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoomViews",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    View = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomViews", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    BranchID = table.Column<int>(type: "int", nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    JobTitleID = table.Column<int>(type: "int", nullable: true),
                    OldID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Governorate",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    OldID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Governorate", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Governorate_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WebSite = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    SalesPersonID = table.Column<long>(type: "bigint", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: true),
                    FirstContractDate = table.Column<DateTime>(type: "date", nullable: true),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Consultant = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FollowUpPeriod = table.Column<int>(type: "int", nullable: false),
                    ConsultantType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SupportedByCompany = table.Column<bool>(type: "bit", nullable: true),
                    SupportedBy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    HasLogo = table.Column<bool>(type: "bit", nullable: true),
                    LastReportDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    NeedApproval = table.Column<int>(type: "int", nullable: true),
                    ClientSerialCounter = table.Column<long>(type: "bigint", nullable: true),
                    OpeningBalance = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    OpeningBalanceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OpeningBalanceDate = table.Column<DateTime>(type: "date", nullable: true),
                    OpeningBalanceCurrencyId = table.Column<int>(type: "int", nullable: true),
                    DefaultDelivaryAndShippingMethodId = table.Column<int>(type: "int", nullable: true),
                    OtherDelivaryAndShippingMethodName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CommercialRecord = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TaxCard = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OwnerCoProfile = table.Column<bool>(type: "bit", nullable: true),
                    ApprovedBy = table.Column<long>(type: "bigint", nullable: true),
                    ClientClassificationId = table.Column<int>(type: "int", nullable: true),
                    ClassificationComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NationalityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Client_Nationalities_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Nationalities",
                        principalColumn: "num_code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    RoomViewId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomViews_RoomViewId",
                        column: x => x.RoomViewId,
                        principalTable: "RoomViews",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Role_User_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Role_User_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GovernorateID = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Area_Governorate_GovernorateID",
                        column: x => x.GovernorateID,
                        principalTable: "Governorate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientLanguagees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    LanguageeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientLanguagees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientLanguagees_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientLanguagees_Languagees_LanguageeId",
                        column: x => x.LanguageeId,
                        principalTable: "Languagees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reservationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<long>(type: "bigint", nullable: false),
                    Provider = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Confirmation = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomRate = table.Column<int>(type: "int", nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: true),
                    BuildingId = table.Column<int>(type: "int", nullable: true),
                    RoomViewId = table.Column<int>(type: "int", nullable: true),
                    SpecialOfferFlag = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rates_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Rates_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Rates_RoomViews_RoomViewId",
                        column: x => x.RoomViewId,
                        principalTable: "RoomViews",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Rates_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomFacilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomFacilities_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomFacilities_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientAddress",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<long>(type: "bigint", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    GovernorateID = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    BuildingNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Floor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAddress", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClientAddress_Area_AreaID",
                        column: x => x.AreaID,
                        principalTable: "Area",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ClientAddress_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientAddress_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Childerns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Years = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Childerns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Childerns_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Childerns_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomsReservationChilderns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    NumbersofAdulte = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsReservationChilderns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomsReservationChilderns_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomsReservationChilderns_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomsReservationMeals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false),
                    MealTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsReservationMeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomsReservationMeals_MealTypes_MealTypeId",
                        column: x => x.MealTypeId,
                        principalTable: "MealTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomsReservationMeals_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomsReservationMeals_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomsReservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomsReservations_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomsReservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Area_GovernorateID",
                table: "Area",
                column: "GovernorateID");

            migrationBuilder.CreateIndex(
                name: "IX_Childerns_ReservationId",
                table: "Childerns",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Childerns_RoomId",
                table: "Childerns",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_NationalityId",
                table: "Client",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddress_AreaID",
                table: "ClientAddress",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddress_ClientID",
                table: "ClientAddress",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddress_CountryID",
                table: "ClientAddress",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_ClientLanguagees_ClientId",
                table: "ClientLanguagees",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientLanguagees_LanguageeId",
                table: "ClientLanguagees",
                column: "LanguageeId");

            migrationBuilder.CreateIndex(
                name: "IX_Governorate_CountryID",
                table: "Governorate",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_BuildingId",
                table: "Rates",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_RoomId",
                table: "Rates",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_RoomTypeId",
                table: "Rates",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rates_RoomViewId",
                table: "Rates",
                column: "RoomViewId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_CreatedBy",
                table: "Role",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Role_ModifiedBy",
                table: "Role",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFacilities_FacilityId",
                table: "RoomFacilities",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFacilities_RoomId",
                table: "RoomFacilities",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BuildingId",
                table: "Rooms",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomViewId",
                table: "Rooms",
                column: "RoomViewId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsReservationChilderns_ReservationId",
                table: "RoomsReservationChilderns",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsReservationChilderns_RoomId",
                table: "RoomsReservationChilderns",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsReservationMeals_MealTypeId",
                table: "RoomsReservationMeals",
                column: "MealTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsReservationMeals_ReservationId",
                table: "RoomsReservationMeals",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsReservationMeals_RoomId",
                table: "RoomsReservationMeals",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsReservations_ReservationId",
                table: "RoomsReservations",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomsReservations_RoomId",
                table: "RoomsReservations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleID",
                table: "UserRole",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserID",
                table: "UserRole",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Childerns");

            migrationBuilder.DropTable(
                name: "ClientAddress");

            migrationBuilder.DropTable(
                name: "ClientLanguagees");

            migrationBuilder.DropTable(
                name: "Extras");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "RoomFacilities");

            migrationBuilder.DropTable(
                name: "RoomServices");

            migrationBuilder.DropTable(
                name: "RoomsReservationChilderns");

            migrationBuilder.DropTable(
                name: "RoomsReservationMeals");

            migrationBuilder.DropTable(
                name: "RoomsReservations");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Languagees");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "MealTypes");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Governorate");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "RoomViews");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Nationalities");
        }
    }
}
