USE db_QLS
GO

SELECT * FROM [dbo].[tblSach]
SELECT * FROM [dbo].[tblCTHD]
SELECT * FROM [dbo].[tblHD]
SELECT * FROM [dbo].[tblkhachhang]
SELECT * FROM [dbo].[tblnhanvien]
SELECT * FROM [dbo].[tblTypes]
SELECT * FROM [dbo].[tblDangNhap]


--ALTER TABLE [dbo].[tblSach]
--ADD isoluongtrongkho INT NOT NULL DEFAULT (0)
--GO

--UPDATE [dbo].[tblSach]
--SET isoluongtrongkho = 50
--GO

--UPDATE [dbo].[tblSach]
--SET sNXB = N'NXB Nhã Nam'
--WHERE smasach = 'MS03' OR smasach = 'MS04' OR smasach = 'MS05'
--GO

--update [dbo].[tblHD]
--SET itongtien = 0


--create trigger CapNhatTongTien ON [dbo].[tblHD]
--after insert, update
--as
--	update [dbo].[tblHD]
--	set itongtien += cthd.fthanhtien
--	from [dbo].[tblHD] hd
--		inner join [dbo].[tblCTHD] cthd on hd.smahd = cthd.smahd


--create table tblDangNhap
--(
--sTaiKhoan varchar(20) not null primary key,
--sMatKhau varchar(20) not null,
--sQuyen varchar(20) not null,
--iTrangThai int not null
--);
--insert into tblDangNhap
--values
--('Admin1','Admin1','Admin',1),
--('Admin2','Admin2','Admin',1),
--('Admin3','Admin3','Admin',1),
--('Admin4','Admin4','Admin',1),
--('Admin5','Admin5','Admin',1),
--('Admin6','Admin6','Admin',1),
--('NhanVien1','NhanVien1','NhanVien',1),
--('NhanVien2','NhanVien2','NhanVien',1),
--('NhanVien3','NhanVien3','NhanVien',1),
--('NhanVien4','NhanVien4','NhanVien',1),
--('NhanVien5','NhanVien5','NhanVien',1)
--go

--insert into tblTypes
--values
--('Loai4', N'Kinh dị'),
--('Loai5', N'Truyền cảm hứng'),
--('Loai6', N'Khoa học - Viễn tưởng'),
--('Loai7', N'Giáo trình'),
--('Loai8', N'Thiếu nhi')

--insert into [dbo].[tblnhanvien]
--values
--('NV01',N'	Phạm Đức Thiện	     ', 'Nam','0168801280', '2003-09-29'),
--('NV02',N'	Võ Đình Quang	     ', 'Nam', '0977191553', '2004-07-30'),
--('NV03',N'	Phan Thị Hoàng Mai	 ', 'Nữ','0919931390', '2001-06-07'),
--('NV04',N'	Phùng Thùy Trang	 ', 'Nữ','0935219069', '2002-05-09'),
--('NV05',N'	Nguyễn Xuân Việt	 ', 'Nam','0904405804', '2000-09-29'),
--('NV06',N'	Trần Thái Bình	     ', 'Nam','0906248184', '2000-10-10'),
--('NV07',N'	Nguyễn Văn Tuyến	 ', 'Nam','0988925428', '2003-09-10'),
--('NV08',N'	Đặng Hà Hữu Đức	     ', 'Nam','0989893182', '2004-10-19'),
--('NV09',N'	Lê Đại Phong         ', 'Nam','0935223855', '2001-02-20'),
--('NV10',N'	Nguyễn Việt Minh Châu', 'Nữ','0913542554', '1999-09-29')


--delete from [dbo].[tblnhanvien]
--delete from [dbo].[tblDangNhap]
--delete from [dbo].[tblHD]
--delete from [dbo].[tblCTHD]
--delete from 
----procedure


--===================LOẠI SÁCH====================
create proc sp_insert_loaisach (
@smaloaisach nvarchar(10),
@stenloaisach nvarchar(30))
as
	insert into [dbo].[tblTypes]
	(smaloaisach, stenloaisach)
	values
	(@smaloaisach, @stenloaisach)
go

create proc sp_update_loaisach_byID (
@smaloaisach nvarchar(10),
@stenloaisach nvarchar(30))
as
	update [dbo].[tblTypes]
	set smaloaisach = @smaloaisach, stenloaisach = @stenloaisach
	where [dbo].[tblTypes].smaloaisach = @smaloaisach
go

create proc sp_delete_loaisach_byID (
@smaloaisach nvarchar(10))
as
	delete from [dbo].[tblTypes]
	where[dbo].[tblTypes].smaloaisach = @smaloaisach
go

create proc sp_find_loaisach_byName (
@stenloaisach nvarchar(30))
as
	select * from [dbo].[tblTypes]
	where [dbo].[tblTypes].stenloaisach  LIKE '%'+ @stenloaisach +'%';
go

exec sp_find_loaisach_byName N'th'
----=================end loại sách =================

--===================SÁCH====================

create proc sp_insert_sach (
@smasach nvarchar(10),
@stensach nvarchar(30),
@stentacgia nvarchar(30),
@sNXB nvarchar(30),
@smaloaisach nvarchar(10),
@isoluongtrongkho int)
as
	insert into [dbo].[tblSach]
	(smasach, stensach, stentacgia, sNXB, smaloaisach, isoluongtrongkho)
	values
	(@smasach, @stensach, @stentacgia, @sNXB, @smaloaisach, @isoluongtrongkho)
