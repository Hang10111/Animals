using Animals.Server.Models;
using Animals.Share;
using Microsoft.EntityFrameworkCore;

namespace Animals.Server.Services
{
    public partial class id11168955_bao_ton_tnContext : DbContext
    {
        public id11168955_bao_ton_tnContext()
        {
        }

        public id11168955_bao_ton_tnContext(DbContextOptions<id11168955_bao_ton_tnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConsvStatus> ConsvStatus { get; set; }
        public virtual DbSet<Coordinates> Coordinates { get; set; }
        public virtual DbSet<Hotspots> Hotspots { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Samples> Samples { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<Taxonomy> Taxonomy { get; set; }
        public virtual DbSet<Topics> Topics { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Videos> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConsvStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("consv_status", "id11168955_bao_ton_tn");

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.StatusName)
                    .HasColumnName("status_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Coordinates>(entity =>
            {
                entity.HasKey(e => e.CoordId);

                entity.ToTable("coordinates", "id11168955_bao_ton_tn");

                entity.HasIndex(e => e.HotspotId)
                    .HasName("coordinates_ibfk_2");

                entity.HasIndex(e => e.SpeciesId)
                    .HasName("coordinates_ibfk_3");

                entity.Property(e => e.CoordId)
                    .HasColumnName("coord_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Coord).HasColumnName("coord");

                entity.Property(e => e.HotspotId)
                    .HasColumnName("hotspot_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SpeciesId)
                    .HasColumnName("species_id")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Hotspots>(entity =>
            {
                entity.HasKey(e => e.HotspotId);

                entity.ToTable("hotspots", "id11168955_bao_ton_tn");

                entity.Property(e => e.HotspotId)
                    .HasColumnName("hotspot_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HotspotName)
                    .HasColumnName("hotspot_name")
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.HasKey(e => e.ImgId);

                entity.ToTable("images", "id11168955_bao_ton_tn");

                entity.HasIndex(e => e.NewsId)
                    .HasName("images_ibfk_1");

                entity.Property(e => e.ImgId)
                    .HasColumnName("img_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ImgPath)
                    .IsRequired()
                    .HasColumnName("img_path")
                    .HasMaxLength(10000)
                    .IsUnicode(false);

                entity.Property(e => e.NewsId)
                    .HasColumnName("news_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.NewsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("images_ibfk_1");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("news", "id11168955_bao_ton_tn");

                entity.HasIndex(e => e.CensoredBy)
                    .HasName("news_ibfk_4");

                entity.HasIndex(e => e.TopicId)
                    .HasName("id_chu_de");

                entity.HasIndex(e => e.UsrId)
                    .HasName("idtv");

                entity.Property(e => e.NewsId)
                    .HasColumnName("news_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Censored)
                    .HasColumnName("censored")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.CensoredBy)
                    .HasColumnName("censored_by")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CensoredDate).HasColumnName("censored_date");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(10000)
                    .IsUnicode(false);

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Feedback)
                    .HasColumnName("feedback")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.NewsType)
                    .HasColumnName("news_type")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Summary)
                    .HasColumnName("summary")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TimeStamp)
                    .HasColumnName("time_stamp")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TopicId)
                    .HasColumnName("topic_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UsrId)
                    .HasColumnName("usr_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CensoredByNavigation)
                    .WithMany(p => p.NewsCensoredByNavigation)
                    .HasForeignKey(d => d.CensoredBy)
                    .HasConstraintName("news_ibfk_4");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("news_ibfk_3");

                entity.HasOne(d => d.Usr)
                    .WithMany(p => p.NewsUsr)
                    .HasForeignKey(d => d.UsrId)
                    .HasConstraintName("news_ibfk_2");
            });

            modelBuilder.Entity<Samples>(entity =>
            {
                entity.HasKey(e => e.SampleId);

                entity.ToTable("samples", "id11168955_bao_ton_tn");

                entity.Property(e => e.SampleId)
                    .HasColumnName("sample_id")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Archive)
                    .HasColumnName("archive")
                    .HasMaxLength(10000)
                    .IsUnicode(false);

                entity.Property(e => e.CollectDate)
                    .HasColumnName("collect_date")
                    .HasColumnType("date");

                entity.Property(e => e.Collector)
                    .HasColumnName("collector")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Expert)
                    .HasColumnName("expert")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Identifier)
                    .HasColumnName("identifier")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SampleCoord).HasColumnName("sample_coord");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.ToTable("species", "id11168955_bao_ton_tn");

                entity.HasIndex(e => e.Genus)
                    .HasName("sinh_vat_fk_1");

                entity.HasIndex(e => e.SampleId)
                    .HasName("species_ibfk_2");

                entity.HasIndex(e => e.StatusId)
                    .HasName("status_id");

                entity.Property(e => e.SpeciesId)
                    .HasColumnName("species_id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.BioCharcs)
                    .HasColumnName("bio_charcs")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Danger)
                    .HasColumnName("danger")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Distribution)
                    .HasColumnName("distribution")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.EngName)
                    .HasColumnName("eng_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Genus)
                    .HasColumnName("genus")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Habitats)
                    .HasColumnName("habitats")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.IsAnimal)
                    .HasColumnName("is_animal")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.MorphoCharcs)
                    .HasColumnName("morpho_charcs")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Reproduction)
                    .HasColumnName("reproduction")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.SampleId)
                    .HasColumnName("sample_id")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ScientificName)
                    .IsRequired()
                    .HasColumnName("scientific_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId)
                    .HasColumnName("status_id")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("NE");

                entity.Property(e => e.UseValue)
                    .HasColumnName("use_value")
                    .HasMaxLength(10000)
                    .IsUnicode(false);

                entity.Property(e => e.VietName)
                    .HasColumnName("viet_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.GenusNavigation)
                    .WithMany(p => p.Species)
                    .HasForeignKey(d => d.Genus)
                    .HasConstraintName("sinh_vat_fk_1");

                entity.HasOne(d => d.SpeciesNavigation)
                    .WithOne(p => p.Species)
                    .HasForeignKey<Species>(d => d.SpeciesId)
                    .HasConstraintName("species_ibfk_3");
            });

            modelBuilder.Entity<Taxonomy>(entity =>
            {
                entity.HasKey(e => e.TaxonId);

                entity.ToTable("taxonomy", "id11168955_bao_ton_tn");

                entity.HasIndex(e => e.ParentId)
                    .HasName("phan_loai_fk");

                entity.Property(e => e.TaxonId)
                    .HasColumnName("taxon_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TaxonName)
                    .IsRequired()
                    .HasColumnName("taxon_name")
                    .HasColumnType("mediumtext");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("phan_loai_fk");
            });

            modelBuilder.Entity<Topics>(entity =>
            {
                entity.HasKey(e => e.TopicId);

                entity.ToTable("topics", "id11168955_bao_ton_tn");

                entity.HasIndex(e => e.ParentId)
                    .HasName("id_cha");

                entity.Property(e => e.TopicId)
                    .HasColumnName("topic_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Censored)
                    .HasColumnName("censored")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TopicName)
                    .IsRequired()
                    .HasColumnName("topic_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("topics_ibfk_1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UsrId);

                entity.ToTable("users", "id11168955_bao_ton_tn");

                entity.Property(e => e.UsrId)
                    .HasColumnName("usr_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Exist)
                    .HasColumnName("exist")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("pass")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNum)
                    .HasColumnName("phone_num")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UsrType)
                    .HasColumnName("usr_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usrname)
                    .IsRequired()
                    .HasColumnName("usrname")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Videos>(entity =>
            {
                entity.HasKey(e => e.VideoId);

                entity.ToTable("videos", "id11168955_bao_ton_tn");

                entity.HasIndex(e => e.NewsId)
                    .HasName("videos_ibfk_1");

                entity.Property(e => e.VideoId)
                    .HasColumnName("video_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NewsId)
                    .HasColumnName("news_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VideoPath)
                    .HasColumnName("video_path")
                    .HasMaxLength(10000)
                    .IsUnicode(false);

                entity.HasOne(d => d.News)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.NewsId)
                    .HasConstraintName("videos_ibfk_1");
            });
        }
    }
}
