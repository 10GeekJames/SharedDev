// This file is now under code-gen control, do not touch, will be regenerated frequenly
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Calculator.Models;
using Microsoft.EntityFrameworkCore;
namespace Calculator.Infrastructure {
    public partial class CalculatorDbContext : DbContext {
        public virtual DbSet<Business> Businesses { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<ChatEntry> ChatEntries { get; set; }
        public virtual DbSet<ChatIndividual> ChatIndividuals { get; set; }
        public virtual DbSet<Individual> Individuals { get; set; }
        public virtual DbSet<IndividualInBusiness> IndividualInBusinesses { get; set; }
        public virtual DbSet<LookupCategory> LookupCategories { get; set; }
        public virtual DbSet<LookupType> LookupTypes { get; set; }
        public virtual DbSet<PageInteraction> PageInteractions { get; set; }
        public virtual DbSet<PageLoad> PageLoads { get; set; }
        public virtual DbSet<Calculator2Character> Calculator2Characters { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<UserInRoom> UserInRooms { get; set; }
        public virtual DbSet<WebContent> WebContents { get; set; }
        public virtual DbSet<WebContentDocument> WebContentDocuments { get; set; }
        public virtual DbSet<WebContentItem> WebContentItems { get; set; }
        public virtual DbSet<WebContentUrl> WebContentUrls { get; set; }
        public virtual DbSet<WebContentVideo> WebContentVideos { get; set; }
        public virtual DbSet<WebForm> WebForms { get; set; }
        public virtual DbSet<WebFormVersion> WebFormVersions { get; set; }
        public virtual DbSet<WebPage> WebPages { get; set; }
        public virtual DbSet<Website> Websites { get; set; }
        public virtual DbSet<WebsiteAlias> WebsiteAliases { get; set; }
        public CalculatorDbContext (DbContextOptions options) : base (options) { }
    }
}