go

drop proc sp_update_sach_byID

create proc sp_update_sach_byID (
@smasach nvarchar(10),
@stensach nvarchar(30),
@stentacgia nvarchar(30),
@sNXB nvarchar(30),
@smaloaisach nvarchar(10),
@isoluongtrongkho int)
as
	update [dbo].[tblSach]
	set smasach = @smasach, stensach = @stensach, stentacgia = @stentacgia, sNXB = @sNXB, smaloaisach = @smaloaisach, isoluongtrongkho = @isoluongtrongkho
	where [dbo].[tblSach].smasach = @smasach
go

create proc sp_delete_sach_byID (
@smasach nvarchar(10))
as
	delete from [dbo].[tblSach]
	where [dbo].[tblSach].smasach = @smasach;
go

--create proc sp_find_sach_byID (
--@smasach nvarchar(10))
--as
--	select * from [dbo].[tblSach]
--	where [dbo].[tblSach].smasach = @smasach;
--go

create proc sp_find_sach_byName (
@stensach nvarchar(30))
as
	select * from [dbo].[tblSach]
	where [dbo].[tblSach].stensach  LIKE '%'+ @stensach +'%';
go

drop proc sp_find_sach_byName
go

exec sp_find_sach_byName N'vòng'

SELECT [dbo].[tblSach].stensach FROM [dbo].[tblSach]

update tblDangNhap
set sMatKhau = 'Quynhanh2310@'
where sTaiKhoan = 'admin2'

select smasach, stensach, stentacgia, sNXB, stenloaisach, isoluongtrongkho from [dbo].[tblSach] sach
join [dbo].[tblTypes] loaisach
on sach.smaloaisach = loaisach.smaloaisach
----=================end sách =================



--đây là code của vanh lấy về db.bak-----------

/****** Object:  StoredProcedure [dbo].[Sp_InsertKhachHang]    Script Date: 4/23/2023 8:36:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_InsertTaiKhoan]
	@sTaiKhoan varchar(10),
	@sMatKhau nvarchar(20),
	@sQuyen varchar(20),
	@iTrangThai int,
	@FK_sMaNV varchar(10)
as
begin 
	insert into tblDangNhap
	values (@sTaiKhoan, @sMatKhau, @sQuyen, @iTrangThai, @FK_sMaNV);
end;
---
GO
alter PROCEDURE [dbo].[sp_UpdateTaiKhoan]
	@sTaiKhoan varchar(10),
	@sMatKhau nvarchar(20),
	@iTrangThai int,
	@FK_sMaNV varchar(10)
AS
BEGIN
    IF (@sMatKhau <> '') -- Kiểm tra mật khẩu không rỗng
    BEGIN
        UPDATE tblDangNhap
        SET sTaiKhoan = @sTaiKhoan, sMatKhau = @sMatKhau, iTrangThai = @iTrangThai
        WHERE FK_sMaNV = @FK_sMaNV 
    END
    ELSE
    BEGIN
        UPDATE tblDangNhap
        SET sTaiKhoan = @sTaiKhoan, iTrangThai = @iTrangThai
        WHERE FK_sMaNV = @FK_sMaNV 
    END
END
---
go
create proc [dbo].[sp_DeleteTaiKhoan]
	@FK_sMaNV varchar(10)
as
begin
	delete tblDangNhap
	where FK_sMaNV = @FK_sMaNV
end
---
go
create view [dbo].[v_DSTaiKhoan]
as
	SELECT sTaiKhoan as N'Tài khoản',
	CASE
	  WHEN iTrangThai = 1 THEN N'Hoạt động'
	  WHEN iTrangThai = 0 THEN N'Khóa'
	END AS N'Trạng thái',
	smanv,
	stennv AS N'Nhân viên'
	FROM tblDangNhap
	INNER JOIN tblnhanvien on smanv = FK_sMaNV
	WHERE sQuyen != 'admin';
	
---
go
alter PROCEDURE[dbo].[sp_SearchTaiKhoan]
	@sTaiKhoan varchar(10) = NULL,
	@iTrangThai int = NULL
AS
BEGIN
	SELECT sTaiKhoan as N'Tài khoản',
	CASE
	  WHEN iTrangThai = 1 THEN N'Hoạt động'
	  WHEN iTrangThai = 0 THEN N'Khóa'
	END AS N'Trạng thái',
	smanv,
	stennv AS N'Nhân viên'
	FROM tblDangNhap
	INNER JOIN tblnhanvien on smanv = FK_sMaNV
    WHERE
        (sTaiKhoan LIKE '%' + @sTaiKhoan + '%' OR @sTaiKhoan IS NULL)

        AND(iTrangThai = @iTrangThai  OR @iTrangThai IS NULL)
		AND sQuyen != 'admin'
END

---
go

ALTER proc [dbo].[SP_KiemTraTaiKhoan]
	@taikhoan varchar(20),
	@matkhau varchar(20)
as
begin
	select * from [dbo].[tblDangNhap]
	inner join tblnhanvien on smanv = FK_sMaNV
	where sTaiKhoan= @taikhoan and sMatKhau= @matkhau

end
---
GO
create proc [dbo].[sp_InsertHoaDon]
	@sMaHD varchar(10),
	@sMaNV nvarchar(10),
	@sMaKH varchar(10),
	@dNgayLap datetime,
	@iTongTien int
as
begin 
	insert into tblHD
	values (@sMaHD, @sMaNV, @sMaKH, @dNgayLap, @iTongTien);
end;
