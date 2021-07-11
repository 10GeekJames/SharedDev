using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Calculator.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Individuals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    WebId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    tzAbbr = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    tzName = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: true),
                    tzOffset = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individuals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserInRooms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    ConnectionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsReconnecting = table.Column<bool>(type: "bit", nullable: false),
                    IsDisconnected = table.Column<bool>(type: "bit", nullable: false),
                    CurrentSessionSince = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebContentDocuments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebContentDocuments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebForms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebSafeKey = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Instructions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FileKey = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IndividualId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Businesses_Individuals_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Calculator2Characters",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WhatISeek = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WhyMe = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WhyYou = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    IntensityRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SkillRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExperienceRating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IndividualId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculator2Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calculator2Characters_Individuals_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsInviteOnly = table.Column<bool>(type: "bit", nullable: false),
                    IsListedInDirectory = table.Column<bool>(type: "bit", nullable: true),
                    IndividualId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Individuals_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomKey = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    SecretSalty = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LiveInteractQaSystemKeyId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LiveInteractStreamViewKeyId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProductEventId = table.Column<long>(type: "bigint", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    IndividualId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Individuals_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebFormVersions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WebSafeKey = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    VersionTag = table.Column<double>(type: "float", nullable: true),
                    DataTemplateJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValuesTemplateJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebFormId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebFormVersions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebFormVersions_WebForms_WebFormId",
                        column: x => x.WebFormId,
                        principalTable: "WebForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookupCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LookupText = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    DisplayText = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true),
                    SortOrderValue = table.Column<long>(type: "bigint", maxLength: 200, nullable: true),
                    BusinessId = table.Column<long>(type: "bigint", nullable: false),
                    ParentLookupCategoryId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookupCategories_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Websites",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    DefaultUrl = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    DefaultSubweb = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    WebsiteLogoUrl = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    WebsiteBannerUrl = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    LoadingScreenImageUrl = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    WebsiteTitle = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    WebsiteKeywords = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    WebsiteDescription = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: true),
                    GoogleAnalyticsTrackingCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MailgunIntegrationId = table.Column<long>(type: "bigint", nullable: true),
                    PrimaryIndividualId = table.Column<long>(type: "bigint", nullable: true),
                    BusinessId = table.Column<long>(type: "bigint", nullable: false),
                    IndividualId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Websites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Websites_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Websites_Individuals_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChatEntries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntryData = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: true),
                    ChatId = table.Column<long>(type: "bigint", nullable: false),
                    IndividualId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatEntries_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatEntries_Individuals_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChatIndividuals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatId = table.Column<long>(type: "bigint", nullable: false),
                    IndividualId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatIndividuals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatIndividuals_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatIndividuals_Individuals_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LookupTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SortOrderValue = table.Column<long>(type: "bigint", nullable: true),
                    TypeBool = table.Column<bool>(type: "bit", nullable: true),
                    TypeNumber = table.Column<long>(type: "bigint", nullable: true),
                    TypeText = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TypeSpecialA = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TypeSpecialB = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TypeBlob = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeJson = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LookupText = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    DisplayText = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ParentLookupTypeId = table.Column<long>(type: "bigint", nullable: true),
                    OwnerIndividualId = table.Column<long>(type: "bigint", nullable: true),
                    BusinessId = table.Column<long>(type: "bigint", nullable: false),
                    LookupCategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookupTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookupTypes_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LookupTypes_Individuals_OwnerIndividualId",
                        column: x => x.OwnerIndividualId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LookupTypes_LookupCategories_LookupCategoryId",
                        column: x => x.LookupCategoryId,
                        principalTable: "LookupCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PageLoads",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TargetRoute = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    TargetTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TargetId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    LoadTimeInMS = table.Column<long>(type: "bigint", nullable: false),
                    IndividualId = table.Column<long>(type: "bigint", nullable: false),
                    BusinessId = table.Column<long>(type: "bigint", nullable: false),
                    WebsiteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageLoads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageLoads_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PageLoads_Individuals_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PageLoads_Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "Websites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebPages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UrlToMatch = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: true),
                    MenuText = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    WebSiteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebPages_Websites_WebSiteId",
                        column: x => x.WebSiteId,
                        principalTable: "Websites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebsiteAliases",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    Subweb = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    WebsiteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebsiteAliases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebsiteAliases_Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "Websites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndividualInBusinesses",
                columns: table => new
                {
                    BusinessId = table.Column<long>(type: "bigint", nullable: false),
                    IndividualId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    RoleLookupTypeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualInBusinesses", x => new { x.IndividualId, x.BusinessId });
                    table.ForeignKey(
                        name: "FK_IndividualInBusinesses_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndividualInBusinesses_Individuals_IndividualId",
                        column: x => x.IndividualId,
                        principalTable: "Individuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IndividualInBusinesses_LookupTypes_RoleLookupTypeId",
                        column: x => x.RoleLookupTypeId,
                        principalTable: "LookupTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PageInteractions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InteractionDescription = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    Interaction = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    PageLoadId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageInteractions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageInteractions_PageLoads_PageLoadId",
                        column: x => x.PageLoadId,
                        principalTable: "PageLoads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebContents",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SortOrder = table.Column<float>(type: "real", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    WebPageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebContents_WebPages_WebPageId",
                        column: x => x.WebPageId,
                        principalTable: "WebPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebContentItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SortOrder = table.Column<float>(type: "real", nullable: false),
                    MiniTitle = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    MiniSubTitle = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    MiniContent = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: true),
                    ExternalUrl = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    InternalUrl = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    StreamUrl = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    BannerUrl = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    CommaTags = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: true),
                    FullTitle = table.Column<string>(type: "nvarchar(140)", maxLength: 140, nullable: true),
                    FullSubTitle = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    GoogleTrackingEventActionCode = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    FullContentJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebContentItemLookupTypeId = table.Column<long>(type: "bigint", nullable: false),
                    WebContentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebContentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebContentItems_LookupTypes_WebContentItemLookupTypeId",
                        column: x => x.WebContentItemLookupTypeId,
                        principalTable: "LookupTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WebContentItems_WebContents_WebContentId",
                        column: x => x.WebContentId,
                        principalTable: "WebContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebContentUrls",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Href = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    AltText = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Target = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WebContentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebContentUrls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebContentUrls_WebContents_WebContentId",
                        column: x => x.WebContentId,
                        principalTable: "WebContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WebContentVideos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Body = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    VideoUrl = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    PublishOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WebContentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebContentVideos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebContentVideos_WebContents_WebContentId",
                        column: x => x.WebContentId,
                        principalTable: "WebContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_IndividualId",
                table: "Businesses",
                column: "IndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_Calculator2Characters_IndividualId",
                table: "Calculator2Characters",
                column: "IndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatEntries_ChatId",
                table: "ChatEntries",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatEntries_IndividualId",
                table: "ChatEntries",
                column: "IndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatIndividuals_ChatId",
                table: "ChatIndividuals",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatIndividuals_IndividualId",
                table: "ChatIndividuals",
                column: "IndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_IndividualId",
                table: "Chats",
                column: "IndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualInBusinesses_BusinessId",
                table: "IndividualInBusinesses",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_IndividualInBusinesses_RoleLookupTypeId",
                table: "IndividualInBusinesses",
                column: "RoleLookupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LookupCategories_BusinessId",
                table: "LookupCategories",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_LookupTypes_BusinessId",
                table: "LookupTypes",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_LookupTypes_LookupCategoryId",
                table: "LookupTypes",
                column: "LookupCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LookupTypes_OwnerIndividualId",
                table: "LookupTypes",
                column: "OwnerIndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_PageInteractions_PageLoadId",
                table: "PageInteractions",
                column: "PageLoadId");

            migrationBuilder.CreateIndex(
                name: "IX_PageLoads_BusinessId",
                table: "PageLoads",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_PageLoads_IndividualId",
                table: "PageLoads",
                column: "IndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_PageLoads_WebsiteId",
                table: "PageLoads",
                column: "WebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_IndividualId",
                table: "Rooms",
                column: "IndividualId");

            migrationBuilder.CreateIndex(
                name: "IX_WebContentItems_WebContentId",
                table: "WebContentItems",
                column: "WebContentId");

            migrationBuilder.CreateIndex(
                name: "IX_WebContentItems_WebContentItemLookupTypeId",
                table: "WebContentItems",
                column: "WebContentItemLookupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_WebContents_WebPageId",
                table: "WebContents",
                column: "WebPageId");

            migrationBuilder.CreateIndex(
                name: "IX_WebContentUrls_WebContentId",
                table: "WebContentUrls",
                column: "WebContentId");

            migrationBuilder.CreateIndex(
                name: "IX_WebContentVideos_WebContentId",
                table: "WebContentVideos",
                column: "WebContentId");

            migrationBuilder.CreateIndex(
                name: "IX_WebFormVersions_WebFormId",
                table: "WebFormVersions",
                column: "WebFormId");

            migrationBuilder.CreateIndex(
                name: "IX_WebPages_WebSiteId",
                table: "WebPages",
                column: "WebSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_WebsiteAliases_WebsiteId",
                table: "WebsiteAliases",
                column: "WebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Websites_BusinessId",
                table: "Websites",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Websites_IndividualId",
                table: "Websites",
                column: "IndividualId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calculator2Characters");

            migrationBuilder.DropTable(
                name: "ChatEntries");

            migrationBuilder.DropTable(
                name: "ChatIndividuals");

            migrationBuilder.DropTable(
                name: "IndividualInBusinesses");

            migrationBuilder.DropTable(
                name: "PageInteractions");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "UserInRooms");

            migrationBuilder.DropTable(
                name: "WebContentDocuments");

            migrationBuilder.DropTable(
                name: "WebContentItems");

            migrationBuilder.DropTable(
                name: "WebContentUrls");

            migrationBuilder.DropTable(
                name: "WebContentVideos");

            migrationBuilder.DropTable(
                name: "WebFormVersions");

            migrationBuilder.DropTable(
                name: "WebsiteAliases");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "PageLoads");

            migrationBuilder.DropTable(
                name: "LookupTypes");

            migrationBuilder.DropTable(
                name: "WebContents");

            migrationBuilder.DropTable(
                name: "WebForms");

            migrationBuilder.DropTable(
                name: "LookupCategories");

            migrationBuilder.DropTable(
                name: "WebPages");

            migrationBuilder.DropTable(
                name: "Websites");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "Individuals");
        }
    }
}
