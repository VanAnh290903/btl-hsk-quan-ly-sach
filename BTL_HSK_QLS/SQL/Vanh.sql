+USE [QLS]
GO
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
create PROCEDURE [dbo].[sp_UpdateTaiKhoan]
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
alter proc [dbo].[sp_DeleteHoaDon]
@sMaHD varchar(10)
as
begin 
delete tblHD
where
smahd=@sMaHD
end

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
----------------- view danh sách hóa đơn
create view [dbo].[v_DSHoaDon]
as
select tblHD.smahd as N'Mã hóa đơn', 
tblnhanvien.stennv as N'Tên nhân viên', 
tblkhachhang.stenkh as N'Tên khách hàng', 
tblHD.dngaylap as N'Ngày lập hóa đơn' ,
tblHD.itongtien as N'Tổng tiền',
case 
when tblHD.iTrangThai =1 Then N'Đã thanh toán'
when tblHD.iTrangThai=0 then N'Chưa thanh toán'
end as N'Trạng thái'
from tblHD  inner join tblkhachhang  on tblHD.smakh=tblkhachhang.smakh inner join tblnhanvien  on tblHD.smanv=tblnhanvien.smanv

go
create PROCEDURE[dbo].[sp_SearchTaiKhoan]
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

alter proc [dbo].[SP_KiemTraTaiKhoan]
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

-- view xem hóa đơn chi tiết
create view [dbo].[v_DSHoaDonCT]
as
select 

from tblCTHD a inner join tblHD
USE [QLS]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateKhachHang]    Script Date: 26/04/2023 11:53:01 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_UpdateKhachHang]
	@sMaKH varchar(10),
	@sTenKH nvarchar(50),
	@sSdt varchar(15)
AS
BEGIN
    UPDATE tblkhachhang
    SET  stenkh = @sTenKH, ssdt = @sSdt
    WHERE smakh = @sMaKH 
END

create PROCEDURE [dbo].[sp_UpdateHoaDon]
	@iTrangThai int,
	@sMaHD varchar(10)
AS
BEGIN
    UPDATE tblHD
    SET  iTrangThai=@iTrangThai
    WHERE smahd=@sMaHD
END
exec [dbo].[sp_UpdateHoaDon] 1, 'HD04'
USE [QLS]
GO
/****** Object:  StoredProcedure [dbo].[sp_SearchKhachHang]    Script Date: 26/04/2023 11:02:45 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---
ALTER PROCEDURE[dbo].[sp_SearchKhachHang]
	@sMaKH varchar(10) = NULL,
	@sTenKH nvarchar(50) = NULL,
	@sSdt varchar(15) = NULL
AS
BEGIN

    SELECT* FROM tblkhachhang
    WHERE
        (smakh LIKE '%' + @sMaKH + '%' OR @sMaKH IS NULL)

        AND(stenkh LIKE '%' + @sTenKH + '%' OR @sTenKH IS NULL)

        AND(ssdt LIKE '%' + @sSdt + '%' OR @sSdt IS NULL)
END
alter PROCEDURE[dbo].[sp_SearchHoaDon]
	@iTrangThai int = NULL,
	@sTenNV nvarchar(50) = null,
	@sTenKH nvarchar(50)=null
AS
BEGIN
    SELECT a.smahd as N'Mã hóa đơn', 
	b.stennv as N'Tên nhân viên',
	c.stenkh as N'Tên khách hàng',
	a.dngaylap as N'Ngày lập hóa đơn',
	a.itongtien as N'Tổng tiền',
	case 
	when a.iTrangThai =1 then N'Đã thanh toán'
	when a.iTrangThai=0 then N'Chưa thanh toán'
	end as N'Trạng thái'
	FROM tblHD a inner join tblnhanvien b on a.smanv= b.smanv inner join tblkhachhang c on a.smakh= c.smakh
    WHERE
        (c.stenkh LIKE '%' + @sTenKH + '%' OR @sTenKH IS NULL)

        AND(a.iTrangThai = @iTrangThai  OR @iTrangThai IS NULL)

        AND(b.stennv LIKE '%' + @sTenNV + '%' OR @sTenNV IS NULL)
END

exec [dbo].[sp_SearchHoaDon]  1 


GO
CREATE proc [dbo].[sp_getHoaDonChiTiet]
 @mahd varchar(10)
AS
begin
    SELECT 
		tblCTHD.smahd, tblCTHD.smasach,
		tblnhanvien.stennv,
		tblkhachhang.stenkh,
		tblHD.dngaylap,
		tblSach.stensach as N'Tên sách',
		tblCTHD.isoluong as N'Số lượng',
		tblCTHD.fdongia as N'Đơn giá',
		tblCTHD.fthanhtien as N'Thành tiền'
	FROM tblCTHD
	inner join tblHD on tblHD.smahd = tblCTHD.smahd
	inner join tblSach on tblSach.smasach = tblCTHD.smasach
	inner join tblkhachhang on tblkhachhang.smakh = tblHD.smakh
	inner join tblnhanvien on tblnhanvien.smanv = tblHD.smanv
	where tblCTHD.smahd = @mahd
end

GO
create PROCEDURE[dbo].[sp_UpdatePassWord]
        @sTaiKhoan varchar(10),
	        @sMatKhau nvarchar(20)
        AS
        BEGIN

            UPDATE tblDangNhap
            SET sMatKhau = @sMatKhau
            WHERE sTaiKhoan = @sTaiKhoan


        END
		GO

 CREATE VIEW [dbo].[v_getHoaDonChiTiet]
AS
    SELECT 
		tblCTHD.smahd, tblCTHD.smasach,
		tblnhanvien.stennv,
		tblkhachhang.stenkh,
		tblHD.dngaylap,
		tblSach.stensach as N'Tên sách',
		tblCTHD.isoluong as N'Số lượng',
		tblCTHD.fdongia as N'Đơn giá',
		tblCTHD.fthanhtien as N'Thành tiền'
	FROM tblCTHD
	inner join tblHD on tblHD.smahd = tblCTHD.smahd
	inner join tblSach on tblSach.smasach = tblCTHD.smasach
	inner join tblkhachhang on tblkhachhang.smakh = tblHD.smakh
	inner join tblnhanvien on tblnhanvien.smanv = tblHD.smanv
GO

alter PROC XEMDSNV
AS
SELECT 
tblnhanvien.smanv as N'Mã nhân viên', stennv as N'Tên nhân viên', sgioitinh as N'Giới tính', ssdt as N'Số điện thoại', ituoi as N'Ngày sinh'
FROM tblnhanvien where smanv not like  '%admin%'

go
create PROCEDURE[dbo].[sp_UpdateSoLuongSach]
@maSach varchar(10),
@soluongsach int
AS
BEGIN
	SET NOCOUNT ON;
    UPDATE tblSach
    SET isoluongtrongkho = isoluongtrongkho - @soluongsach
    WHERE smasach = @maSach
END

