using Animals.Share;
using Animals.Server.Models;
using Microsoft.EntityFrameworkCore;


namespace Animals.Server.Services
{
    public partial class bao_ton_tnContext : DbContext
    {
        public bao_ton_tnContext()
        {
        }

        public bao_ton_tnContext(DbContextOptions<bao_ton_tnContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChuDe> ChuDe { get; set; }
        public virtual DbSet<Hinh> Hinh { get; set; }
        public virtual DbSet<PhanLoai> PhanLoai { get; set; }
        public virtual DbSet<SinhVat> SinhVat { get; set; }
        public virtual DbSet<TinTuc> TinTuc { get; set; }
        public virtual DbSet<TtBaoTonIucn> TtBaoTonIucn { get; set; }
        public virtual DbSet<ThanhVien> ThanhVien { get; set; }
        public virtual DbSet<Video> Video { get; set; }
        public virtual DbSet<VungDiaLi> VungDiaLi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChuDe>(entity =>
            {
                entity.HasKey(e => e.IdChuDe);

                entity.ToTable("chu_de", "bao_ton_tn");

                entity.HasIndex(e => e.IdCha)
                    .HasName("id_cha");

                entity.Property(e => e.IdChuDe)
                    .HasColumnName("id_chu_de")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Duyet)
                    .HasColumnName("duyet")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.IdCha)
                    .HasColumnName("id_cha")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TenChuDe)
                    .IsRequired()
                    .HasColumnName("ten_chu_de")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdChaNavigation)
                    .WithMany(p => p.InverseIdChaNavigation)
                    .HasForeignKey(d => d.IdCha)
                    .HasConstraintName("chu_de_ibfk_1");
            });

            modelBuilder.Entity<Hinh>(entity =>
            {
                entity.HasKey(e => e.Idhinh);

                entity.ToTable("hinh", "bao_ton_tn");

                entity.HasIndex(e => e.Idtin)
                    .HasName("idtin");

                entity.Property(e => e.Idhinh)
                    .HasColumnName("idhinh")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DuongDan)
                    .IsRequired()
                    .HasColumnName("duong_dan")
                    .HasMaxLength(10000)
                    .IsUnicode(false);

                entity.Property(e => e.Idtin)
                    .HasColumnName("idtin")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdtinNavigation)
                    .WithMany(p => p.Hinh)
                    .HasForeignKey(d => d.Idtin)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("hinh_ibfk_1");
            });

            modelBuilder.Entity<PhanLoai>(entity =>
            {
                entity.HasKey(e => e.IdPhanLoai);

                entity.ToTable("phan_loai", "bao_ton_tn");

                entity.HasIndex(e => e.IdCha)
                    .HasName("phan_loai_fk");

                entity.Property(e => e.IdPhanLoai)
                    .HasColumnName("id_phan_loai")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCha)
                    .HasColumnName("id_cha")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TenPhanLoai)
                    .IsRequired()
                    .HasColumnName("ten_phan_loai")
                    .HasColumnType("mediumtext");

                entity.HasOne(d => d.IdChaNavigation)
                    .WithMany(p => p.InverseIdChaNavigation)
                    .HasForeignKey(d => d.IdCha)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("phan_loai_fk");
            });

            modelBuilder.Entity<SinhVat>(entity =>
            {
                entity.HasKey(e => e.IdSinhVat);

                entity.ToTable("sinh_vat", "bao_ton_tn");

                entity.HasIndex(e => e.ThuocChi)
                    .HasName("sinh_vat_fk_1");

                entity.HasIndex(e => e.TtBaoTon)
                    .HasName("sinh_vat_fk_2");

                entity.Property(e => e.IdSinhVat)
                    .HasColumnName("id_sinh_vat")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.DdHinhThai)
                    .HasColumnName("dd_hinh_thai")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.DdSinhHoc)
                    .HasColumnName("dd_sinh_hoc")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.DoNguyHiem)
                    .HasColumnName("do_nguy_hiem")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.GtSuDung)
                    .HasColumnName("gt_su_dung")
                    .HasMaxLength(10000)
                    .IsUnicode(false);

                entity.Property(e => e.LaDv)
                    .HasColumnName("la_dv")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.MtSong)
                    .HasColumnName("mt_song")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.NoiTruMau)
                    .HasColumnName("noi_tru_mau")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PhanBo)
                    .HasColumnName("phan_bo")
                    .HasColumnType("mediumtext");

                entity.Property(e => e.TenKh)
                    .IsRequired()
                    .HasColumnName("ten_kh")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TenThuong)
                    .HasColumnName("ten_thuong")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TenTiengAnh)
                    .HasColumnName("ten_tieng_anh")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ThuocChi)
                    .HasColumnName("thuoc_chi")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TinhTrangMau)
                    .HasColumnName("tinh_trang_mau")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ToaDo)
                    .HasColumnName("toa_do")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TtBaoTon)
                    .HasColumnName("tt_bao_ton")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.TtSinhSan)
                    .HasColumnName("tt_sinh_san")
                    .HasColumnType("mediumtext");

                entity.HasOne(d => d.IdSinhVatNavigation)
                    .WithOne(p => p.SinhVat)
                    .HasForeignKey<SinhVat>(d => d.IdSinhVat)
                    .HasConstraintName("sinh_vat_ibfk_1");

                entity.HasOne(d => d.ThuocChiNavigation)
                    .WithMany(p => p.SinhVat)
                    .HasForeignKey(d => d.ThuocChi)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("sinh_vat_fk_1");

                entity.HasOne(d => d.TtBaoTonNavigation)
                    .WithMany(p => p.SinhVat)
                    .HasForeignKey(d => d.TtBaoTon)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("sinh_vat_fk_2");
            });

            modelBuilder.Entity<TinTuc>(entity =>
            {
                entity.HasKey(e => e.Idtin);

                entity.ToTable("tin_tuc", "bao_ton_tn");

                entity.HasIndex(e => e.IdChuDe)
                    .HasName("id_chu_de");

                entity.HasIndex(e => e.Idtv)
                    .HasName("idtv");

                entity.Property(e => e.Idtin)
                    .HasColumnName("idtin")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DuyetTin)
                    .HasColumnName("duyet_tin")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.IdChuDe)
                    .HasColumnName("id_chu_de")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idtv)
                    .HasColumnName("idtv")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LoaiTin)
                    .HasColumnName("loai_tin")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NoiDung)
                    .HasColumnName("noi_dung")
                    .HasMaxLength(10000)
                    .IsUnicode(false);

                entity.Property(e => e.TieuDe)
                    .HasColumnName("tieu_de")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.TomTat)
                    .HasColumnName("tom_tat")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdChuDeNavigation)
                    .WithMany(p => p.TinTuc)
                    .HasForeignKey(d => d.IdChuDe)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tin_tuc_ibfk_1");

                entity.HasOne(d => d.IdtvNavigation)
                    .WithMany(p => p.TinTuc)
                    .HasForeignKey(d => d.Idtv)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tin_tuc_ibfk_2");
            });

            modelBuilder.Entity<TtBaoTonIucn>(entity =>
            {
                entity.HasKey(e => e.IdTinhTrang);

                entity.ToTable("tt_bao_ton_iucn", "bao_ton_tn");

                entity.Property(e => e.IdTinhTrang)
                    .HasColumnName("id_tinh_trang")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.TenTinhTrang)
                    .HasColumnName("ten_tinh_trang")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ThanhVien>(entity =>
            {
                entity.HasKey(e => e.Idtv);

                entity.ToTable("thanh_vien", "bao_ton_tn");

                entity.Property(e => e.Idtv)
                    .HasColumnName("idtv")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HoTen)
                    .IsRequired()
                    .HasColumnName("ho_ten")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasColumnName("mat_khau")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Sdt)
                    .HasColumnName("sdt")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TenDn)
                    .IsRequired()
                    .HasColumnName("ten_dn")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.HasKey(e => e.Idvideo);

                entity.ToTable("video", "bao_ton_tn");

                entity.Property(e => e.Idvideo)
                    .HasColumnName("idvideo")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.DuongDanVideo)
                    .HasColumnName("duong_dan_video")
                    .HasMaxLength(10000)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdvideoNavigation)
                    .WithOne(p => p.Video)
                    .HasForeignKey<Video>(d => d.Idvideo)
                    .HasConstraintName("video_ibfk_1");
            });

            modelBuilder.Entity<VungDiaLi>(entity =>
            {
                entity.HasKey(e => e.IdVung);

                entity.ToTable("vung_dia_li", "bao_ton_tn");

                entity.HasIndex(e => e.IdSinhVat)
                    .HasName("id_sinh_vat");

                entity.Property(e => e.IdVung)
                    .HasColumnName("id_vung")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdSinhVat)
                    .HasColumnName("id_sinh_vat")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ToaDo).HasColumnName("toa_do");

            });
        }
    }
}
