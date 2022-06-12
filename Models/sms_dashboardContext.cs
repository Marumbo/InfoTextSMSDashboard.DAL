using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace InfoTextSMSDashboard.DAL.Models
{
    public partial class sms_dashboardContext : DbContext
    {
        public sms_dashboardContext()
        {
        }

        public sms_dashboardContext(DbContextOptions<sms_dashboardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupContact> GroupContacts { get; set; }
        public virtual DbSet<OutgoingSmsList> OutgoingSmsLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=sms_dashboard;Username=marumbo;Password=testPassword");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contacts");

                entity.HasIndex(e => e.EmailAddress, "contacts_email_address_key")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "contacts_phone_number_key")
                    .IsUnique();

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.AddedBy)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("added_by");

                entity.Property(e => e.DateAdded)
                    .HasColumnName("date_added")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(150)
                    .HasColumnName("email_address");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("last_name");

                entity.Property(e => e.Organization)
                    .HasMaxLength(30)
                    .HasColumnName("organization");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("groups");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("group_name");
            });

            modelBuilder.Entity<GroupContact>(entity =>
            {
                entity.ToTable("group_contact");

                entity.Property(e => e.GroupContactId).HasColumnName("group_contact_id");

                entity.Property(e => e.ContactId).HasColumnName("contact_id");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupContacts)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("group_contact_group_id_fkey");
            });

            modelBuilder.Entity<OutgoingSmsList>(entity =>
            {
                entity.HasKey(e => e.SmsId)
                    .HasName("outgoing_sms_list_pkey");

                entity.ToTable("outgoing_sms_list");

                entity.Property(e => e.SmsId).HasColumnName("sms_id");

                entity.Property(e => e.AtMessageid)
                    .IsRequired()
                    .HasMaxLength(55)
                    .HasColumnName("at_messageid");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("message");

                entity.Property(e => e.MessageCost)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("message_cost");

                entity.Property(e => e.RecipientNumber)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("recipient_number");

                entity.Property(e => e.RecipientStatus)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("recipient_status");

                entity.Property(e => e.SenderUsername)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("sender_username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
