using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PCMS.Models;

namespace PCMS.Data;

public partial class PhotoCmsContext : DbContext
{

    public PhotoCmsContext()
    {
    }


    public PhotoCmsContext(DbContextOptions<PhotoCmsContext> options)
        : base(options)
    {
    }

    public  DbSet<Customers> Customers { get; set; }

    public  DbSet<DebtCollection> DebtCollection { get; set; }

    public  DbSet<EquipmentTypes> EquipmentTypes { get; set; }

    public  DbSet<Functions> Functions { get; set; }

    public  DbSet<InventoryIn> InventoryIn { get; set; }

    public  DbSet<InventoryInDetails> InventoryInDetails { get; set; }

    public  DbSet<InventoryOut> InventoryOut { get; set; }

    public  DbSet<InventoryOutDetails> InventoryOutDetails { get; set; }

    public  DbSet<Materials> Materials { get; set; }

    public  DbSet<MaterialGroup> MaterialGroup { get; set; }

    public  DbSet<MoneyAccount> MoneyAccount { get; set; }

    public  DbSet<Organizations> Organizations { get; set; }

    public  DbSet<Photocopier> Photocopier { get; set; }

    public  DbSet<Receipts> Receipts { get; set; }

    public  DbSet<ReceiptDetail> ReceiptDetail { get; set; }

    public  DbSet<Role> Role { get; set; }

    public  DbSet<RoleFacilities> RoleFacilities { get; set; }

    public  DbSet<RoleFunction> RoleFunction { get; set; }

    public  DbSet<Schools> Schools { get; set; }

    public  DbSet<Service> Service { get; set; }

    public  DbSet<ServiceGroups> ServiceGroups { get; set; }

    public  DbSet<Suppliers> Suppliers { get; set; }

    public  DbSet<TrainingFacilities> TrainingFacilities { get; set; }

    public  DbSet<UnitsOfMeasure> UnitsOfMeasure { get; set; }

    public  DbSet<Users> Users { get; set; }

    public  DbSet<UsersRole> UsersRole { get; set; }

    public  DbSet<Warehouses> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source= DESKTOP-CURC7TC\\LEHUY; Initial Catalog=PhotoCMS; User Id= sa; password = 123;Trusted_Connection=False;TrustServerCertificate=True");
    
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<Customers>(entity =>
        {
            entity.HasKey(e => e.CustomerID).HasName("pk_CustomerID");


            entity.Property(e => e.OrganizationID).HasColumnName("CustomerID");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Faculty).HasMaxLength(250);
            entity.Property(e => e.CustomerName).HasMaxLength(50);
            entity.Property(e => e.OrganizationID).HasColumnName("OrganizationID");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CodeUser).HasMaxLength(20);
            entity.Property(e => e.Gender).HasMaxLength(20);

