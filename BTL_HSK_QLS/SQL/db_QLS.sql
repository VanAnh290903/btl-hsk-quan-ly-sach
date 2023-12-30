/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [smahd]
      ,[smanv]
      ,[smakh]
      ,[dngaylap]
  FROM [QLS].[dbo].[tblHD]
  alter table [QLS].[dbo].[tblHD]
  add itongtien float
  create proc [dbo].[Sp_InsertKhachHang]
  (@sMaKH varchar(10),
  @sTenKH nvarchar(50),
  @sSdt varchar(15))
as
begin 
	insert into tblkhachhang
	values (@sMaKH, @sTenKH, @sSDT);
end;

---- 
go
create PROCEDURE [dbo].[sp_UpdateKhachHang]
	@sMaKH varchar(10),
	@sTenKH nvarchar(50),
	@sSdt varchar(15)
AS
BEGIN
    UPDATE tblkhachhang
    SET  stenkh = @sTenKH, ssdt = @sSdt
    WHERE smakh = @sMaKH 
END
go
---
create proc [dbo].[Sp_DeleteKhachHang]
	@sMaKH varchar(10)
as
begin
delete tblkhachhang
where smakh = @sMaKH
end
go
---
 CREATE VIEW [dbo].[vv_getKhachHang]
AS
    SELECT smakh as N'Mã khách hàng', 
	stenkh as N'Tên khách hàng', 
	ssdt as N'Số điện thoại' FROM tblkhachhang
GO
---
CREATE PROCEDURE[dbo].[sp_SearchKhachHang]
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
GO
CREATE VIEW [dbo].[vv_getHoaDon]
AS
    SELECT smahd as N'Mã hóa đơn', 
	stennv as N'Tên nhân viên', 
	stenkh as N'Tên khách hàng', 
	dngaylap as N'Ngày lập hóa đơn',
	itongtien as N'Tổng tiền',
	iTrangThai as 
	FROM tblHD inner join tblnhanvien on tblHD.smanv= tblnhanvien.smanv inner join tblkhachhang on tblHD.smakh= tblkhachhang.smakh
GO
-- thêm cột trạng thái vào hóa đơn 
alter table tblHD
add iTrangThai int 