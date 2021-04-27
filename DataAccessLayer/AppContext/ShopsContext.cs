using DataAccessLayer.Entities.Shops;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataAccessLayer.AppContext
{
    public partial class ShopsContext : DbContext
    {
        public ShopsContext()
        {
        }

        public ShopsContext(DbContextOptions<ShopsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessDepartmentForm> AccessDepartmentForms { get; set; }
        public virtual DbSet<AccessType> AccessTypes { get; set; }
        public virtual DbSet<BitrixResponse> BitrixResponses { get; set; }
        public virtual DbSet<CitiesLocalization> CitiesLocalizations { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<CityStreetView> CityStreetViews { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<DistrictCityView> DistrictCityViews { get; set; }
        public virtual DbSet<DistrictsLocalization> DistrictsLocalizations { get; set; }
        public virtual DbSet<DocumentFile> DocumentFiles { get; set; }
        public virtual DbSet<DocumentFileContent> DocumentFileContents { get; set; }
        public virtual DbSet<DocumentFolder> DocumentFolders { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<FileContent> FileContents { get; set; }
        public virtual DbSet<FileConvertVideo> FileConvertVideos { get; set; }
        public virtual DbSet<Folder> Folders { get; set; }
        public virtual DbSet<ImportHistory> ImportHistories { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<LinkedShop> LinkedShops { get; set; }
        public virtual DbSet<MediaFolder> MediaFolders { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<ProviderHistory> ProviderHistories { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<RegionDistrictView> RegionDistrictViews { get; set; }
        public virtual DbSet<RegionsLocalization> RegionsLocalizations { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleAccess> RoleAccesses { get; set; }
        public virtual DbSet<RoleAccessToCatalog> RoleAccessToCatalogs { get; set; }
        public virtual DbSet<RoleAccessToDocumentFolder> RoleAccessToDocumentFolders { get; set; }
        public virtual DbSet<RoleAccessToField> RoleAccessToFields { get; set; }
        public virtual DbSet<RoleAccessToFolder> RoleAccessToFolders { get; set; }
        public virtual DbSet<RoleAccessToStatus> RoleAccessToStatuses { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<ShopContactPerson> ShopContactPersons { get; set; }
        public virtual DbSet<ShopContactPersonHistory> ShopContactPersonHistories { get; set; }
        public virtual DbSet<ShopContractor1C> ShopContractor1Cs { get; set; }
        public virtual DbSet<ShopContractor1Chistory> ShopContractor1Chistories { get; set; }
        public virtual DbSet<ShopDocumentFolder> ShopDocumentFolders { get; set; }
        public virtual DbSet<ShopFieldsMapping> ShopFieldsMappings { get; set; }
        public virtual DbSet<ShopGridView> ShopGridViews { get; set; }
        public virtual DbSet<ShopHeatingType> ShopHeatingTypes { get; set; }
        public virtual DbSet<ShopHeatingTypeHistory> ShopHeatingTypeHistories { get; set; }
        public virtual DbSet<ShopHistory> ShopHistories { get; set; }
        public virtual DbSet<ShopHistoryNotification> ShopHistoryNotifications { get; set; }
        public virtual DbSet<ShopHistoryNotificationDateComment> ShopHistoryNotificationDateComments { get; set; }
        public virtual DbSet<ShopInstallersDevelopment> ShopInstallersDevelopments { get; set; }
        public virtual DbSet<ShopInstallersDevelopmentHistory> ShopInstallersDevelopmentHistories { get; set; }
        public virtual DbSet<ShopIt> ShopIts { get; set; }
        public virtual DbSet<ShopIthistory> ShopIthistories { get; set; }
        public virtual DbSet<ShopItresponsibleForAssembling> ShopItresponsibleForAssemblings { get; set; }
        public virtual DbSet<ShopItresponsibleForDisAssembling> ShopItresponsibleForDisAssemblings { get; set; }
        public virtual DbSet<ShopObjectComplexity> ShopObjectComplexities { get; set; }
        public virtual DbSet<ShopObjectComplexityHistory> ShopObjectComplexityHistories { get; set; }
        public virtual DbSet<ShopOptimizationSchedule> ShopOptimizationSchedules { get; set; }
        public virtual DbSet<ShopOptimizationScheduleHistory> ShopOptimizationScheduleHistories { get; set; }
        public virtual DbSet<ShopProvider> ShopProviders { get; set; }
        public virtual DbSet<ShopProviderHistory> ShopProviderHistories { get; set; }
        public virtual DbSet<ShopRegion> ShopRegions { get; set; }
        public virtual DbSet<ShopRegionLocalization> ShopRegionLocalizations { get; set; }
        public virtual DbSet<ShopRent> ShopRents { get; set; }
        public virtual DbSet<ShopRentHistory> ShopRentHistories { get; set; }
        public virtual DbSet<ShopSecurity> ShopSecurities { get; set; }
        public virtual DbSet<ShopSecurityHistory> ShopSecurityHistories { get; set; }
        public virtual DbSet<ShopWorkTime> ShopWorkTimes { get; set; }
        public virtual DbSet<ShopWorkTimeHistory> ShopWorkTimeHistories { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<StatusesIt> StatusesIts { get; set; }
        public virtual DbSet<StatusesLocalization> StatusesLocalizations { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<StreetsLocalization> StreetsLocalizations { get; set; }
        public virtual DbSet<TempImportAdress> TempImportAdresses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserShopGridSetting> UserShopGridSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=sql26;Initial Catalog=Shops;Persist Security Info=True;User ID=j-sql26-reader-shops;Password=1GAxzpWtGojxCWnW8sYY");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<AccessDepartmentForm>(entity =>
            {
                entity.Property(e => e.AccessDepartmentKeyName)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.KeyName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AccessType>(entity =>
            {
                entity.ToTable("AccessType");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.KeyName)
                    .IsRequired()
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<BitrixResponse>(entity =>
            {
                entity.HasIndex(e => e.ShopId, "IX_BitrixResponses_ShopId");

                entity.Property(e => e.Comments).HasMaxLength(512);

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.TaskNumber).HasMaxLength(32);

                entity.Property(e => e.TaskReason).HasMaxLength(512);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.BitrixResponses)
                    .HasForeignKey(d => d.ShopId);
            });

            modelBuilder.Entity<CitiesLocalization>(entity =>
            {
                entity.ToTable("CitiesLocalization");

                entity.HasIndex(e => e.CityId, "IX_CitiesLocalization_CityId");

                entity.HasIndex(e => e.Name, "IX_CitiesLocalization_Name");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.CitiesLocalizations)
                    .HasForeignKey(d => d.CityId);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasIndex(e => e.DistrictId, "IX_Cities_DistrictId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.DistrictId);
            });

            modelBuilder.Entity<CityStreetView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("City_Street_View");

                entity.Property(e => e.StreetName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.HasIndex(e => e.RegionId, "IX_Districts_RegionId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.RegionId);
            });

            modelBuilder.Entity<DistrictCityView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("District_City_View");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<DistrictsLocalization>(entity =>
            {
                entity.ToTable("DistrictsLocalization");

                entity.HasIndex(e => e.DistrictId, "IX_DistrictsLocalization_DistrictId");

                entity.HasIndex(e => e.Name, "IX_DistrictsLocalization_Name");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.DistrictsLocalizations)
                    .HasForeignKey(d => d.DistrictId);
            });

            modelBuilder.Entity<DocumentFile>(entity =>
            {
                entity.HasIndex(e => e.ShopDocumentId, "IX_DocumentFiles_ShopDocumentId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.FileGuid)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.FileOriginalName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.ShopDocument)
                    .WithMany(p => p.DocumentFiles)
                    .HasForeignKey(d => d.ShopDocumentId);
            });

            modelBuilder.Entity<DocumentFileContent>(entity =>
            {
                entity.HasIndex(e => e.DocumentFileId, "IX_DocumentFileContents_DocumentFileId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.IsPdfforDocx).HasColumnName("IsPDFforDOCX");

                entity.HasOne(d => d.DocumentFile)
                    .WithMany(p => p.DocumentFileContents)
                    .HasForeignKey(d => d.DocumentFileId);
            });

            modelBuilder.Entity<DocumentFolder>(entity =>
            {
                entity.HasIndex(e => e.ParentDocumentFolderId, "IX_DocumentFolders_ParentDocumentFolderId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.ParentDocumentFolder)
                    .WithMany(p => p.InverseParentDocumentFolder)
                    .HasForeignKey(d => d.ParentDocumentFolderId);
            });

            modelBuilder.Entity<Field>(entity =>
            {
                entity.HasIndex(e => e.AccessDepartmentFormId, "IX_Fields_AccessDepartmentFormId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.KeyName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.AccessDepartmentForm)
                    .WithMany(p => p.Fields)
                    .HasForeignKey(d => d.AccessDepartmentFormId);
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasIndex(e => e.FileConvertVideoId, "IX_Files_FileConvertVideoId");

                entity.HasIndex(e => e.MediaFolderId, "IX_Files_MediaFolderId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.Description).HasMaxLength(256);

                entity.Property(e => e.FileGuid)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.FileOriginalName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.FileConvertVideo)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.FileConvertVideoId);

                entity.HasOne(d => d.MediaFolder)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.MediaFolderId);
            });

            modelBuilder.Entity<FileContent>(entity =>
            {
                entity.HasIndex(e => e.FileId, "IX_FileContents_FileId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.HasOne(d => d.File)
                    .WithMany(p => p.FileContents)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<FileConvertVideo>(entity =>
            {
                entity.Property(e => e.CreatedByUserId).IsRequired();
            });

            modelBuilder.Entity<Folder>(entity =>
            {
                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<ImportHistory>(entity =>
            {
                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.FileName).IsRequired();
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Code).IsRequired();

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<LinkedShop>(entity =>
            {
                entity.HasIndex(e => e.FirstShopId, "IX_LinkedShops_FirstShopId");

                entity.HasIndex(e => e.SecondShopId, "IX_LinkedShops_SecondShopId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.HasOne(d => d.FirstShop)
                    .WithMany(p => p.LinkedShopFirstShops)
                    .HasForeignKey(d => d.FirstShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SecondShop)
                    .WithMany(p => p.LinkedShopSecondShops)
                    .HasForeignKey(d => d.SecondShopId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<MediaFolder>(entity =>
            {
                entity.HasIndex(e => e.FolderId, "IX_MediaFolders_FolderId");

                entity.HasIndex(e => e.ParentFolderId, "IX_MediaFolders_ParentFolderId");

                entity.HasIndex(e => e.ShopId, "IX_MediaFolders_ShopId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.MediaFolders)
                    .HasForeignKey(d => d.FolderId);

                entity.HasOne(d => d.ParentFolder)
                    .WithMany(p => p.InverseParentFolder)
                    .HasForeignKey(d => d.ParentFolderId);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.MediaFolders)
                    .HasForeignKey(d => d.ShopId);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasIndex(e => e.ShopId, "IX_Notifications_ShopId");

                entity.Property(e => e.NotificationType).HasMaxLength(150);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.ShopId);
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasIndex(e => e.AccountLink, "IX_Providers_AccountLink")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_Providers_Name")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "IX_Providers_PhoneNumber")
                    .IsUnique();

                entity.HasIndex(e => e.SiteLink, "IX_Providers_SiteLink")
                    .IsUnique();

                entity.Property(e => e.AccountLink).HasMaxLength(2048);

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(512);

                entity.Property(e => e.SiteLink).HasMaxLength(2048);
            });

            modelBuilder.Entity<ProviderHistory>(entity =>
            {
                entity.Property(e => e.FieldName).HasMaxLength(128);

                entity.Property(e => e.TransactionId).HasMaxLength(256);

                entity.Property(e => e.UpdatedByUser).IsRequired();
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.CreatedByUserId).IsRequired();
            });

            modelBuilder.Entity<RegionDistrictView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Region_District_View");

                entity.Property(e => e.DistrictName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<RegionsLocalization>(entity =>
            {
                entity.ToTable("RegionsLocalization");

                entity.HasIndex(e => new { e.LanguageId, e.Name }, "IX_RegionLocalization_LanguageId_Name")
                    .IsUnique();

                entity.HasIndex(e => e.LanguageId, "IX_RegionsLocalization_LanguageId");

                entity.HasIndex(e => e.RegionId, "IX_RegionsLocalization_RegionId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.RegionsLocalizations)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RegionsLocalization_Languages_languageId");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.RegionsLocalizations)
                    .HasForeignKey(d => d.RegionId);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.HasIndex(e => e.Code, "IX_Role_Code")
                    .IsUnique();

                entity.HasIndex(e => e.Name, "IX_Role_Name")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<RoleAccess>(entity =>
            {
                entity.HasIndex(e => e.AccessTypeId, "IX_RoleAccesses_AccessTypeId");

                entity.HasIndex(e => e.RoleId, "IX_RoleAccesses_RoleId");

                entity.Property(e => e.AccessKeyName).IsRequired();

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.HasOne(d => d.AccessType)
                    .WithMany(p => p.RoleAccesses)
                    .HasForeignKey(d => d.AccessTypeId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleAccesses)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<RoleAccessToCatalog>(entity =>
            {
                entity.HasIndex(e => e.AccessTypeId, "IX_RoleAccessToCatalogs_AccessTypeId");

                entity.HasIndex(e => e.RoleId, "IX_RoleAccessToCatalogs_RoleId");

                entity.Property(e => e.CatalogKeyName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.HasOne(d => d.AccessType)
                    .WithMany(p => p.RoleAccessToCatalogs)
                    .HasForeignKey(d => d.AccessTypeId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleAccessToCatalogs)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<RoleAccessToDocumentFolder>(entity =>
            {
                entity.HasIndex(e => e.AccessTypeId, "IX_RoleAccessToDocumentFolders_AccessTypeId");

                entity.HasIndex(e => e.DocumentFolderId, "IX_RoleAccessToDocumentFolders_DocumentFolderId");

                entity.HasIndex(e => e.RoleId, "IX_RoleAccessToDocumentFolders_RoleId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.HasOne(d => d.AccessType)
                    .WithMany(p => p.RoleAccessToDocumentFolders)
                    .HasForeignKey(d => d.AccessTypeId);

                entity.HasOne(d => d.DocumentFolder)
                    .WithMany(p => p.RoleAccessToDocumentFolders)
                    .HasForeignKey(d => d.DocumentFolderId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleAccessToDocumentFolders)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<RoleAccessToField>(entity =>
            {
                entity.HasIndex(e => e.AccessTypeId, "IX_RoleAccessToFields_AccessTypeId");

                entity.HasIndex(e => e.FieldId, "IX_RoleAccessToFields_FieldId");

                entity.HasIndex(e => e.RoleId, "IX_RoleAccessToFields_RoleId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.HasOne(d => d.AccessType)
                    .WithMany(p => p.RoleAccessToFields)
                    .HasForeignKey(d => d.AccessTypeId);

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.RoleAccessToFields)
                    .HasForeignKey(d => d.FieldId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleAccessToFields)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<RoleAccessToFolder>(entity =>
            {
                entity.HasIndex(e => e.AccessTypeId, "IX_RoleAccessToFolders_AccessTypeId");

                entity.HasIndex(e => e.FolderId, "IX_RoleAccessToFolders_FolderId");

                entity.HasIndex(e => e.RoleId, "IX_RoleAccessToFolders_RoleId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.HasOne(d => d.AccessType)
                    .WithMany(p => p.RoleAccessToFolders)
                    .HasForeignKey(d => d.AccessTypeId);

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.RoleAccessToFolders)
                    .HasForeignKey(d => d.FolderId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleAccessToFolders)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<RoleAccessToStatus>(entity =>
            {
                entity.HasIndex(e => e.AccessTypeId, "IX_RoleAccessToStatuses_AccessTypeId");

                entity.HasIndex(e => e.RoleId, "IX_RoleAccessToStatuses_RoleId");

                entity.HasIndex(e => e.StatusId, "IX_RoleAccessToStatuses_StatusId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.HasOne(d => d.AccessType)
                    .WithMany(p => p.RoleAccessToStatuses)
                    .HasForeignKey(d => d.AccessTypeId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleAccessToStatuses)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.RoleAccessToStatuses)
                    .HasForeignKey(d => d.StatusId);
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.HasIndex(e => e.AdministratorId, "IX_Shops_AdministratorId");

                entity.HasIndex(e => e.CityId, "IX_Shops_CityId");

                entity.HasIndex(e => e.DeputyAdministratorId, "IX_Shops_DeputyAdministratorId");

                entity.HasIndex(e => e.DevelopmentDepartmentCoordinatorId, "IX_Shops_DevelopmentDepartmentCoordinatorId");

                entity.HasIndex(e => e.DevelopmentDepartmentManagerId, "IX_Shops_DevelopmentDepartmentManagerId");

                entity.HasIndex(e => e.DistrictId, "IX_Shops_DistrictId");

                entity.HasIndex(e => e.PrivateEntrepreneurId, "IX_Shops_PrivateEntrepreneurId");

                entity.HasIndex(e => e.RegionId, "IX_Shops_RegionId");

                entity.HasIndex(e => e.RegionalManagerId, "IX_Shops_RegionalManagerId");

                entity.HasIndex(e => e.ShopHeatingTypeId, "IX_Shops_ShopHeatingTypeId");

                entity.HasIndex(e => e.ShopObjectComplexityId, "IX_Shops_ShopObjectComplexityId");

                entity.HasIndex(e => e.ShopRegionId, "IX_Shops_ShopRegionId");

                entity.HasIndex(e => e.ShopSecurityId, "IX_Shops_ShopSecurityId");

                entity.HasIndex(e => e.ShopWorkTimeId, "IX_Shops_ShopWorkTimeId")
                    .IsUnique();

                entity.HasIndex(e => e.StaffManagerId, "IX_Shops_StaffManagerId");

                entity.HasIndex(e => e.StatusId, "IX_Shops_StatusId");

                entity.HasIndex(e => e.StreetId, "IX_Shops_StreetId");

                entity.HasIndex(e => e.TerritorialManagerId, "IX_Shops_TerritorialManagerId");

                entity.Property(e => e.Address).HasMaxLength(256);

                entity.Property(e => e.AddressComment).HasMaxLength(512);

                entity.Property(e => e.AdministratorId)
                    .HasMaxLength(16)
                    .IsFixedLength(true);

                entity.Property(e => e.Conditioners).HasMaxLength(512);

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.DeputyAdministratorId)
                    .HasMaxLength(16)
                    .IsFixedLength(true);

                entity.Property(e => e.DevelopmentDepartmentCoordinatorComments).HasMaxLength(1024);

                entity.Property(e => e.DevelopmentDepartmentCoordinatorId)
                    .HasMaxLength(16)
                    .IsFixedLength(true);

                entity.Property(e => e.DevelopmentDepartmentManagerId)
                    .HasMaxLength(16)
                    .IsFixedLength(true);

                entity.Property(e => e.DifficultyTtunloading)
                    .HasMaxLength(512)
                    .HasColumnName("DifficultyTTUnloading");

                entity.Property(e => e.DistrinutionDepartmentComments).HasMaxLength(1024);

                entity.Property(e => e.Itequipment)
                    .HasMaxLength(1024)
                    .HasColumnName("ITEquipment");

                entity.Property(e => e.LandlordLoyaltyComments).HasMaxLength(512);

                entity.Property(e => e.Latitude).HasMaxLength(32);

                entity.Property(e => e.Ledpanels)
                    .HasMaxLength(512)
                    .HasColumnName("LEDPanels");

                entity.Property(e => e.Logistics).HasMaxLength(1024);

                entity.Property(e => e.Longitude).HasMaxLength(32);

                entity.Property(e => e.PriceList).HasMaxLength(1024);

                entity.Property(e => e.PrivateEntrepreneurId)
                    .HasMaxLength(16)
                    .IsFixedLength(true);

                entity.Property(e => e.RegionalManagerId)
                    .HasMaxLength(16)
                    .IsFixedLength(true);

                entity.Property(e => e.Repair).HasMaxLength(512);

                entity.Property(e => e.ShopWorkTimeString).HasMaxLength(256);

                entity.Property(e => e.StaffManagerId)
                    .HasMaxLength(16)
                    .IsFixedLength(true);

                entity.Property(e => e.TerritorialManagerId)
                    .HasMaxLength(16)
                    .IsFixedLength(true);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.CityId);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.DistrictId);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.RegionId);

                entity.HasOne(d => d.ShopHeatingType)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.ShopHeatingTypeId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.ShopObjectComplexity)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.ShopObjectComplexityId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.ShopRegion)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.ShopRegionId);

                entity.HasOne(d => d.ShopSecurity)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.ShopSecurityId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.ShopWorkTime)
                    .WithOne(p => p.Shop)
                    .HasForeignKey<Shop>(d => d.ShopWorkTimeId);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.StatusId);

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.Shops)
                    .HasForeignKey(d => d.StreetId);
            });

            modelBuilder.Entity<ShopContactPerson>(entity =>
            {
                entity.HasIndex(e => e.ShopId, "IX_ShopContactPersons_ShopId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Fullname).HasMaxLength(256);

                entity.Property(e => e.Phone).HasMaxLength(256);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.ShopContactPeople)
                    .HasForeignKey(d => d.ShopId);
            });

            modelBuilder.Entity<ShopContactPersonHistory>(entity =>
            {
                entity.HasIndex(e => e.ShopContactPersonId, "IX_ShopContactPersonHistories_ShopContactPersonId");

                entity.Property(e => e.FieldName).HasMaxLength(128);

                entity.Property(e => e.TransactionId).HasMaxLength(256);

                entity.Property(e => e.UpdatedByUser).IsRequired();
            });

            modelBuilder.Entity<ShopContractor1C>(entity =>
            {
                entity.ToTable("ShopContractor1C");

                entity.HasIndex(e => e.ShopId, "IX_ShopContractor1C_ShopId");

                entity.Property(e => e.Comments).HasMaxLength(256);

                entity.Property(e => e.Contractor1C).HasMaxLength(256);

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.Okpo)
                    .HasMaxLength(10)
                    .HasColumnName("OKPO");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.ShopContractor1Cs)
                    .HasForeignKey(d => d.ShopId);
            });

            modelBuilder.Entity<ShopContractor1Chistory>(entity =>
            {
                entity.ToTable("ShopContractor1CHistories");

                entity.HasIndex(e => e.ShopContractorId, "IX_ShopContractor1CHistories_ShopContractorId");

                entity.Property(e => e.FieldName).HasMaxLength(128);

                entity.Property(e => e.TransactionId).HasMaxLength(256);

                entity.Property(e => e.UpdatedByUser).IsRequired();
            });

            modelBuilder.Entity<ShopDocumentFolder>(entity =>
            {
                entity.HasIndex(e => e.DocumentId, "IX_ShopDocumentFolders_DocumentId");

                entity.HasIndex(e => e.ShopId, "IX_ShopDocumentFolders_ShopId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.ShopDocumentFolders)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.ShopDocumentFolders)
                    .HasForeignKey(d => d.ShopId);
            });

            modelBuilder.Entity<ShopFieldsMapping>(entity =>
            {
                entity.ToTable("ShopFieldsMapping");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.FieldKeyName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.FieldName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.Property(e => e.TextFieldNameRu)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("TextFieldNameRU");

                entity.Property(e => e.TextFieldNameUa)
                    .IsRequired()
                    .HasMaxLength(64)
                    .HasColumnName("TextFieldNameUA");
            });

            modelBuilder.Entity<ShopGridView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Shop_Grid_View");

                entity.Property(e => e.Address).HasMaxLength(256);

                entity.Property(e => e.AddressComment).HasMaxLength(512);

                entity.Property(e => e.AdministratorId)
                    .HasMaxLength(16)
                    .IsFixedLength(true);

                entity.Property(e => e.AdministratorName).HasMaxLength(200);

                entity.Property(e => e.CheckInItassembling).HasColumnName("CheckInITAssembling");

                entity.Property(e => e.CheckInItdisassembling).HasColumnName("CheckInITDisassembling");

                entity.Property(e => e.CityName).HasMaxLength(256);

                entity.Property(e => e.Comment).HasMaxLength(256);

                entity.Property(e => e.Conditioners).HasMaxLength(512);

                entity.Property(e => e.DeputyAdministratorId)
                    .HasMaxLength(16)
                    .IsFixedLength(true);

                entity.Property(e => e.DeputyAdministratorName).HasMaxLength(200);

                entity.Property(e => e.DevelopmentDepartmentCoordinatorComments).HasMaxLength(1024);

                entity.Property(e => e.DevelopmentDepartmentCoordinatorId)
                    .HasMaxLength(16)
                    .IsFixedLength(true);

                entity.Property(e => e.DevelopmentDepartmentCoordinatorName).HasMaxLength(200);

                entity.Property(e => e.DevelopmentDepartmentManagerId)
                    .HasMaxLength(16)
                    .IsFixedLength(true);

                entity.Property(e => e.DevelopmentDepartmentManagerName).HasMaxLength(200);

                entity.Property(e => e.DifficultyTtunloading)
                    .HasMaxLength(512)
                    .HasColumnName("DifficultyTTUnloading");

                entity.Property(e => e.DistrictName).HasMaxLength(256);

                entity.Property(e => e.DistrinutionDepartmentComments).HasMaxLength(1024);

                entity.Property(e => e.Horn).HasMaxLength(256);

                entity.Property(e => e.Itequipment)
                    .HasMaxLength(1024)
                    .HasColumnName("ITEquipment");

                entity.Property(e => e.LandlordLoyaltyComments).HasMaxLength(512);

                entity.Property(e => e.Latitude).HasMaxLength(32);

                entity.Property(e => e.Ledpanels)
                    .HasMaxLength(512)
                    .HasColumnName("LEDPanels");

                entity.Property(e => e.Logistics).HasMaxLength(1024);

                entity.Property(e => e.Longitude).HasMaxLength(32);

                entity.Property(e => e.ParentStatusName).HasMaxLength(450);

                entity.Property(e => e.PchminiNumber).HasColumnName("PCHMiniNumber");

                entity.Property(e => e.PriceList).HasMaxLength(1024);

                entity.Property(e => e.PrivateEntrepreneurId)
                    .HasMaxLength(16)
                    .IsFixedLength(true);

                entity.Property(e => e.PrivateEntrepreneurName).HasMaxLength(150);

                entity.Property(e => e.RegionName).HasMaxLength(256);

                entity.Property(e => e.RegionalManagerId)
                    .HasMaxLength(16)
                    .IsFixedLength(true);

                entity.Property(e => e.RegionalManagerName).HasMaxLength(200);

                entity.Property(e => e.Repair).HasMaxLength(512);

                entity.Property(e => e.ShopHeatingType)
                    .IsRequired()
                    .HasMaxLength(796);

                entity.Property(e => e.ShopItid).HasColumnName("ShopITId");

                entity.Property(e => e.ShopItresponsibleForAssemblingNames).HasColumnName("ShopITResponsibleForAssemblingNames");

                entity.Property(e => e.ShopItresponsibleForDisAssemblingNames).HasColumnName("ShopITResponsibleForDisAssemblingNames");

                entity.Property(e => e.ShopObjectComplexity)
                    .IsRequired()
                    .HasMaxLength(269);

                entity.Property(e => e.ShopRegionName).HasMaxLength(256);

                entity.Property(e => e.ShopSecurity)
                    .IsRequired()
                    .HasMaxLength(287);

                entity.Property(e => e.ShopWorkTimeString).HasMaxLength(256);

                entity.Property(e => e.StaffManagerId)
                    .HasMaxLength(16)
                    .IsFixedLength(true);

                entity.Property(e => e.StaffManagerName).HasMaxLength(200);

                entity.Property(e => e.StatusItid).HasColumnName("StatusITId");

                entity.Property(e => e.StatusItname)
                    .HasMaxLength(100)
                    .HasColumnName("StatusITName");

                entity.Property(e => e.StatusName).HasMaxLength(450);

                entity.Property(e => e.StreetName).HasMaxLength(256);

                entity.Property(e => e.TerritorialManagerId)
                    .HasMaxLength(16)
                    .IsFixedLength(true);

                entity.Property(e => e.TerritorialManagerName).HasMaxLength(200);
            });

            modelBuilder.Entity<ShopHeatingType>(entity =>
            {
                entity.Property(e => e.Comments).HasMaxLength(256);

                entity.Property(e => e.Counters).HasMaxLength(256);

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.HeatingType).HasMaxLength(256);
            });

            modelBuilder.Entity<ShopHeatingTypeHistory>(entity =>
            {
                entity.HasIndex(e => e.ShopHeatingTypeId, "IX_ShopHeatingTypeHistories_ShopHeatingTypeId");

                entity.Property(e => e.FieldName).HasMaxLength(128);

                entity.Property(e => e.TransactionId).HasMaxLength(256);

                entity.Property(e => e.UpdatedByUser).IsRequired();
            });

            modelBuilder.Entity<ShopHistory>(entity =>
            {
                entity.ToTable("ShopHistory");

                entity.HasIndex(e => e.ShopId, "IX_ShopHistory_ShopId");

                entity.Property(e => e.FieldName).HasMaxLength(128);

                entity.Property(e => e.TransactionId).HasMaxLength(256);

                entity.Property(e => e.UpdatedByUser).IsRequired();
            });

            modelBuilder.Entity<ShopHistoryNotification>(entity =>
            {
                entity.HasIndex(e => e.ShopHistoryId, "IX_ShopHistoryNotifications_ShopHistoryId");

                entity.HasIndex(e => e.UserId, "IX_ShopHistoryNotifications_UserId");

                entity.Property(e => e.ShopHistoryKeyName)
                    .IsRequired()
                    .HasMaxLength(32);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ShopHistoryNotifications)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<ShopHistoryNotificationDateComment>(entity =>
            {
                entity.HasIndex(e => e.ShopHistoryId, "IX_ShopHistoryNotificationDateComments_ShopHistoryId")
                    .IsUnique();

                entity.Property(e => e.Comment).HasMaxLength(512);

                entity.HasOne(d => d.ShopHistory)
                    .WithOne(p => p.ShopHistoryNotificationDateComment)
                    .HasForeignKey<ShopHistoryNotificationDateComment>(d => d.ShopHistoryId);
            });

            modelBuilder.Entity<ShopInstallersDevelopment>(entity =>
            {
                entity.HasIndex(e => e.ShopId, "IX_ShopInstallersDevelopments_ShopId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(16)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.ShopInstallersDevelopments)
                    .HasForeignKey(d => d.ShopId);
            });

            modelBuilder.Entity<ShopInstallersDevelopmentHistory>(entity =>
            {
                entity.HasIndex(e => e.ShopInstallersDevelopmentId, "IX_ShopInstallersDevelopmentHistories_ShopInstallersDevelopmentId");

                entity.Property(e => e.FieldName).HasMaxLength(128);

                entity.Property(e => e.TransactionId).HasMaxLength(256);

                entity.Property(e => e.UpdatedByUser).IsRequired();
            });

            modelBuilder.Entity<ShopIt>(entity =>
            {
                entity.ToTable("ShopITs");

                entity.HasIndex(e => new { e.Id, e.ShopId }, "IX_ShopITs_Id_ShopId")
                    .IsUnique();

                entity.HasIndex(e => e.ShopId, "IX_ShopITs_ShopId")
                    .IsUnique();

                entity.HasIndex(e => e.StatusItid, "IX_ShopITs_StatusITId");

                entity.Property(e => e.CheckInItassembling).HasColumnName("CheckInITAssembling");

                entity.Property(e => e.CheckInItdisassembling).HasColumnName("CheckInITDisassembling");

                entity.Property(e => e.Comment).HasMaxLength(256);

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.Horn).HasMaxLength(256);

                entity.Property(e => e.PchminiNumber).HasColumnName("PCHMiniNumber");

                entity.Property(e => e.ShopItresponsibleForAssemblingNames).HasColumnName("ShopITResponsibleForAssemblingNames");

                entity.Property(e => e.ShopItresponsibleForDisAssemblingNames).HasColumnName("ShopITResponsibleForDisAssemblingNames");

                entity.Property(e => e.StatusItid).HasColumnName("StatusITId");

                entity.HasOne(d => d.Shop)
                    .WithOne(p => p.ShopIt)
                    .HasForeignKey<ShopIt>(d => d.ShopId);

                entity.HasOne(d => d.StatusIt)
                    .WithMany(p => p.ShopIts)
                    .HasForeignKey(d => d.StatusItid)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<ShopIthistory>(entity =>
            {
                entity.ToTable("ShopITHistories");

                entity.HasIndex(e => e.ShopItid, "IX_ShopITHistories_ShopITId");

                entity.Property(e => e.FieldName).HasMaxLength(128);

                entity.Property(e => e.ShopItid).HasColumnName("ShopITId");

                entity.Property(e => e.TransactionId).HasMaxLength(256);

                entity.Property(e => e.UpdatedByUser).IsRequired();
            });

            modelBuilder.Entity<ShopItresponsibleForAssembling>(entity =>
            {
                entity.ToTable("ShopITResponsibleForAssemblings");

                entity.HasIndex(e => e.ShopItid, "IX_ShopITResponsibleForAssemblings_ShopITId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.EmployeeDirectoryId).HasMaxLength(16);

                entity.Property(e => e.ShopItid).HasColumnName("ShopITId");

                entity.HasOne(d => d.ShopIt)
                    .WithMany(p => p.ShopItresponsibleForAssemblings)
                    .HasForeignKey(d => d.ShopItid);
            });

            modelBuilder.Entity<ShopItresponsibleForDisAssembling>(entity =>
            {
                entity.ToTable("ShopITResponsibleForDisAssemblings");

                entity.HasIndex(e => e.ShopItid, "IX_ShopITResponsibleForDisAssemblings_ShopITId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.EmployeeDirectoryId).HasMaxLength(16);

                entity.Property(e => e.ShopItid).HasColumnName("ShopITId");

                entity.HasOne(d => d.ShopIt)
                    .WithMany(p => p.ShopItresponsibleForDisAssemblings)
                    .HasForeignKey(d => d.ShopItid);
            });

            modelBuilder.Entity<ShopObjectComplexity>(entity =>
            {
                entity.Property(e => e.Complexity).HasMaxLength(256);

                entity.Property(e => e.CreatedByUserId).IsRequired();
            });

            modelBuilder.Entity<ShopObjectComplexityHistory>(entity =>
            {
                entity.HasIndex(e => e.ShopObjectComplexityId, "IX_ShopObjectComplexityHistories_ShopObjectComplexityId");

                entity.Property(e => e.FieldName).HasMaxLength(128);

                entity.Property(e => e.TransactionId).HasMaxLength(256);

                entity.Property(e => e.UpdatedByUser).IsRequired();
            });

            modelBuilder.Entity<ShopOptimizationSchedule>(entity =>
            {
                entity.HasIndex(e => e.ShopId, "IX_ShopOptimizationSchedules_ShopId");

                entity.Property(e => e.Action).HasMaxLength(256);

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.ShopOptimizationSchedules)
                    .HasForeignKey(d => d.ShopId);
            });

            modelBuilder.Entity<ShopOptimizationScheduleHistory>(entity =>
            {
                entity.HasIndex(e => e.ShopOptimizationScheduleId, "IX_ShopOptimizationScheduleHistories_ShopOptimizationScheduleId");

                entity.Property(e => e.FieldName).HasMaxLength(128);

                entity.Property(e => e.TransactionId).HasMaxLength(256);

                entity.Property(e => e.UpdatedByUser).IsRequired();
            });

            modelBuilder.Entity<ShopProvider>(entity =>
            {
                entity.HasIndex(e => e.ProviderId, "IX_ShopProviders_ProviderId");

                entity.HasIndex(e => e.ShopId, "IX_ShopProviders_ShopId");

                entity.Property(e => e.AccountLogin).HasMaxLength(256);

                entity.Property(e => e.ConnectionType).HasMaxLength(256);

                entity.Property(e => e.ContractNumber).HasMaxLength(256);

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.Ip)
                    .HasMaxLength(256)
                    .HasColumnName("IP");

                entity.Property(e => e.IssuedOn).HasMaxLength(256);

                entity.Property(e => e.Note).HasMaxLength(256);

                entity.Property(e => e.Password).HasMaxLength(256);

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.ShopProviders)
                    .HasForeignKey(d => d.ProviderId);

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.ShopProviders)
                    .HasForeignKey(d => d.ShopId);
            });

            modelBuilder.Entity<ShopProviderHistory>(entity =>
            {
                entity.Property(e => e.FieldName).HasMaxLength(128);

                entity.Property(e => e.TransactionId).HasMaxLength(256);

                entity.Property(e => e.UpdatedByUser).IsRequired();
            });

            modelBuilder.Entity<ShopRegion>(entity =>
            {
                entity.Property(e => e.CreatedByUserId).IsRequired();
            });

            modelBuilder.Entity<ShopRegionLocalization>(entity =>
            {
                entity.HasIndex(e => new { e.LanguageId, e.Name }, "IX_ShopRegionLocalizations_LanguageId_Name")
                    .IsUnique();

                entity.HasIndex(e => e.ShopRegionId, "IX_ShopRegionLocalizations_ShopRegionId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.ShopRegion)
                    .WithMany(p => p.ShopRegionLocalizations)
                    .HasForeignKey(d => d.ShopRegionId);
            });

            modelBuilder.Entity<ShopRent>(entity =>
            {
                entity.HasIndex(e => e.ShopId, "IX_ShopRents_ShopId");

                entity.Property(e => e.Comments).HasMaxLength(256);

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.RentValue).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.ShopRents)
                    .HasForeignKey(d => d.ShopId);
            });

            modelBuilder.Entity<ShopRentHistory>(entity =>
            {
                entity.HasIndex(e => e.ShopRentId, "IX_ShopRentHistories_ShopRentId");

                entity.Property(e => e.FieldName).HasMaxLength(128);

                entity.Property(e => e.TransactionId).HasMaxLength(256);

                entity.Property(e => e.UpdatedByUser).IsRequired();
            });

            modelBuilder.Entity<ShopSecurity>(entity =>
            {
                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.Security).HasMaxLength(256);
            });

            modelBuilder.Entity<ShopSecurityHistory>(entity =>
            {
                entity.HasIndex(e => e.ShopSecurityId, "IX_ShopSecurityHistories_ShopSecurityId");

                entity.Property(e => e.FieldName).HasMaxLength(128);

                entity.Property(e => e.TransactionId).HasMaxLength(256);

                entity.Property(e => e.UpdatedByUser).IsRequired();
            });

            modelBuilder.Entity<ShopWorkTime>(entity =>
            {
                entity.Property(e => e.CreatedByUserId).IsRequired();
            });

            modelBuilder.Entity<ShopWorkTimeHistory>(entity =>
            {
                entity.ToTable("ShopWorkTimeHistory");

                entity.HasIndex(e => e.ShopWorkTimeId, "IX_ShopWorkTimeHistory_ShopWorkTimeId");

                entity.Property(e => e.FieldName).HasMaxLength(128);

                entity.Property(e => e.TransactionId).HasMaxLength(256);

                entity.Property(e => e.UpdatedByUser).IsRequired();
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.CreatedByUserId).IsRequired();
            });

            modelBuilder.Entity<StatusesIt>(entity =>
            {
                entity.ToTable("StatusesIT");

                entity.HasIndex(e => e.Name, "IX_StatusesIT_Name")
                    .IsUnique();

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SystemKey).HasMaxLength(50);
            });

            modelBuilder.Entity<StatusesLocalization>(entity =>
            {
                entity.ToTable("StatusesLocalization");

                entity.HasIndex(e => e.Name, "IX_StatusesLocalization_Name");

                entity.HasIndex(e => e.StatusId, "IX_StatusesLocalization_StatusId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.StatusesLocalizations)
                    .HasForeignKey(d => d.StatusId);
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.HasIndex(e => e.CityId, "IX_Streets_CityId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Streets)
                    .HasForeignKey(d => d.CityId);
            });

            modelBuilder.Entity<StreetsLocalization>(entity =>
            {
                entity.ToTable("StreetsLocalization");

                entity.HasIndex(e => e.Name, "IX_StreetsLocalization_Name");

                entity.HasIndex(e => e.StreetId, "IX_StreetsLocalization_StreetId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.StreetsLocalizations)
                    .HasForeignKey(d => d.StreetId);
            });

            modelBuilder.Entity<TempImportAdress>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.District).HasMaxLength(100);

                entity.Property(e => e.Region).HasMaxLength(100);

                entity.Property(e => e.Street).HasMaxLength(100);
            });

            modelBuilder.Entity<UserShopGridSetting>(entity =>
            {
                entity.HasIndex(e => new { e.GridName, e.UserId }, "IX_UserShopGridSettings_GridName_UserId")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "IX_UserShopGridSettings_UserId");

                entity.Property(e => e.CreatedByUserId).IsRequired();

                entity.Property(e => e.GridName)
                    .IsRequired()
                    .HasMaxLength(64);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserShopGridSettings)
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