            entity.HasOne(d => d.Organiza_3).WithMany(p => p.Ctm)
                .HasForeignKey(d => d.OrganizationID)
                .HasConstraintName("fk_OrganizationID_2");
        });

        modelBuilder.Entity<DebtCollection>(entity =>
        {
            entity.HasKey(e => e.DebtCollectionID).HasName("pk_DebtCollectionID");

            entity.ToTable("DebtCollection");

            entity.Property(e => e.DebtCollectionID).HasColumnName("DebtCollectionID");
            entity.Property(e => e.AmountPaid).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CollectionDate).HasColumnType("date");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CustomerID).HasColumnName("CustomerID");
            entity.Property(e => e.DebtAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(100);
            entity.Property(e => e.RecordCreationDate).HasColumnType("datetime");
            entity.Property(e => e.RemainingAmount)
                .HasComment("RemainingAmount = DebtAmount - Amount Paid")
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Ctm_2).WithMany(p => p.Debt)
                .HasForeignKey(d => d.CustomerID)
                .HasConstraintName("FK_DebtCollection_Customers");
        });

        modelBuilder.Entity<EquipmentTypes>(entity =>
        {
            entity.HasKey(e => e.EquipmentTypeID).HasName("pk_EquipmentTypeID");

            entity.Property(e => e.EquipmentTypeID).HasColumnName("EquipmentTypeID");
            entity.Property(e => e.Manufacturer).HasMaxLength(250);
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.PurchasePrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.TypeName).HasMaxLength(250);
        });

        modelBuilder.Entity<Functions>(entity =>
        {
            entity.HasKey(e => e.FunctionID).HasName("pk_FunctionID");

            entity.Property(e => e.FunctionID).HasColumnName("FunctionID");
            entity.Property(e => e.FunctionName).HasMaxLength(200);
        });

        modelBuilder.Entity<InventoryIn>(entity =>
        {
            entity.HasKey(e => e.InventoryInID).HasName("pk_InventoryInID");

            entity.ToTable("InventoryIn");

            entity.Property(e => e.InventoryInID)
                .ValueGeneratedNever()
                .HasColumnName("InventoryInID");
            entity.Property(e => e.AmountReceived).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Created_by)
                .HasMaxLength(250)
                .HasColumnName("Created_by");
            entity.Property(e => e.Created_date)
                .HasColumnType("date")
                .HasColumnName("Created_date");
            entity.Property(e => e.Discount_amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Discount_amount");
            entity.Property(e => e.InventoryInDate).HasColumnType("date");
            entity.Property(e => e.Modified_date)
                .HasColumnType("date")
                .HasColumnName("Modified_date");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.Percentage_discount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Percentage_discount");
            entity.Property(e => e.Percentage_tax)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Percentage_tax");
            entity.Property(e => e.ReceivedBy).HasMaxLength(50);
            entity.Property(e => e.SupplierID)
                .ValueGeneratedOnAdd()
                .HasColumnName("SupplierID");
            entity.Property(e => e.Tax_amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Tax_amount");


            entity.Property(e => e.Total_amount)
                .HasComment("Total_amount = AmountReceived + Total_amount - Percentage_discount")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Total_amount");
            entity.Property(e => e.WarehouseID).HasColumnName("WarehouseID");

            entity.HasOne(d => d.Suppli).WithMany(p => p.InvenIns_2)
                .HasForeignKey(d => d.SupplierID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InventoryIn_Suppliers");

            entity.HasOne(d => d.Wahouses_2).WithMany(p => p.InvenIns)
                .HasForeignKey(d => d.WarehouseID)
                .HasConstraintName("fk_WarehouseID");
        });

        modelBuilder.Entity<InventoryInDetails>(entity =>
        {
            entity.HasKey(e => e.InventoryInDetailID).HasName("pk_InventoryInDetailID");

            entity.Property(e => e.InventoryInDetailID).HasColumnName("InventoryInDetailID");
            entity.Property(e => e.InventoryInID).HasColumnName("InventoryInID");
            entity.Property(e => e.MaterialID).HasColumnName("MaterialID");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnitOfMeasureID).HasColumnName("UnitOfMeasureID");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.InvenIn).WithMany(p => p.InvenInDetails)
                .HasForeignKey(d => d.InventoryInID)
                .HasConstraintName("fk_InventoryInID");

            entity.HasOne(d => d.Materials_2).WithMany(p => p.InvenInDetails)
                .HasForeignKey(d => d.MaterialID)
                .HasConstraintName("fk_MaterialID");

            entity.HasOne(d => d.UnitMeasure).WithMany(p => p.InvenInDetails_2)
                .HasForeignKey(d => d.UnitOfMeasureID)
                .HasConstraintName("fk_UnitOfMeasureID");
        });

        modelBuilder.Entity<InventoryOut>(entity =>
        {
            entity.HasKey(e => e.InventoryOutID).HasName("pk_InventoryOutID");

            entity.ToTable("InventoryOut");

            entity.Property(e => e.InventoryOutID).HasColumnName("InventoryOutID");
            entity.Property(e => e.Created_by)
                .HasMaxLength(50)
                .HasColumnName("Created_by");
            entity.Property(e => e.Created_date)
                .HasColumnType("date")
                .HasColumnName("Created_date");
            entity.Property(e => e.DeliveryMethod).HasMaxLength(50);
            entity.Property(e => e.Discount_Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Discount_Amount");
            entity.Property(e => e.ModifiedDate).HasColumnType("date");
            entity.Property(e => e.OrganizationID).HasColumnName("OrganizationID");
            entity.Property(e => e.OutDate).HasColumnType("date");
            entity.Property(e => e.Percentage_Discount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Percentage_Discount");
            entity.Property(e => e.Percentage_Tax)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Percentage_Tax");
            entity.Property(e => e.ReceiverName).HasMaxLength(100);
            entity.Property(e => e.ReceiverPhone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Tax_Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Tax_Amount");
            entity.Property(e => e.Tong_tien)
                .HasComment("Tong_tien=AmountReceived+Tax_Amount-Percentage_Discount")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Tong_tien");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.WarehouseID).HasColumnName("WarehouseID");

            entity.HasOne(d => d.Organiza_2).WithMany(p => p.InvenOuts_3)
                .HasForeignKey(d => d.OrganizationID)
                .HasConstraintName("fk_OrganizationID");

            entity.HasOne(d => d.Wahouses_3).WithMany(p => p.InvenOuts)
                .HasForeignKey(d => d.WarehouseID)
                .HasConstraintName("FK_WarehouseID_2");
        });

        modelBuilder.Entity<InventoryOutDetails>(entity =>
        {
            entity.HasKey(e => e.InventoryOutDetailID).HasName("pk_InventoryOutDetailID");

            entity.Property(e => e.InventoryOutDetailID).HasColumnName("InventoryOutDetailID");
            entity.Property(e => e.EquipmentTypeID).HasColumnName("EquipmentTypeID");
            entity.Property(e => e.InventoryOutID).HasColumnName("InventoryOutID");
            entity.Property(e => e.MaterialID).HasColumnName("MaterialID");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnitOfMeasureID).HasColumnName("UnitOfMeasureID");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.EquipType_2).WithMany(p => p.InvenOutDetails_4)
                .HasForeignKey(d => d.EquipmentTypeID)
                .HasConstraintName("fk_EquipmentTypeID");

            entity.HasOne(d => d.InvenOuts_4).WithMany(p => p.InvenOutDetails_3)
                .HasForeignKey(d => d.InventoryOutID)
                .HasConstraintName("fk_InventoryOutID");

            entity.HasOne(d => d.Materialist_3).WithMany(p => p.InvenOutDetails)
                .HasForeignKey(d => d.MaterialID)
                .HasConstraintName("fk_MaterialID_2");

            entity.HasOne(d => d.UnitMeasure_2).WithMany(p => p.InvenOutDetails_2)
                .HasForeignKey(d => d.UnitOfMeasureID)
                .HasConstraintName("fk_UnitOfMeasureID_2");
        });

        modelBuilder.Entity<Materials>(entity =>
        {
            entity.HasKey(e => e.MaterialID).HasName("pk_MaterialID");

            entity.Property(e => e.MaterialID).HasColumnName("MaterialID");
            entity.Property(e => e.MaterialGroup_1).HasColumnName("MaterialGroupID");
            entity.Property(e => e.MaterialGroup_1).HasMaxLength(100);

            entity.HasOne(d => d.MaterialGroup_1).WithMany(p => p.Materialist)
                .HasForeignKey(d => d.MaterialGroupID)
                .HasConstraintName("fk_MaterialGroupID");
        });

        modelBuilder.Entity<MaterialGroup>(entity =>
        {
            entity.HasKey(e => e.Materialist).HasName("pk_MaterialGroupID");

            entity.ToTable("Material_Group");

            entity.Property(e => e.Materialist).HasColumnName("MaterialGroupID");
            entity.Property(e => e.MaterialGroupName).HasMaxLength(100);
        });

        modelBuilder.Entity<MoneyAccount>(entity =>
        {
            entity.HasKey(e => e.AccountID).HasName("pk_AccountID");

            entity.ToTable("MoneyAccount");

            entity.Property(e => e.AccountID).HasColumnName("AccountID");
            entity.Property(e => e.AccountName).HasMaxLength(100);
            entity.Property(e => e.AccountNumber).HasMaxLength(50);
            entity.Property(e => e.AccountType).HasMaxLength(20);
            entity.Property(e => e.Balance).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.BankName).HasMaxLength(250);
            entity.Property(e => e.ContactEmail).HasMaxLength(100);
            entity.Property(e => e.ContactPerson).HasMaxLength(100);
            entity.Property(e => e.ContactPhone).HasMaxLength(50);
            entity.Property(e => e.Currency).HasMaxLength(3);
        });

        modelBuilder.Entity<Organizations>(entity =>
        {
            entity.HasKey(e => e.OrganizationID).HasName("pk_OrganizationID");

            entity.Property(e => e.OrganizationID).HasColumnName("OrganizationID");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.ContactPerson).HasMaxLength(100);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.OrganizationName).HasMaxLength(250);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SchoolID).HasColumnName("SchoolID");

            entity.HasOne(d => d.Sch).WithMany(p => p.Organiza)
                .HasForeignKey(d => d.SchoolID)
                .HasConstraintName("fk_SchoolID");
        });

        modelBuilder.Entity<Photocopier>(entity =>
        {
            entity.HasKey(e => e.PhotocopierID).HasName("pk_PhotocopierID");

            entity.ToTable("Photocopier");

            entity.Property(e => e.PhotocopierID).HasColumnName("PhotocopierID");
            entity.Property(e => e.FacilityID).HasColumnName("FacilityID");
            entity.Property(e => e.Location).HasMaxLength(250);
            entity.Property(e => e.Manufacturer)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.PurchaseDate).HasColumnType("date");
            entity.Property(e => e.PurchasePrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SerialNumber).HasMaxLength(20);

            entity.HasOne(d => d.Facility_2).WithMany(p => p.Photo)
                .HasForeignKey(d => d.FacilityID)
                .HasConstraintName("fk_FacilityID_2");
        });

        modelBuilder.Entity<Receipts>(entity =>
        {
            entity.HasKey(e => e.ReceiptID).HasName("pk_ReceiptID");

            entity.Property(e => e.ReceiptID).HasColumnName("ReceiptID");
            entity.Property(e => e.AccountID).HasColumnName("AccountID");
            entity.Property(e => e.AmountReceived)
                .HasComment("=sum(TotalAmount) - details")
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Created_by)
                .HasMaxLength(250)
                .HasColumnName("Created_by");
            entity.Property(e => e.Created_date)
                .HasColumnType("date")
                .HasColumnName("Created_date");
            entity.Property(e => e.CustomerID).HasColumnName("CustomerID");
            entity.Property(e => e.DepositPayment).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Discount_amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Discount_amount");
            entity.Property(e => e.Modified_date)
                .HasColumnType("date")
                .HasColumnName("Modified_date");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.Percentage_discount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Percentage_discount");
            entity.Property(e => e.Percentage_tax)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Percentage_tax");
            entity.Property(e => e.ReceivedDate).HasColumnType("date");
            entity.Property(e => e.Tax_amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Tax_amount");
            entity.Property(e => e.Total_amount)
                .HasComment("Total_amount = AmountReceived + tax_amount -Discount_amount - DepositPayment")
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Total_amount");

            entity.HasOne(d => d.Acc).WithMany(p => p.Recei_2)
                .HasForeignKey(d => d.AccountID)
                .HasConstraintName("fk_AccountID");

            entity.HasOne(d => d.Ctm_3).WithMany(p => p.Recei)
                .HasForeignKey(d => d.CustomerID)
                .HasConstraintName("fk_CustomerID_2");
        });

        modelBuilder.Entity<ReceiptDetail>(entity =>
        {
            entity.HasKey(e => e.ReceiptDetailID).HasName("pk_PhotocopierID_2");

            entity.ToTable("ReceiptDetail");

            entity.Property(e => e.ReceiptDetailID).HasColumnName("ReceiptDetailID");
            entity.Property(e => e.PhotocopierID).HasColumnName("PhotocopierID");
            entity.Property(e => e.ReceiptID).HasColumnName("ReceiptID");
            entity.Property(e => e.ServiceID).HasColumnName("ServiceID");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Photo_2).WithMany(p => p.ReDetails_3)
                .HasForeignKey(d => d.PhotocopierID)
                .HasConstraintName("fk_PhotocopierID");

            entity.HasOne(d => d.Recei_3).WithMany(p => p.ReDetails)
                .HasForeignKey(d => d.ReceiptID)
                .HasConstraintName("fk_ReceiptID");

            entity.HasOne(d => d.Ser_2).WithMany(p => p.ReDetails_2)
                .HasForeignKey(d => d.ServiceID)
                .HasConstraintName("fk_ServiceID");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleID).HasName("pk_RoleID");

            entity.ToTable("Role");

            entity.Property(e => e.RoleID).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        modelBuilder.Entity<RoleFacilities>(entity =>
        {
            entity.HasKey(e => e.RoleFacilitiesID).HasName("pk_RoleFacilitiesID");

            entity.Property(e => e.RoleFacilitiesID).HasColumnName("RoleFacilitiesID");
            entity.Property(e => e.FacilityID).HasColumnName("FacilityID");
            entity.Property(e => e.RoleID).HasColumnName("RoleID");

            entity.HasOne(d => d.Facility_3).WithMany(p => p.RoleFaci)
                .HasForeignKey(d => d.FacilityID)
                .HasConstraintName("fk_FacilityID_3");

            entity.HasOne(d => d.Rl_3).WithMany(p => p.RFacilities)
                .HasForeignKey(d => d.RoleID)
                .HasConstraintName("fk_RoleID_2");
        });

        modelBuilder.Entity<RoleFunction>(entity =>
        {
            entity.HasKey(e => e.RoleFunctionID).HasName("pk_RoleFunctionID");

            entity.ToTable("RoleFunction");

            entity.Property(e => e.RoleFunctionID).HasColumnName("RoleFunctionID");
            entity.Property(e => e.FunctionID).HasColumnName("FunctionID");
            entity.Property(e => e.RoleID).HasColumnName("RoleID");

            entity.HasOne(d => d.Func).WithMany(p => p.RFunctions)
                .HasForeignKey(d => d.FunctionID)
                .HasConstraintName("fk_FunctionID");

            entity.HasOne(d => d.Rl).WithMany(p => p.RFunctions_2)
                .HasForeignKey(d => d.RoleID)
                .HasConstraintName("FK_RoleFunction_Role");
        });

        modelBuilder.Entity<Schools>(entity =>
        {
            entity.HasKey(e => e.SchoolID).HasName("pk_SchoolID");

            entity.Property(e => e.SchoolID).HasColumnName("SchoolID");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PrincipalName).HasMaxLength(100);
            entity.Property(e => e.SchoolName).HasMaxLength(250);
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceID).HasName("pk_ServiceID");

            entity.ToTable("Service");

            entity.Property(e => e.ServiceID).HasColumnName("ServiceID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ServiceCategory).HasMaxLength(250);
            entity.Property(e => e.ServiceGroupID).HasColumnName("ServiceGroupID");
            entity.Property(e => e.ServiceName).HasMaxLength(250);

            entity.HasOne(d => d.SerGroup).WithMany(p => p.Ser)
                .HasForeignKey(d => d.ServiceGroupID)
                .HasConstraintName("fk_ServiceGroupID");
        });

        modelBuilder.Entity<ServiceGroups>(entity =>
        {
            entity.HasKey(e => e.ServiceGroupID).HasName("pk_ServiceGroupID");

            entity.Property(e => e.ServiceGroupID).HasColumnName("ServiceGroupID");
            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.GroupName).HasMaxLength(250);
        });

        modelBuilder.Entity<Suppliers>(entity =>
        {
            entity.HasKey(e => e.SupplierID).HasName("pk_SupplierID");

            entity.Property(e => e.SupplierID).HasColumnName("SupplierID");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContactName).HasMaxLength(100);
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SupplierName).HasMaxLength(250);
        });

        modelBuilder.Entity<TrainingFacilities>(entity =>
        {
            entity.HasKey(e => e.FacilityId).HasName("pk_FacilityID");

            entity.Property(e => e.FacilityId).HasColumnName("FacilityID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ContactName).HasMaxLength(50);
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FacilityName).HasMaxLength(50);
            entity.Property(e => e.Website).HasMaxLength(100);
        });

        modelBuilder.Entity<UnitsOfMeasure>(entity =>
        {
            entity.HasKey(e => e.UnitOfMeasureID).HasName("pk_UnitOfMeasureID");

            entity.ToTable("UnitsOfMeasure");

            entity.Property(e => e.UnitOfMeasureID).HasColumnName("UnitOfMeasureID");
            entity.Property(e => e.Abbreviation).HasMaxLength(20);
            entity.Property(e => e.ConversionFactor).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UnitName).HasMaxLength(250);
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.UserID).HasName("pk_UserID");

            entity.Property(e => e.UserID).HasColumnName("UserID");
            entity.Property(e => e.CustomerID).HasColumnName("CustomerID");
            entity.Property(e => e.Email)
            .HasMaxLength(150)
            .IsUnicode(false);
          
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.UserName).HasMaxLength(100);

            entity.HasOne(d => d.Ctm_4).WithMany(p => p.Usr)
                .HasForeignKey(d => d.CustomerID)
                .HasConstraintName("fk_CustomerID_3");
        });

        modelBuilder.Entity<UsersRole>(entity =>
        {
            entity.HasKey(e => e.UsersRoleID).HasName("pk_UsersRoleID");

            entity.ToTable("UsersRole");

            entity.Property(e => e.UsersRoleID).HasColumnName("UsersRoleID");
            entity.Property(e => e.RoleID).HasColumnName("RoleID");
            entity.Property(e => e.UserID).HasColumnName("UserID");

            entity.HasOne(d => d.Rl_2).WithMany(p => p.URoles_2)
                .HasForeignKey(d => d.RoleID)
                .HasConstraintName("fk_RoleID");

            entity.HasOne(d => d.Usr_2).WithMany(p => p.URoles)
                .HasForeignKey(d => d.UserID)
                .HasConstraintName("fk_UserID_2");
        });

        modelBuilder.Entity<Warehouses>(entity =>
        {
            entity.HasKey(e => e.WarehouseID).HasName("pk_WarehouseID");

            entity.Property(e => e.WarehouseID)
                
                .HasColumnName("WarehouseID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.FacilityID).HasColumnName("FacilityID");
            entity.Property(e => e.ManagerNameWh)
                .HasMaxLength(100)
                .HasColumnName("ManagerNameWh");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.WarehouseName).HasMaxLength(250);

            entity.HasOne(d => d.Facility).WithMany(p => p.Wahouses)
                .HasForeignKey(d => d.FacilityID)
                .HasConstraintName("fk_FacilityID");
        });

        OnModelCreatingPartial(modelBuilder);
    }



    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
