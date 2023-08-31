﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Palmfit.Data.AppDbContext;

#nullable disable

namespace Palmfit.Data.Migrations
{
    [DbContext(typeof(PalmfitDbContext))]
    partial class PalmfitDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Data.Entities.UserOTP", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("OTP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("UserOTPs");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<bool?>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Area")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("InviteCode")
                        .HasColumnType("text");

                    b.Property<bool?>("IsArchived")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsLockedOut")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsVerified")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastOnline")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("ReferralCode")
                        .HasColumnType("text");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.AppUserPermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AppUserPermissions");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.AppUserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("AppUserRole");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.FileUploadModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("CloudinaryPublicId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CloudinaryUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("bytea");

                    b.Property<string>("ImageName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("FileUploadmodels");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Food", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<decimal>("Calorie")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Carbs")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Fats")
                        .HasColumnType("numeric");

                    b.Property<string>("FoodClassId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Proteins")
                        .HasColumnType("numeric");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FoodClassId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.FoodClass", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("FoodClasses");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Health", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Balance")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("BloodGroup")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("GenoType")
                        .HasColumnType("integer");

                    b.Property<double>("Height")
                        .HasColumnType("double precision");

                    b.Property<int>("HeightUnit")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.Property<int>("WeightUnit")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("Healths");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Invite", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Invites");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.MealPlan", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Day")
                        .HasColumnType("integer");

                    b.Property<string>("FoodClassId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FoodId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("MealOfDay")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FoodClassId");

                    b.HasIndex("FoodId");

                    b.ToTable("MealPlans");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Notification", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsRead")
                        .HasColumnType("boolean");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Referral", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("InvitedUserid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("ReferralCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("InvitedUserid");

                    b.ToTable("Referrals");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Review", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Verdict")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.SelectedPlans", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("FoodClassId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("FoodClassId");

                    b.ToTable("SelectedPlans");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Setting", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Subscription", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsExpired")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Transaction", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Channel")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsSuccessful")
                        .HasColumnType("boolean");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Vendor")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.UserCalorieData", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<int>("ActivityLevel")
                        .HasColumnType("integer");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<decimal>("Height")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("Weight")
                        .HasColumnType("numeric");

                    b.Property<int>("WeightGoal")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("userCaloriesData");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Wallet", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<string>("AppUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId")
                        .IsUnique();

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.WalletHistory", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HealthId")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("WalletAppUserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WalletId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("HealthId");

                    b.HasIndex("WalletId");

                    b.ToTable("WalletHistories");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Food", b =>
                {
                    b.HasOne("Palmfit.Data.Entities.FoodClass", "FoodClass")
                        .WithMany()
                        .HasForeignKey("FoodClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodClass");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Health", b =>
                {
                    b.HasOne("Palmfit.Data.Entities.AppUser", "AppUser")
                        .WithOne("Health")
                        .HasForeignKey("Palmfit.Data.Entities.Health", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Invite", b =>
                {
                    b.HasOne("Palmfit.Data.Entities.AppUser", "AppUser")
                        .WithMany("Invities")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.MealPlan", b =>
                {
                    b.HasOne("Palmfit.Data.Entities.FoodClass", "FoodClass")
                        .WithMany("MealPlan")
                        .HasForeignKey("FoodClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Palmfit.Data.Entities.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("FoodClass");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Notification", b =>
                {
                    b.HasOne("Palmfit.Data.Entities.AppUser", "AppUser")
                        .WithMany("Notifications")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Referral", b =>
                {
                    b.HasOne("Palmfit.Data.Entities.AppUser", "InvitedUser")
                        .WithMany("Referrals")
                        .HasForeignKey("InvitedUserid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InvitedUser");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Review", b =>
                {
                    b.HasOne("Palmfit.Data.Entities.AppUser", "AppUser")
                        .WithMany("Reviews")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.SelectedPlans", b =>
                {
                    b.HasOne("Palmfit.Data.Entities.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Palmfit.Data.Entities.FoodClass", "FoodClass")
                        .WithMany()
                        .HasForeignKey("FoodClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("FoodClass");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Setting", b =>
                {
                    b.HasOne("Palmfit.Data.Entities.AppUser", "AppUser")
                        .WithOne("Setting")
                        .HasForeignKey("Palmfit.Data.Entities.Setting", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Subscription", b =>
                {
                    b.HasOne("Palmfit.Data.Entities.AppUser", "AppUser")
                        .WithMany("Subscriptions")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Transaction", b =>
                {
                    b.HasOne("Palmfit.Data.Entities.AppUser", "AppUser")
                        .WithMany("Transactions")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.UserCalorieData", b =>
                {
                    b.HasOne("Palmfit.Data.Entities.AppUser", "AppUser")
                        .WithMany()
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Wallet", b =>
                {
                    b.HasOne("Palmfit.Data.Entities.AppUser", "AppUser")
                        .WithOne("Wallet")
                        .HasForeignKey("Palmfit.Data.Entities.Wallet", "AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.WalletHistory", b =>
                {
                    b.HasOne("Palmfit.Data.Entities.Health", null)
                        .WithMany("Histories")
                        .HasForeignKey("HealthId");

                    b.HasOne("Palmfit.Data.Entities.Wallet", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletId");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.AppUser", b =>
                {
                    b.Navigation("Health");

                    b.Navigation("Invities");

                    b.Navigation("Notifications");

                    b.Navigation("Referrals");

                    b.Navigation("Reviews");

                    b.Navigation("Setting");

                    b.Navigation("Subscriptions");

                    b.Navigation("Transactions");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.FoodClass", b =>
                {
                    b.Navigation("MealPlan");
                });

            modelBuilder.Entity("Palmfit.Data.Entities.Health", b =>
                {
                    b.Navigation("Histories");
                });
#pragma warning restore 612, 618
        }
    }
}
