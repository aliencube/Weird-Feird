

// This file was automatically generated.
// Do not make changes directly to this file - edit the template instead.
// 
// The following connection settings were used to generate this file
// 
//     Configuration file:     "WeirdFeird.Repositories\App.config"
//     Connection String Name: "WeirdFeirdDbContext"
//     Connection String:      "Data Source=(localdb)\v11.0;Initial Catalog=WeirdFeird;Integrated Security=True"

// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
//using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace Aliencube.WeirdFeird.Repositories
{
    // ************************************************************************
    // Unit of work
    public interface IWeirdFeirdDbContext : IDisposable
    {
        IDbSet<Author> Authors { get; set; } // Authors
        IDbSet<Category> Categories { get; set; } // Categories
        IDbSet<Editor> Editors { get; set; } // Editors
        IDbSet<Entry> Entries { get; set; } // Entries
        IDbSet<Feed> Feeds { get; set; } // Feeds
        IDbSet<User> Users { get; set; } // Users
        IDbSet<UserCategory> UserCategories { get; set; } // UserCategories
        IDbSet<UserEntry> UserEntries { get; set; } // UserEntries
        IDbSet<UserFeed> UserFeeds { get; set; } // UserFeeds

        int SaveChanges();
    }

    // ************************************************************************
    // Database context
    public partial class WeirdFeirdDbContext : DbContext, IWeirdFeirdDbContext
    {
        public IDbSet<Author> Authors { get; set; } // Authors
        public IDbSet<Category> Categories { get; set; } // Categories
        public IDbSet<Editor> Editors { get; set; } // Editors
        public IDbSet<Entry> Entries { get; set; } // Entries
        public IDbSet<Feed> Feeds { get; set; } // Feeds
        public IDbSet<User> Users { get; set; } // Users
        public IDbSet<UserCategory> UserCategories { get; set; } // UserCategories
        public IDbSet<UserEntry> UserEntries { get; set; } // UserEntries
        public IDbSet<UserFeed> UserFeeds { get; set; } // UserFeeds

        static WeirdFeirdDbContext()
        {
            Database.SetInitializer<WeirdFeirdDbContext>(null);
        }

        public WeirdFeirdDbContext()
            : base("Name=WeirdFeirdDbContext")
        {
        InitializePartial();
        }

        public WeirdFeirdDbContext(string connectionString) : base(connectionString)
        {
        InitializePartial();
        }

        public WeirdFeirdDbContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model) : base(connectionString, model)
        {
        InitializePartial();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AuthorConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
            modelBuilder.Configurations.Add(new EditorConfiguration());
            modelBuilder.Configurations.Add(new EntryConfiguration());
            modelBuilder.Configurations.Add(new FeedConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserCategoryConfiguration());
            modelBuilder.Configurations.Add(new UserEntryConfiguration());
            modelBuilder.Configurations.Add(new UserFeedConfiguration());
        OnModelCreatingPartial(modelBuilder);
        }

        public static DbModelBuilder CreateModel(DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new AuthorConfiguration(schema));
            modelBuilder.Configurations.Add(new CategoryConfiguration(schema));
            modelBuilder.Configurations.Add(new EditorConfiguration(schema));
            modelBuilder.Configurations.Add(new EntryConfiguration(schema));
            modelBuilder.Configurations.Add(new FeedConfiguration(schema));
            modelBuilder.Configurations.Add(new UserConfiguration(schema));
            modelBuilder.Configurations.Add(new UserCategoryConfiguration(schema));
            modelBuilder.Configurations.Add(new UserEntryConfiguration(schema));
            modelBuilder.Configurations.Add(new UserFeedConfiguration(schema));
            return modelBuilder;
        }

        partial void InitializePartial();
        partial void OnModelCreatingPartial(DbModelBuilder modelBuilder);
    }

    // ************************************************************************
    // POCO classes

    // Authors
    public partial class Author
    {
        public int AuthorId { get; set; } // AuthorId (Primary key)
        public int EntryId { get; set; } // EntryId
        public string Author_ { get; set; } // Author
        public DateTime DateAdded { get; set; } // DateAdded

        // Foreign keys
        public virtual Entry Entry { get; set; } //  FK_Authors_Entries

        public Author()
        {
            DateAdded = System.DateTime.Now;
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Categories
    public partial class Category
    {
        public int CategoryId { get; set; } // CategoryId (Primary key)
        public int EntryId { get; set; } // EntryId
        public string Category_ { get; set; } // Category
        public string CategoryLink { get; set; } // CategoryLink
        public DateTime DateAdded { get; set; } // DateAdded

        // Foreign keys
        public virtual Entry Entry { get; set; } //  FK_Categories_Entries

        public Category()
        {
            DateAdded = System.DateTime.Now;
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Editors
    public partial class Editor
    {
        public int EditorId { get; set; } // EditorId (Primary key)
        public int FeedId { get; set; } // FeedId
        public string Editor_ { get; set; } // Editor
        public DateTime DateAdded { get; set; } // DateAdded

        // Foreign keys
        public virtual Feed Feed { get; set; } //  FK_Editors_Feeds

        public Editor()
        {
            DateAdded = System.DateTime.Now;
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Entries
    public partial class Entry
    {
        public int EntryId { get; set; } // EntryId (Primary key)
        public int FeedId { get; set; } // FeedId
        public string Title { get; set; } // Title
        public string Link { get; set; } // Link
        public string Permalink { get; set; } // Permalink
        public string CommentLink { get; set; } // CommentLink
        public string Description { get; set; } // Description
        public string Content { get; set; } // Content
        public string Thumbnail { get; set; } // Thumbnail
        public DateTime DateAdded { get; set; } // DateAdded
        public DateTime? DatePublished { get; set; } // DatePublished

        // Reverse navigation
        public virtual ICollection<Author> Authors { get; set; } // Authors.FK_Authors_Entries
        public virtual ICollection<Category> Categories { get; set; } // Categories.FK_Categories_Entries
        public virtual ICollection<UserEntry> UserEntries { get; set; } // UserEntries.FK_UserEntries_Entries

        // Foreign keys
        public virtual Feed Feed { get; set; } //  FK_Entries_Feeds

        public Entry()
        {
            DateAdded = System.DateTime.Now;
            Authors = new List<Author>();
            Categories = new List<Category>();
            UserEntries = new List<UserEntry>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Feeds
    public partial class Feed
    {
        public int FeedId { get; set; } // FeedId (Primary key)
        public string Title { get; set; } // Title
        public string Description { get; set; } // Description
        public string Link { get; set; } // Link
        public string FeedLink { get; set; } // FeedLink
        public string Generator { get; set; } // Generator
        public DateTime DateAdded { get; set; } // DateAdded
        public DateTime? DateLastUpdated { get; set; } // DateLastUpdated

        // Reverse navigation
        public virtual ICollection<Editor> Editors { get; set; } // Editors.FK_Editors_Feeds
        public virtual ICollection<Entry> Entries { get; set; } // Entries.FK_Entries_Feeds
        public virtual ICollection<UserFeed> UserFeeds { get; set; } // UserFeeds.FK_UserFeeds_Feeds

        public Feed()
        {
            DateAdded = System.DateTime.Now;
            Editors = new List<Editor>();
            Entries = new List<Entry>();
            UserFeeds = new List<UserFeed>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Users
    public partial class User
    {
        public int UserId { get; set; } // UserId (Primary key)
        public string Username { get; set; } // Username
        public string Password { get; set; } // Password
        public string Email { get; set; } // Email
        public DateTime DateCreated { get; set; } // DateCreated
        public DateTime? DateValidated { get; set; } // DateValidated

        // Reverse navigation
        public virtual ICollection<UserCategory> UserCategories { get; set; } // UserCategories.FK_UserCategories_Users
        public virtual ICollection<UserEntry> UserEntries { get; set; } // UserEntries.FK_UserEntries_Users

        public User()
        {
            DateCreated = System.DateTime.Now;
            UserCategories = new List<UserCategory>();
            UserEntries = new List<UserEntry>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // UserCategories
    public partial class UserCategory
    {
        public int UserCategoryId { get; set; } // UserCategoryId (Primary key)
        public int UserId { get; set; } // UserId
        public string Category { get; set; } // Category
        public string CategoryHierarchy { get; set; } // CategoryHierarchy
        public DateTime DateAdded { get; set; } // DateAdded

        // Reverse navigation
        public virtual ICollection<UserFeed> UserFeeds { get; set; } // UserFeeds.FK_UserFeeds_UserCategories

        // Foreign keys
        public virtual User User { get; set; } //  FK_UserCategories_Users

        public UserCategory()
        {
            DateAdded = System.DateTime.Now;
            UserFeeds = new List<UserFeed>();
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // UserEntries
    public partial class UserEntry
    {
        public int UserEntryId { get; set; } // UserEntryId (Primary key)
        public int UserId { get; set; } // UserId
        public int EntryId { get; set; } // EntryId
        public bool HasRead { get; set; } // HasRead
        public DateTime? DateRead { get; set; } // DateRead

        // Foreign keys
        public virtual Entry Entry { get; set; } //  FK_UserEntries_Entries
        public virtual User User { get; set; } //  FK_UserEntries_Users
    }

    // UserFeeds
    public partial class UserFeed
    {
        public int UserFeedId { get; set; } // UserFeedId (Primary key)
        public int FeedId { get; set; } // FeedId
        public int UserCategoryId { get; set; } // UserCategoryId
        public DateTime DateAdded { get; set; } // DateAdded

        // Foreign keys
        public virtual Feed Feed { get; set; } //  FK_UserFeeds_Feeds
        public virtual UserCategory UserCategory { get; set; } //  FK_UserFeeds_UserCategories

        public UserFeed()
        {
            DateAdded = System.DateTime.Now;
            InitializePartial();
        }
        partial void InitializePartial();
    }


    // ************************************************************************
    // POCO Configuration

    // Authors
    internal partial class AuthorConfiguration : EntityTypeConfiguration<Author>
    {
        public AuthorConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Authors");
            HasKey(x => x.AuthorId);

            Property(x => x.AuthorId).HasColumnName("AuthorId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(x => x.EntryId).HasColumnName("EntryId").IsRequired();
            Property(x => x.Author_).HasColumnName("Author").IsRequired().HasMaxLength(256);
            Property(x => x.DateAdded).HasColumnName("DateAdded").IsRequired();

            // Foreign keys
            HasRequired(a => a.Entry).WithMany(b => b.Authors).HasForeignKey(c => c.EntryId); // FK_Authors_Entries
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Categories
    internal partial class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Categories");
            HasKey(x => x.CategoryId);

            Property(x => x.CategoryId).HasColumnName("CategoryId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.EntryId).HasColumnName("EntryId").IsRequired();
            Property(x => x.Category_).HasColumnName("Category").IsRequired().HasMaxLength(256);
            Property(x => x.CategoryLink).HasColumnName("CategoryLink").IsOptional().HasMaxLength(512);
            Property(x => x.DateAdded).HasColumnName("DateAdded").IsRequired();

            // Foreign keys
            HasRequired(a => a.Entry).WithMany(b => b.Categories).HasForeignKey(c => c.EntryId); // FK_Categories_Entries
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Editors
    internal partial class EditorConfiguration : EntityTypeConfiguration<Editor>
    {
        public EditorConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Editors");
            HasKey(x => x.EditorId);

            Property(x => x.EditorId).HasColumnName("EditorId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FeedId).HasColumnName("FeedId").IsRequired();
            Property(x => x.Editor_).HasColumnName("Editor").IsRequired().HasMaxLength(256);
            Property(x => x.DateAdded).HasColumnName("DateAdded").IsRequired();

            // Foreign keys
            HasRequired(a => a.Feed).WithMany(b => b.Editors).HasForeignKey(c => c.FeedId); // FK_Editors_Feeds
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Entries
    internal partial class EntryConfiguration : EntityTypeConfiguration<Entry>
    {
        public EntryConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Entries");
            HasKey(x => x.EntryId);

            Property(x => x.EntryId).HasColumnName("EntryId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FeedId).HasColumnName("FeedId").IsRequired();
            Property(x => x.Title).HasColumnName("Title").IsRequired().HasMaxLength(256);
            Property(x => x.Link).HasColumnName("Link").IsRequired().HasMaxLength(512);
            Property(x => x.Permalink).HasColumnName("Permalink").IsRequired().HasMaxLength(512);
            Property(x => x.CommentLink).HasColumnName("CommentLink").IsOptional().HasMaxLength(512);
            Property(x => x.Description).HasColumnName("Description").IsOptional();
            Property(x => x.Content).HasColumnName("Content").IsOptional();
            Property(x => x.Thumbnail).HasColumnName("Thumbnail").IsOptional().HasMaxLength(512);
            Property(x => x.DateAdded).HasColumnName("DateAdded").IsRequired();
            Property(x => x.DatePublished).HasColumnName("DatePublished").IsOptional();

            // Foreign keys
            HasRequired(a => a.Feed).WithMany(b => b.Entries).HasForeignKey(c => c.FeedId); // FK_Entries_Feeds
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Feeds
    internal partial class FeedConfiguration : EntityTypeConfiguration<Feed>
    {
        public FeedConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Feeds");
            HasKey(x => x.FeedId);

            Property(x => x.FeedId).HasColumnName("FeedId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Title).HasColumnName("Title").IsRequired().HasMaxLength(256);
            Property(x => x.Description).HasColumnName("Description").IsRequired().HasMaxLength(1024);
            Property(x => x.Link).HasColumnName("Link").IsRequired().HasMaxLength(1024);
            Property(x => x.FeedLink).HasColumnName("FeedLink").IsRequired().HasMaxLength(1024);
            Property(x => x.Generator).HasColumnName("Generator").IsOptional().HasMaxLength(128);
            Property(x => x.DateAdded).HasColumnName("DateAdded").IsRequired();
            Property(x => x.DateLastUpdated).HasColumnName("DateLastUpdated").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // Users
    internal partial class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".Users");
            HasKey(x => x.UserId);

            Property(x => x.UserId).HasColumnName("UserId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Username).HasColumnName("Username").IsRequired().HasMaxLength(128);
            Property(x => x.Password).HasColumnName("Password").IsRequired().HasMaxLength(256);
            Property(x => x.Email).HasColumnName("Email").IsRequired().HasMaxLength(256);
            Property(x => x.DateCreated).HasColumnName("DateCreated").IsRequired();
            Property(x => x.DateValidated).HasColumnName("DateValidated").IsOptional();
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // UserCategories
    internal partial class UserCategoryConfiguration : EntityTypeConfiguration<UserCategory>
    {
        public UserCategoryConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".UserCategories");
            HasKey(x => x.UserCategoryId);

            Property(x => x.UserCategoryId).HasColumnName("UserCategoryId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UserId).HasColumnName("UserId").IsRequired();
            Property(x => x.Category).HasColumnName("Category").IsRequired().HasMaxLength(256);
            Property(x => x.CategoryHierarchy).HasColumnName("CategoryHierarchy").IsRequired().HasMaxLength(256);
            Property(x => x.DateAdded).HasColumnName("DateAdded").IsRequired();

            // Foreign keys
            HasRequired(a => a.User).WithMany(b => b.UserCategories).HasForeignKey(c => c.UserId); // FK_UserCategories_Users
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // UserEntries
    internal partial class UserEntryConfiguration : EntityTypeConfiguration<UserEntry>
    {
        public UserEntryConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".UserEntries");
            HasKey(x => x.UserEntryId);

            Property(x => x.UserEntryId).HasColumnName("UserEntryId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UserId).HasColumnName("UserId").IsRequired();
            Property(x => x.EntryId).HasColumnName("EntryId").IsRequired();
            Property(x => x.HasRead).HasColumnName("HasRead").IsRequired();
            Property(x => x.DateRead).HasColumnName("DateRead").IsOptional();

            // Foreign keys
            HasRequired(a => a.User).WithMany(b => b.UserEntries).HasForeignKey(c => c.UserId); // FK_UserEntries_Users
            HasRequired(a => a.Entry).WithMany(b => b.UserEntries).HasForeignKey(c => c.EntryId); // FK_UserEntries_Entries
            InitializePartial();
        }
        partial void InitializePartial();
    }

    // UserFeeds
    internal partial class UserFeedConfiguration : EntityTypeConfiguration<UserFeed>
    {
        public UserFeedConfiguration(string schema = "dbo")
        {
            ToTable(schema + ".UserFeeds");
            HasKey(x => x.UserFeedId);

            Property(x => x.UserFeedId).HasColumnName("UserFeedId").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FeedId).HasColumnName("FeedId").IsRequired();
            Property(x => x.UserCategoryId).HasColumnName("UserCategoryId").IsRequired();
            Property(x => x.DateAdded).HasColumnName("DateAdded").IsRequired();

            // Foreign keys
            HasRequired(a => a.Feed).WithMany(b => b.UserFeeds).HasForeignKey(c => c.FeedId); // FK_UserFeeds_Feeds
            HasRequired(a => a.UserCategory).WithMany(b => b.UserFeeds).HasForeignKey(c => c.UserCategoryId); // FK_UserFeeds_UserCategories
            InitializePartial();
        }
        partial void InitializePartial();
    }

}

